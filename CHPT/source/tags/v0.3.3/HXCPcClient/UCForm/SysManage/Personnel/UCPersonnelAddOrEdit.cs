﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ServiceStationClient.ComponentUI;
using Utility.Common;
using HXCPcClient.CommonClass;
using SYSModel;
using HXCPcClient.Chooser;
using System.IO;
using Model;

namespace HXCPcClient.UCForm.SysManage.Personnel
{
    /// <summary>
    /// 人员管理 编辑复制新增
    /// 孙明生.
    /// 修改人：杨天帅
    /// </summary>
    public partial class UCPersonnelAddOrEdit : UCBase
    {
        #region --回调更新事件
        public delegate void RefreshData();
        public RefreshData RefreshDataStart;
        #endregion

        #region --成员变量
        public string id = string.Empty;
        private string parentName = string.Empty;
        public WindowStatus wStatus;
        private string photoID = string.Empty;//图片附件ID
        private DataRow dr;

        #endregion

        #region --构造函数
        public UCPersonnelAddOrEdit(DataRow dr, string parentName)
        {
            InitializeComponent();
            this.dr = dr;
            this.parentName = parentName;
        }
        #endregion

        #region --窗体加载
        private void UCPersonnelAddOrEdit_Load(object sender, EventArgs e)
        {
            base.SetBtnStatus(wStatus);

            this.InitEvent();

            this.InitData();

            if (wStatus == WindowStatus.Edit || wStatus == WindowStatus.Copy)
            {
                if (this.dr != null)
                {
                    this.BindControls();
                }
                txtland_name.ReadOnly = true;
            }
        }
        #endregion

        #region --初始化事件和数据
        private void InitEvent()
        {
            base.SaveEvent += new ClickHandler(UCPersonnelAddOrEdit_SaveEvent);
            base.CancelEvent += new ClickHandler(UCPersonnelAddOrEdit_CancelEvent);
        }
        private void InitData()
        {
            CommonFuncCall.BindComBoxDataSource(cbojkzk, "sys_health", "请选择");//健康状况
            DataSources.BindComBoxDataEnum(cbois_operator, typeof(DataSources.EnumYesNo), false);//是否操作员
            CommonFuncCall.BindComBoxDataSource(cbonation, "sys_nation", "请选择");//民族
            CommonFuncCall.BindComBoxDataSource(cbosex, "sys_sex", "请选择");//性别
            CommonFuncCall.BindComBoxDataSource(cboidcard_type, "sys_certificates_type", "请选择");//证件类型
            CommonFuncCall.BindComBoxDataSource(cboeducation, "sys_education", "请选择");//学历
            CommonFuncCall.BindComBoxDataSource(cboposition, "sys_post", "请选择");//岗位
            CommonFuncCall.BindComBoxDataSource(cbolevel, "sys_personnel_level", "请选择");//级别
        }
        #endregion

