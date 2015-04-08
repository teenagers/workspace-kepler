﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HXCPcClient.Chooser;
using ServiceStationClient.ComponentUI;
using HXCPcClient.CommonClass;
using SYSModel;
using Utility.Common;
using System.Drawing.Printing;

namespace HXCPcClient.UCForm.AccessoriesBusiness.SaleManagement.SaleOrder
{
    public partial class UCSaleOrderManagerSearch : UCBase
    {
        BusinessPrint businessPrint;//业务打印功能
        string printObject = string.Empty;
        string printTitle = string.Empty;
        List<string> listNotPrint = new List<string>();
        PaperSize paperSize = new PaperSize();
        #region 窗体初始化
        /// <summary> 窗体初始化
        /// </summary>
        public UCSaleOrderManagerSearch()
        {
            InitializeComponent();

            #region 窗体容器控件自适应大小
            //tabControlEx1自适应大小
            this.tabControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));


            #region 按采购订单查询界面控件的自适应
            this.panelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                | System.Windows.Forms.AnchorStyles.Right)));
            this.extUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPurchaseOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)
                       | System.Windows.Forms.AnchorStyles.Bottom));
            #endregion

            #region 按配件或客户查询界面控件的自适应
            this.panelEx3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                | System.Windows.Forms.AnchorStyles.Right)));
            this.extUserControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPurchaseList2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)
                       | System.Windows.Forms.AnchorStyles.Bottom));
            #endregion
            #endregion

            gvPurchaseOrderList.CellMouseClick += new DataGridViewCellMouseEventHandler(gvPurchaseOrderList_CellMouseClick);
            gvPurchaseList2.CellMouseClick += new DataGridViewCellMouseEventHandler(gvPurchaseList2_CellMouseClick);
            base.ExportEvent += new ClickHandler(UCSaleOrderManagerSearch_ExportEvent);
            base.ViewEvent += new ClickHandler(UCSaleOrderManagerSearch_ViewEvent);
            base.PrintEvent += new ClickHandler(UCSaleOrderManagerSearch_PrintEvent);
            base.SetEvent += new ClickHandler(UCSaleOrderManagerSearch_SetEvent);
            #region 预览、打印设置
            paperSize.Width = 297;
            paperSize.Height = 210;
            listNotPrint.Add(sale_order_id.Name);
            #endregion
        }
        /// <summary> 窗体加载
        /// </summary>
        private void UCSaleOrderManager_Load(object sender, EventArgs e)
        {
            //base.SetBaseButtonStatus();
            //base.SetButtonVisiableManagerSearch();
            string[] NotReadOnlyColumnsName = new string[] { "colCheck" };
            CommonFuncCall.SetColumnReadOnly(gvPurchaseOrderList, NotReadOnlyColumnsName);
            string[] NotReadOnlyColumnsName2 = new string[] { "p_colCheck" };
            CommonFuncCall.SetColumnReadOnly(gvPurchaseList2, NotReadOnlyColumnsName2);

            base.SetContentMenuScrip(gvPurchaseOrderList);
            base.SetContentMenuScrip(gvPurchaseList2);
            base.ClearAllToolStripItem();
            base.AddToolStripItem(base.btnExport);
            base.AddToolStripItem(base.btnView);
            base.AddToolStripItem(base.btnSet);
            base.AddToolStripItem(base.btnPrint);
            //设置查询按钮和清除按钮样式
            UIAssistants.SetButtonStyle4QueryAndClear(this,btnSearch, btnClear);
            //设置查询按钮和清除按钮样式
            UIAssistants.SetButtonStyle4QueryAndClear(this,btnSearch2, btnClear2);  

            dateTimeStart.Value = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            dateTimeEnd.Value = DateTime.Now;

            dateTimeStart2.Value = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            dateTimeEnd2.Value = DateTime.Now;

            //运输方式
            CommonFuncCall.BindComBoxDataSource(ddltrans_mode, "sys_trans_mode", "全部");
            //结算方式
            CommonFuncCall.BindBalanceWay(ddlclosing_way, "全部");

            CommonFuncCall.BindCompany(ddlCompany, "全部");
            CommonFuncCall.BindCompany(ddlddlCompany2, "全部");
            CommonFuncCall.BindDepartment(ddlDepartment, "", "全部");
            CommonFuncCall.BindHandle(ddlhandle, "", "全部");
            CommonFuncCall.BindFinishStatus(ddlFinishStatus, true);
            CommonFuncCall.BindFinishStatus(ddlBillStatus2, true);
            CommonFuncCall.BindIs_Gift(ddlis_gift2, true);
            BindgvSaleOrderList();

            Choosefrm.CusNameChoose(txtcust_name, Choosefrm.delDataBack = null);

            //按客户或配件信息查看---注册配件编码速查
            Choosefrm.PartsCodeChoose(txtparts_code2, Choosefrm.delDataBack = PartsName_DataBack);
            //按客户或配件信息查看---注册配件类型速查
            Choosefrm.PartsTypeNameChoose(txtparts_type2, Choosefrm.delDataBack = null);
            //按客户或配件信息查看---注册配件车型速查
            Choosefrm.PartsCarModelNameChoose(txtparts_cartype2, Choosefrm.delDataBack = null);
            //按客户或配件信息查看---注册客户编码速查
            Choosefrm.CusCodeChoose(txtcust_code2, Choosefrm.delDataBack = CustName2_DataBack);
        }
        #endregion

        #region 打印事件
        void UCSaleOrderManagerSearch_PrintEvent(object sender, EventArgs e)
        {
            if (tabControlEx1.SelectedIndex == 0)
            {
                printObject = "sale_order_parts_s";
                printTitle = "按销售订单查询";
                businessPrint = new BusinessPrint(gvPurchaseOrderList, printObject, printTitle, paperSize, listNotPrint);
                businessPrint.Print(gvPurchaseOrderList.GetBoundData());
            }
            else if (tabControlEx1.SelectedIndex == 1)
            {
                printObject = "sale_order_parts_search";
                printTitle = "销售订单按配件或客户查询";
                businessPrint = new BusinessPrint(gvPurchaseList2, printObject, printTitle, paperSize, listNotPrint);
                businessPrint.Print(gvPurchaseList2.GetBoundData());
            }
        }
        #endregion

        #region 预览事件
        void UCSaleOrderManagerSearch_ViewEvent(object sender, EventArgs e)
        {
            if (tabControlEx1.SelectedIndex == 0)
            {
                printObject = "sale_order_parts_s";
                printTitle = "按销售订单查询";
                businessPrint = new BusinessPrint(gvPurchaseOrderList, printObject, printTitle, paperSize, listNotPrint);
                businessPrint.Preview(gvPurchaseOrderList.GetBoundData());
            }
            else if (tabControlEx1.SelectedIndex == 1)
            {
                printObject = "sale_order_parts_search";
                printTitle = "销售订单按配件或客户查询";
                businessPrint = new BusinessPrint(gvPurchaseList2, printObject, printTitle, paperSize, listNotPrint);
                businessPrint.Preview(gvPurchaseList2.GetBoundData());
            }
        }
        #endregion

        #region 导出事件
        void UCSaleOrderManagerSearch_ExportEvent(object sender, EventArgs e)
        {
            if (tabControlEx1.SelectedIndex == 0)
            {
                ExportToxls(gvPurchaseOrderList, "按销售订单查询");
            }
            else if (tabControlEx1.SelectedIndex == 1)
            {
                ExportToxls(gvPurchaseList2, "销售订单按配件或客户查询");
            }
        }
        private void ExportToxls(DataGridViewEx dgv, string strMsg)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            try
            {
                string fileName = strMsg + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                ExcelHandler.ExportExcel(fileName, dgv);
            }
            catch (Exception ex)
            {
                Utility.Log.Log.writeLineToLog("【" + strMsg + "】" + ex.Message, "server");
                MessageBoxEx.ShowWarning("导出失败！");
            }
        }
        #endregion

        #region 预览、打印设置
        void UCSaleOrderManagerSearch_SetEvent(object sender, EventArgs e)
        {
            if (tabControlEx1.SelectedIndex == 0)
            {
                printObject = "sale_order_parts_s";
                printTitle = "按销售订单查询";
                businessPrint = new BusinessPrint(gvPurchaseOrderList, printObject, printTitle, paperSize, listNotPrint);
                businessPrint.PrintSet(gvPurchaseOrderList); 
            }
            else if (tabControlEx1.SelectedIndex == 1)
            {
                printObject = "sale_order_parts_search";
                printTitle = "销售订单按配件或客户查询";
                businessPrint = new BusinessPrint(gvPurchaseList2, printObject, printTitle, paperSize, listNotPrint);
                businessPrint.PrintSet(gvPurchaseList2); 
            }
        } 
        #endregion

        #region 按销售订单查询代码块
        #region 按钮事件
        /// <summary> 选择客户名称
        /// </summary>
        private void txtcus_name_ChooserClick(object sender, EventArgs e)
        {
            frmCustomerInfo chooseSupplier = new frmCustomerInfo();
            chooseSupplier.ShowDialog();
            string supperID = chooseSupplier.strCustomerId;
            if (!string.IsNullOrEmpty(supperID))
            {
                txtcust_name.Text = chooseSupplier.strCustomerName;
            }
        }
        /// <summary> 公司选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCompany.SelectedValue.ToString()))
            {
                CommonFuncCall.BindDepartment(ddlDepartment, ddlCompany.SelectedValue.ToString(), "全部");
            }
            else
            {
                CommonFuncCall.BindDepartment(ddlDepartment, "", "全部");
                CommonFuncCall.BindHandle(ddlhandle, "", "全部");
            }
        }
        /// <summary> 部门选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDepartment.SelectedValue.ToString()))
            {
                CommonFuncCall.BindHandle(ddlhandle, ddlDepartment.SelectedValue.ToString(), "全部");
            }
            else
            {
                CommonFuncCall.BindHandle(ddlhandle, "", "全部");
            }
        }
        /// <summary> 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtcust_name.Text = string.Empty;
            txtorder_num.Caption = string.Empty;
            txtRemark.Caption = string.Empty;
            dateTimeStart.Value = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            dateTimeEnd.Value = DateTime.Now;

            ddltrans_mode.SelectedIndex = 0;
            ddlclosing_way.SelectedIndex = 0;
            ddlFinishStatus.SelectedIndex = 0;
            ddlCompany.SelectedIndex = 0;
            ddlDepartment.SelectedIndex = 0;
            ddlhandle.SelectedIndex = 0;
        }
        /// <summary> 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateTimeStart.Value.ToShortDateString() + " 00:00:00") > Convert.ToDateTime(dateTimeEnd.Value.ToShortDateString() + " 00:00:00"))
            {
                MessageBoxEx.Show("单据日期的开始时间不可以大于结束时间");
            }
            else
                BindgvSaleOrderList();
        }
        /// <summary> 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void winFormPager1_PageIndexChanged(object sender, EventArgs e)
        {
            BindgvSaleOrderList();
        }
        /// <summary> 双击行查看明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPurchaseOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//双击表头或列头时不起作用   
            {
                string order_status = this.gvPurchaseOrderList.CurrentRow.Cells["order_status"].Value.ToString();
                string sale_order_Id = this.gvPurchaseOrderList.CurrentRow.Cells["sale_order_id"].Value.ToString();
                UCSaleOrderViewSearch UCSaleOrderView = new UCSaleOrderViewSearch(sale_order_Id, order_status, this);
                base.addUserControl(UCSaleOrderView, "销售订单-查看", "UCSaleOrderView" + sale_order_Id + "", this.Tag.ToString(), this.Name);
            }
        }
        /// <summary> 单元格格式化内容 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPurchaseOrderList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value.ToString().Length == 0)
            {
                return;
            }
            string fieldNmae = gvPurchaseOrderList.Columns[e.ColumnIndex].DataPropertyName;
            if (fieldNmae.Equals("order_date") || fieldNmae.Equals("delivery_time"))
            {
                long ticks = (long)e.Value;
                if (fieldNmae.Equals("order_date"))
                {
                    e.Value = Common.UtcLongToLocalDateTime(ticks).ToShortDateString();
                }
                else
                {
                    e.Value = Common.UtcLongToLocalDateTime(ticks);
                }
            }
        }
        #endregion

        #region 方法、函数
        /// <summary>
        /// 组合查询条件
        /// </summary>
        /// <returns></returns>
        string BuildString()
        {
            string Str_Where = " enable_flag='1' and order_status='2' ";
            if (!string.IsNullOrEmpty(txtcust_name.Text.Trim()))
            {
                Str_Where += " and cust_name like '%" + txtcust_name.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtorder_num.Caption.Trim()))
            {
                Str_Where += " and order_num like '%" + txtorder_num.Caption.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(ddltrans_mode.SelectedValue.ToString()))
            {
                Str_Where += " and trans_way='" + ddltrans_mode.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(ddlclosing_way.SelectedValue.ToString()))
            {
                Str_Where += " and closing_way='" + ddlclosing_way.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(ddlFinishStatus.SelectedValue.ToString()))
            {
                if (ddlFinishStatus.SelectedValue.ToString() == "1")
                { Str_Where += " and FinishStatus='已开单'"; }
                else if (ddlFinishStatus.SelectedValue.ToString() == "2")
                { Str_Where += " and FinishStatus='开单中'"; }
                else if (ddlFinishStatus.SelectedValue.ToString() == "3")
                { Str_Where += " and FinishStatus='未开单'"; }
                else if (ddlFinishStatus.SelectedValue.ToString() == "4")
                { Str_Where += " and FinishStatus='已中止'"; }
            }
            if (!string.IsNullOrEmpty(ddlCompany.SelectedValue.ToString()))
            {
                Str_Where += " and com_id='" + ddlCompany.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(ddlDepartment.SelectedValue.ToString()))
            {
                Str_Where += " and org_id='" + ddlDepartment.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(ddlhandle.SelectedValue.ToString()))
            {
                Str_Where += " and handle='" + ddlhandle.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(txtRemark.Caption.Trim()))
            {
                Str_Where += " and remark like '%" + txtRemark.Caption.Trim() + "%'";
            }
            if (dateTimeStart.Value != null)
            {
                DateTime dtime = Convert.ToDateTime(dateTimeStart.Value.ToShortDateString() + " 00:00:00");
                Str_Where += " and order_date>=" + Common.LocalDateTimeToUtcLong(dtime);
            }
            if (dateTimeEnd.Value != null)
            {
                DateTime dtime = Convert.ToDateTime(dateTimeEnd.Value.ToShortDateString() + " 23:59:59");
                Str_Where += " and order_date<=" + Common.LocalDateTimeToUtcLong(dtime);
            }
            return Str_Where;
        }
        /// <summary>
        /// 获取gvPurchaseOrderList列表选中的记录条数
        /// </summary>
        /// <returns></returns>
        private List<string> GetSelectedRecord()
        {
            List<string> listField = new List<string>();
            foreach (DataGridViewRow dr in gvPurchaseOrderList.Rows)
            {
                object isCheck = dr.Cells["colCheck"].EditedFormattedValue;
                if (isCheck != null && (bool)isCheck)
                {
                    listField.Add(dr.Cells["sale_order_id"].Value.ToString());
                }
            }
            return listField;
        }
        /// <summary>
        /// 获取gvPurchaseOrderList列表选中要审核的记录
        /// 只有工单状态是已提交的才可以被审核
        /// </summary>
        /// <returns></returns>
        private List<string> GetVerifyRecord()
        {
            List<string> listField = new List<string>();
            foreach (DataGridViewRow dr in gvPurchaseOrderList.Rows)
            {
                object isCheck = dr.Cells["colCheck"].EditedFormattedValue;
                if (isCheck != null && (bool)isCheck)
                {
                    //获取已提交/审核未通过的状态的编号
                    string order_status_SUBMIT = Convert.ToInt32(DataSources.EnumAuditStatus.SUBMIT).ToString();
                    string order_status_NOTAUDIT = Convert.ToInt32(DataSources.EnumAuditStatus.NOTAUDIT).ToString();
                    string colorder_status = dr.Cells["order_status"].Value.ToString();
                    if (order_status_SUBMIT == colorder_status || order_status_NOTAUDIT == colorder_status)
                    {
                        listField.Add(dr.Cells["sale_order_id"].Value.ToString());
                    }
                }
            }
            return listField;
        }
        /// <summary>
        /// 加载销售订单列表信息
        /// </summary>
        public void BindgvSaleOrderList()
        {
            try
            {
                int RecordCount = 0;
                string TableName = string.Format(@" (
                                                      select case is_suspend 
                                                            when '0' then '已中止'
                                                            else 
                                                                case  is_occupy 
                                                                when '0' then '未开单'
                                                                when '2' then '开单中'
                                                                when '3' then '已开单'
                                                                end
                                                            end FinishStatus,* from tb_parts_sale_order
                                                    ) tb_sal_order");
                DataTable gvPurchaseOrder_dt = DBHelper.GetTableByPage("查询销售订单列表信息", TableName, "*", BuildString(), "", " order by create_time desc ", winFormPager1.PageIndex, winFormPager1.PageSize, out RecordCount);
                gvPurchaseOrderList.DataSource = gvPurchaseOrder_dt;
                winFormPager1.RecordCount = RecordCount;
            }
            catch (Exception ex)
            {
                //异常日志
            }
        }
        #endregion 
        #endregion

        #region 按配件或客户查询代码块
        #region 控件事件
        /// <summary> 选择配件编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtparts_code2_ChooserClick(object sender, EventArgs e)
        {
            frmParts chooseParts = new frmParts();
            chooseParts.ShowDialog();
            if (!string.IsNullOrEmpty(chooseParts.PartsID))
            {
                txtparts_code2.Text = chooseParts.PartsCode;
                txtparts_name2.Caption = chooseParts.PartsName;
            }
        }
        /// <summary> 选择客户编码 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtcust_code2_ChooserClick(object sender, EventArgs e)
        {
            frmCustomerInfo chooseSupplier = new frmCustomerInfo();
            chooseSupplier.ShowDialog();
            if (!string.IsNullOrEmpty(chooseSupplier.strCustomerId))
            {
                txtcust_code2.Text = chooseSupplier.strCustomerNo;
                txtcust_name2.Caption = chooseSupplier.strCustomerName;

                DataTable dt = DBHelper.GetTable("查询客户档案信息", "tb_customer", "*", " enable_flag != 0 and cust_id='" + chooseSupplier.strCustomerId + "'", "", "");
                if (dt.Rows.Count > 0)
                {
                    txtcontacts_tel2.Caption = dt.Rows[0]["cust_tel"].ToString();
                }
            }
        }
        /// <summary> 选择配件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtparts_type2_ChooserClick(object sender, EventArgs e)
        {
            frmPartsType choosePartsType = new frmPartsType();
            choosePartsType.ShowDialog();
            if (!string.IsNullOrEmpty(choosePartsType.TypeID))
            {
                txtparts_type2.Text = choosePartsType.TypeName;
            }
        }
        /// <summary> 选择配件车型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtparts_cartype2_ChooserClick(object sender, EventArgs e)
        {
            frmVehicleModels chooseCarModel = new frmVehicleModels();
            chooseCarModel.ShowDialog();
            if (!string.IsNullOrEmpty(chooseCarModel.VMID))
            {
                txtparts_cartype2.Text = chooseCarModel.VMName;
            }
        }
        /// <summary> 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear2_Click(object sender, EventArgs e)
        {
            txtparts_code2.Text = string.Empty;
            txtparts_name2.Caption = string.Empty;
            txtcust_code2.Text = string.Empty;
            txtcust_name2.Caption = string.Empty;
            txtparts_type2.Text = string.Empty;
            txtparts_cartype2.Text = string.Empty;
            txtcontacts2.Caption = string.Empty;
            txtcontacts_tel2.Caption = string.Empty;
            txtdrawing_num2.Caption = string.Empty;
            txtparts_brand2.Caption = string.Empty;
            ddlis_gift2.SelectedIndex = 0;
            txtremark2.Caption = string.Empty;
            dateTimeStart2.Value = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            dateTimeEnd2.Value = DateTime.Now;
            ddlddlCompany2.SelectedIndex = 0;
            ddlBillStatus2.SelectedIndex = 0;
        }
        /// <summary> 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateTimeStart2.Value.ToShortDateString() + " 00:00:00") > Convert.ToDateTime(dateTimeEnd2.Value.ToShortDateString() + " 00:00:00"))
            {
                MessageBoxEx.Show("单据日期的开始时间不可以大于结束时间");
            }
            else
                BindgvPurchaseList2();
        }
        /// <summary> 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void winFormPager2_PageIndexChanged(object sender, EventArgs e)
        {
            BindgvPurchaseList2();
        }
        /// <summary> 单元格格式化内容 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPurchaseList2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value.ToString().Length == 0)
            {
                return;
            }
            string fieldNmae = gvPurchaseList2.Columns[e.ColumnIndex].DataPropertyName;
            if (fieldNmae.Equals("order_date"))
            {
                long ticks = (long)e.Value;
                e.Value = Common.UtcLongToLocalDateTime(ticks).ToShortDateString();
            }
            if (fieldNmae.Equals("is_gift"))
            {
                e.Value = e.Value.ToString() == "0" ? "否" : "是";
            }
        }
        #endregion

        #region 方法、函数
        /// <summary> 按配件或客户信息查询的查询条件
        /// </summary>
        /// <returns></returns>
        string BuildString2()
        {
            string Str_Where = " enable_flag='1' and order_status='2' ";
            if (!string.IsNullOrEmpty(txtparts_code2.Text.Trim()))
            {
                Str_Where += " and parts_code='" + txtparts_code2.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(txtparts_name2.Caption.Trim()))
            {
                Str_Where += " and parts_name like '%" + txtparts_name2.Caption.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtcust_code2.Text.Trim()))
            {
                Str_Where += " and cust_code='" + txtcust_code2.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(txtcust_name2.Caption.Trim()))
            {
                Str_Where += " and cust_name like '%" + txtcust_name2.Caption.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtparts_type2.Text.Trim()))
            {
                Str_Where += " and parts_type_name like '%" + txtparts_type2.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtparts_cartype2.Text.Trim()))
            {
                Str_Where += " and vm_name like '%" + txtparts_cartype2.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtcontacts2.Caption.Trim()))
            {
                Str_Where += " and contacts like '%" + txtcontacts2.Caption.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtcontacts_tel2.Caption.Trim()))
            {
                Str_Where += " and contacts_tel like '%" + txtcontacts_tel2.Caption.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtdrawing_num2.Caption.Trim()))
            {
                Str_Where += " and drawing_num like '%" + txtdrawing_num2.Caption.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtparts_brand2.Caption.Trim()))
            {
                Str_Where += " and parts_brand_name like '%" + txtparts_brand2.Caption.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(ddlis_gift2.SelectedValue.ToString()))
            {
                Str_Where += " and is_gift='" + ddlis_gift2.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(txtremark2.Caption.Trim()))
            {
                Str_Where += " and remark like '%" + txtremark2.Caption.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(ddlddlCompany2.SelectedValue.ToString()))
            {
                Str_Where += " and com_id='" + ddlddlCompany2.SelectedValue.ToString() + "'";
            }
            if (dateTimeStart2.Value != null)
            {
                DateTime dtime = Convert.ToDateTime(dateTimeStart2.Value.ToShortDateString() + " 00:00:00");
                Str_Where += " and order_date>=" + Common.LocalDateTimeToUtcLong(dtime);
            }
            if (dateTimeEnd2.Value != null)
            {
                DateTime dtime = Convert.ToDateTime(dateTimeEnd2.Value.ToShortDateString() + " 23:59:59");
                Str_Where += " and order_date<=" + Common.LocalDateTimeToUtcLong(dtime);
            }
            if (!string.IsNullOrEmpty(ddlBillStatus2.SelectedValue.ToString()))
            {
                if (ddlBillStatus2.SelectedValue.ToString() == "1")
                { Str_Where += " and FinishStatus='已开单'"; }
                else if (ddlBillStatus2.SelectedValue.ToString() == "2")
                { Str_Where += " and FinishStatus='开单中'"; }
                else if (ddlBillStatus2.SelectedValue.ToString() == "3")
                { Str_Where += " and FinishStatus='未开单'"; }
                else if (ddlBillStatus2.SelectedValue.ToString() == "4")
                { Str_Where += " and FinishStatus='已中止'"; }
            }
            return Str_Where;
        }
        /// <summary> 绑定按配件或客户信息查询的列表
        /// </summary>
        void BindgvPurchaseList2()
        {
            try
            {
                int RecordCount = 0;
                DataTable gvPurchaseList2_dt = DBHelper.GetTableByPage("查询采购订单列表信息", "v_sale_order_parts_search", "*", BuildString2(), "", " order by createtime desc ", winFormPager2.PageIndex, winFormPager2.PageSize, out RecordCount);
                gvPurchaseList2.DataSource = gvPurchaseList2_dt;
                winFormPager2.RecordCount = RecordCount;
            }
            catch (Exception ex)
            { }
        }
        #endregion
        private void txtorder_num_Load(object sender, EventArgs e)
        {

        }
        #endregion    

        #region --选择器获取数据后需执行的回调函数
        /// <summary> 供应商速查关联控件赋值
        /// </summary>
        /// <param name="dr"></param>
        private void CustName2_DataBack(DataRow dr)
        {
            if (dr.Table.Columns.Contains("cust_name"))
            {
                this.txtcust_name2.Caption = dr["cust_name"].ToString();
            }
        }
        /// <summary> 配件编码速查关联控件赋值
        /// </summary>
        /// <param name="dr"></param>
        private void PartsName_DataBack(DataRow dr)
        {
            if (dr.Table.Columns.Contains("parts_name"))
            {
                this.txtparts_name2.Caption = dr["parts_name"].ToString();
            }
        }
        #endregion

        /// <summary> 单击一行，选择或取消选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gvPurchaseList2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == colCheck.Index)
            {
                return;
            }
            //清空已选择框
            foreach (DataGridViewRow dgvr in gvPurchaseList2.Rows)
            {
                object check = dgvr.Cells[p_colCheck.Name].EditedFormattedValue;
                if (check != null && (bool)check)
                {
                    dgvr.Cells[p_colCheck.Name].Value = false;
                }
            }
            //选择当前行
            gvPurchaseList2.Rows[e.RowIndex].Cells[p_colCheck.Name].Value = true;
        }
        /// <summary> 单击一行，选择或取消选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gvPurchaseOrderList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == colCheck.Index)
            {
                return;
            }
            //清空已选择框
            foreach (DataGridViewRow dgvr in gvPurchaseOrderList.Rows)
            {
                object check = dgvr.Cells[colCheck.Name].EditedFormattedValue;
                if (check != null && (bool)check)
                {
                    dgvr.Cells[colCheck.Name].Value = false;
                }
            }
            //选择当前行
            gvPurchaseOrderList.Rows[e.RowIndex].Cells[colCheck.Name].Value = true;
        } 
    }
}
