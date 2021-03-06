﻿namespace HXCPcClient.UCForm.DataManage.VehicleModels
{
    partial class UCVehicleModelsManage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCVehicleModelsManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlEx1 = new ServiceStationClient.ComponentUI.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.page = new ServiceStationClient.ComponentUI.WinFormPager();
            this.dgvVehicleModels = new ServiceStationClient.ComponentUI.DataGridViewEx(this.components);
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colVM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsmiMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmsiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSearch = new ServiceStationClient.ComponentUI.PanelEx();
            this.txtCreateUser = new ServiceStationClient.ComponentUI.TextBoxEx();
            this.cboType = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.cboBrand = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.cboDataSource = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.cboStatus = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.btnSearch = new ServiceStationClient.ComponentUI.ButtonEx();
            this.btnClear = new ServiceStationClient.ComponentUI.ButtonEx();
            this.txtName = new ServiceStationClient.ComponentUI.TextBoxEx();
            this.txtCode = new ServiceStationClient.ComponentUI.TextBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.diCreate = new ServiceStationClient.ComponentUI.DateTimeInterval_sms();
            this.tabControlEx1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleModels)).BeginInit();
            this.tsmiMenu.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOpt
            // 
            this.pnlOpt.Size = new System.Drawing.Size(891, 52);
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlEx1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(79)))), ((int)(((byte)(125)))));
            this.tabControlEx1.Controls.Add(this.tabPage1);
            this.tabControlEx1.Location = new System.Drawing.Point(3, 215);
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(885, 269);
            this.tabControlEx1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.page);
            this.tabPage1.Controls.Add(this.dgvVehicleModels);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(877, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "车型列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // page
            // 
            this.page.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.page.BackColor = System.Drawing.Color.Transparent;
            this.page.BtnTextNext = "下页";
            this.page.BtnTextPrevious = "上页";
            this.page.DisplayStyle = ServiceStationClient.ComponentUI.WinFormPager.DisplayStyleEnum.图片;
            this.page.Location = new System.Drawing.Point(391, 202);
            this.page.Name = "page";
            this.page.PageCount = 0;
            this.page.PageSize = 15;
            this.page.RecordCount = 0;
            this.page.Size = new System.Drawing.Size(480, 31);
            this.page.TabIndex = 7;
            this.page.TextImageRalitions = ServiceStationClient.ComponentUI.WinFormPager.TextImageRalitionEnum.图片显示在文字前方;
            this.page.PageIndexChanged += new ServiceStationClient.ComponentUI.WinFormPager.EventHandler(this.page_PageIndexChanged);
            // 
            // dgvVehicleModels
            // 
            this.dgvVehicleModels.AllowUserToAddRows = false;
            this.dgvVehicleModels.AllowUserToDeleteRows = false;
            this.dgvVehicleModels.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvVehicleModels.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVehicleModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVehicleModels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVehicleModels.BackgroundColor = System.Drawing.Color.White;
            this.dgvVehicleModels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicleModels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehicleModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colVM_ID,
            this.colDataSource,
            this.colBrand,
            this.colType,
            this.colCode,
            this.colName,
            this.colCreateUser,
            this.colCreateDate,
            this.colStatus,
            this.colRemark});
            this.dgvVehicleModels.ContextMenuStrip = this.tsmiMenu;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(233)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehicleModels.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVehicleModels.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvVehicleModels.EnableHeadersVisualStyles = false;
            this.dgvVehicleModels.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(192)))), ((int)(((byte)(232)))));
            this.dgvVehicleModels.Location = new System.Drawing.Point(6, 6);
            this.dgvVehicleModels.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgvVehicleModels.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvVehicleModels.MergeColumnNames")));
            this.dgvVehicleModels.MultiSelect = false;
            this.dgvVehicleModels.Name = "dgvVehicleModels";
            this.dgvVehicleModels.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvVehicleModels.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVehicleModels.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(172)))), ((int)(((byte)(138)))));
            this.dgvVehicleModels.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVehicleModels.RowTemplate.Height = 23;
            this.dgvVehicleModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleModels.ShowCheckBox = true;
            this.dgvVehicleModels.Size = new System.Drawing.Size(865, 190);
            this.dgvVehicleModels.TabIndex = 0;
            this.dgvVehicleModels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicleModels_CellContentClick);
            this.dgvVehicleModels.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicleModels_CellDoubleClick);
            this.dgvVehicleModels.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVehicleModels_CellMouseClick);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.MinimumWidth = 18;
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Width = 18;
            // 
            // colVM_ID
            // 
            this.colVM_ID.DataPropertyName = "vm_id";
            this.colVM_ID.HeaderText = "ID";
            this.colVM_ID.Name = "colVM_ID";
            this.colVM_ID.ReadOnly = true;
            this.colVM_ID.Visible = false;
            this.colVM_ID.Width = 28;
            // 
            // colDataSource
            // 
            this.colDataSource.DataPropertyName = "data_sources";
            this.colDataSource.HeaderText = "数据来源";
            this.colDataSource.Name = "colDataSource";
            this.colDataSource.ReadOnly = true;
            this.colDataSource.Width = 81;
            // 
            // colBrand
            // 
            this.colBrand.DataPropertyName = "v_brand";
            this.colBrand.HeaderText = "车辆品牌";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            this.colBrand.Width = 81;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "vm_type";
            this.colType.HeaderText = "车辆类别";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 81;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "vm_code";
            this.colCode.HeaderText = "车型编号";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 81;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "vm_name";
            this.colName.HeaderText = "车型名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 81;
            // 
            // colCreateUser
            // 
            this.colCreateUser.DataPropertyName = "create_by";
            this.colCreateUser.HeaderText = "创建人";
            this.colCreateUser.Name = "colCreateUser";
            this.colCreateUser.ReadOnly = true;
            this.colCreateUser.Width = 69;
            // 
            // colCreateDate
            // 
            this.colCreateDate.DataPropertyName = "create_time";
            this.colCreateDate.HeaderText = "创建时间";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.ReadOnly = true;
            this.colCreateDate.Width = 81;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "status";
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 57;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "remark";
            this.colRemark.HeaderText = "备注";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 57;
            // 
            // tsmiMenu
            // 
            this.tsmiMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsiView,
            this.tsmiEdit,
            this.tsmiCopy,
            this.tsmiDelete});
            this.tsmiMenu.Name = "tsmiMenu";
            this.tsmiMenu.Size = new System.Drawing.Size(101, 92);
            // 
            // tmsiView
            // 
            this.tmsiView.Name = "tmsiView";
            this.tmsiView.Size = new System.Drawing.Size(100, 22);
            this.tmsiView.Text = "查看";
            this.tmsiView.Click += new System.EventHandler(this.tmsiView_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(100, 22);
            this.tsmiEdit.Text = "编辑";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(100, 22);
            this.tsmiCopy.Text = "复制";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlSearch.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlSearch.Controls.Add(this.diCreate);
            this.pnlSearch.Controls.Add(this.txtCreateUser);
            this.pnlSearch.Controls.Add(this.cboType);
            this.pnlSearch.Controls.Add(this.cboBrand);
            this.pnlSearch.Controls.Add(this.cboDataSource);
            this.pnlSearch.Controls.Add(this.cboStatus);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnClear);
            this.pnlSearch.Controls.Add(this.txtName);
            this.pnlSearch.Controls.Add(this.txtCode);
            this.pnlSearch.Controls.Add(this.label8);
            this.pnlSearch.Controls.Add(this.label7);
            this.pnlSearch.Controls.Add(this.label6);
            this.pnlSearch.Controls.Add(this.label5);
            this.pnlSearch.Controls.Add(this.label4);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Location = new System.Drawing.Point(3, 61);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(885, 132);
            this.pnlSearch.TabIndex = 0;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCreateUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCreateUser.BackColor = System.Drawing.Color.Transparent;
            this.txtCreateUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtCreateUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtCreateUser.ForeImage = null;
            this.txtCreateUser.Location = new System.Drawing.Point(542, 58);
            this.txtCreateUser.MaxLengh = 32767;
            this.txtCreateUser.Multiline = false;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.Radius = 3;
            this.txtCreateUser.ReadOnly = false;
            this.txtCreateUser.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtCreateUser.Size = new System.Drawing.Size(121, 23);
            this.txtCreateUser.TabIndex = 27;
            this.txtCreateUser.UseSystemPasswordChar = false;
            this.txtCreateUser.WaterMark = null;
            this.txtCreateUser.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // cboType
            // 
            this.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(542, 24);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 22);
            this.cboType.TabIndex = 25;
            // 
            // cboBrand
            // 
            this.cboBrand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(339, 24);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(121, 22);
            this.cboBrand.TabIndex = 24;
            // 
            // cboDataSource
            // 
            this.cboDataSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataSource.FormattingEnabled = true;
            this.cboDataSource.Location = new System.Drawing.Point(106, 24);
            this.cboDataSource.Name = "cboDataSource";
            this.cboDataSource.Size = new System.Drawing.Size(121, 22);
            this.cboDataSource.TabIndex = 23;
            // 
            // cboStatus
            // 
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.cboStatus.Location = new System.Drawing.Point(106, 92);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 22);
            this.cboStatus.TabIndex = 21;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Caption = "查询";
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearch.DownImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.DownImage")));
            this.btnSearch.Location = new System.Drawing.Point(730, 99);
            this.btnSearch.MoveImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.MoveImage")));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.NormalImage")));
            this.btnSearch.Size = new System.Drawing.Size(60, 26);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Caption = "清除";
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClear.DownImage = ((System.Drawing.Image)(resources.GetObject("btnClear.DownImage")));
            this.btnClear.Location = new System.Drawing.Point(730, 62);
            this.btnClear.MoveImage = ((System.Drawing.Image)(resources.GetObject("btnClear.MoveImage")));
            this.btnClear.Name = "btnClear";
            this.btnClear.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnClear.NormalImage")));
            this.btnClear.Size = new System.Drawing.Size(60, 26);
            this.btnClear.TabIndex = 18;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtName.ForeImage = null;
            this.txtName.Location = new System.Drawing.Point(339, 58);
            this.txtName.MaxLengh = 32767;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Radius = 3;
            this.txtName.ReadOnly = false;
            this.txtName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtName.Size = new System.Drawing.Size(123, 23);
            this.txtName.TabIndex = 13;
            this.txtName.UseSystemPasswordChar = false;
            this.txtName.WaterMark = null;
            this.txtName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtCode
            // 
            this.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCode.BackColor = System.Drawing.Color.Transparent;
            this.txtCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtCode.ForeImage = null;
            this.txtCode.Location = new System.Drawing.Point(106, 58);
            this.txtCode.MaxLengh = 32767;
            this.txtCode.Multiline = false;
            this.txtCode.Name = "txtCode";
            this.txtCode.Radius = 3;
            this.txtCode.ReadOnly = false;
            this.txtCode.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtCode.Size = new System.Drawing.Size(121, 23);
            this.txtCode.TabIndex = 12;
            this.txtCode.UseSystemPasswordChar = false;
            this.txtCode.WaterMark = null;
            this.txtCode.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(489, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "创建人:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "车型类别:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "创建时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "车型名称:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "车辆品牌:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "状态:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "车型编号:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据来源:";
            // 
            // diCreate
            // 
            this.diCreate.BackColor = System.Drawing.Color.Transparent;
            this.diCreate.customFormat = null;
            this.diCreate.EndDate = "";
            this.diCreate.Location = new System.Drawing.Point(339, 90);
            this.diCreate.Margin = new System.Windows.Forms.Padding(0);
            this.diCreate.Name = "diCreate";
            this.diCreate.Size = new System.Drawing.Size(263, 27);
            this.diCreate.StartDate = "";
            this.diCreate.TabIndex = 28;
            // 
            // UCVehicleModelsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlEx1);
            this.Controls.Add(this.pnlSearch);
            this.Name = "UCVehicleModelsManage";
            this.Size = new System.Drawing.Size(891, 496);
            this.Load += new System.EventHandler(this.UCVehicleModelsManage_Load);
            this.Controls.SetChildIndex(this.pnlSearch, 0);
            this.Controls.SetChildIndex(this.pnlOpt, 0);
            this.Controls.SetChildIndex(this.tabControlEx1, 0);
            this.tabControlEx1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleModels)).EndInit();
            this.tsmiMenu.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ServiceStationClient.ComponentUI.PanelEx pnlSearch;
        private ServiceStationClient.ComponentUI.ButtonEx btnSearch;
        private ServiceStationClient.ComponentUI.ButtonEx btnClear;
        private ServiceStationClient.ComponentUI.TextBoxEx txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ServiceStationClient.ComponentUI.TextBoxEx txtCode;
        private ServiceStationClient.ComponentUI.TabControlEx tabControlEx1;
        private System.Windows.Forms.TabPage tabPage1;
        private ServiceStationClient.ComponentUI.DataGridViewEx dgvVehicleModels;
        private ServiceStationClient.ComponentUI.ComboBoxEx cboStatus;
        private ServiceStationClient.ComponentUI.ComboBoxEx cboType;
        private ServiceStationClient.ComponentUI.ComboBoxEx cboBrand;
        private ServiceStationClient.ComponentUI.ComboBoxEx cboDataSource;
        private ServiceStationClient.ComponentUI.WinFormPager page;
        private System.Windows.Forms.ContextMenuStrip tsmiMenu;
        private System.Windows.Forms.ToolStripMenuItem tmsiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private ServiceStationClient.ComponentUI.TextBoxEx txtCreateUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVM_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private ServiceStationClient.ComponentUI.DateTimeInterval_sms diCreate;

    }
}
