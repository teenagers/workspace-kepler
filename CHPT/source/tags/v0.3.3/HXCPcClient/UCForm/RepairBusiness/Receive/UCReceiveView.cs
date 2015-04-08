﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HXCPcClient.CommonClass;
using Utility.Common;
using SYSModel;
using ServiceStationClient.ComponentUI;

namespace HXCPcClient.UCForm.RepairBusiness.Receive
{
    /// <summary>
    /// 维修管理-维修接待预览
    /// Author：JC
    /// AddTime：2014.10.08
    /// </summary>
    public partial class UCReceiveView : UCBase
    {
        #region 属性设置
        /// <summary>
        /// 维修接待单的Id值
        /// </summary>
        string strReceiveId = string.Empty;
        /// <summary>
        /// 父窗体
        /// </summary>
        public UCReceiveManager uc;
        /// <summary>
        /// 审核窗体
        /// </summary>
        UCVerify verify;
        /// <summary>
        /// 前置单据Id
        /// </summary>
        public string strBeforOrderId = string.Empty;
        /// <summary>
        /// 前置单据来源
        /// </summary>
        public string strBeforSource = string.Empty;
        /// <summary>
        /// 单据状态
        /// </summary>
        string strStatus = string.Empty;
        #endregion

        #region 初始化
        public UCReceiveView(string ReceiveId)
        {
            InitializeComponent();
            strReceiveId = ReceiveId;
            SetDgvAnchor();
            SetTopbuttonShow();
            base.SubmitEvent += new ClickHandler(UCReceiveView_SubmitEvent);
            base.VerifyEvent += new ClickHandler(UCReceiveView_VerifyEvent);
            base.DeleteEvent += new ClickHandler(UCReceiveView_DeleteEvent);           
            base.EditEvent += new ClickHandler(UCReceiveView_EditEvent);
            base.CopyEvent += new ClickHandler(UCReceiveView_CopyEvent);
            base.AddEvent += new ClickHandler(UCReceiveView_AddEvent);
            base.InvalidOrActivationEvent += new ClickHandler(UCReceiveView_InvalidOrActivationEvent);
        }      
        #endregion

