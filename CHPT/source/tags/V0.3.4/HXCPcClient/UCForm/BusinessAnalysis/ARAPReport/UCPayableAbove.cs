﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HXCPcClient.Chooser;
using Utility.Common;
using HXCPcClient.CommonClass;

namespace HXCPcClient.UCForm.BusinessAnalysis.ARAPReport
{
    public partial class UCPayableAbove : UCReport
    {
        public UCPayableAbove()
            : base("v_payable_above", "应付款超信用额度报表")
        {
            InitializeComponent();
            colChao.DefaultCellStyle = styleMoney;
            colEDu.DefaultCellStyle = styleMoney;
            colYingFu.DefaultCellStyle = styleMoney;
            dtEndDate.Value = DateTime.Now;
        }

        private void UCPayableAbove_Load(object sender, EventArgs e)
        {
            //供应商类别
            CommonFuncCall.BindComBoxDataSource(cboSup_type, "sys_supplier_category", "全部");
            //公司
            CommonFuncCall.BindCompany(cboCompany, "全部");
            listNegative = new List<string>();
            listNegative.Add("应付款");//应付款

            BindData();
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCompany.SelectedValue == null)
            {
                return;
            }
            CommonFuncCall.BindDepartment(cboorg_id, cboCompany.SelectedValue.ToString(), "全部");
        }

        private void txtcSup_code_ChooserClick(object sender, EventArgs e)
        {
            frmSupplier frmSup = new frmSupplier();
            if (frmSup.ShowDialog() == DialogResult.OK)
            {
                txtcSup_code.Text = frmSup.supperCode;
                txtSup_name.Caption = frmSup.supperName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            string strWhere = GetWhere();
            strWhere += " and isnull(b.credit_line,0)<a.本期发生";
            string filed = "b.sup_code,b.sup_full_name,a.本期发生,b.credit_line,a.本期发生-ISNULL(b.credit_line,0) 超信用额度";
            string table = string.Format(@"(
select sup_id,SUM(allmoney) 本期发生 from tb_parts_purchase_billing  where order_date<{0}
group by sup_id) a
inner join tb_supplier b on a.sup_id=b.sup_id", Common.LocalDateTimeToUtcLong(dtEndDate.Value.Date));
            dt = DBHelper.GetTable("", table, filed, strWhere, "", "order by sup_full_name");
            List<string> listNot = new List<string>();
            listNot.Add("credit_line");
            listNot.Add("超信用额度");
            dt.DataTableSum(listNot);
            dgvReport.DataSource = dt;
        }
    }
}
