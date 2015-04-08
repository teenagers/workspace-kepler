﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HXCPcClient.CommonClass;
using ServiceStationClient.ComponentUI;
using HXCPcClient.Chooser;
using Utility.Common;
using SYSModel;
using Model;
using System.Reflection;

namespace HXCPcClient.UCForm.AccessoriesBusiness.PurchaseManagement.PurchaseBilling
{
    public partial class UCPurchaseBillManang : UCBase
    {
        List<string> listIDs = new List<string>();//已选择项的ID列表
        List<string> listStart = new List<string>();//启用状态
        List<string> listStop = new List<string>();//停用状态
        #region 窗体初始化
        /// <summary>
        /// 窗体初始化
        /// </summary>
        public UCPurchaseBillManang()
        {
            InitializeComponent();
            dateTimeStart.Value = DateTime.Now;
            dateTimeEnd.Value = DateTime.Now;

            base.AddEvent += new ClickHandler(UCPurchaseBillManang_AddEvent);
            base.EditEvent += new ClickHandler(UCPurchaseBillManang_EditEvent);
            base.CopyEvent += new ClickHandler(UCPurchaseBillManang_CopyEvent);
            base.DeleteEvent += new ClickHandler(UCPurchaseBillManang_DeleteEvent);
            base.VerifyEvent += new ClickHandler(UCPurchaseBillManang_VerifyEvent);
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCPurchaseBillManang_Load(object sender, EventArgs e)
        {
            base.SetBaseButtonStatus();
            base.SetButtonVisiableManager();
            string[] NotReadOnlyColumnsName = new string[] { "colCheck" };
            CommonFuncCall.SetColumnReadOnly(gvPurchaseOrderList, NotReadOnlyColumnsName);
            UIAssistants.SetButtonStyle4QueryAndClear(btnSearch, btnClear);  //设置查询按钮和清除按钮样式

            //单据类型
            CommonFuncCall.BindPurchaseOrderType(ddlorder_type, true, "全部");
            //运输方式
            CommonFuncCall.BindComBoxDataSource(ddltrans_way, "sys_trans_mode", "全部");
            //发票类型
            CommonFuncCall.BindComBoxDataSource(ddlreceipt_type, "sys_receipt_type", "全部");
            //单据状态
            CommonFuncCall.BindOrderStatus(ddlState, true);

            CommonFuncCall.BindCompany(ddlCompany, "全部");
            CommonFuncCall.BindDepartment(ddlDepartment, "", "全部");
            CommonFuncCall.BindHandle(ddlhandle, "", "全部");

            BindgvPurchaseOrderList();
        } 
        #endregion

        #region 控件事件
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UCPurchaseBillManang_AddEvent(object sender, EventArgs e)
        {
            UCPurchaseBillAddOrEdit UCPurchaseBillAdd = new UCPurchaseBillAddOrEdit(WindowStatus.Add, null, this);
            base.addUserControl(UCPurchaseBillAdd, "采购开单-添加", "UCPurchaseBillAdd", this.Tag.ToString(), this.Name);
        }
        /// <summary>
        /// 复制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UCPurchaseBillManang_CopyEvent(object sender, EventArgs e)
        {
            string purchase_billing_id = string.Empty;
            List<string> listField = GetSelectedRecord();
            if (listField.Count == 0)
            {
                MessageBoxEx.Show("请选择要复制的数据!");
                return;
            }
            if (listField.Count > 1)
            {
                MessageBoxEx.Show("一次只可以复制一条数据!");
                return;
            }
            purchase_billing_id = listField[0].ToString();
            UCPurchaseBillAddOrEdit UCPurchaseBillCopy = new UCPurchaseBillAddOrEdit(WindowStatus.Copy, purchase_billing_id, this);
            base.addUserControl(UCPurchaseBillCopy, "采购开单-复制", "UCPurchaseBillCopy" + purchase_billing_id + "", this.Tag.ToString(), this.Name);
        }
        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UCPurchaseBillManang_EditEvent(object sender, EventArgs e)
        {
            string purchase_billing_id = string.Empty;
            bool IsHandle = true;
            List<string> listField = GetSelectedRecordByEditDelete(ref IsHandle);
            if (IsHandle)
            {
                if (listField.Count == 0)
                {
                    MessageBoxEx.Show("请选择要编辑的数据!");
                    return;
                }
                if (listField.Count > 1)
                {
                    MessageBoxEx.Show("一次只可以编辑一条数据!");
                    return;
                }
                purchase_billing_id = listField[0].ToString();
                UCPurchaseBillAddOrEdit UCPurchaseBillEdit = new UCPurchaseBillAddOrEdit(WindowStatus.Edit, purchase_billing_id, this);
                base.addUserControl(UCPurchaseBillEdit, "采购开单-编辑", "UCPurchaseBillEdit" + purchase_billing_id + "", this.Tag.ToString(), this.Name);
            }
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UCPurchaseBillManang_DeleteEvent(object sender, EventArgs e)
        {
            bool IsHandle = true;
            List<string> listField = GetSelectedRecordByEditDelete(ref IsHandle);
            if (IsHandle)
            {
                if (listField.Count == 0)
                {
                    MessageBoxEx.Show("请选择要删除的数据!");
                    return;
                }
                if (MessageBoxEx.Show("确认要删除选中的数据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
                Dictionary<string, string> purchaseOrderField = new Dictionary<string, string>();
                purchaseOrderField.Add("enable_flag", "0");
                bool flag = DBHelper.BatchUpdateDataByIn("批量删除采购开单表", "tb_parts_purchase_billing", purchaseOrderField, "purchase_billing_id", listField.ToArray());
                if (flag)
                {
                    BindgvPurchaseOrderList();
                    MessageBoxEx.Show("操作成功！");
                }
                else
                {
                    MessageBoxEx.Show("操作失败！");
                }
            }
        }
        /// <summary> 审核事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UCPurchaseBillManang_VerifyEvent(object sender, EventArgs e)
        {
            List<string> listField = GetVerifyRecord();
            if (listField.Count == 0)
            {
                MessageBoxEx.Show("请选择要审核的数据!");
                return;
            }
            UCVerify UcVerify = new UCVerify();
            if (UcVerify.ShowDialog() == DialogResult.OK)
            {
                string Content = UcVerify.Content;
                SYSModel.DataSources.EnumAuditStatus UcVerifyStatus = UcVerify.auditStatus;

                Dictionary<string, string> purchasePlanField = new Dictionary<string, string>();
                if (UcVerifyStatus == DataSources.EnumAuditStatus.AUDIT)
                {
                    //获取采购开单状态(已审核)
                    purchasePlanField.Add("order_status", Convert.ToInt32(DataSources.EnumAuditStatus.AUDIT).ToString());
                    purchasePlanField.Add("order_status_name", DataSources.GetDescription(DataSources.EnumAuditStatus.AUDIT, true));
                }
                else if (UcVerifyStatus == DataSources.EnumAuditStatus.NOTAUDIT)
                {
                    //获取采购开单状态(审核不通过)
                    purchasePlanField.Add("order_status", Convert.ToInt32(DataSources.EnumAuditStatus.NOTAUDIT).ToString());
                    purchasePlanField.Add("order_status_name", DataSources.GetDescription(DataSources.EnumAuditStatus.NOTAUDIT, true));
                }
                bool flag = DBHelper.BatchUpdateDataByIn("批量审核采购开单表", "tb_parts_purchase_billing", purchasePlanField, "purchase_billing_id", listField.ToArray());
                if (flag)
                {
                    CreateBill(listField);
                    BindgvPurchaseOrderList();
                    MessageBoxEx.Show("操作成功！");
                }
                else
                {
                    MessageBoxEx.Show("操作失败！");
                }
            }
        }
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void winFormPager1_PageIndexChanged(object sender, EventArgs e)
        {
            BindgvPurchaseOrderList();
        }
        /// <summary>
        /// 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtsup_code.Text = string.Empty;
            txtsup_name.Caption = string.Empty;
            txtorder_num.Caption = string.Empty;
            dateTimeStart.Value = DateTime.Now;
            dateTimeEnd.Value = DateTime.Now;

            ddlorder_type.SelectedIndex = 0;
            ddltrans_way.SelectedIndex = 0;
            ddlreceipt_type.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlCompany.SelectedIndex = 0;
            ddlDepartment.SelectedIndex = 0;
            ddlhandle.SelectedIndex = 0;
        }
        /// <summary>
        /// 查询按钮事件
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
                BindgvPurchaseOrderList();
        }
        /// <summary>
        /// 选择配件编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtsup_code_ChooserClick(object sender, EventArgs e)
        {
            frmSupplier chooseSupplier = new frmSupplier();
            chooseSupplier.ShowDialog();
            string supperID = chooseSupplier.supperID;
            if (!string.IsNullOrEmpty(supperID))
            {
                txtsup_code.Text = chooseSupplier.supperCode;
                txtsup_name.Caption = chooseSupplier.supperName;
            }
        }
        /// <summary>
        /// 公司选择事件
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
        /// <summary>
        /// 部门选择事件
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
        /// <summary>
        /// 列表双击查看明细事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPurchaseOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//双击表头或列头时不起作用   
            {
                string purchase_billing_id = Convert.ToString(this.gvPurchaseOrderList.CurrentRow.Cells[0].Value.ToString());
                UCPurchaseBillView UCPurchaseBillView = new UCPurchaseBillView(purchase_billing_id, this);
                base.addUserControl(UCPurchaseBillView, "采购开单-查看", "UCPurchaseBillView" + purchase_billing_id + "", this.Tag.ToString(), this.Name);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPurchaseOrderList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == string.Empty)
            {
                return;
            }
            string fieldNmae = gvPurchaseOrderList.Columns[e.ColumnIndex].DataPropertyName;
            if (fieldNmae.Equals("order_date"))
            {
                long ticks = (long)e.Value;
                e.Value = Common.UtcLongToLocalDateTime(ticks);
            }
            if (fieldNmae.Equals("order_status_name"))
            {
                string num = gvPurchaseOrderList.Rows[e.RowIndex].Cells["order_status"].Value.ToString();
                num = string.IsNullOrEmpty(num) ? "0" : num;
                if (num == "3")
                { gvPurchaseOrderList.Rows[e.RowIndex].Cells["order_status_name"].Style.ForeColor = Color.Red; }
                else
                { gvPurchaseOrderList.Rows[e.RowIndex].Cells["order_status_name"].Style.ForeColor = Color.Black; }
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
            string Str_Where = " enable_flag=1  ";
            if (!string.IsNullOrEmpty(txtorder_num.Text.Trim()))
            {
                Str_Where += " and order_num = '" + txtorder_num.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(txtsup_code.Text.Trim()))
            {
                Str_Where += " and sup_code = '" + txtsup_code.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(txtsup_name.Caption.Trim()))
            {
                Str_Where += " and sup_name like '%" + txtsup_name.Caption.Trim() + "%'";
            }

            if (!string.IsNullOrEmpty(ddlorder_type.SelectedValue.ToString()))
            {
                Str_Where += " and order_type='" + ddlorder_type.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(ddltrans_way.SelectedValue.ToString()))
            {
                Str_Where += " and trans_way='" + ddltrans_way.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(ddlreceipt_type.SelectedValue.ToString()))
            {
                Str_Where += " and receipt_type='" + ddlreceipt_type.SelectedValue.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(ddlState.SelectedValue.ToString()))
            {
                Str_Where += " and order_status='" + ddlState.SelectedValue.ToString() + "'";
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
                    listField.Add(dr.Cells["purchase_billing_id"].Value.ToString());
                }
            }
            return listField;
        }
        /// <summary>
        /// 获取gvPurchaseOrderList列表选中的记录条数
        /// </summary>
        /// <returns></returns>
        private List<string> GetSelectedRecordByEditDelete(ref bool IsHandle)
        {
            List<string> listField = new List<string>();
            foreach (DataGridViewRow dr in gvPurchaseOrderList.Rows)
            {
                object isCheck = dr.Cells["colCheck"].EditedFormattedValue;
                if (isCheck != null && (bool)isCheck)
                {
                    string import_status = dr.Cells["is_occupy"].Value.ToString();
                    if (import_status == "0")
                    { listField.Add(dr.Cells["purchase_billing_id"].Value.ToString()); }
                    else if (import_status == "1")
                    {
                        IsHandle = false;
                        MessageBoxEx.Show("单号为：" + dr.Cells["order_num"].Value.ToString() + "的单据，已经被占用,暂时不可操作!");
                        return listField;
                    }
                    else if (import_status == "2")
                    {
                        IsHandle = false;
                        MessageBoxEx.Show("单号为：" + dr.Cells["order_num"].Value.ToString() + "的单据，已经被锁定,不可以再次操作!");
                        return listField;
                    }
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
                        listField.Add(dr.Cells["purchase_billing_id"].Value.ToString());
                    }
                }
            }
            return listField;
        }
        /// <summary>
        /// 加载采购订单列表信息
        /// </summary>
        public void BindgvPurchaseOrderList()
        {
            try
            {
                int RecordCount = 0;
                DataTable gvPurchaseOrder_dt = DBHelper.GetTableByPage("查询采购开单列表信息", "tb_parts_purchase_billing", "*", BuildString(), "", " order by create_time desc ", winFormPager1.PageIndex, winFormPager1.PageSize, out RecordCount);
                gvPurchaseOrderList.DataSource = gvPurchaseOrder_dt;
                winFormPager1.RecordCount = RecordCount;
            }
            catch (Exception ex)
            {
                //异常日志
            }
        }
        /// <summary>
        /// 审核通过后需要自动生成的单子的方法
        /// </summary>
        void CreateBill(List<string> listField)
        {
            if (listField.Count > 0)
            {
                for (int i = 0; i < listField.Count; i++)
                {
                    DataTable dt = DBHelper.GetTable("", "tb_parts_purchase_billing", "*", string.Format("purchase_billing_id='{0}'", listField[i]), "", "");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        tb_parts_purchase_billing model = new tb_parts_purchase_billing();
                        CommonFuncCall.SetModlByDataTable(model, dt);

                        #region 当金额大于0时，自动生成预付款单
                        if (model.this_payment > 0)
                        {
                            tb_bill_receivable a = new tb_bill_receivable();
                            tb_balance_documents b = new tb_balance_documents();
                            tb_payment_detail c = new tb_payment_detail();
                            a.cust_id = model.sup_id;//供应商ID
                            a.order_num = CommonUtility.GetNewNo(DataSources.EnumProjectType.PAYMENT);//订单号
                            a.order_type = (int)DataSources.EnumOrderType.PAYMENT;
                            a.payment_type = (int)DataSources.EnumPaymentType.PAYMENT;
                            a.org_id = model.org_id;

                            b.billing_money = model.this_payment;//开单金额
                            b.documents_date = model.order_date;//单据日期
                            b.documents_id = model.purchase_billing_id;//单据ID
                            b.documents_name = "采购开单";//单据名称
                            b.documents_num = model.order_num;//单据编码

                            c.money = model.this_payment;//金额
                            c.balance_way = model.balance_way;//结算方式
                            c.check_number = model.check_number;//票号

                            DBOperation.AddBillReceivable(a, b, c);
                        }
                        #endregion

                        #region 自动生产出入库单
                        #region 一:采购收货单-->自动生成入库单
                        if (model.order_type == DataSources.EnumPurchaseOrderType.PurchaseReceive.ToString())
                        {
                            string stock_inout_id = string.Empty;
                            //1.生成入库单
                            if (CreateIntoStock("入库单", model, ref stock_inout_id))
                            {
                                //2.查询配件信息，生成配件信息入库单
                                DataTable dt_parts = DBHelper.GetTable("查询采购开单配件信息表", "tb_parts_purchase_billing_p", "*", " purchase_billing_id='" + model.purchase_billing_id + "'", "", "");
                                if (dt_parts != null && dt_parts.Rows.Count > 0)
                                {
                                    for (int a = 0; a < dt_parts.Rows.Count; a++)
                                    {
                                        tb_parts_purchase_billing_p bill_p_model = new tb_parts_purchase_billing_p();
                                        CommonFuncCall.SetModlByDataTable(bill_p_model, dt_parts, a);
                                        CreateIntoPartsStock(stock_inout_id, bill_p_model);
                                    }
                                }
                            }
                        }
                        #endregion

                        #region 二:采购退货-->自动生成出库单
                        else if (model.order_type == DataSources.EnumPurchaseOrderType.PurchaseBack.ToString())
                        {
                            string stock_inout_id = string.Empty;
                            //1.生成出库单
                            if (CreateIntoStock("出库单", model, ref stock_inout_id))
                            {
                                //2.查询配件信息，生成配件信息出库单
                                DataTable dt_parts = DBHelper.GetTable("查询采购开单配件信息表", "tb_parts_purchase_billing_p", "*", " purchase_billing_id='" + model.purchase_billing_id + "'", "", "");
                                if (dt_parts != null && dt_parts.Rows.Count > 0)
                                {
                                    for (int a = 0; a < dt_parts.Rows.Count; a++)
                                    {
                                        tb_parts_purchase_billing_p bill_p_model = new tb_parts_purchase_billing_p();
                                        CommonFuncCall.SetModlByDataTable(bill_p_model, dt_parts, a);
                                        CreateIntoPartsStock(stock_inout_id, bill_p_model);
                                    }
                                }
                            }
                        } 
                        #endregion

                        #region 三:采购换货-->自动生成出、入库单(数量大于0是入库，小于0是出库)
                        else if (model.order_type == DataSources.EnumPurchaseOrderType.PurchaseExchange.ToString())
                        {
                            string stock_in_id = string.Empty;
                            string stock_out_id = string.Empty;
                            //1.生成入库单
                            if (CreateIntoStock("入库单", model, ref stock_in_id))
                            {
                                //2.查询配件入库数量大于0的，生成配件信息入库单
                                DataTable dt_parts = DBHelper.GetTable("查询采购开单配件信息表", "tb_parts_purchase_billing_p", "*", " purchase_billing_id='" + model.purchase_billing_id + "' and storage_count>0 ", "", "");
                                if (dt_parts != null && dt_parts.Rows.Count > 0)
                                {
                                    for (int a = 0; a < dt_parts.Rows.Count; a++)
                                    {
                                        tb_parts_purchase_billing_p bill_p_model = new tb_parts_purchase_billing_p();
                                        CommonFuncCall.SetModlByDataTable(bill_p_model, dt_parts, a);
                                        CreateIntoPartsStock(stock_in_id, bill_p_model);
                                    }
                                }
                            }

                            //3.生成出库单
                            if (CreateIntoStock("出库单", model, ref stock_out_id))
                            {
                                //4.查询配件入库数量小于0的，生成配件信息出库单
                                DataTable dt_parts = DBHelper.GetTable("查询采购开单配件信息表", "tb_parts_purchase_billing_p", "*", " purchase_billing_id='" + model.purchase_billing_id + "' and storage_count<0 ", "", "");
                                if (dt_parts != null && dt_parts.Rows.Count > 0)
                                {
                                    for (int a = 0; a < dt_parts.Rows.Count; a++)
                                    {
                                        tb_parts_purchase_billing_p bill_p_model = new tb_parts_purchase_billing_p();
                                        CommonFuncCall.SetModlByDataTable(bill_p_model, dt_parts, a);
                                        CreateIntoPartsStock(stock_out_id, bill_p_model);
                                    }
                                }
                            }
                        } 
                        #endregion
                        #endregion

                        #region 向宇通发送配送单号
                        if (!string.IsNullOrEmpty(model.ration_send_code))
                        {
                            //DBHelper.WebServHandler("审核通过入库时发送配送单号到宇通系统", EnumWebServFunName.UpLoadPartPutStore, model.ration_send_code);
                            DBHelper.WebServHandler("", EnumWebServFunName.LoadPartInStore, model.ration_send_code);
                        }
                        #endregion
                    }
                }
            }
        }