        #region 页面控件绑定数据
        /// <summary>
        /// 页面控件绑定数据
        /// </summary>      
        private void BindControls()
        {
            txtuser_code.Caption = this.dr["user_code"].ToString();
            txtuser_name.Caption = this.dr["user_name"].ToString();
            txtland_name.Caption = this.dr["land_name"].ToString();

            txtuser_phone.Caption = this.dr["user_phone"].ToString();
            txtuser_telephone.Caption = this.dr["user_telephone"].ToString();
            txtremark.Caption = this.dr["remark"].ToString();
            txtcom_name.Caption = this.dr["com_name"].ToString();
            txcorg_name.Text = this.dr["org_name"].ToString();
            txcorg_name.Tag = this.dr["org_id"].ToString();
            txtuser_fax.Caption = this.dr["user_fax"].ToString();
            cbosex.SelectedValue = this.dr["sex"].ToString();
            cbois_operator.SelectedValue = this.dr["is_operator"].ToString();
            cboidcard_type.SelectedValue = this.dr["idcard_type"].ToString();
            txtuser_email.Caption = this.dr["user_email"].ToString();
            txtidcard_num.Caption = this.dr["idcard_num"].ToString();
            txtuser_address.Caption = this.dr["user_address"].ToString();

            cbonation.SelectedValue = this.dr["nation"].ToString();
            txtgraduate_institutions.Caption = this.dr["graduate_institutions"].ToString();
            txttechnical_expertise.Caption = this.dr["technical_expertise"].ToString();
            txtuser_height.Caption = this.dr["user_height"].ToString();
            txtnative_place.Caption = this.dr["native_place"].ToString();
            txtspecialty.Caption = this.dr["specialty"].ToString();
            dtpentry_date.Value = Common.UtcLongToLocalDateTime(Convert.ToInt64(this.dr["entry_date"].ToString()));
            txtuser_weight.Caption = this.dr["user_weight"].ToString();
            txtregister_address.Caption = this.dr["register_address"].ToString();
            dtpgraduate_date.Value = Common.UtcLongToLocalDateTime(Convert.ToInt64(this.dr["graduate_date"].ToString()));
            txtwage.Caption = this.dr["wage"].ToString();
            dtpbirthday.Value = Common.UtcLongToLocalDateTime(Convert.ToInt64(this.dr["birthday"].ToString()));
            cboeducation.SelectedValue = this.dr["education"].ToString();
            cboposition.SelectedValue = this.dr["position"].ToString();
            txtpolitical_status.Caption = this.dr["political_status"].ToString();
            cbolevel.SelectedValue = this.dr["level"].ToString();

            //cbojkzk.SelectedValue = this.dr["jkzk"].ToString();//健康状况 

            DataTable dt_pic = DBHelper.GetTable("查询用户图片", "attachment_info", "*", "relation_object_id='" + id + "' and att_name='用户图片' and att_type='图片'", "", "");
            if (dt_pic != null && dt_pic.Rows.Count > 0)
            {
                string photoPath = CommonCtrl.IsNullToString(dt_pic.Rows[0]["att_path"]);
                photoID = CommonCtrl.IsNullToString(dt_pic.Rows[0]["att_id"]);
                picuser.BackgroundImage = FileOperation.DownLoadImage(photoPath);
            }
            BindAData("sys_user", id);
        }
        /// <summary>
        /// 加载附件信息
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strOrderId"></param>
        private void BindAData(string strTableName, string strOrderId)
        {
            //附件信息数据
            ucAttr.TableName = strTableName;
            ucAttr.TableNameKeyValue = strOrderId;
            ucAttr.BindAttachment();
        }
        #endregion

        #region 取消
        /// <summary>
        /// 取消
        /// </summary>
        void UCPersonnelAddOrEdit_CancelEvent(object sender, EventArgs e)
        {
            deleteMenuByTag(this.Tag.ToString(), this.parentName);
        }
        #endregion

        #region 控件内容验证
        /// <summary>
        /// 控件内容验证
        /// </summary>
        /// <param name="msg">返回提示信息</param>
        /// <returns></returns>
        private bool Validator(ref string msg)
        {
            this.errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtuser_name.Caption.Trim()))
            {
                Utility.Common.Validator.SetError(errorProvider1, txtuser_name, "人员姓名不能为空!");
                return false;
            }
            if (!string.IsNullOrEmpty(txtuser_phone.Caption.Trim()) && !Utility.Common.Validator.IsMobile(txtuser_phone.Caption.Trim()))
            {
                Utility.Common.Validator.SetError(errorProvider1, txtuser_phone, "手机格式不正确!");
                return false;
            }
            if (!string.IsNullOrEmpty(txtuser_telephone.Caption.Trim()) && !Utility.Common.Validator.IsTel(txtuser_telephone.Caption.Trim()))
            {
                Utility.Common.Validator.SetError(errorProvider1, txtuser_telephone, "固话格式不正确!");
                return false;
            }
            if (txcorg_name.Tag == null)// string.IsNullOrEmpty(txcorg_name.Tag.ToString().Trim()))
            {
                Utility.Common.Validator.SetError(errorProvider1, txcorg_name, "请选择公司组织!");
                return false;
            }
            if (cbosex.SelectedValue.ToString().Length == 0)
            {
                Utility.Common.Validator.SetError(errorProvider1, cbosex, "请选择性别!");
                return false;
            }
            if (!string.IsNullOrEmpty(txtuser_fax.Caption.Trim()) && !Utility.Common.Validator.IsTel(txtuser_fax.Caption.Trim()))
            {
                Utility.Common.Validator.SetError(errorProvider1, txtuser_fax, "传真格式不正确!");
                return false;
            }
            // dicFileds.Add("is_operator", cbois_operator.SelectedValue.ToString());//是否操作员 
            //dicFileds.Add("idcard_type", cboidcard_type.SelectedValue.ToString());//证件类型 
            if (!string.IsNullOrEmpty(txtuser_email.Caption.Trim()) && !Utility.Common.Validator.IsEmail(txtuser_email.Caption.Trim()))
            {
                Utility.Common.Validator.SetError(errorProvider1, txtuser_email, "邮箱格式不正确!");
                return false;
            }

