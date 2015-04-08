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

namespace HXCPcClient.UCForm.RepairBusiness.FetchMaterialReturn
{
    /// <summary>
    /// 维修管理-领料退货单预览
    /// Author：JC
    /// AddTime：2014.10.29
    /// </summary>
    public partial class UCFMaterialReturnView : UCBase
    {
        #region 属性设置
        /// <summary>
        /// 领料退货单的Id值
        /// </summary>
        string strReturnId = string.Empty;
        /// <summary>
        /// 领料退货单的详情Id值
        /// </summary>
        string strDReturnId = string.Empty;
        /// <summary>
        /// 父窗体
        /// </summary>
        public UCFMaterialReturnManager uc;
        /// <summary>
        /// 审核窗体
        /// </summary>
        UCVerify verify;
        /// <summary>
        /// 单据状态
        /// </summary>
        string strStatus = string.Empty;
        /// <summary>
        /// 退料时间
        /// </summary>
        string strFetchTime = string.Empty;
        #endregion

        #region 初始化窗体
        public UCFMaterialReturnView(string strId,string strDId)
        {
            InitializeComponent();
            strReturnId= strId;
            strDReturnId = strDId;
            SetTopbuttonShow();
            base.EditEvent += new ClickHandler(UCFMaterialReturnView_EditEvent);
            base.DeleteEvent += new ClickHandler(UCFMaterialReturnView_DeleteEvent);
            base.VerifyEvent += new ClickHandler(UCFMaterialReturnView_VerifyEvent);
            base.SubmitEvent += new ClickHandler(UCFMaterialReturnView_SubmitEvent);
            base.CopyEvent += new ClickHandler(UCFMaterialReturnView_CopyEvent);
            base.InvalidOrActivationEvent += new ClickHandler(UCFMaterialReturnView_InvalidOrActivationEvent);
        }
        #endregion


        #region 作废激活事件
        void UCFMaterialReturnView_InvalidOrActivationEvent(object sender, EventArgs e)
        {
            string strmsg = string.Empty;
            List<SQLObj> listSql = new List<SQLObj>();
            SQLObj obj = new SQLObj();
            obj.cmdType = CommandType.Text;
            Dictionary<string, ParamObj> dicParam = new Dictionary<string, ParamObj>();
            dicParam.Add("refund_id", new ParamObj("refund_id", strReturnId, SysDbType.VarChar, 40));//单据ID
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
                DataTable dvt = DBHelper.GetTable("获得前一个状态", "tb_maintain_refund_material_BackUp", "info_status", "refund_id='" + strReturnId + "'", "", "order by update_time desc");
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
            obj.sqlString = "update tb_maintain_refund_material set info_status=@info_status,update_by=@update_by,update_name=@update_name,update_time=@update_time where refund_id=@refund_id";
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
                deleteMenuByTag(this.Tag.ToString(), uc.Name);
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
            base.btnAdd.Visible = false;           
            base.btnSave.Visible = false;
            base.btnCancel.Visible = false;
            base.btnImport.Visible = false;
            base.btnSync.Visible = false;
            base.btnConfirm.Visible = false;
            base.btnStatus.Visible = false;
            base.btnCopy.Visible = false;
        }
        #endregion

        #region 复制事件
        void UCFMaterialReturnView_CopyEvent(object sender, EventArgs e)
        {
            UCFMaterialReturnAddOrEdit MaterialCopy = new UCFMaterialReturnAddOrEdit();
            MaterialCopy.wStatus = WindowStatus.Copy;
            MaterialCopy.uc = uc;
            MaterialCopy.strId = strReturnId;
            MaterialCopy.strDId = strReturnId;
            base.addUserControl(MaterialCopy, "领料退货单-复制", "MaterialCopy" + MaterialCopy.strId, this.Tag.ToString(), this.Name);
            deleteMenuByTag(this.Tag.ToString(), MaterialCopy.Name);
        }
        #endregion