        /// <summary> 创建出入库单
        /// </summary>
        /// <param name="ordertype">单据类型</param>
        /// <param name="bill_model">采购开单信息</param>
        bool CreateIntoStock(string ordertype, tb_parts_purchase_billing bill_model, ref string stock_inout_id)
        {
            tb_parts_stock_inout stoct_inout_model = new tb_parts_stock_inout();
            Dictionary<string, string> dicParam = new Dictionary<string, string>();//参数

            stoct_inout_model.stock_inout_id = Guid.NewGuid().ToString();
            
            stoct_inout_model.order_date = Common.LocalDateTimeToUtcLong(DateTime.Now);
            stoct_inout_model.order_status = Convert.ToInt32(DataSources.EnumAuditStatus.DRAFT).ToString();
            stoct_inout_model.order_status_name = DataSources.GetDescription(DataSources.EnumAuditStatus.DRAFT, true);
            if (ordertype == "入库单")
            {
                stoct_inout_model.order_num = CommonUtility.GetNewNo(DataSources.EnumProjectType.InBill);//获取入库单编号
                stoct_inout_model.order_type = Convert.ToInt32(DataSources.EnumAllocationBillType.Storage).ToString();
                stoct_inout_model.order_type_name = Convert.ToInt32(DataSources.EnumAllocationBillType.Storage).ToString();
            }
            else if (ordertype == "出库单")
            {
                stoct_inout_model.order_num = CommonUtility.GetNewNo(DataSources.EnumProjectType.OutBill);//获取出库单编号
                stoct_inout_model.order_type = Convert.ToInt32(DataSources.EnumAllocationBillType.OutboundOrder).ToString();
                stoct_inout_model.order_type_name = Convert.ToInt32(DataSources.EnumAllocationBillType.OutboundOrder).ToString();
            }
            stoct_inout_model.billing_type = Convert.ToInt32(DataSources.EnumAllocationBillingType.PurchaseBilling).ToString();
            stoct_inout_model.billing_type_name = Convert.ToInt32(DataSources.EnumAllocationBillingType.PurchaseBilling).ToString();
            stoct_inout_model.arrival_place = bill_model.delivery_address;
            stoct_inout_model.bussiness_units = "";
            stoct_inout_model.com_id = GlobalStaticObj.CurrUserCom_Id;
            stoct_inout_model.com_name = GlobalStaticObj.CurrUserCom_Name;
            stoct_inout_model.org_id = bill_model.org_id;
            stoct_inout_model.org_name = bill_model.org_name;
            stoct_inout_model.handle = bill_model.handle;
            stoct_inout_model.handle_name = bill_model.handle_name;
            stoct_inout_model.operators = bill_model.operators;
            stoct_inout_model.operator_name = bill_model.operator_name;
            stoct_inout_model.create_by = GlobalStaticObj.UserID;
            stoct_inout_model.create_name = GlobalStaticObj.UserName;
            stoct_inout_model.create_time = Common.LocalDateTimeToUtcLong(DateTime.Now);
            stoct_inout_model.remark = "";
            stoct_inout_model.enable_flag = "1";

            foreach (PropertyInfo info in stoct_inout_model.GetType().GetProperties())
            {
                string name = info.Name;
                object value = info.GetValue(stoct_inout_model, null);
                dicParam.Add(name, value == null ? "" : value.ToString());
            }
            return DBHelper.Submit_AddOrEdit("出入库单表添加信息", "tb_parts_stock_inout", "stock_inout_id", "", dicParam);
        }
        /// <summary> 创建出入库单配件信息
        /// </summary>
        /// <param name="stock_inout_id">出入库单ID</param>
        /// <param name="parts_model">采购开单配件信息</param>
        bool CreateIntoPartsStock(string stock_inout_id, tb_parts_purchase_billing_p parts_model)
        {
            tb_parts_stock_inout_p PartsInoutModel = new tb_parts_stock_inout_p();
            Dictionary<string, string> dicParam = new Dictionary<string, string>();//参数

            PartsInoutModel.stock_inout_parts_id = Guid.NewGuid().ToString();
            PartsInoutModel.stock_inout_id = stock_inout_id;
            PartsInoutModel.wh_id = parts_model.wh_id;
            PartsInoutModel.num = parts_model.num;
            PartsInoutModel.parts_num = parts_model.parts_code;
            PartsInoutModel.parts_name = parts_model.parts_name;
            PartsInoutModel.drawing_num = parts_model.drawing_num;
            PartsInoutModel.unit = parts_model.unit_id;
            PartsInoutModel.unit_name = parts_model.unit_name;
            PartsInoutModel.parts_brand = parts_model.parts_brand;
            PartsInoutModel.count = parts_model.storage_count;//入库数量
            PartsInoutModel.is_gift = parts_model.is_gift;
            PartsInoutModel.remark = parts_model.remark;
            PartsInoutModel.create_by = GlobalStaticObj.UserID;
            PartsInoutModel.create_name = GlobalStaticObj.UserName;
            PartsInoutModel.create_time = Common.LocalDateTimeToUtcLong(DateTime.Now);

            foreach (PropertyInfo info in PartsInoutModel.GetType().GetProperties())
            {
                string name = info.Name;
                object value = info.GetValue(PartsInoutModel, null);
                dicParam.Add(name, value == null ? "" : value.ToString());
            }
            return DBHelper.Submit_AddOrEdit("出入库配件表添加信息", "tb_parts_stock_inout_p", "stock_inout_parts_id", "", dicParam);
        }
        #endregion

