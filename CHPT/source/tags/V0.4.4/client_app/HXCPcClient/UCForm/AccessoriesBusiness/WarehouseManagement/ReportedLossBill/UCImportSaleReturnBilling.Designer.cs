﻿namespace HXCPcClient.UCForm.AccessoriesBusiness.WarehouseManagement.ReportedLossBill
{
    partial class UCImportSaleReturnBilling
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCImportSaleReturnBilling));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimeStart = new ServiceStationClient.ComponentUI.DateTimePickerEx_sms();
            this.dateTimeEnd = new ServiceStationClient.ComponentUI.DateTimePickerEx_sms();
            this.dgPartslist = new ServiceStationClient.ComponentUI.DataGridViewEx(this.components);
            this.colDetailCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PartBillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parts_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parts_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drawing_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrigPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusCounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValTogether = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemainCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarPartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBillList = new ServiceStationClient.ComponentUI.DataGridViewEx(this.components);
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StockBillingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance_money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.org_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handle_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operator_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtparts_name = new ServiceStationClient.ComponentUI.TextBox.TextChooser();
            this.txtparts_code = new ServiceStationClient.ComponentUI.TextBox.TextChooser();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtorder_num = new ServiceStationClient.ComponentUI.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlhandle = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.ddloperator = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.ddlorg_id = new ServiceStationClient.ComponentUI.ComboBoxEx(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtparts_type = new ServiceStationClient.ComponentUI.TextBox.TextChooser();
            this.btnOK = new ServiceStationClient.ComponentUI.ButtonEx();
            this.btnClose = new ServiceStationClient.ComponentUI.ButtonEx();
            this.btnNotCheck = new ServiceStationClient.ComponentUI.ButtonEx();
            this.btnAllCheck = new ServiceStationClient.ComponentUI.ButtonEx();
            this.btnSearch = new ServiceStationClient.ComponentUI.ButtonEx();
            this.btnClear = new ServiceStationClient.ComponentUI.ButtonEx();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPartslist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.btnSearch);
            this.pnlContainer.Controls.Add(this.btnClear);
            this.pnlContainer.Controls.Add(this.btnAllCheck);
            this.pnlContainer.Controls.Add(this.btnNotCheck);
            this.pnlContainer.Controls.Add(this.btnClose);
            this.pnlContainer.Controls.Add(this.btnOK);
            this.pnlContainer.Controls.Add(this.txtparts_type);
            this.pnlContainer.Controls.Add(this.dateTimeStart);
            this.pnlContainer.Controls.Add(this.dateTimeEnd);
            this.pnlContainer.Controls.Add(this.dgPartslist);
            this.pnlContainer.Controls.Add(this.dgBillList);
            this.pnlContainer.Controls.Add(this.txtparts_name);
            this.pnlContainer.Controls.Add(this.txtparts_code);
            this.pnlContainer.Controls.Add(this.label4);
            this.pnlContainer.Controls.Add(this.label3);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.txtorder_num);
            this.pnlContainer.Controls.Add(this.label5);
            this.pnlContainer.Controls.Add(this.label7);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.ddlhandle);
            this.pnlContainer.Controls.Add(this.ddloperator);
            this.pnlContainer.Controls.Add(this.ddlorg_id);
            this.pnlContainer.Controls.Add(this.label9);
            this.pnlContainer.Controls.Add(this.label8);
            this.pnlContainer.Controls.Add(this.label6);
            this.pnlContainer.Size = new System.Drawing.Size(816, 483);
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(93, 18);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.ShowFormat = "yyyy-MM-dd";
            this.dateTimeStart.Size = new System.Drawing.Size(144, 21);
            this.dateTimeStart.TabIndex = 135;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(319, 17);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.ShowFormat = "yyyy-MM-dd";
            this.dateTimeEnd.Size = new System.Drawing.Size(142, 21);
            this.dateTimeEnd.TabIndex = 134;
            // 
            // dgPartslist
            // 
            this.dgPartslist.AllowUserToAddRows = false;
            this.dgPartslist.AllowUserToDeleteRows = false;
            this.dgPartslist.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgPartslist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgPartslist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPartslist.BackgroundColor = System.Drawing.Color.White;
            this.dgPartslist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPartslist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgPartslist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPartslist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailCheck,
            this.PartBillID,
            this.parts_code,
            this.parts_name,
            this.drawing_num,
            this.unit,
            this.OrigPrice,
            this.BusPrice,
            this.BusCounts,
            this.ValTogether,
            this.RefCount,
            this.RemainCount,
            this.ArrivDate,
            this.CarPartCode});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(233)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPartslist.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgPartslist.EnableHeadersVisualStyles = false;
            this.dgPartslist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.dgPartslist.IsCheck = true;
            this.dgPartslist.Location = new System.Drawing.Point(11, 278);
            this.dgPartslist.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgPartslist.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgPartslist.MergeColumnNames")));
            this.dgPartslist.MultiSelect = false;
            this.dgPartslist.Name = "dgPartslist";
            this.dgPartslist.ReadOnly = true;
            this.dgPartslist.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgPartslist.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgPartslist.RowHeadersVisible = false;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(233)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dgPartslist.RowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgPartslist.RowTemplate.Height = 23;
            this.dgPartslist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPartslist.ShowCheckBox = true;
            this.dgPartslist.Size = new System.Drawing.Size(792, 154);
            this.dgPartslist.TabIndex = 129;
            this.dgPartslist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPartslist_CellContentClick);
            // 
            // colDetailCheck
            // 
            this.colDetailCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDetailCheck.HeaderText = "";
            this.colDetailCheck.MinimumWidth = 30;
            this.colDetailCheck.Name = "colDetailCheck";
            this.colDetailCheck.ReadOnly = true;
            this.colDetailCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDetailCheck.Width = 30;
            // 
            // PartBillID
            // 
            this.PartBillID.HeaderText = "开单主键ID";
            this.PartBillID.Name = "PartBillID";
            this.PartBillID.ReadOnly = true;
            this.PartBillID.Visible = false;
            // 
            // parts_code
            // 
            this.parts_code.DataPropertyName = "parts_code";
            this.parts_code.HeaderText = "配件编码";
            this.parts_code.Name = "parts_code";
            this.parts_code.ReadOnly = true;
            // 
            // parts_name
            // 
            this.parts_name.DataPropertyName = "parts_name";
            this.parts_name.HeaderText = "配件名称";
            this.parts_name.Name = "parts_name";
            this.parts_name.ReadOnly = true;
            // 
            // drawing_num
            // 
            this.drawing_num.DataPropertyName = "drawing_num";
            this.drawing_num.HeaderText = "图号";
            this.drawing_num.Name = "drawing_num";
            this.drawing_num.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OrigPrice
            // 
            this.OrigPrice.DataPropertyName = "original_price";
            this.OrigPrice.HeaderText = "单价";
            this.OrigPrice.Name = "OrigPrice";
            this.OrigPrice.ReadOnly = true;
            // 
            // BusPrice
            // 
            this.BusPrice.DataPropertyName = "business_price";
            this.BusPrice.HeaderText = "含税单价";
            this.BusPrice.Name = "BusPrice";
            this.BusPrice.ReadOnly = true;
            // 
            // BusCounts
            // 
            this.BusCounts.DataPropertyName = "business_counts";
            this.BusCounts.HeaderText = "数量";
            this.BusCounts.Name = "BusCounts";
            this.BusCounts.ReadOnly = true;
            // 
            // ValTogether
            // 
            this.ValTogether.DataPropertyName = "valorem_together";
            this.ValTogether.HeaderText = "金额";
            this.ValTogether.Name = "ValTogether";
            this.ValTogether.ReadOnly = true;
            // 
            // RefCount
            // 
            this.RefCount.DataPropertyName = "storage_count";
            this.RefCount.HeaderText = "引用数量";
            this.RefCount.Name = "RefCount";
            this.RefCount.ReadOnly = true;
            this.RefCount.Visible = false;
            // 
            // RemainCount
            // 
            this.RemainCount.DataPropertyName = "return_count";
            this.RemainCount.HeaderText = "剩余数量";
            this.RemainCount.Name = "RemainCount";
            this.RemainCount.ReadOnly = true;
            this.RemainCount.Visible = false;
            // 
            // ArrivDate
            // 
            this.ArrivDate.DataPropertyName = "arrival_date";
            this.ArrivDate.HeaderText = "到货日期";
            this.ArrivDate.Name = "ArrivDate";
            this.ArrivDate.ReadOnly = true;
            // 
            // CarPartCode
            // 
            this.CarPartCode.DataPropertyName = "car_parts_code";
            this.CarPartCode.HeaderText = "厂商编码";
            this.CarPartCode.Name = "CarPartCode";
            this.CarPartCode.ReadOnly = true;
            // 
            // dgBillList
            // 
            this.dgBillList.AllowUserToAddRows = false;
            this.dgBillList.AllowUserToDeleteRows = false;
            this.dgBillList.AllowUserToResizeRows = false;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgBillList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            this.dgBillList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBillList.BackgroundColor = System.Drawing.Color.White;
            this.dgBillList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBillList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgBillList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBillList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.StockBillingId,
            this.OrderName,
            this.order_type_name,
            this.order_num,
            this.order_date,
            this.balance_money,
            this.org_name,
            this.handle_name,
            this.operator_name,
            this.remark});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(233)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBillList.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgBillList.EnableHeadersVisualStyles = false;
            this.dgBillList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.dgBillList.IsCheck = true;
            this.dgBillList.Location = new System.Drawing.Point(12, 104);
            this.dgBillList.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgBillList.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgBillList.MergeColumnNames")));
            this.dgBillList.MultiSelect = false;
            this.dgBillList.Name = "dgBillList";
            this.dgBillList.ReadOnly = true;
            this.dgBillList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgBillList.RowHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dgBillList.RowHeadersVisible = false;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(233)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dgBillList.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.dgBillList.RowTemplate.Height = 23;
            this.dgBillList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBillList.ShowCheckBox = true;
            this.dgBillList.Size = new System.Drawing.Size(792, 168);
            this.dgBillList.TabIndex = 128;
            this.dgBillList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBillList_CellClick);
            this.dgBillList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBillList_CellContentClick);
            // 
            // colCheck
            // 
            this.colCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCheck.HeaderText = "";
            this.colCheck.MinimumWidth = 30;
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCheck.Width = 30;
            // 
            // StockBillingId
            // 
            this.StockBillingId.HeaderText = "库存开单主键ID";
            this.StockBillingId.Name = "StockBillingId";
            this.StockBillingId.ReadOnly = true;
            this.StockBillingId.Visible = false;
            // 
            // OrderName
            // 
            this.OrderName.HeaderText = "单据名称";
            this.OrderName.Name = "OrderName";
            this.OrderName.ReadOnly = true;
            // 
            // order_type_name
            // 
            this.order_type_name.DataPropertyName = "order_type_name";
            this.order_type_name.HeaderText = "单据类型";
            this.order_type_name.Name = "order_type_name";
            this.order_type_name.ReadOnly = true;
            // 
            // order_num
            // 
            this.order_num.DataPropertyName = "order_num";
            this.order_num.HeaderText = "单据号码";
            this.order_num.Name = "order_num";
            this.order_num.ReadOnly = true;
            // 
            // order_date
            // 
            this.order_date.DataPropertyName = "order_date";
            this.order_date.HeaderText = "开单日期";
            this.order_date.Name = "order_date";
            this.order_date.ReadOnly = true;
            // 
            // balance_money
            // 
            this.balance_money.DataPropertyName = "balance_money";
            this.balance_money.HeaderText = "金额";
            this.balance_money.Name = "balance_money";
            this.balance_money.ReadOnly = true;
            // 
            // org_name
            // 
            this.org_name.DataPropertyName = "org_name";
            this.org_name.HeaderText = "部门";
            this.org_name.Name = "org_name";
            this.org_name.ReadOnly = true;
            // 
            // handle_name
            // 
            this.handle_name.DataPropertyName = "handle_name";
            this.handle_name.HeaderText = "经办人";
            this.handle_name.Name = "handle_name";
            this.handle_name.ReadOnly = true;
            // 
            // operator_name
            // 
            this.operator_name.DataPropertyName = "operator_name";
            this.operator_name.HeaderText = "操作人";
            this.operator_name.Name = "operator_name";
            this.operator_name.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // txtparts_name
            // 
            this.txtparts_name.ChooserTypeImage = ServiceStationClient.ComponentUI.TextBox.ChooserType.Part;
            this.txtparts_name.Location = new System.Drawing.Point(319, 74);
            this.txtparts_name.Name = "txtparts_name";
            this.txtparts_name.ReadOnly = false;
            this.txtparts_name.Size = new System.Drawing.Size(143, 24);
            this.txtparts_name.TabIndex = 126;
            this.txtparts_name.ToolTipTitle = "";
            this.txtparts_name.ChooserClick += new System.EventHandler(this.txtparts_name_ChooserClick);
            // 
            // txtparts_code
            // 
            this.txtparts_code.ChooserTypeImage = ServiceStationClient.ComponentUI.TextBox.ChooserType.PartCode;
            this.txtparts_code.Location = new System.Drawing.Point(91, 74);
            this.txtparts_code.Name = "txtparts_code";
            this.txtparts_code.ReadOnly = false;
            this.txtparts_code.Size = new System.Drawing.Size(146, 24);
            this.txtparts_code.TabIndex = 125;
            this.txtparts_code.ToolTipTitle = "";
            this.txtparts_code.ChooserClick += new System.EventHandler(this.txtparts_code_ChooserClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 124;
            this.label4.Text = "配件类别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 123;
            this.label3.Text = "配件名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 122;
            this.label2.Text = "配件编码：";
            // 
            // txtorder_num
            // 
            this.txtorder_num.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtorder_num.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtorder_num.BackColor = System.Drawing.Color.Transparent;
            this.txtorder_num.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtorder_num.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtorder_num.ForeImage = null;
            this.txtorder_num.InputtingVerifyCondition = null;
            this.txtorder_num.Location = new System.Drawing.Point(547, 14);
            this.txtorder_num.MaxLengh = 32767;
            this.txtorder_num.Multiline = false;
            this.txtorder_num.Name = "txtorder_num";
            this.txtorder_num.Radius = 3;
            this.txtorder_num.ReadOnly = false;
            this.txtorder_num.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtorder_num.ShowError = false;
            this.txtorder_num.Size = new System.Drawing.Size(144, 23);
            this.txtorder_num.TabIndex = 121;
            this.txtorder_num.UseSystemPasswordChar = false;
            this.txtorder_num.Value = "";
            this.txtorder_num.VerifyCondition = null;
            this.txtorder_num.VerifyType = null;
            this.txtorder_num.VerifyTypeName = null;
            this.txtorder_num.WaterMark = null;
            this.txtorder_num.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 120;
            this.label5.Text = "单号：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 118;
            this.label7.Text = "查询日期：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 119;
            this.label1.Text = "至";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlhandle
            // 
            this.ddlhandle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ddlhandle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlhandle.FormattingEnabled = true;
            this.ddlhandle.Location = new System.Drawing.Point(319, 45);
            this.ddlhandle.Name = "ddlhandle";
            this.ddlhandle.Size = new System.Drawing.Size(143, 22);
            this.ddlhandle.TabIndex = 115;
            // 
            // ddloperator
            // 
            this.ddloperator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ddloperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddloperator.FormattingEnabled = true;
            this.ddloperator.Location = new System.Drawing.Point(547, 45);
            this.ddloperator.Name = "ddloperator";
            this.ddloperator.Size = new System.Drawing.Size(144, 22);
            this.ddloperator.TabIndex = 114;
            // 
            // ddlorg_id
            // 
            this.ddlorg_id.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ddlorg_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlorg_id.FormattingEnabled = true;
            this.ddlorg_id.Location = new System.Drawing.Point(93, 45);
            this.ddlorg_id.Name = "ddlorg_id";
            this.ddlorg_id.Size = new System.Drawing.Size(144, 22);
            this.ddlorg_id.TabIndex = 113;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(488, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 112;
            this.label9.Text = "操作人：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 111;
            this.label8.Text = "经办人：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 110;
            this.label6.Text = "部门：";
            // 
            // txtparts_type
            // 
            this.txtparts_type.ChooserTypeImage = ServiceStationClient.ComponentUI.TextBox.ChooserType.Part;
            this.txtparts_type.Location = new System.Drawing.Point(547, 74);
            this.txtparts_type.Name = "txtparts_type";
            this.txtparts_type.ReadOnly = false;
            this.txtparts_type.Size = new System.Drawing.Size(143, 24);
            this.txtparts_type.TabIndex = 136;
            this.txtparts_type.ToolTipTitle = "";
            this.txtparts_type.ChooserClick += new System.EventHandler(this.txtparts_type_ChooserClick);
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Caption = "确定";
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.DownImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnOK.Location = new System.Drawing.Point(635, 443);
            this.btnOK.MoveImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormalImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 149;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Caption = "关闭";
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DownImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnClose.Location = new System.Drawing.Point(721, 443);
            this.btnClose.MoveImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnClose.Size = new System.Drawing.Size(80, 24);
            this.btnClose.TabIndex = 150;
            this.btnClose.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // btnNotCheck
            // 
            this.btnNotCheck.BackgroundImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnNotCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNotCheck.Caption = "反选";
            this.btnNotCheck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNotCheck.DownImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnNotCheck.Location = new System.Drawing.Point(549, 443);
            this.btnNotCheck.MoveImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnNotCheck.Name = "btnNotCheck";
            this.btnNotCheck.NormalImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnNotCheck.Size = new System.Drawing.Size(80, 24);
            this.btnNotCheck.TabIndex = 151;
            this.btnNotCheck.Click += new System.EventHandler(this.btnNotCheck_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.BackgroundImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnAllCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAllCheck.Caption = "全选";
            this.btnAllCheck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAllCheck.DownImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnAllCheck.Location = new System.Drawing.Point(463, 443);
            this.btnAllCheck.MoveImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.NormalImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnAllCheck.Size = new System.Drawing.Size(80, 24);
            this.btnAllCheck.TabIndex = 152;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Caption = "查询";
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearch.DownImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnSearch.Location = new System.Drawing.Point(720, 57);
            this.btnSearch.MoveImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NormalImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnSearch.Size = new System.Drawing.Size(80, 24);
            this.btnSearch.TabIndex = 154;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Caption = "清除";
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClear.DownImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnClear.Location = new System.Drawing.Point(720, 16);
            this.btnClear.MoveImage = global::HXCPcClient.Properties.Resources.button_d1;
            this.btnClear.Name = "btnClear";
            this.btnClear.NormalImage = global::HXCPcClient.Properties.Resources.button_n1;
            this.btnClear.Size = new System.Drawing.Size(80, 24);
            this.btnClear.TabIndex = 153;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // UCImportSaleReturnBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 514);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UCImportSaleReturnBilling";
            this.Text = "导入销售退货单";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPartslist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ServiceStationClient.ComponentUI.DateTimePickerEx_sms dateTimeStart;
        private ServiceStationClient.ComponentUI.DateTimePickerEx_sms dateTimeEnd;
        private ServiceStationClient.ComponentUI.DataGridViewEx dgPartslist;
        private ServiceStationClient.ComponentUI.DataGridViewEx dgBillList;
        private ServiceStationClient.ComponentUI.TextBox.TextChooser txtparts_name;
        private ServiceStationClient.ComponentUI.TextBox.TextChooser txtparts_code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ServiceStationClient.ComponentUI.TextBoxEx txtorder_num;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private ServiceStationClient.ComponentUI.ComboBoxEx ddlhandle;
        private ServiceStationClient.ComponentUI.ComboBoxEx ddloperator;
        private ServiceStationClient.ComponentUI.ComboBoxEx ddlorg_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private ServiceStationClient.ComponentUI.TextBox.TextChooser txtparts_type;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockBillingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance_money;
        private System.Windows.Forms.DataGridViewTextBoxColumn org_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn handle_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn operator_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDetailCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartBillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn parts_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn parts_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn drawing_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrigPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusCounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValTogether;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemainCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarPartCode;
        private ServiceStationClient.ComponentUI.ButtonEx btnOK;
        private ServiceStationClient.ComponentUI.ButtonEx btnClose;
        private ServiceStationClient.ComponentUI.ButtonEx btnNotCheck;
        private ServiceStationClient.ComponentUI.ButtonEx btnAllCheck;
        private ServiceStationClient.ComponentUI.ButtonEx btnSearch;
        private ServiceStationClient.ComponentUI.ButtonEx btnClear;

    }
}