            if (string.IsNullOrEmpty(txtland_name.Caption.Trim()))
            {
                Utility.Common.Validator.SetError(errorProvider1, txtland_name, "账号不能为空!");
                return false;
            }
            if (WindowStatus.Add == this.wStatus
                && DBHelper.IsExist("判断账户是否存在", "sys_user", "land_name='" + txtland_name.Caption.Trim() + "'"))
            {
                Utility.Common.Validator.SetError(errorProvider1, txtland_name, "账号已存在!");
                return false;
            }
            //密码
            if (cbois_operator.SelectedValue.ToString() == "1")
            {
                if (!Utility.Common.ValidateUtil.IsPassword(txtPassWord.Caption.Trim()))
                {
                    Utility.Common.Validator.SetError(errorProvider1, txtPassWord, "密码为6-20字母数字混合组成!");
                    return false;
                }
            }

            //dicFileds.Add("nation", cbonation.SelectedValue.ToString());//民族 
            //dicFileds.Add("entry_date", Common.LocalDateTimeToUtcLong(dtpentry_date.Value).ToString());//  入职日期 
            //dicFileds.Add("graduate_date", Common.LocalDateTimeToUtcLong(dtpgraduate_date.Value).ToString());// 毕业时间
            // dicFileds.Add("birthday", Common.LocalDateTimeToUtcLong(dtpbirthday.Value).ToString());// 出生日期 
            //dicFileds.Add("education", cboeducation.SelectedValue.ToString());//学历
            //dicFileds.Add("position", cboposition.SelectedValue.ToString());//岗位
            return true;
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        void UCPersonnelAddOrEdit_SaveEvent(object sender, EventArgs e)
        {
            string msg = string.Empty;
            bool bln = Validator(ref msg);
            if (!bln)
            {
                return;
            }

            string newGuid = string.Empty;
            string currUser_id = "";

            string keyName = string.Empty;
            string keyValue = string.Empty;
            string opName = "新增人员信息";
            Dictionary<string, string> dicFileds = new Dictionary<string, string>();

            dicFileds.Add("user_name", txtuser_name.Caption.Trim());//人员姓名
            dicFileds.Add("land_name", txtland_name.Caption.Trim());//账号
            dicFileds.Add("user_phone", txtuser_phone.Caption.Trim());//手机
            dicFileds.Add("user_telephone", txtuser_telephone.Caption.Trim());//固话    
            dicFileds.Add("org_id", txcorg_name.Tag.ToString().Trim());//组织id 
            dicFileds.Add("sex", cbosex.SelectedValue.ToString());//性别
            dicFileds.Add("user_fax", txtuser_fax.Caption.Trim());//传真 
            dicFileds.Add("is_operator", cbois_operator.SelectedValue.ToString());//是否操作员 
            dicFileds.Add("idcard_type", cboidcard_type.SelectedValue.ToString());//证件类型 
            dicFileds.Add("user_email", txtuser_email.Caption.Trim());//邮箱 
            dicFileds.Add("idcard_num", txtidcard_num.Caption.Trim());//证件号码 
            dicFileds.Add("user_address", txtuser_address.Caption.Trim());//联系地址
            dicFileds.Add("remark", txtremark.Caption.Trim());//备注 
            //密码
            if (cbois_operator.SelectedValue.ToString() == DataSources.EnumYesNo.Yes.ToString("d"))
            {
                dicFileds.Add("password", txtPassWord.Caption.Trim());
            }
            else
            {
                dicFileds.Add("password", "111111");//密码
            }

            dicFileds.Add("nation", cbonation.SelectedValue.ToString());//民族 
            dicFileds.Add("graduate_institutions", txtgraduate_institutions.Caption.Trim());//毕业学校 
            dicFileds.Add("technical_expertise", txttechnical_expertise.Caption.Trim());//技术特长 
            dicFileds.Add("user_height", txtuser_height.Caption.Trim());//身高 
            dicFileds.Add("native_place", txtnative_place.Caption.Trim());//籍贯 
            dicFileds.Add("specialty", txtspecialty.Caption.Trim());//专业
            dicFileds.Add("entry_date", Common.LocalDateTimeToUtcLong(dtpentry_date.Value).ToString());//  入职日期 
            dicFileds.Add("user_weight", txtuser_weight.Caption.Trim());//体重 
            dicFileds.Add("register_address", txtregister_address.Caption.Trim());//户籍所在地 
            dicFileds.Add("graduate_date", Common.LocalDateTimeToUtcLong(dtpgraduate_date.Value).ToString());// 毕业时间 
            dicFileds.Add("wage", txtwage.Caption.Trim());// 工资 
            dicFileds.Add("birthday", Common.LocalDateTimeToUtcLong(dtpbirthday.Value).ToString());// 出生日期  
            dicFileds.Add("education", cboeducation.SelectedValue.ToString());//学历
            dicFileds.Add("position", cboposition.SelectedValue.ToString());//岗位
            dicFileds.Add("political_status", txtpolitical_status.Caption.Trim());//政治面貌
            dicFileds.Add("level", cbolevel.SelectedValue.ToString());//级别



            dicFileds.Add("health", cbojkzk.SelectedValue.ToString());//健康状况

            string nowUtcTicks = Common.LocalDateTimeToUtcLong(HXCPcClient.GlobalStaticObj.CurrentDateTime).ToString();
            dicFileds.Add("update_by", HXCPcClient.GlobalStaticObj.UserID);
            dicFileds.Add("update_time", nowUtcTicks);

            string crmId = string.Empty;

            if (wStatus == WindowStatus.Add || wStatus == WindowStatus.Copy)
            {
                dicFileds.Add("user_code", CommonUtility.GetNewNo(SYSModel.DataSources.EnumProjectType.User));//人员编码               

                newGuid = Guid.NewGuid().ToString();
                currUser_id = newGuid;
                dicFileds.Add("user_id", newGuid);//新ID                   
                dicFileds.Add("create_by", HXCPcClient.GlobalStaticObj.UserID);
                dicFileds.Add("create_time", nowUtcTicks);
                dicFileds.Add("enable_flag", SYSModel.DataSources.EnumEnableFlag.USING.ToString("d"));//1为未删除状态
                dicFileds.Add("status", SYSModel.DataSources.EnumStatus.Start.ToString("d"));//启用
                dicFileds.Add("data_sources", Convert.ToInt16(SYSModel.DataSources.EnumDataSources.SELFBUILD).ToString());//来源 自建
            }
            else if (wStatus == WindowStatus.Edit)
            {
                keyName = "user_id";
                keyValue = id;
                currUser_id = id;
                newGuid = id;
                crmId = dr["cont_crm_guid"].ToString();
                opName = "更新人员管理";
            }
            bln = DBHelper.Submit_AddOrEdit(opName, "sys_user", keyName, keyValue, dicFileds);

            string photo = string.Empty;
            if (picuser.Tag != null)
            {
                photo = Guid.NewGuid().ToString() + Path.GetExtension(picuser.Tag.ToString());
                if (!FileOperation.UploadFile(picuser.Tag.ToString(), photo))
                {
                    return;
                }
            }

            List<SQLObj> listSql = new List<SQLObj>();
            listSql = AddPhoto(listSql, currUser_id, photo);
            ucAttr.TableName = "sys_user";
            ucAttr.TableNameKeyValue = currUser_id;
            listSql.AddRange(ucAttr.AttachmentSql);
            DBHelper.BatchExeSQLMultiByTrans(opName, listSql);
            if (bln)
            {
                if (wStatus == WindowStatus.Add || wStatus == WindowStatus.Edit)
                {
                    var cont = new tb_contacts_ex
                           {
                               cont_id = CommonCtrl.IsNullToString(newGuid),
                               cont_name = CommonCtrl.IsNullToString(this.txtuser_name.Caption.Trim()),
                               cont_post = CommonCtrl.IsNullToString(""),
                               cont_phone = CommonCtrl.IsNullToString(""),
                               nation = CommonCtrl.IsNullToString(this.cbonation.SelectedValue.ToString()),
                               parent_customer = CommonCtrl.IsNullToString(""),
                               sex = UpSex(),
                               status = CommonCtrl.IsNullToString(SYSModel.DataSources.EnumStatus.Start.ToString("d")),
                               cont_post_remark = CommonCtrl.IsNullToString(""),
                               cont_crm_guid = CommonCtrl.IsNullToString(crmId),
                               contact_type = "02"
                           };
                    DBHelper.WebServHandlerByFun("上传服务站工作人员", SYSModel.EnumWebServFunName.UpLoadCcontact, cont);
                }

                if (this.RefreshDataStart != null)
                {
                    this.RefreshDataStart();
                }

                LocalCache._Update(CacheList.User);

                MessageBoxEx.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);

                deleteMenuByTag(this.Tag.ToString(), this.parentName);
            }
            else
            {
                MessageBoxEx.Show("保存失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //上传到宇通接口的性别转化 男为1 女为2
        private string UpSex()
        {
            if (CommonCtrl.IsNullToString(this.cbosex.Text.ToString()) == "")
            {
                return "100000000";
            }
            if (this.cbosex.Text.ToString() == "女")
                return "100000001";
            else
                return "100000000";


        }
        #endregion

        #region  添加sql语句 -图片
        /// <summary>
        /// 添加sql语句 -图片
        /// </summary>
        /// <param name="listSql">listSql</param>
        /// <param name="partID">用户id</param>
        /// <param name="path">图片id</param>
        /// <returns></returns>
        private List<SQLObj> AddPhoto(List<SQLObj> listSql, string partID, string path)
        {
            if (path != string.Empty)
            {
                SQLObj sqlObj = new SQLObj();
                sqlObj.cmdType = CommandType.Text;
                Dictionary<string, ParamObj> dic = new Dictionary<string, ParamObj>();
                dic.Add("att_path", new ParamObj("att_path", path, SysDbType.VarChar, 40));
                sqlObj.Param = dic;
                if (photoID.Length == 0)
                {
                    dic.Add("att_name", new ParamObj("att_name", "用户图片", SysDbType.NVarChar, 15));
                    dic.Add("att_type", new ParamObj("att_type", "图片", SysDbType.NVarChar, 15));
                    photoID = Guid.NewGuid().ToString();
                    dic.Add("is_main", new ParamObj("is_main", (int)DataSources.EnumYesNo.Yes, SysDbType.VarChar, 5));
                    dic.Add("relation_object", new ParamObj("relation_object", "tb_parts", SysDbType.NVarChar, 30));
                    dic.Add("relation_object_id", new ParamObj("relation_object_id", partID, SysDbType.VarChar, 40));
                    dic.Add("enable_flag", new ParamObj("enable_flag", (int)DataSources.EnumEnableFlag.USING, SysDbType.VarChar, 5));
                    dic.Add("create_by", new ParamObj("create_by", GlobalStaticObj.UserID, SysDbType.NVarChar, 40));
                    dic.Add("create_time", new ParamObj("create_time", DateTime.UtcNow.Ticks, SysDbType.BigInt));
                    sqlObj.sqlString = @"insert into [attachment_info] ([att_id],[att_name],[att_type],[att_path],[relation_object],[relation_object_id],[enable_flag],[create_by],[create_time],[is_main])
                            values (@att_id,@att_name,@att_type,@att_path,@relation_object,@relation_object_id,@enable_flag,@create_by,@create_time,@is_main);";
                }
                else
                {
                    dic.Add("update_by", new ParamObj("update_by", GlobalStaticObj.UserID, SysDbType.NVarChar, 40));
                    dic.Add("update_time", new ParamObj("update_time", DateTime.UtcNow.Ticks, SysDbType.BigInt));
                    sqlObj.sqlString = "update [attachment_info] set [att_path]=@att_path,[update_by]=@update_by,[update_time]=@update_time where [att_id]=@att_id;";
                }
                dic.Add("att_id", new ParamObj("att_id", photoID, SysDbType.VarChar, 40));
                listSql.Add(sqlObj);
            }
            return listSql;
        }
        #endregion

        #region 组织 公司选择
        private void txcorg_name_ChooserClick(object sender, EventArgs e)
        {
            frmOrganization frmModels = new frmOrganization();
            DialogResult result = frmModels.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtcom_name.Caption = frmModels.Com_Name;
                txcorg_name.Text = frmModels.Org_Name;
                txcorg_name.Tag = frmModels.Org_Id;
            }
        }
        #endregion

        #region 是否操作员选择事件
        private void cbois_operator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbois_operator.SelectedValue.ToString() == "1")
            {
                lblPassword.Visible = true;
                txtPassWord.Visible = true;
                lbltippassword.Visible = true;
            }
            else
            {
                lblPassword.Visible = false;
                txtPassWord.Visible = false;
                lbltippassword.Visible = false;
            }
        }
        #endregion

        #region 图片点击事件 选择图片
        /// <summary>
        /// 图片点击事件 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picuser_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "图片|*.jpg;*.png;*.gif;*.bmp";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.Length == 0)
                {
                    return;
                }
                Image image = new Bitmap(fileDialog.FileName);
                //picPhoto.Image = image;
                picuser.BackgroundImage = image;
                picuser.Tag = fileDialog.FileName;
            }
        }
        #endregion
    }
}
