﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HXCPcClient.Chooser;
using HXCPcClient.CommonClass;
using HXCPcClient.UCForm.AccessoriesBusiness.SaleManagement.SaleBilling;

namespace HXCPcClient.UCForm.BusinessAnalysis.SaleReport
{
    public partial class UCSaleBillingDetail : UCReport
    {
        #region 属性，用来设置查询条件的默认值
        public string orderType = string.Empty;
        public string receiptType = string.Empty;
        public string balanceWay = string.Empty;
        public string balanceAccount = string.Empty;
        public string supCode = string.Empty;
        public string supName = string.Empty;
        public string supType = string.Empty;
        public string whCode = string.Empty;
        public string partsCode = string.Empty;
        public string partsName = string.Empty;
        public string drawingNum = string.Empty;
        public string partsBrand = string.Empty;
        public string stratDate = DateTime.Now.ToString("yyyy-MM-01");
        public string endDate = DateTime.Now.ToString("yyyy-MM-dd");
        public string commpany = string.Empty;
        public string orgID = string.Empty;
        #endregion
        public UCSaleBillingDetail()
            : base("v_sale_billing_detail_report", "销售开单明细表")
        {
            InitializeComponent();

            colNum.DefaultCellStyle = styleNum;
            colPrice.DefaultCellStyle = styleMoney;
            colAssistNum.DefaultCellStyle = styleNum;
            colPayment.DefaultCellStyle = styleMoney;
            colTax.DefaultCellStyle = styleMoney;
            colMoney.DefaultCellStyle = styleMoney;

            Quick quick = new Quick();
            quick.BindCustomer(txtcCust_code);
            txtcCust_code.DataBacked += new ServiceStationClient.ComponentUI.TextBox.TextChooser.DataBackHandler(txtcCust_code_DataBacked);

            quick.BindParts(txtcparts_code);
            txtcparts_code.DataBacked += new ServiceStationClient.ComponentUI.TextBox.TextChooser.DataBackHandler(txtcparts_code_DataBacked);
        }

        void txtcCust_code_DataBacked(DataRow dr)
        {
            txtCust_name.Caption = CommonCtrl.IsNullToString(dr["cust_name"]);
            txtcCust_code.Text = CommonCtrl.IsNullToString(dr["cust_code"]);
        }

        void txtcparts_code_DataBacked(DataRow dr)
        {
            txtcparts_code.Text = CommonCtrl.IsNullToString(dr["ser_parts_code"]);
            txtPartsName.Caption = CommonCtrl.IsNullToString(dr["parts_name"]);
        }

        //窗体加载
        private void UCSaleBillingDetail_Load(object sender, EventArgs e)
        {
            //单据类型
            CommonFuncCall.BindSaleOrderType(cboorder_type, true, "全部");
            //发票类型
            CommonFuncCall.BindComBoxDataSource(cboreceipt_type, "sys_receipt_type", "全部");
            //结算单位
            CommonFuncCall.BindBalanceWayByItem(cbobalance_way, "全部");
            //客户类别
            CommonFuncCall.BindComBoxDataSource(cboCust_type, "sys_customer_category", "全部");
            //仓库
            CommonFuncCall.BindWarehouse(cbowh_code, "全部");
            //公司
            CommonFuncCall.BindCompany(cboCompany, "全部");
            #region 初始化查询
            cboorder_type.SelectedValue = orderType;
            cboreceipt_type.SelectedValue = receiptType;
            cbobalance_way.SelectedValue = balanceWay;
            cbobalance_account.SelectedValue = balanceAccount;
            txtcCust_code.Text = supCode;
            txtCust_name.Caption = supName;
            cboCust_type.SelectedValue = supType;
            cbowh_code.SelectedValue = whCode;
            txtcparts_code.Text = partsCode;
            txtPartsName.Caption = partsName;
            txtdrawing_num.Caption = drawingNum;
            txtparts_brand.Caption = partsBrand;
            dicreate_time.StartDate = stratDate;
            dicreate_time.EndDate = endDate;
            cboCompany.SelectedValue = commpany;
            cboorg_id.SelectedValue = orgID;
            #endregion
            BindData();
            //双击查看明细,要手动调用权限
            if (this.Name != "CL_BusinessAnalysis_Sale_BillingDet")
            {
                base.RoleButtonStstus("CL_BusinessAnalysis_Sale_BillingDet");
            }
        }
        //选择结算单位，绑定默认结算账户
        private void cbobalance_way_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbobalance_way.SelectedItem == null)
            {
                return;
            }
            DataRowView drv = (DataRowView)cbobalance_way.SelectedItem;
            string defalutAccount = drv["default_account"].ToString();
            if (defalutAccount.Length == 0)
            {
                return;
            }
            CommonFuncCall.BindAccount(cbobalance_account, defalutAccount, "全部");
        }

        //选择公司，绑定公司所有部门
        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCompany.SelectedValue == null)
            {
                return;
            }
            CommonFuncCall.BindDepartment(cboorg_id, cboCompany.SelectedValue.ToString(), "全部");
        }
        //客户选择
        private void txtcCust_code_ChooserClick(object sender, EventArgs e)
        {
            frmCustomerInfo frmCust = new frmCustomerInfo();
            if (frmCust.ShowDialog() == DialogResult.OK)
            {
                txtcCust_code.Text = frmCust.strCustomerNo;
                txtCust_name.Caption = frmCust.strCustomerName;
            }
        }
        //配件选择
        private void txtcparts_code_ChooserClick(object sender, EventArgs e)
        {
            frmParts parts = new frmParts();
            if (parts.ShowDialog() == DialogResult.OK)
            {
                txtcparts_code.Text = parts.PartsCode;
                txtPartsName.Caption = parts.PartsName;
            }
        }
        //查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenDocument();
        }
        //绑定报表数据
        void BindData()
        {
            dt = DBHelper.GetTable("", "v_sale_billing_detail_report", "*", GetWhere(), "", "order by cust_name");
            dt.DataTableToDate("单据日期");
            List<string> listNot = new List<string>();
            listNot.Add("create_time");
            //按客户分组
            dt.DataTableGroup("cust_name", "公司", "客户名称：", "cust_code", "单据类型", "客户编码：", listNot);
            dgvReport.DataSource = dt;
        }
        /// <summary>
        /// 打开销售开单
        /// </summary>
        void OpenDocument()
        {
            if (dgvReport.CurrentRow == null)
            {
                return;
            }
            string sale_billing_id = Convert.ToString(this.dgvReport.CurrentRow.Cells[colID.Name].Value);
            if (sale_billing_id.Length == 0)
            {
                return;
            }
            UCSaleBillView view = new UCSaleBillView(sale_billing_id, null);
            base.addUserControl(view, "销售开单-查看", "UCSaleBillView" + sale_billing_id + "", this.Tag.ToString(), this.Name);
        }
    }
}