        /// <summary> 选中列标头的复选框事件
        /// </summary>
        private void gvPurchaseOrderList_HeadCheckChanged()
        {
            SetSelectedStatus();
        }
        /// <summary> 选择复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPurchaseOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvPurchaseOrderList.CurrentCell == null)
            {
                return;
            }
            //点击选择框
            if (gvPurchaseOrderList.CurrentCell.OwningColumn.Name == colCheck.Name)
            {
                SetSelectedStatus();
            }
        }
        /// <summary> 单击一行，选择或取消选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPurchaseOrderList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            SetSelectedStatus();
        }
        /// <summary> 设置选择项后状态
        /// </summary>
        void SetSelectedStatus()
        {
            listIDs.Clear();
            //已选择状态列表
            List<string> listFiles = new List<string>();
            foreach (DataGridViewRow dgvr in gvPurchaseOrderList.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells[colCheck.Name].EditedFormattedValue))
                {
                    listFiles.Add(dgvr.Cells[order_status.Name].Value.ToString());
                    listIDs.Add(dgvr.Cells[purchase_billing_id.Name].Value.ToString());
                }
            }

            //提交
            string submitStr = ((int)DataSources.EnumAuditStatus.SUBMIT).ToString();
            //审核
            string auditStr = ((int)DataSources.EnumAuditStatus.AUDIT).ToString();
            //草稿
            string draftStr = ((int)DataSources.EnumAuditStatus.DRAFT).ToString();
            //审核未通过
            string noAuditStr = ((int)DataSources.EnumAuditStatus.NOTAUDIT).ToString();
            //作废
            string invalid = ((int)DataSources.EnumAuditStatus.Invalid).ToString();
            //复制按钮，只选择一个并且不是作废，可以复制
            if (listFiles.Count == 1 && !listFiles.Contains(invalid))
            {
                btnCopy.Enabled = true;
            }
            else
            {
                btnCopy.Enabled = false;
            }
            //编辑按钮，只选择一个并且是草稿或未通过状态，可以编辑
            if (listFiles.Count == 1 && (listFiles.Contains(draftStr) || listFiles.Contains(noAuditStr)))
            {
                btnEdit.Enabled = true;
                //tsmiEdit.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                //tsmiEdit.Enabled = false;
            }
            //判断”审核“按钮是否可用
            if (listFiles.Contains(auditStr) || listFiles.Contains(draftStr) || listFiles.Contains(noAuditStr) || listFiles.Contains(invalid))
            {
                btnVerify.Enabled = false;
                //tsmiVerify.Enabled = false;
            }
            else
            {
                btnVerify.Enabled = true;
                //tsmiVerify.Enabled = true;
            }
            //包含已审核、已提交、已作废状态，提交、删除按钮不可用
            if (listFiles.Contains(auditStr) || listFiles.Contains(submitStr) || listFiles.Contains(invalid))
            {
                btnSubmit.Enabled = false;
                btnDelete.Enabled = false;
                //tsmiSubmit.Enabled = false;
                //tsmiDelete.Enabled = false;
            }
            else
            {
                btnSubmit.Enabled = true;
                btnDelete.Enabled = true;
                //tsmiSubmit.Enabled = true;
                //tsmiDelete.Enabled = true;
            }

            if (listFiles.Contains(invalid))
            {

            }
        }
    }
}