        #region 提交事件
        void UCFMaterialReturnView_SubmitEvent(object sender, EventArgs e)
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
                labMaterialNoS.Text = CommonUtility.GetNewNo(SYSModel.DataSources.EnumProjectType.ReturnMaterialNo);
            }
            dicParam.Add("refund_no", new ParamObj("refund_no", labMaterialNoS.Text, SysDbType.VarChar, 40));//单据编号                   
            dicParam.Add("refund_id", new ParamObj("refund_id", strReturnId, SysDbType.VarChar, 40));//单据ID
            dicParam.Add("info_status", new ParamObj("info_status", DataSources.EnumAuditStatus.SUBMIT, SysDbType.VarChar, 40));//单据状态
            dicParam.Add("update_by", new ParamObj("update_by", HXCPcClient.GlobalStaticObj.UserID, SysDbType.VarChar, 40));//修改人Id
            dicParam.Add("update_name", new ParamObj("update_name", HXCPcClient.GlobalStaticObj.UserName, SysDbType.VarChar, 40));//修改人姓名
            dicParam.Add("update_time", new ParamObj("update_time", Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString(), SysDbType.BigInt));//修改时间               
            obj.sqlString = "update tb_maintain_refund_material set info_status=@info_status,refund_no=@refund_no,update_by=@update_by,update_name=@update_name,update_time=@update_time where refund_id=@refund_id";
            obj.Param = dicParam;
            listSql.Add(obj);
            if (DBHelper.BatchExeSQLMultiByTrans("更新单据状态为提交", listSql))
            {
                MessageBoxEx.Show("提交成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uc.BindPageData();
                deleteMenuByTag(this.Tag.ToString(), uc.Name);
            }
        }
        #endregion

