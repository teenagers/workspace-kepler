﻿namespace HXCPcClient.UCForm.RepairBusiness.OldPartsManagement.OldPartsSend
{
    partial class UCOldPartsSendAddOrEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCOldPartsSendAddOrEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.palTop = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpReceiptTime = new ServiceStationClient.ComponentUI.DateTimePickerEx();
            this.labReceiptTime = new System.Windows.Forms.Label();
            this.labReceiptNoS = new System.Windows.Forms.Label();
            this.labReceiptNo = new System.Windows.Forms.Label();
            this.palInfo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContactPhone = new ServiceStationClient.ComponentUI.TextBoxEx();
            this.labContactPhone = new System.Windows.Forms.Label();
            this.txtCustomNO = new ServiceStationClient.ComponentUI.TextBox.TextChooser();
            this.txtRemark = new ServiceStationClient.ComponentUI.TextBoxEx();
            this.txtContact = new ServiceStationClient.ComponentUI.TextBoxEx();
            this.txtCustomName = new ServiceStationClient.ComponentUI.TextBoxEx();
            this.labRemark = new System.Windows.Forms.Label();
            this.labContact = new System.Windows.Forms.Label();
            this.labCustomName = new System.Windows.Forms.Label();
            this.labCustomNO = new System.Windows.Forms.Label();
            this.palBottom = new System.Windows.Forms.Panel();
            this.dgvMaterials = new ServiceStationClient.ComponentUI.DataGridViewEx(this.components);
            this.Mcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.parts_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parts_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicle_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.norms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drawn_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum_money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventory_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process_mode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parts_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmParts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addParts = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteParts = new System.Windows.Forms.ToolStripMenuItem();
            this.palbottom1 = new ServiceStationClient.ComponentUI.PanelEx();
            this.labCreatePersonS = new System.Windows.Forms.Label();
            this.labCreatePerson = new System.Windows.Forms.Label();
            this.cboOrgId = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.cobYHandle = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.labDepart = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.contextMenuM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.palTop.SuspendLayout();
            this.palInfo.SuspendLayout();
            this.palBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.ctmParts.SuspendLayout();
            this.palbottom1.SuspendLayout();
            this.contextMenuM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // palTop
            // 
            this.palTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.palTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.palTop.Controls.Add(this.label3);
            this.palTop.Controls.Add(this.label4);
            this.palTop.Controls.Add(this.dtpReceiptTime);
            this.palTop.Controls.Add(this.labReceiptTime);
            this.palTop.Controls.Add(this.labReceiptNoS);
            this.palTop.Controls.Add(this.labReceiptNo);
            this.palTop.Location = new System.Drawing.Point(0, 29);
            this.palTop.Name = "palTop";
            this.palTop.Size = new System.Drawing.Size(1030, 40);
            this.palTop.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(472, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 78;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(9, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 32;
            this.label4.Text = "单据信息";
            // 
            // dtpReceiptTime
            // 
            this.dtpReceiptTime.Location = new System.Drawing.Point(488, 16);
            this.dtpReceiptTime.Name = "dtpReceiptTime";
            this.dtpReceiptTime.ShowFormat = "yyyy-MM-dd HH:mm";
            this.dtpReceiptTime.Size = new System.Drawing.Size(121, 21);
            this.dtpReceiptTime.TabIndex = 31;
            this.dtpReceiptTime.Value = new System.DateTime(2014, 9, 24, 0, 0, 0, 0);
            // 
            // labReceiptTime
            // 
            this.labReceiptTime.AutoSize = true;
            this.labReceiptTime.Location = new System.Drawing.Point(418, 21);
            this.labReceiptTime.Name = "labReceiptTime";
            this.labReceiptTime.Size = new System.Drawing.Size(65, 12);
            this.labReceiptTime.TabIndex = 30;
            this.labReceiptTime.Text = "发货日期：";
            // 
            // labReceiptNoS
            // 
            this.labReceiptNoS.AutoSize = true;
            this.labReceiptNoS.Location = new System.Drawing.Point(206, 21);
            this.labReceiptNoS.Name = "labReceiptNoS";
            this.labReceiptNoS.Size = new System.Drawing.Size(23, 12);
            this.labReceiptNoS.TabIndex = 1;
            this.labReceiptNoS.Text = "123";
            // 
            // labReceiptNo
            // 
            this.labReceiptNo.AutoSize = true;
            this.labReceiptNo.Location = new System.Drawing.Point(135, 21);
            this.labReceiptNo.Name = "labReceiptNo";
            this.labReceiptNo.Size = new System.Drawing.Size(65, 12);
            this.labReceiptNo.TabIndex = 0;
            this.labReceiptNo.Text = "发货单号：";
            // 
            // palInfo
            // 
            this.palInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.palInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.palInfo.Controls.Add(this.label1);
            this.palInfo.Controls.Add(this.label2);
            this.palInfo.Controls.Add(this.txtContactPhone);
            this.palInfo.Controls.Add(this.labContactPhone);
            this.palInfo.Controls.Add(this.txtCustomNO);
            this.palInfo.Controls.Add(this.txtRemark);
            this.palInfo.Controls.Add(this.txtContact);
            this.palInfo.Controls.Add(this.txtCustomName);
            this.palInfo.Controls.Add(this.labRemark);
            this.palInfo.Controls.Add(this.labContact);
            this.palInfo.Controls.Add(this.labCustomName);
            this.palInfo.Controls.Add(this.labCustomNO);
            this.palInfo.Location = new System.Drawing.Point(0, 71);
            this.palInfo.Name = "palInfo";
            this.palInfo.Size = new System.Drawing.Size(1030, 76);
            this.palInfo.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(70, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(279, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "*";
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtContactPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtContactPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtContactPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtContactPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtContactPhone.ForeImage = null;
            this.txtContactPhone.InputtingVerifyCondition = null;
            this.txtContactPhone.Location = new System.Drawing.Point(713, 12);
            this.txtContactPhone.MaxLengh = 32767;
            this.txtContactPhone.Multiline = false;
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.Radius = 3;
            this.txtContactPhone.ReadOnly = false;
            this.txtContactPhone.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtContactPhone.ShowError = false;
            this.txtContactPhone.Size = new System.Drawing.Size(120, 23);
            this.txtContactPhone.TabIndex = 76;
            this.txtContactPhone.UseSystemPasswordChar = false;
            this.txtContactPhone.Value = "";
            this.txtContactPhone.VerifyCondition = null;
            this.txtContactPhone.VerifyType = null;
            this.txtContactPhone.VerifyTypeName = null;
            this.txtContactPhone.WaterMark = null;
            this.txtContactPhone.WaterMarkColor = System.Drawing.Color.Silver;
            this.txtContactPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContactPhone_KeyPress);
            // 
            // labContactPhone
            // 
            this.labContactPhone.AutoSize = true;
            this.labContactPhone.Location = new System.Drawing.Point(630, 17);
            this.labContactPhone.Name = "labContactPhone";
            this.labContactPhone.Size = new System.Drawing.Size(77, 12);
            this.labContactPhone.TabIndex = 75;
            this.labContactPhone.Text = "联系人手机：";
            // 
            // txtCustomNO
            // 
            this.txtCustomNO.ChooserTypeImage = ServiceStationClient.ComponentUI.TextBox.ChooserType.Default;
            this.txtCustomNO.Location = new System.Drawing.Point(87, 12);
            this.txtCustomNO.Name = "txtCustomNO";
            this.txtCustomNO.ReadOnly = false;
            this.txtCustomNO.Size = new System.Drawing.Size(117, 24);
            this.txtCustomNO.TabIndex = 65;
            this.txtCustomNO.ToolTipTitle = "";
            this.txtCustomNO.ChooserClick += new System.EventHandler(this.txtCustomNO_ChooserClick);
            // 
            // txtRemark
            // 
            this.txtRemark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRemark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRemark.BackColor = System.Drawing.Color.Transparent;
            this.txtRemark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtRemark.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtRemark.ForeImage = null;
            this.txtRemark.InputtingVerifyCondition = null;
            this.txtRemark.Location = new System.Drawing.Point(87, 42);
            this.txtRemark.MaxLengh = 200;
            this.txtRemark.Multiline = false;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Radius = 3;
            this.txtRemark.ReadOnly = false;
            this.txtRemark.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtRemark.ShowError = false;
            this.txtRemark.Size = new System.Drawing.Size(746, 23);
            this.txtRemark.TabIndex = 39;
            this.txtRemark.UseSystemPasswordChar = false;
            this.txtRemark.Value = "";
            this.txtRemark.VerifyCondition = null;
            this.txtRemark.VerifyType = null;
            this.txtRemark.VerifyTypeName = null;
            this.txtRemark.WaterMark = null;
            this.txtRemark.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtContact
            // 
            this.txtContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtContact.BackColor = System.Drawing.Color.Transparent;
            this.txtContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtContact.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtContact.ForeImage = null;
            this.txtContact.InputtingVerifyCondition = null;
            this.txtContact.Location = new System.Drawing.Point(495, 12);
            this.txtContact.MaxLengh = 20;
            this.txtContact.Multiline = false;
            this.txtContact.Name = "txtContact";
            this.txtContact.Radius = 3;
            this.txtContact.ReadOnly = false;
            this.txtContact.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtContact.ShowError = false;
            this.txtContact.Size = new System.Drawing.Size(120, 23);
            this.txtContact.TabIndex = 38;
            this.txtContact.UseSystemPasswordChar = false;
            this.txtContact.Value = "";
            this.txtContact.VerifyCondition = null;
            this.txtContact.VerifyType = null;
            this.txtContact.VerifyTypeName = null;
            this.txtContact.WaterMark = null;
            this.txtContact.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtCustomName
            // 
            this.txtCustomName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCustomName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCustomName.BackColor = System.Drawing.Color.Transparent;
            this.txtCustomName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtCustomName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtCustomName.ForeImage = null;
            this.txtCustomName.InputtingVerifyCondition = null;
            this.txtCustomName.Location = new System.Drawing.Point(295, 12);
            this.txtCustomName.MaxLengh = 20;
            this.txtCustomName.Multiline = false;
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Radius = 3;
            this.txtCustomName.ReadOnly = false;
            this.txtCustomName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtCustomName.ShowError = false;
            this.txtCustomName.Size = new System.Drawing.Size(120, 23);
            this.txtCustomName.TabIndex = 37;
            this.txtCustomName.UseSystemPasswordChar = false;
            this.txtCustomName.Value = "";
            this.txtCustomName.VerifyCondition = null;
            this.txtCustomName.VerifyType = null;
            this.txtCustomName.VerifyTypeName = null;
            this.txtCustomName.WaterMark = null;
            this.txtCustomName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // labRemark
            // 
            this.labRemark.AutoSize = true;
            this.labRemark.Location = new System.Drawing.Point(39, 48);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(41, 12);
            this.labRemark.TabIndex = 35;
            this.labRemark.Text = "备注：";
            // 
            // labContact
            // 
            this.labContact.AutoSize = true;
            this.labContact.Location = new System.Drawing.Point(436, 18);
            this.labContact.Name = "labContact";
            this.labContact.Size = new System.Drawing.Size(53, 12);
            this.labContact.TabIndex = 34;
            this.labContact.Text = "联系人：";
            // 
            // labCustomName
            // 
            this.labCustomName.AutoSize = true;
            this.labCustomName.Location = new System.Drawing.Point(225, 18);
            this.labCustomName.Name = "labCustomName";
            this.labCustomName.Size = new System.Drawing.Size(65, 12);
            this.labCustomName.TabIndex = 33;
            this.labCustomName.Text = "客户名称：";
            // 
            // labCustomNO
            // 
            this.labCustomNO.AutoSize = true;
            this.labCustomNO.Location = new System.Drawing.Point(16, 18);
            this.labCustomNO.Name = "labCustomNO";
            this.labCustomNO.Size = new System.Drawing.Size(65, 12);
            this.labCustomNO.TabIndex = 32;
            this.labCustomNO.Text = "客户编码：";
            // 
            // palBottom
            // 
            this.palBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.palBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.palBottom.Controls.Add(this.dgvMaterials);
            this.palBottom.Location = new System.Drawing.Point(1, 150);
            this.palBottom.Name = "palBottom";
            this.palBottom.Size = new System.Drawing.Size(1029, 355);
            this.palBottom.TabIndex = 11;
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.AllowUserToAddRows = false;
            this.dgvMaterials.AllowUserToDeleteRows = false;
            this.dgvMaterials.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvMaterials.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaterials.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaterials.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mcheck,
            this.parts_code,
            this.parts_name,
            this.vehicle_no,
            this.norms,
            this.drawn_no,
            this.unit,
            this.quantity,
            this.unit_price,
            this.sum_money,
            this.inventory_num,
            this.process_mode,
            this.remarks,
            this.parts_id});
            this.dgvMaterials.ContextMenuStrip = this.ctmParts;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(233)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterials.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMaterials.EnableHeadersVisualStyles = false;
            this.dgvMaterials.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.dgvMaterials.IsCheck = true;
            this.dgvMaterials.Location = new System.Drawing.Point(3, 3);
            this.dgvMaterials.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgvMaterials.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMaterials.MergeColumnNames")));
            this.dgvMaterials.MultiSelect = false;
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterials.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvMaterials.RowHeadersVisible = false;
            this.dgvMaterials.RowHeadersWidth = 30;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(172)))), ((int)(((byte)(138)))));
            this.dgvMaterials.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvMaterials.RowTemplate.Height = 23;
            this.dgvMaterials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterials.ShowCheckBox = true;
            this.dgvMaterials.Size = new System.Drawing.Size(1021, 292);
            this.dgvMaterials.TabIndex = 19;
            this.dgvMaterials.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterials_CellDoubleClick);
            this.dgvMaterials.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterials_CellValueChanged);
            // 
            // Mcheck
            // 
            this.Mcheck.HeaderText = "";
            this.Mcheck.MinimumWidth = 30;
            this.Mcheck.Name = "Mcheck";
            this.Mcheck.ReadOnly = true;
            this.Mcheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Mcheck.Width = 30;
            // 
            // parts_code
            // 
            this.parts_code.DataPropertyName = "parts_code";
            this.parts_code.HeaderText = "配件编码";
            this.parts_code.Name = "parts_code";
            this.parts_code.ReadOnly = true;
            this.parts_code.Width = 90;
            // 
            // parts_name
            // 
            this.parts_name.DataPropertyName = "parts_name";
            this.parts_name.HeaderText = "配件名称";
            this.parts_name.Name = "parts_name";
            this.parts_name.ReadOnly = true;
            this.parts_name.Width = 90;
            // 
            // vehicle_no
            // 
            this.vehicle_no.DataPropertyName = "vehicle_no";
            this.vehicle_no.HeaderText = "车牌号";
            this.vehicle_no.Name = "vehicle_no";
            this.vehicle_no.ReadOnly = true;
            // 
            // norms
            // 
            this.norms.DataPropertyName = "norms";
            this.norms.HeaderText = "规格";
            this.norms.Name = "norms";
            this.norms.ReadOnly = true;
            // 
            // drawn_no
            // 
            this.drawn_no.DataPropertyName = "drawn_no";
            this.drawn_no.HeaderText = "图号";
            this.drawn_no.Name = "drawn_no";
            this.drawn_no.ReadOnly = true;
            this.drawn_no.Width = 80;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 60;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "数量";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // unit_price
            // 
            this.unit_price.DataPropertyName = "unit_price";
            this.unit_price.HeaderText = "单价";
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            // 
            // sum_money
            // 
            this.sum_money.DataPropertyName = "sum_money";
            this.sum_money.HeaderText = "金额";
            this.sum_money.Name = "sum_money";
            this.sum_money.ReadOnly = true;
            // 
            // inventory_num
            // 
            this.inventory_num.DataPropertyName = "inventory_num";
            this.inventory_num.HeaderText = "库存数量";
            this.inventory_num.Name = "inventory_num";
            this.inventory_num.ReadOnly = true;
            // 
            // process_mode
            // 
            this.process_mode.DataPropertyName = "process_mode";
            this.process_mode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.process_mode.DisplayStyleForCurrentCellOnly = true;
            this.process_mode.HeaderText = "处理方式";
            this.process_mode.Name = "process_mode";
            this.process_mode.ReadOnly = true;
            this.process_mode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.process_mode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "备注";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 90;
            // 
            // parts_id
            // 
            this.parts_id.DataPropertyName = "parts_id";
            this.parts_id.HeaderText = "parts_id";
            this.parts_id.Name = "parts_id";
            this.parts_id.ReadOnly = true;
            this.parts_id.Visible = false;
            this.parts_id.Width = 10;
            // 
            // ctmParts
            // 
            this.ctmParts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addParts,
            this.deleteParts});
            this.ctmParts.Name = "ctmParts";
            this.ctmParts.Size = new System.Drawing.Size(153, 70);
            // 
            // addParts
            // 
            this.addParts.Image = global::HXCPcClient.Properties.Resources.Add_E;
            this.addParts.Name = "addParts";
            this.addParts.Size = new System.Drawing.Size(152, 22);
            this.addParts.Text = "添加配件";
            this.addParts.Click += new System.EventHandler(this.addParts_Click);
            // 
            // deleteParts
            // 
            this.deleteParts.Image = global::HXCPcClient.Properties.Resources.Delete_E;
            this.deleteParts.Name = "deleteParts";
            this.deleteParts.Size = new System.Drawing.Size(152, 22);
            this.deleteParts.Text = "删除配件";
            this.deleteParts.Click += new System.EventHandler(this.deleteParts_Click);
            // 
            // palbottom1
            // 
            this.palbottom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.palbottom1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.palbottom1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.palbottom1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(211)))), ((int)(((byte)(254)))));
            this.palbottom1.BorderWidth = 1;
            this.palbottom1.Controls.Add(this.labCreatePersonS);
            this.palbottom1.Controls.Add(this.labCreatePerson);
            this.palbottom1.Controls.Add(this.cboOrgId);
            this.palbottom1.Controls.Add(this.cobYHandle);
            this.palbottom1.Controls.Add(this.labDepart);
            this.palbottom1.Controls.Add(this.label31);
            this.palbottom1.Curvature = 0;
            this.palbottom1.CurveMode = ((ServiceStationClient.ComponentUI.CornerCurveMode)((((ServiceStationClient.ComponentUI.CornerCurveMode.TopLeft | ServiceStationClient.ComponentUI.CornerCurveMode.TopRight)
                        | ServiceStationClient.ComponentUI.CornerCurveMode.BottomLeft)
                        | ServiceStationClient.ComponentUI.CornerCurveMode.BottomRight)));
            this.palbottom1.GradientMode = ServiceStationClient.ComponentUI.LinearGradientMode.None;
            this.palbottom1.Location = new System.Drawing.Point(3, 511);
            this.palbottom1.Name = "palbottom1";
            this.palbottom1.Size = new System.Drawing.Size(1027, 30);
            this.palbottom1.TabIndex = 16;
            // 
            // labCreatePersonS
            // 
            this.labCreatePersonS.AutoSize = true;
            this.labCreatePersonS.Location = new System.Drawing.Point(559, 7);
            this.labCreatePersonS.Name = "labCreatePersonS";
            this.labCreatePersonS.Size = new System.Drawing.Size(17, 12);
            this.labCreatePersonS.TabIndex = 162;
            this.labCreatePersonS.Text = "aa";
            // 
            // labCreatePerson
            // 
            this.labCreatePerson.AutoSize = true;
            this.labCreatePerson.Location = new System.Drawing.Point(500, 7);
            this.labCreatePerson.Name = "labCreatePerson";
            this.labCreatePerson.Size = new System.Drawing.Size(53, 12);
            this.labCreatePerson.TabIndex = 161;
            this.labCreatePerson.Text = "创建人：";
            // 
            // cboOrgId
            // 
            this.cboOrgId.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboOrgId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrgId.FormattingEnabled = true;
            this.cboOrgId.Location = new System.Drawing.Point(681, 3);
            this.cboOrgId.Name = "cboOrgId";
            this.cboOrgId.Size = new System.Drawing.Size(121, 22);
            this.cboOrgId.TabIndex = 160;
            this.cboOrgId.SelectedIndexChanged += new System.EventHandler(this.cboOrgId_SelectedIndexChanged);
            // 
            // cobYHandle
            // 
            this.cobYHandle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cobYHandle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobYHandle.FormattingEnabled = true;
            this.cobYHandle.Location = new System.Drawing.Point(861, 3);
            this.cobYHandle.Name = "cobYHandle";
            this.cobYHandle.Size = new System.Drawing.Size(118, 22);
            this.cobYHandle.TabIndex = 159;
            // 
            // labDepart
            // 
            this.labDepart.AutoSize = true;
            this.labDepart.Location = new System.Drawing.Point(634, 7);
            this.labDepart.Name = "labDepart";
            this.labDepart.Size = new System.Drawing.Size(41, 12);
            this.labDepart.TabIndex = 158;
            this.labDepart.Text = "部门：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(808, 7);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 157;
            this.label31.Text = "经办人：";
            // 
            // contextMenuM
            // 
            this.contextMenuM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.contextMenuM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuM.Name = "contextMenuM";
            this.contextMenuM.Size = new System.Drawing.Size(161, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "旧件收货单导入";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UCOldPartsSendAddOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.palbottom1);
            this.Controls.Add(this.palBottom);
            this.Controls.Add(this.palInfo);
            this.Controls.Add(this.palTop);
            this.Name = "UCOldPartsSendAddOrEdit";
            this.Load += new System.EventHandler(this.UCOldPartsSendAddOrEdit_Load);
            this.Controls.SetChildIndex(this.pnlOpt, 0);
            this.Controls.SetChildIndex(this.palTop, 0);
            this.Controls.SetChildIndex(this.palInfo, 0);
            this.Controls.SetChildIndex(this.palBottom, 0);
            this.Controls.SetChildIndex(this.palbottom1, 0);
            this.palTop.ResumeLayout(false);
            this.palTop.PerformLayout();
            this.palInfo.ResumeLayout(false);
            this.palInfo.PerformLayout();
            this.palBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.ctmParts.ResumeLayout(false);
            this.palbottom1.ResumeLayout(false);
            this.palbottom1.PerformLayout();
            this.contextMenuM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel palTop;
        private System.Windows.Forms.Label label4;
        private ServiceStationClient.ComponentUI.DateTimePickerEx dtpReceiptTime;
        private System.Windows.Forms.Label labReceiptTime;
        private System.Windows.Forms.Label labReceiptNoS;
        private System.Windows.Forms.Label labReceiptNo;
        private System.Windows.Forms.Panel palInfo;
        private ServiceStationClient.ComponentUI.TextBoxEx txtContactPhone;
        private System.Windows.Forms.Label labContactPhone;
        private ServiceStationClient.ComponentUI.TextBox.TextChooser txtCustomNO;
        private ServiceStationClient.ComponentUI.TextBoxEx txtRemark;
        private ServiceStationClient.ComponentUI.TextBoxEx txtContact;
        private ServiceStationClient.ComponentUI.TextBoxEx txtCustomName;
        private System.Windows.Forms.Label labRemark;
        private System.Windows.Forms.Label labContact;
        private System.Windows.Forms.Label labCustomName;
        private System.Windows.Forms.Label labCustomNO;
        private System.Windows.Forms.Panel palBottom;
        private ServiceStationClient.ComponentUI.PanelEx palbottom1;
        private System.Windows.Forms.Label labCreatePersonS;
        private System.Windows.Forms.Label labCreatePerson;
        private ServiceStationClient.ComponentUI.ComboBoxEx cboOrgId;
        private ServiceStationClient.ComponentUI.ComboBoxEx cobYHandle;
        private System.Windows.Forms.Label labDepart;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ContextMenuStrip contextMenuM;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ServiceStationClient.ComponentUI.DataGridViewEx dgvMaterials;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn parts_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn parts_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicle_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn norms;
        private System.Windows.Forms.DataGridViewTextBoxColumn drawn_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum_money;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventory_num;
        private System.Windows.Forms.DataGridViewComboBoxColumn process_mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn parts_id;
        private System.Windows.Forms.ContextMenuStrip ctmParts;
        private System.Windows.Forms.ToolStripMenuItem addParts;
        private System.Windows.Forms.ToolStripMenuItem deleteParts;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}