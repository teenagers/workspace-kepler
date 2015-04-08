﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYSModel;
using System.Data;
using HXCPcClient.CommonClass;
using System.Windows.Forms;
using Utility.Common;

namespace HXCPcClient.Chooser
{
    /// <summary>
    /// 维修结算单
    /// </summary>
    public class frmRepairByFinance : frmBalanceDocuments
    {
        public frmRepairByFinance(string custCode) :
            base(custCode)
        {
            lblDateBill.Visible = false;
            dtiBillDate.Visible = false;
            lblCheckNum.Visible = false;
            txtCheckNumber.Visible = false;
            colBillsType.Visible = false;
            colReceivablesDate.Visible = false;
            colReceiptNO.Visible = false;
        }
        public frmRepairByFinance()
            : base()
        { }
        protected override void BindData()
        {
            if (custCode.Length == 0)
            {
                return;
            }
            dgvData.RowCount = 0;
            DataTable dt;//数据
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.AppendFormat("cust_id='{0}'", custCode);
            sbWhere.AppendFormat(" and wait_money>0");
            sbWhere.AppendFormat(" and isnull(is_occupy_finance,0)='{0}'", (int)DataSources.EnumImportStaus.OPEN);
            if (!string.IsNullOrEmpty(dtiDate.StartDate))
            {
                sbWhere.AppendFormat(" and order_date>{0}", Common.LocalDateTimeToUtcLong(Convert.ToDateTime(dtiDate.StartDate).Date));
            }
            if (!string.IsNullOrEmpty(dtiDate.EndDate))
            {
                sbWhere.AppendFormat(" and order_date <{0}", Common.LocalDateTimeToUtcLong(Convert.ToDateTime(dtiDate.EndDate).Date.AddDays(1)));
            }
            string orderNum = txtOrderNum.Caption.Trim();//单据编号
            if (orderNum.Length > 0)
            {
                sbWhere.AppendFormat(" and maintain_no like '%{0}%'", orderNum);
            }
            dt = DBHelper.GetTable("", "v_maintain_settlement_info_receivable", "*", sbWhere.ToString(), "", "order by order_date");
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow dgvr = dgvData.Rows[dgvData.Rows.Add()];
                dgvr.Cells["colID"].Value = dr["settlement_id"];//ID
                dgvr.Cells["colBillsName"].Value = "维修结算单";//单据名称
                //dgvr.Cells["colBillsType"].Value = dr["price_type"];//单据类型
                dgvr.Cells["colBillsCode"].Value = dr["maintain_no"];//单据编码
                dgvr.Cells["colTotalMoney"].Value = dr["should_sum"];//总金额
                dgvr.Cells["colBalanceMoney"].Value = dr["money"];//已结算
                dgvr.Cells["colWaitMoney"].Value = dr["wait_money"];//未结算
                //string date = CommonCtrl.IsNullToString(dr["receivables_date"]);
                //if (date.Length > 0)
                //{
                //    dgvr.Cells["colReceivablesDate"].Value = Common.UtcLongToLocalDateTime(Int64.Parse(date));//收款日期
                //}
                //dgvr.Cells["colReceiptNO"].Value = dr["receipt_no"];//发票号
                dgvr.Cells[colOrderDate.Name].Value = Common.UtcLongToLocalDateTime(dr["order_date"], "yyyy-MM-dd");//单据日期
            }
        }

        protected override bool LockDocument(string ids)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("is_occupy_finance", ((int)DataSources.EnumImportStaus.OCCUPY).ToString());
            return DBHelper.BatchUpdateDataByIn("锁定维修单", "tb_maintain_settlement_info", dic, "settlement_id", ids.Split(','));
        }
    }
}