        #region 审核事件
        void UCFMaterialReturnView_VerifyEvent(object sender, EventArgs e)
        {
            //if (MessageBoxEx.Show("确认要审核吗?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //{
            //    return;
            //}
            Dictionary<string, long> OrderIDDateDic = new Dictionary<string, long>();//获取需要核实的记录行
            verify = new UCVerify();
            if (verify.ShowDialog() == DialogResult.OK)
            {
                List<SQLObj> listSql = new List<SQLObj>();
                SQLObj obj = new SQLObj();
                obj.cmdType = CommandType.Text;
                Dictionary<string, ParamObj> dicParam = new Dictionary<string, ParamObj>();
                dicParam.Add("refund_id", new ParamObj("refund_id", strReturnId, SysDbType.VarChar, 40));//单据ID
                dicParam.Add("info_status", new ParamObj("info_status", verify.auditStatus, SysDbType.VarChar, 40));//单据状态
                dicParam.Add("Verify_advice", new ParamObj("Verify_advice", verify.Content, SysDbType.VarChar, 200));//审核意见
                dicParam.Add("update_by", new ParamObj("update_by", HXCPcClient.GlobalStaticObj.UserID, SysDbType.VarChar, 40));//修改人Id
                dicParam.Add("update_name", new ParamObj("update_name", HXCPcClient.GlobalStaticObj.UserName, SysDbType.VarChar, 40));//修改人姓名
                dicParam.Add("update_time", new ParamObj("update_time", Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString(), SysDbType.BigInt));//修改时间               
                obj.sqlString = "update tb_maintain_refund_material set info_status=@info_status,Verify_advice=@Verify_advice,update_by=@update_by,update_name=@update_name,update_time=@update_time where refund_id=@refund_id";
                obj.Param = dicParam;
                listSql.Add(obj);
                long OrdeDate = (long)Convert.ToInt64(strFetchTime);
                OrderIDDateDic.Add(strReturnId, OrdeDate);//添加已审核单据主键ID和单据日期键值对
                if (DBHelper.BatchExeSQLMultiByTrans("更新单据状态为审核", listSql))
                {
                    string strMsg = string.Empty;
                    if (verify.auditStatus == DataSources.EnumAuditStatus.AUDIT)
                    {
                        strMsg = "成功";
                        CommonFuncCall.StatisticStock(GetInoutPart(OrderIDDateDic), "领料退货单明细数据表");//同步更新实际库存
                    }
                    else
                    {
                        strMsg = "不通过";
                    }
                    MessageBoxEx.Show("审核" + strMsg + "！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uc.BindPageData();
                    deleteMenuByTag(this.Tag.ToString(), uc.Name);
                }
            } 
        }
        #endregion

        #region 添加库存
        /// <summary>
        /// 添加库存
        /// </summary>
        /// <param name="OrderIDDateDic"></param>
        /// <returns></returns>
        private DataTable GetInoutPart(Dictionary<string, long> OrderIDDateDic)
        {
            try
            {
                DataTable TemplateTable = null;//模版表
                foreach (KeyValuePair<string, long> KVPair in OrderIDDateDic)
                {
                    string strFileds = " a.warehouse,c.wh_name,b.parts_id,a.parts_code,a.parts_name,a.norms,b.parts_barcode,b.car_parts_code,a.drawn_no,a.unit,a.retreat_num,a.refund_id  ";//所查询的字段
                    string RelationTable = "tb_maintain_refund_material_detai a left join tb_parts b on a.parts_code=b.ser_parts_code left join tb_warehouse c on a.warehouse=c.wh_id";//要查询的关联表名
                    TemplateTable = CommonFuncCall.CreatePartStatisticTable();//获取要填充的公用表
                    //获取对应单据的
                    DataTable IOPartTable = DBHelper.GetTable("领料退料数据明细", RelationTable, strFileds, "refund_id='" + KVPair.Key.ToString() + "'", "", "");
                    for (int i = 0; i < IOPartTable.Rows.Count; i++)
                    {
                        DataRow dr = TemplateTable.NewRow();//创建模版表行项
                        dr["OrderDate"] = KVPair.Value.ToString();//单据日期
                        dr["WareHouseID"] = CommonCtrl.IsNullToString(IOPartTable.Rows[i]["warehouse"]);//仓库ID
                        dr["WareHouseName"] = CommonCtrl.IsNullToString(IOPartTable.Rows[i]["wh_name"]);//仓库名称
                        dr["PartID"] = CommonCtrl.IsNullToString(IOPartTable.Rows[i]["parts_id"]);//配件ID
                        dr["PartCode"] = IOPartTable.Rows[i]["parts_code"].ToString();//配件编码
                        dr["PartName"] = IOPartTable.Rows[i]["parts_name"].ToString();//配件名称
                        dr["PartSpec"] = IOPartTable.Rows[i]["norms"].ToString();//配件规格
                        dr["PartBarCode"] = IOPartTable.Rows[i]["parts_barcode"].ToString();//配件条码
                        dr["CarPartsCode"] = IOPartTable.Rows[i]["car_parts_code"].ToString();//车厂编码
                        dr["DrawNum"] = IOPartTable.Rows[i]["drawn_no"].ToString();//配件图号
                        dr["UnitName"] = IOPartTable.Rows[i]["unit"].ToString();//单位名称
                        dr["PartCount"] = !string.IsNullOrEmpty(CommonCtrl.IsNullToString(IOPartTable.Rows[i]["retreat_num"])) ? Math.Abs(Convert.ToDecimal(IOPartTable.Rows[i]["retreat_num"].ToString())).ToString() : "0";//配件数量
                        dr["StatisticType"] = (int)DataSources.EnumStatisticType.PaperCount;//统计类型
                        TemplateTable.Rows.Add(dr);//添加新的数据行项
                    }
                }
                return TemplateTable;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "异常提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return null;
            }

        }
        #endregion

        #region 删除事件
        void UCFMaterialReturnView_DeleteEvent(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("确认要删除吗?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            List<SQLObj> listSql = new List<SQLObj>();
            List<string> listField = new List<string>();
            listField.Add(strReturnId);
            Dictionary<string, string> comField = new Dictionary<string, string>();
            comField.Add("enable_flag", Convert.ToInt32(DataSources.EnumEnableFlag.DELETED).ToString());
            comField.Add("update_by", HXCPcClient.GlobalStaticObj.UserID);//修改人Id
            comField.Add("update_name", HXCPcClient.GlobalStaticObj.UserName);//修改人姓名
            comField.Add("update_time", Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString());//修改时间  
            bool flag = DBHelper.BatchUpdateDataByIn("删除领料退货单", "tb_maintain_refund_material", comField, "refund_id", listField.ToArray());
            if (flag)
            {
                MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uc.BindPageData();
                deleteMenuByTag(this.Tag.ToString(), uc.Name);
            }
            else
            {
                MessageBoxEx.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 编辑事件
        void UCFMaterialReturnView_EditEvent(object sender, EventArgs e)
        {
            UCFMaterialReturnAddOrEdit MaterialEdit = new UCFMaterialReturnAddOrEdit();
            MaterialEdit.wStatus = WindowStatus.Edit;
            MaterialEdit.uc = uc;
            MaterialEdit.strId = strReturnId;
            MaterialEdit.strDId = strReturnId;
            base.addUserControl(MaterialEdit, "领料退货单-编辑", "MaterialEdit" + MaterialEdit.strId, this.Tag.ToString(), this.Name);
            deleteMenuByTag(this.Tag.ToString(), MaterialEdit.Name);
        }
        #endregion

        #region 根据领料单Id获取相应的详细信息
        /// <summary>
        /// 根据领料单Id获取相应的详细信息
        /// </summary>
        /// <param name="strRId">领料单Id值</param>
        /// <param name="strRId">领料单详情Id值</param>
        private void GetRescueData(string strRId,string strDRId)
        {
            #region 基本信息
            //SetBtnStatus(WindowStatus.View);
            DataTable dt = DBHelper.GetTable("领料退货单预览", "tb_maintain_refund_material", "*", string.Format(" refund_id='{0}'", strRId), "", "");
            if (dt.Rows.Count > 0)
            {
                #region 维修表信息
                DataRow dr = dt.Rows[0];
                if (!string.IsNullOrEmpty(CommonCtrl.IsNullToString(dr["refund_no"])))
                {
                    labMaterialNoS.Text = CommonCtrl.IsNullToString(dr["refund_no"]);//退料单号  
                }
                else
                {
                    labMaterialNoS.Text = string.Empty;
                }        
               
                 strFetchTime = CommonCtrl.IsNullToString(dr["refund_time"]); //退料时间
                if (!string.IsNullOrEmpty(strFetchTime))
                {
                    labFetchTimeS.Text = Common.UtcLongToLocalDateTime(Convert.ToInt64(strFetchTime)).ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    labFetchTimeS.Text = string.Empty;
                }
                labCustomNOS.Text = CommonCtrl.IsNullToString(dr["customer_code"]);//客户编码
                labCustomNameS.Text = CommonCtrl.IsNullToString(dr["customer_name"]);//客户名称
                labContactS.Text = CommonCtrl.IsNullToString(dr["linkman"]);//联系人
                labContactPhoneS.Text = CommonCtrl.IsNullToString(dr["link_man_mobile"]);//联系人电话
                labCarNOS.Text = CommonCtrl.IsNullToString(dr["vehicle_no"]);//车牌号
                labCarTypeS.Text = GetVmodel(CommonCtrl.IsNullToString(dr["vehicle_model"]));//车型               
                labStatusS.Text = DataSources.GetDescription(typeof(DataSources.EnumAuditStatus), int.Parse(CommonCtrl.IsNullToString(dr["info_status"])));//单据状态              
                labDepartS.Text = GetDepartmentName(CommonCtrl.IsNullToString(dr["org_id"]));//部门
                labAttnS.Text = GetSetJBName(CommonCtrl.IsNullToString(dr["responsible_opid"]));//经办人
                labCreatePersonS.Text = CommonCtrl.IsNullToString(dr["create_name"]);//创建人
                labFetchOpidS.Text = GetSetName(CommonCtrl.IsNullToString(dr["fetch_opid"]));//退料人
                labRemarkS.Text = CommonCtrl.IsNullToString(dr["remarks"]);//备注
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
                #endregion
            #endregion

            #region 领料信息
                DataTable dlt = DBHelper.GetTable("领料数据", "tb_maintain_refund_material_detai", "*", string.Format(" refund_id='{0}'", strRId), "", "");
                if (dlt.Rows.Count > 0)
                {
                    if (dlt.Rows.Count > dgvMaterials.Rows.Count)
                    {
                        dgvMaterials.Rows.Add(dlt.Rows.Count - dgvMaterials.Rows.Count + 1);
                    }
                    for (int i = 0; i < dlt.Rows.Count; i++)
                    {
                        DataRow dor = dlt.Rows[i];
                        dgvMaterials.Rows[i].Cells["parts_code"].Value = CommonCtrl.IsNullToString(dor["parts_code"]);
                        dgvMaterials.Rows[i].Cells["parts_name"].Value = CommonCtrl.IsNullToString(dor["parts_name"]);
                        dgvMaterials.Rows[i].Cells["unit"].Value = CommonCtrl.IsNullToString(dor["unit"]);
                        dgvMaterials.Rows[i].Cells["quantity"].Value = ControlsConfig.SetNewValue(CommonCtrl.IsNullToString(dor["retreat_num"]), 1);
                        dgvMaterials.Rows[i].Cells["warehouse"].Value = GetWarehouseName(CommonCtrl.IsNullToString(dor["warehouse"]));
                        dgvMaterials.Rows[i].Cells["whether_imported"].Value = CommonCtrl.IsNullToString(dor["whether_imported"]) == "1" ? "是" : "否";
                        dgvMaterials.Rows[i].Cells["drawn_no"].Value = CommonCtrl.IsNullToString(dor["drawn_no"]);
                        dgvMaterials.Rows[i].Cells["vehicle_brand"].Value = CommonCtrl.IsNullToString(dor["vehicle_brand"]);                      
                        dgvMaterials.Rows[i].Cells["Mremarks"].Value = CommonCtrl.IsNullToString(dor["remarks"]);
                        dgvMaterials.Rows[i].Cells["material_id"].Value = CommonCtrl.IsNullToString(dor["material_id"]);
                    }
                }
                #endregion
            }
            else
            {
                #region 没有数据时全部显示为空
                labAttnS.Text = string.Empty;
                labCarNOS.Text = string.Empty;
                labCarTypeS.Text = string.Empty;
                labContactPhoneS.Text = string.Empty;
                labContactS.Text = string.Empty;
                labCreatePersonS.Text = string.Empty;
                labCreateTimeS.Text = string.Empty;
                labCustomNameS.Text = string.Empty;
                labCustomNOS.Text = string.Empty;
                labDepartS.Text = string.Empty;
                labFinallyPerS.Text = string.Empty;
                labFinallyTimeS.Text = string.Empty;
                labStatusS.Text = string.Empty;
                labRemarkS.Text = string.Empty;
                #endregion
            }
        }
        #endregion

        #region 获取车型名称
        private string GetVmodel(string strVId)
        {
            return DBHelper.GetSingleValue("获得车型名称", "tb_vehicle_models", "vm_name", "vm_id='" + strVId + "'", "");
        }
        #endregion

        #region 根据码表ID获取其对应的名称
        /// <summary>
        /// 根据码表ID获取其对应的名称
        /// </summary>
        /// <param name="strId">码表Id值</param>
        private string GetDicName(string strId)
        {
            return DBHelper.GetSingleValue("获取码表值", "sys_dictionaries", "dic_name", "dic_id='" + strId + "'", "");
        }
        #endregion

        #region 获得退料人名称
        private string GetSetName(string strPid)
        {
            return DBHelper.GetSingleValue("获得退料人名称", "sys_user", "user_name", "user_id='" + strPid + "'", "");
        }
        #endregion

        #region 获取部门名称
        private string GetDepartmentName(string strDId)
        {
            return DBHelper.GetSingleValue("获得部门名称", "tb_organization", "org_name", "org_id='" + strDId + "'", "");
        }
        #endregion

        #region 获得经办人名称
        private string GetSetJBName(string strPid)
        {
            return DBHelper.GetSingleValue("获得人员名称", "sys_user", "user_name", "user_id='" + strPid + "'", "");
        }
        #endregion

        #region 窗体Load事件
        private void UCFMaterialReturnView_Load(object sender, EventArgs e)
        {
            GetRescueData(strReturnId, strDReturnId);
        }
        #endregion

        #region 重写单据仓库、货位等值
        private void dgvMaterials_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            string fieldNmae = dgvMaterials.Columns[e.ColumnIndex].DataPropertyName;
            if (fieldNmae.Equals("warehouse"))
            {
                e.Value = GetWarehouseName(e.Value.ToString());
            }
        }
        #endregion

        #region 根据仓库Id获取仓库名称
        private string GetWarehouseName(string strWId)
        {
            return DBHelper.GetSingleValue("获取仓库名称", "tb_warehouse", "wh_name", "wh_id='" + strWId + "'", "");
        }
        #endregion
    }
}