        #region 作废激活事件
        void UCReceiveView_InvalidOrActivationEvent(object sender, EventArgs e)
        {
            string strmsg = string.Empty;
            List<SQLObj> listSql = new List<SQLObj>();
            SQLObj obj = new SQLObj();
            obj.cmdType = CommandType.Text;
            Dictionary<string, ParamObj> dicParam = new Dictionary<string, ParamObj>();
            dicParam.Add("maintain_id", new ParamObj("maintain_id", strReceiveId, SysDbType.VarChar, 40));//单据ID
            dicParam.Add("update_by", new ParamObj("update_by", HXCPcClient.GlobalStaticObj.UserID, SysDbType.VarChar, 40));//修改人Id
            dicParam.Add("update_name", new ParamObj("update_name", HXCPcClient.GlobalStaticObj.UserName, SysDbType.VarChar, 40));//修改人姓名
            dicParam.Add("update_time", new ParamObj("update_time", Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString(), SysDbType.BigInt));//修改时间               
            if (strStatus != Convert.ToInt32(DataSources.EnumAuditStatus.Invalid).ToString())
            {
                strmsg = "作废";
                dicParam.Add("info_status", new ParamObj("info_status", DataSources.EnumAuditStatus.Invalid, SysDbType.VarChar, 40));//单据状态
            }
            else
            {
                strmsg = "激活";
                string OnStatus = "";
                DataTable dvt = DBHelper.GetTable("获得前一个状态", "tb_maintain_info_BackUp", "info_status", "maintain_id='" + strReceiveId + "'", "", "order by update_time desc");
                if (dvt.Rows.Count > 0)
                {
                    DataRow dr = dvt.Rows[0];
                    OnStatus = CommonCtrl.IsNullToString(dr["info_status"]);
                    if (OnStatus == Convert.ToInt32(DataSources.EnumAuditStatus.Invalid).ToString())
                    {
                        DataRow dr1 = dvt.Rows[1];
                        OnStatus = CommonCtrl.IsNullToString(dr1["info_status"]);
                    }

                }
                OnStatus = !string.IsNullOrEmpty(OnStatus) ? OnStatus : Convert.ToInt32(DataSources.EnumAuditStatus.DRAFT).ToString();
                dicParam.Add("info_status", new ParamObj("info_status", OnStatus, SysDbType.VarChar, 40));//单据状态
            }
            obj.sqlString = "update tb_maintain_info set info_status=@info_status,update_by=@update_by,update_name=@update_name,update_time=@update_time where maintain_id=@maintain_id";
            obj.Param = dicParam;
            listSql.Add(obj);
            if (MessageBoxEx.Show("确认要" + strmsg + "吗?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            if (DBHelper.BatchExeSQLMultiByTrans("更新单据状态为" + strmsg + "", listSql))
            {
                MessageBoxEx.Show("" + strmsg + "成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uc.BindPageData();
                deleteMenuByTag(this.Tag.ToString(), "UCReceiveView");
            }
            else
            {
                MessageBoxEx.Show("" + strmsg + "失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 顶部button显示设置
        /// <summary>
        ///  顶部button显示设置
        /// </summary>
        private void SetTopbuttonShow()
        {
            base.btnSave.Visible = false;
            base.btnCancel.Visible = false;
            base.btnImport.Visible = false;
            base.btnSync.Visible = false;
            base.btnConfirm.Visible = false;
            base.btnStatus.Visible = false;            
        }
        #endregion

        #region 新增事件
        void UCReceiveView_AddEvent(object sender, EventArgs e)
        {
            UCReceiveAddOrEdit ReceiveAdd = new UCReceiveAddOrEdit();
            ReceiveAdd.wStatus = WindowStatus.Add;
            ReceiveAdd.uc = uc;
            base.addUserControl(ReceiveAdd, "维修接待-新增", "UCReceiveAdd", this.Tag.ToString(), this.Name);
            deleteMenuByTag(this.Tag.ToString(), "UCReceiveView");
        }
        #endregion

        #region 复制事件
        void UCReceiveView_CopyEvent(object sender, EventArgs e)
        {
            UCReceiveAddOrEdit ReceiveCopy = new UCReceiveAddOrEdit();
            ReceiveCopy.wStatus = WindowStatus.Copy;
            ReceiveCopy.uc = uc;
            ReceiveCopy.strId = strReceiveId;  //复制单据的Id值
            base.addUserControl(ReceiveCopy, "维修接待-复制", "ReceiveCopy" + ReceiveCopy.strId, this.Tag.ToString(), this.Name);
            deleteMenuByTag(this.Tag.ToString(), "UCReceiveView");
        }
        #endregion

        #region 编辑事件
        void UCReceiveView_EditEvent(object sender, EventArgs e)
        {
            UCReceiveAddOrEdit ReceiveEdit = new UCReceiveAddOrEdit();
            ReceiveEdit.wStatus = WindowStatus.Edit;
            ReceiveEdit.uc = uc;
            ReceiveEdit.strId = strReceiveId;  //编辑单据的Id值
            base.addUserControl(ReceiveEdit, "维修接待-编辑", "ReceiveEdit" + ReceiveEdit.strId, this.Tag.ToString(), this.Name);
            deleteMenuByTag(this.Tag.ToString(), "UCReceiveView");
        }
        #endregion     

        #region 删除事件
        void UCReceiveView_DeleteEvent(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("确认要删除吗?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            List<SQLObj> listSql = new List<SQLObj>();
            List<string> listField = new List<string>();
            listField.Add(strReceiveId);
            Dictionary<string, string> comField = new Dictionary<string, string>();
            comField.Add("enable_flag", Convert.ToInt32(DataSources.EnumEnableFlag.DELETED).ToString());
            comField.Add("update_by", HXCPcClient.GlobalStaticObj.UserID);//修改人Id
            comField.Add("update_name",HXCPcClient.GlobalStaticObj.UserName);//修改人姓名
            comField.Add("update_time",Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString());//修改时间               
            UpdateMaintainInfo(listSql, strBeforOrderId, strBeforSource, "1");
            bool flag = DBHelper.BatchUpdateDataByIn("删除维修接待单", "tb_maintain_info", comField, "maintain_id", listField.ToArray());
            if (flag && DBHelper.BatchExeSQLMultiByTrans("更新前置单据状态", listSql))
            {
                MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uc.BindPageData();
                deleteMenuByTag(this.Tag.ToString(), "UCReceiveView");
            }
            else
            {
                MessageBoxEx.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 审核事件
        void UCReceiveView_VerifyEvent(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("确认要审核吗?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            verify = new UCVerify(); 
            if (verify.ShowDialog() == DialogResult.OK)
            {
                List<SQLObj> listSql = new List<SQLObj>();
                SQLObj obj = new SQLObj();
                obj.cmdType = CommandType.Text;
                Dictionary<string, ParamObj> dicParam = new Dictionary<string, ParamObj>();
                dicParam.Add("maintain_id", new ParamObj("maintain_id", strReceiveId, SysDbType.VarChar, 40));//单据ID
                dicParam.Add("info_status", new ParamObj("info_status", verify.auditStatus, SysDbType.VarChar, 40));//单据状态
                dicParam.Add("Verify_advice", new ParamObj("Verify_advice", verify.Content, SysDbType.VarChar, 200));//审核意见
                dicParam.Add("update_by", new ParamObj("update_by", HXCPcClient.GlobalStaticObj.UserID, SysDbType.VarChar, 40));//修改人Id
                dicParam.Add("update_name", new ParamObj("update_name", HXCPcClient.GlobalStaticObj.UserName, SysDbType.VarChar, 40));//修改人姓名
                dicParam.Add("update_time", new ParamObj("update_time", Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString(), SysDbType.BigInt));//修改时间               
                obj.sqlString = "update tb_maintain_info set info_status=@info_status,Verify_advice=@Verify_advice,update_by=@update_by,update_name=@update_name,update_time=@update_time where maintain_id=@maintain_id";
                obj.Param = dicParam;
                listSql.Add(obj);
                UpdateMaintainInfo(listSql, strBeforOrderId, strBeforSource, "0");
                if (DBHelper.BatchExeSQLMultiByTrans("更新单据状态为审核", listSql))
                {
                    string strMsg = string.Empty;
                    if (verify.auditStatus == DataSources.EnumAuditStatus.AUDIT)
                    {
                        strMsg = "成功";
                    }
                    else
                    {
                        strMsg = "不通过";
                    }
                    MessageBoxEx.Show("审核" + strMsg + "！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
                    uc.BindPageData();
                    deleteMenuByTag(this.Tag.ToString(), "UCReceiveView");
                }
            }
        }
       
        #endregion

        #region 提交事件
        void UCReceiveView_SubmitEvent(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("确认要提交吗?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            List<SQLObj> listSql = new List<SQLObj>();           
            SQLObj obj = new SQLObj();
            obj.cmdType = CommandType.Text;
            Dictionary<string, ParamObj> dicParam = new Dictionary<string, ParamObj>();
            if (strStatus == Convert.ToInt32(DataSources.EnumAuditStatus.DRAFT).ToString())
            {
                labMaintain_noS.Text = CommonUtility.GetNewNo(SYSModel.DataSources.EnumProjectType.Repair);
            }
            dicParam.Add("maintain_no", new ParamObj("maintain_no", labMaintain_noS.Text, SysDbType.VarChar, 40));//单据编号                   
            dicParam.Add("maintain_id", new ParamObj("maintain_id", strReceiveId, SysDbType.VarChar, 40));//单据ID
            dicParam.Add("info_status", new ParamObj("info_status", DataSources.EnumAuditStatus.SUBMIT, SysDbType.VarChar, 40));//单据状态
            dicParam.Add("update_by", new ParamObj("update_by", HXCPcClient.GlobalStaticObj.UserID, SysDbType.VarChar, 40));//修改人Id
            dicParam.Add("update_name", new ParamObj("update_name", HXCPcClient.GlobalStaticObj.UserName, SysDbType.VarChar, 40));//修改人姓名
            dicParam.Add("update_time", new ParamObj("update_time", Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString(), SysDbType.BigInt));//修改时间               
            obj.sqlString = "update tb_maintain_info set info_status=@info_status,maintain_no=@maintain_no,update_by=@update_by,update_name=@update_name,update_time=@update_time where maintain_id=@maintain_id";
            obj.Param = dicParam;
            listSql.Add(obj);
            UpdateMaintainInfo(listSql, strBeforOrderId, strBeforSource, "0");
            if (DBHelper.BatchExeSQLMultiByTrans("更新单据状态为提交", listSql))
            {
                MessageBoxEx.Show("提交成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
               uc.BindPageData();
               deleteMenuByTag(this.Tag.ToString(), "UCReceiveView");
            }
        }
        #endregion

        #region 提交、审核时如果为前置单据则更新前置单据的状态
        /// <summary>
        /// 提交、审核时如果为前置单据则更新前置单据的状态
        /// </summary>
        /// <param name="strReservId">预约单Id</param>
        /// <param name="status">操作状态，0提交、审核，1删除</param>
        private void UpdateMaintainInfo(List<SQLObj> listSql, string strReservId,string strSource, string status)
        {
            if (!string.IsNullOrEmpty(strReservId) && !string.IsNullOrEmpty(strReservId))
            {
                SQLObj obj = new SQLObj();
                obj.cmdType = CommandType.Text;
                Dictionary<string, ParamObj> dicParam = new Dictionary<string, ParamObj>();
                if (strSource == "1")//预约单
                {
                    dicParam.Add("update_by", new ParamObj("update_by", HXCPcClient.GlobalStaticObj.UserID, SysDbType.VarChar, 40));//修改人Id
                    dicParam.Add("update_name", new ParamObj("update_name", HXCPcClient.GlobalStaticObj.UserName, SysDbType.VarChar, 40));//修改人姓名
                    dicParam.Add("update_time", new ParamObj("update_time", Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString(), SysDbType.BigInt));//修改时间               
                    if (status == "0")
                    {
                        //审核提交时，前置单据被锁定并添加维修单号        
                        dicParam.Add("reserv_id", new ParamObj("reserv_id", strReservId, SysDbType.VarChar, 40));
                        dicParam.Add("Import_status", new ParamObj("Import_status", "2", SysDbType.VarChar, 40));//锁定                       
                        obj.sqlString = "update tb_maintain_reservation set Import_status=@Import_status,update_by=@update_by,update_name=@update_name,update_time=@update_time where reserv_id=@reserv_id";
                    }
                    else if (status == "1")
                    {
                        //删除时，前置单据中的维修编号置空、前置状体置为开放0
                        dicParam.Add("reserv_id", new ParamObj("reserv_id", strReservId, SysDbType.VarChar, 40));
                        dicParam.Add("maintain_no", new ParamObj("maintain_no", null, SysDbType.VarChar, 40));
                        dicParam.Add("Import_status", new ParamObj("Import_status", "0", SysDbType.VarChar, 40));//开放
                        obj.sqlString = "update tb_maintain_reservation set maintain_no=@maintain_no,Import_status=@Import_status,update_by=@update_by,update_name=@update_name,update_time=@update_time where reserv_id=@reserv_id";
                    }
                }
                obj.Param = dicParam;
                listSql.Add(obj);
            }
        }
        #endregion      

        #region 根据预约单Id获取相应的详细信息
        /// <summary>
        /// 根据预约单Id获取相应的详细信息
        /// </summary>
        /// <param name="strRId">预约单reserv_id值</param>
        private void GetReservData(string strRId)
        {
                #region 基本信息
            //SetBtnStatus(WindowStatus.View);
            DataTable dt = DBHelper.GetTable("维修接待单预览", "tb_maintain_info", "*", string.Format(" maintain_id='{0}'", strRId), "", "");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (!string.IsNullOrEmpty(CommonCtrl.IsNullToString(dr["maintain_no"])))
                {
                    labMaintain_noS.Text = CommonCtrl.IsNullToString(dr["maintain_no"]);//维修单号
                }
                else
                {
                    labMaintain_noS.Text = string.Empty;
                }
                string strReTime = CommonCtrl.IsNullToString(dr["reception_time"]);//接待时间
                if (!string.IsNullOrEmpty(strReTime))
                {
                    labRTimeS.Text = Common.UtcLongToLocalDateTime(Convert.ToInt64(strReTime)).ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    labRTimeS.Text = string.Empty;
                }
                labCustomNOS.Text = CommonCtrl.IsNullToString(dr["customer_code"]);//客户编码
                labCustomNameS.Text = CommonCtrl.IsNullToString(dr["customer_name"]);//客户名称
                labContactS.Text = CommonCtrl.IsNullToString(dr["linkman"]);//联系人
                labContactPhoneS.Text = CommonCtrl.IsNullToString(dr["link_man_mobile"]);//联系人电话
                labCarNOS.Text = CommonCtrl.IsNullToString(dr["vehicle_no"]);//车牌号
                labCarTypeS.Text =GetDicName(CommonCtrl.IsNullToString(dr["vehicle_model"]));//车型
                labCarBrandS.Text =GetDicName( CommonCtrl.IsNullToString(dr["vehicle_brand"]));//车辆品牌
                labVINS.Text = CommonCtrl.IsNullToString(dr["vehicle_vin"]);//VIN
                labEngineNoS.Text = CommonCtrl.IsNullToString(dr["engine_no"]);//发动机号
                labColorS.Text =GetDicName( CommonCtrl.IsNullToString(dr["vehicle_color"]));//颜色
                labDriverS.Text = CommonCtrl.IsNullToString(dr["driver_name"]);//司机
                labDriverPhoneS.Text = CommonCtrl.IsNullToString(dr["driver_mobile"]);//司机手机
                labRepTypeS.Text =GetDicName( CommonCtrl.IsNullToString(dr["maintain_type"]));//维修类别
                labPayTypeS.Text = GetDicName(CommonCtrl.IsNullToString(dr["maintain_payment"]));//维修付费方式
                string strInTime = CommonCtrl.IsNullToString(dr["completion_time"]);//预计完工时间
                if (!string.IsNullOrEmpty(strInTime))
                {
                    labSuTimeS.Text = Common.UtcLongToLocalDateTime(Convert.ToInt64(strInTime)).ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    labSuTimeS.Text = string.Empty;
                }
                labMlS.Text = !String.IsNullOrEmpty(CommonCtrl.IsNullToString(dr["oil_into_factory"]))?CommonCtrl.IsNullToString(dr["oil_into_factory"])+"%":"";//进场油量
                labMilS.Text =!String.IsNullOrEmpty(CommonCtrl.IsNullToString(dr["travel_mileage"]))?CommonCtrl.IsNullToString(dr["travel_mileage"])+"Km":"";//行驶里程
                labDescS.Text = CommonCtrl.IsNullToString(dr["fault_describe"]);//故障描述

                #region 会员信息 
                string strMemnerID = CommonCtrl.IsNullToString(dr["member_id"]);//会员信息Id
                if (!string.IsNullOrEmpty(strMemnerID))
                {
                    DataTable dct = DBHelper.GetTable("获取会员信息", "tb_customer", "member_number,member_class,accessories_discount,workhours_discount", " is_member='1' and cust_id='" + strMemnerID + "'", "", "");
                    labMemberNoS.Text = CommonCtrl.IsNullToString(dr["member_number"]);//会员卡号
                    labMemberGradeS.Text = CommonCtrl.IsNullToString(dr["member_class"]);//会员等级
                    labMemberPZkS.Text = CommonCtrl.IsNullToString(dr["workhours_discount"]);//会员项目折扣
                    labMemberLZkS.Text = CommonCtrl.IsNullToString(dr["accessories_discount"]);//会员用料折扣

                }
                else
                {
                    labMemberNoS.Text = string.Empty;//会员卡号
                    labMemberGradeS.Text = string.Empty;//会员等级
                    labMemberPZkS.Text = string.Empty;//会员项目折扣
                    labMemberLZkS.Text = string.Empty;
                }
                #endregion

                labRemarkS.Text = CommonCtrl.IsNullToString(dr["remark"]);//备注
                labStatusS.Text =DataSources.GetDescription(typeof(DataSources.EnumAuditStatus), int.Parse(CommonCtrl.IsNullToString(dr["info_status"]))) ;//单据状态
                //labMoney.Text = CommonCtrl.IsNullToString(dr["maintain_payment"]);//欠款余额
                labDepartS.Text = GetDepartmentName(CommonCtrl.IsNullToString(dr["org_name"]));//部门
                labAttnS.Text = GetSetName(CommonCtrl.IsNullToString(dr["responsible_name"]));//经办人
                labCreatePersonS.Text = CommonCtrl.IsNullToString(dr["create_name"]);//创建人
                string strCreateTime = CommonCtrl.IsNullToString(dr["create_time"]); //创建时间
                if (!string.IsNullOrEmpty(strCreateTime))
                {
                    labCreateTimeS.Text = Common.UtcLongToLocalDateTime(Convert.ToInt64(strCreateTime)).ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    labCreateTimeS.Text = string.Empty;
                }
                labFinallyPerS.Text = CommonCtrl.IsNullToString(dr["update_name"]);//最后编辑人
                string strFinallyTime = CommonCtrl.IsNullToString(dr["update_time"]); //最后编辑时间
                if (!string.IsNullOrEmpty(strFinallyTime))
                {
                    labFinallyTimeS.Text = Common.UtcLongToLocalDateTime(Convert.ToInt64(strFinallyTime)).ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    labFinallyTimeS.Text = string.Empty;
                }

                 strStatus = CommonCtrl.IsNullToString(dr["info_status"]);//单据状态
                 if (strStatus == Convert.ToInt32(DataSources.EnumAuditStatus.SUBMIT).ToString())
                 {
                     //已提交状态屏蔽提交、编辑、删除按钮
                     base.btnSubmit.Enabled = false;
                     base.btnEdit.Enabled = false;
                     base.btnDelete.Enabled = false;
                     base.btnActivation.Enabled = false;
                 }
                 else if (strStatus == Convert.ToInt32(DataSources.EnumAuditStatus.AUDIT).ToString())
                 {
                     //已审核时屏蔽提交、审核、编辑、删除按钮
                     base.btnSubmit.Enabled = false;
                     base.btnVerify.Enabled = false;
                     base.btnEdit.Enabled = false;
                     base.btnDelete.Enabled = false;
                     base.btnActivation.Enabled = false;
                 }
                 else if (strStatus == Convert.ToInt32(DataSources.EnumAuditStatus.NOTAUDIT).ToString() || strStatus == Convert.ToInt32(DataSources.EnumAuditStatus.DRAFT).ToString())
                 {
                     //审核没通过时屏蔽审核按钮
                     base.btnVerify.Enabled = false;
                 }
                 else if (strStatus == Convert.ToInt32(DataSources.EnumAuditStatus.Invalid).ToString())
                 {
                     base.btnActivation.Caption = "激活";
                     base.btnSubmit.Enabled = false;
                     base.btnVerify.Enabled = false;
                     base.btnEdit.Enabled = false;
                 }
                strBeforOrderId = CommonCtrl.IsNullToString(dr["before_orderId"]);
                strBeforSource = CommonCtrl.IsNullToString(dr["orders_source"]);
            #endregion

                #region 底部datagridview数据

                #region 维修项目数据
                //维修项目数据     
                decimal dcPmoney = 0;
                DataTable dpt = DBHelper.GetTable("维修项目数据", "tb_maintain_item", "*", string.Format(" maintain_id='{0}'", strRId), "", ""); ;
                if (dpt.Rows.Count > 0)
                {
                    if (dpt.Rows.Count > dgvproject.Rows.Count)
                    {
                        dgvproject.Rows.Add(dpt.Rows.Count - dgvproject.Rows.Count + 1);
                    }
                    for (int i = 0; i < dpt.Rows.Count; i++)
                    {
                        DataRow dpr = dpt.Rows[i];
                        dgvproject.Rows[i].Cells["item_id"].Value = CommonCtrl.IsNullToString(dpr["item_id"]);
                        dgvproject.Rows[i].Cells["three_warranty"].Value = CommonCtrl.IsNullToString(dpr["three_warranty"]) == "1" ? "是" : "否";
                        dgvproject.Rows[i].Cells["man_hour_type"].Value = CommonCtrl.IsNullToString(dpr["man_hour_type"]);
                        dgvproject.Rows[i].Cells["item_no"].Value = CommonCtrl.IsNullToString(dpr["item_no"]);
                        dgvproject.Rows[i].Cells["item_name"].Value = CommonCtrl.IsNullToString(dpr["item_name"]);
                        dgvproject.Rows[i].Cells["item_type"].Value = CommonCtrl.IsNullToString(dpr["item_type"]);
                        dgvproject.Rows[i].Cells["man_hour_quantity"].Value = CommonCtrl.IsNullToString(dpr["man_hour_quantity"]);
                        dgvproject.Rows[i].Cells["man_hour_norm_unitprice"].Value = CommonCtrl.IsNullToString(dpr["man_hour_norm_unitprice"]);
                        dgvproject.Rows[i].Cells["remarks"].Value = CommonCtrl.IsNullToString(dpr["remarks"]);
                        dgvproject.Rows[i].Cells["sum_money_goods"].Value = CommonCtrl.IsNullToString(dpr["sum_money_goods"]);
                        dgvproject.Rows[i].Cells["member_discount"].Value = CommonCtrl.IsNullToString(dpr["member_discount"]);
                        dgvproject.Rows[i].Cells["member_price"].Value = CommonCtrl.IsNullToString(dpr["member_price"]);
                        dgvproject.Rows[i].Cells["member_sum_money"].Value = CommonCtrl.IsNullToString(dpr["member_sum_money"]);

                    }                  
                    foreach (DataGridViewRow dgvr in dgvproject.Rows)
                    {
                        dcPmoney += Convert.ToDecimal(!string.IsNullOrEmpty(CommonCtrl.IsNullToString(dgvr.Cells["sum_money_goods"].Value)) ? dgvr.Cells["sum_money_goods"].Value : 0);
                    }
                    labAssessS.Text = dcPmoney.ToString();
                }
                #endregion

                #region 维修用料数据
                //维修用料数据   
                decimal dcMmoney = 0;
                DataTable dmt = DBHelper.GetTable("维修用料数据", "tb_maintain_material_detail", "*", string.Format(" maintain_id='{0}'", strRId), "", "");
                if (dmt.Rows.Count > 0)
                {

                    if (dmt.Rows.Count > dgvMaterials.Rows.Count)
                    {
                        dgvMaterials.Rows.Add(dmt.Rows.Count - dgvMaterials.Rows.Count + 1);
                    }
                    for (int i = 0; i < dmt.Rows.Count; i++)
                    {
                        DataRow dmr = dmt.Rows[i];
                        dgvMaterials.Rows[i].Cells["material_id"].Value = CommonCtrl.IsNullToString(dmr["material_id"]);
                        dgvMaterials.Rows[i].Cells["parts_code"].Value = CommonCtrl.IsNullToString(dmr["parts_code"]);
                        dgvMaterials.Rows[i].Cells["parts_name"].Value = CommonCtrl.IsNullToString(dmr["parts_name"]);
                        dgvMaterials.Rows[i].Cells["norms"].Value = CommonCtrl.IsNullToString(dmr["norms"]);
                        dgvMaterials.Rows[i].Cells["unit"].Value = CommonCtrl.IsNullToString(dmr["unit"]);
                        dgvMaterials.Rows[i].Cells["quantity"].Value = CommonCtrl.IsNullToString(dmr["quantity"]);
                        dgvMaterials.Rows[i].Cells["unit_price"].Value = CommonCtrl.IsNullToString(dmr["unit_price"]);
                        dgvMaterials.Rows[i].Cells["Mmember_discount"].Value = CommonCtrl.IsNullToString(dmr["member_discount"]);
                        dgvMaterials.Rows[i].Cells["Mmember_price"].Value = CommonCtrl.IsNullToString(dmr["member_price"]);
                        dgvMaterials.Rows[i].Cells["sum_money"].Value = CommonCtrl.IsNullToString(dmr["sum_money"]);
                        dgvMaterials.Rows[i].Cells["drawn_no"].Value = CommonCtrl.IsNullToString(dmr["drawn_no"]);
                        dgvMaterials.Rows[i].Cells["vehicle_brand"].Value = CommonCtrl.IsNullToString(dmr["vehicle_brand"]);
                        dgvMaterials.Rows[i].Cells["Mthree_warranty"].Value = CommonCtrl.IsNullToString(dmr["three_warranty"]) == "1" ? "是" : "否";
                        dgvMaterials.Rows[i].Cells["Mremarks"].Value = CommonCtrl.IsNullToString(dmr["remarks"]);
                        dgvMaterials.Rows[i].Cells["whether_imported"].Value = CommonCtrl.IsNullToString(dmr["whether_imported"]) == "1" ? "是" : "否";

                    }                  
                    foreach (DataGridViewRow dgvr in dgvMaterials.Rows)
                    {
                        dcMmoney += Convert.ToDecimal(!string.IsNullOrEmpty(CommonCtrl.IsNullToString(dgvr.Cells["sum_money"].Value)) ? dgvr.Cells["sum_money"].Value : 0);
                    }
                    labLAssessS.Text = dcMmoney.ToString();
                }
                #endregion

                #region 其他项目收费数据
                //其他项目收费数据
                decimal doMmoney = 0;
                DataTable dot = DBHelper.GetTable("其他项目收费数据", "tb_maintain_other_toll", "*", string.Format(" maintain_id='{0}'", strRId), "", "");
                if (dot.Rows.Count > 0)
                {
                    if (dot.Rows.Count > dgvOther.Rows.Count)
                    {
                        dgvOther.Rows.Add(dot.Rows.Count - dgvOther.Rows.Count + 1);
                    }
                    for (int i = 0; i < dot.Rows.Count; i++)
                    {
                        DataRow dor = dot.Rows[i];
                        dgvOther.Rows[i].Cells["toll_id"].Value = CommonCtrl.IsNullToString(dor["toll_id"]);
                        dgvOther.Rows[i].Cells["Osum_money"].Value = CommonCtrl.IsNullToString(dor["sum_money"]);
                        dgvOther.Rows[i].Cells["Oremarks"].Value = CommonCtrl.IsNullToString(dor["remarks"]);
                        dgvOther.Rows[i].Cells["cost_types"].Value = GetDicName(CommonCtrl.IsNullToString(dor["cost_types"]));
                    }                   
                    foreach (DataGridViewRow dgvr in dgvOther.Rows)
                    {
                        doMmoney += Convert.ToDecimal(!string.IsNullOrEmpty(CommonCtrl.IsNullToString(dgvr.Cells["Osum_money"].Value)) ? dgvr.Cells["Osum_money"].Value : 0);
                    }
                    labOAssessS.Text = doMmoney.ToString();
                }
                labTotalS.Text = (dcPmoney + dcMmoney + doMmoney).ToString();
                #endregion

                #region 附件信息数据
                //附件信息数据
                ucAttr.TableName = "tb_maintain_info";
                ucAttr.TableNameKeyValue = strRId;
                ucAttr.BindAttachment();
                #endregion
                #endregion
            }
            else
            {
                #region 没有数据时全部显示为空
                labMaintain_noS.Text = string.Empty;
                labRTimeS.Text = string.Empty;
                labAttnS.Text = string.Empty;
                labCarBrandS.Text = string.Empty;
                labCarNOS.Text = string.Empty;
                labCarTypeS.Text = string.Empty;
                labColorS.Text = string.Empty;
                labContactPhoneS.Text = string.Empty;
                labContactS.Text = string.Empty;
                labCreatePersonS.Text = string.Empty;
                labCreateTimeS.Text = string.Empty;
                labCustomNameS.Text = string.Empty;
                labCustomNOS.Text = string.Empty;
                labDepartS.Text = string.Empty;
                labDescS.Text = string.Empty;
                labDriverPhoneS.Text = string.Empty;
                labDriverS.Text = string.Empty;              
                labEngineNoS.Text = string.Empty;
                labFinallyPerS.Text = string.Empty;
                labFinallyTimeS.Text = string.Empty;
                labPayTypeS.Text = string.Empty;
                labRemarkS.Text = string.Empty;
                labRepTypeS.Text = string.Empty;
                labStatusS.Text = string.Empty;
                labVINS.Text = string.Empty;
                labMlS.Text = string.Empty;
                labMilS.Text = string.Empty;
                labMemberNoS.Text = string.Empty;
                labMemberGradeS.Text = string.Empty;
                labMemberPZkS.Text = string.Empty;
                labMemberLZkS.Text = string.Empty;              
                #endregion
            }
        }
        #endregion

        #region 设置底部DataGridView的Anchor属性
        /// <summary>
        /// 设置底部DataGridView的Anchor属性
        /// </summary>
        private void SetDgvAnchor()
        {           
            dgvMaterials.Dock = DockStyle.Fill;
            //dgvMaterials.Columns["MCheck"].HeaderText = "选择";
            dgvOther.Dock = DockStyle.Fill;
            //dgvOther.Columns["OCheck"].HeaderText = "选择";
            dgvproject.Dock = DockStyle.Fill;
            //dgvproject.Columns["colCheck"].HeaderText = "选择";
        }
        #endregion

        #region 窗体Load事件
        private void UCReceiveView_Load(object sender, EventArgs e)
        {
            GetReservData(strReceiveId);
            ucAttr.ReadOnly = true;
        }
        #endregion

        #region 根据码表ID获取其对应的名称
        /// <summary>
        /// 根据码表ID获取其对应的名称
        /// </summary>
        /// <param name="strId">码表Id值</param>
        private string GetDicName(string strId)
        {
           return DBHelper.GetSingleValue("获取码表值", "sys_dictionaries", "dic_name", "dic_id='"+strId+"'", "");
        }
        #endregion

        #region 获取部门名称
        private string GetDepartmentName(string strDId)
        {
            return DBHelper.GetSingleValue("获得部门名称", "tb_organization", "org_name", "org_id='" + strDId + "'", "");
        }
        #endregion

        #region 获得人员名称
        private string GetSetName(string strPid)
        {
            return DBHelper.GetSingleValue("获得人员名称", "sys_user", "user_name", "user_id='" + strPid + "'", "");
        }
        #endregion
    }
}
