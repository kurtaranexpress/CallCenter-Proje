namespace CallCenter
{
    partial class LogList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dt2 = new DevExpress.XtraEditors.DateEdit();
            this.btn_bul = new DevExpress.XtraEditors.SimpleButton();
            this.dt1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grd_list = new DevExpress.XtraGrid.GridControl();
            this.grdview_list = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LG_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KUL_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_ISLEM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_ISLEMDETAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ts_cagsure = new DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_cagsure)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dt2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_bul, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dt1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(934, 46);
            this.tableLayoutPanel1.TabIndex = 53;
            // 
            // dt2
            // 
            this.dt2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dt2.EditValue = null;
            this.dt2.Location = new System.Drawing.Point(231, 13);
            this.dt2.Name = "dt2";
            this.dt2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt2.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dt2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt2.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "g";
            this.dt2.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dt2.Properties.CalendarTimeProperties.EditFormat.FormatString = "t";
            this.dt2.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dt2.Properties.CalendarTimeProperties.Mask.EditMask = "t";
            this.dt2.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = true;
            this.dt2.Properties.CalendarTimeProperties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal;
            this.dt2.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dt2.Properties.Mask.EditMask = "g";
            this.dt2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dt2.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dt2.Size = new System.Drawing.Size(114, 20);
            this.dt2.TabIndex = 2;
            // 
            // btn_bul
            // 
            this.btn_bul.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_bul.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_bul.Appearance.Options.UseBackColor = true;
            this.btn_bul.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_bul.ImageOptions.Image")));
            this.btn_bul.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_bul.Location = new System.Drawing.Point(358, 7);
            this.btn_bul.Name = "btn_bul";
            this.btn_bul.Size = new System.Drawing.Size(32, 32);
            this.btn_bul.TabIndex = 11;
            this.btn_bul.Click += new System.EventHandler(this.btn_bul_Click);
            // 
            // dt1
            // 
            this.dt1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dt1.EditValue = null;
            this.dt1.Location = new System.Drawing.Point(101, 13);
            this.dt1.Name = "dt1";
            this.dt1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt1.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "g";
            this.dt1.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dt1.Properties.CalendarTimeProperties.EditFormat.FormatString = "t";
            this.dt1.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dt1.Properties.CalendarTimeProperties.Mask.EditMask = "t";
            this.dt1.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = true;
            this.dt1.Properties.Mask.EditMask = "g";
            this.dt1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dt1.Size = new System.Drawing.Size(114, 20);
            this.dt1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(221, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(5, 13);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "-";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(3, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Tarih Aralığı:";
            // 
            // grd_list
            // 
            this.grd_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_list.Location = new System.Drawing.Point(0, 46);
            this.grd_list.MainView = this.grdview_list;
            this.grd_list.Name = "grd_list";
            this.grd_list.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ts_cagsure});
            this.grd_list.Size = new System.Drawing.Size(934, 556);
            this.grd_list.TabIndex = 55;
            this.grd_list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdview_list});
            // 
            // grdview_list
            // 
            this.grdview_list.AppearancePrint.GroupFooter.Options.UseTextOptions = true;
            this.grdview_list.AppearancePrint.GroupFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdview_list.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.LG_TARIH,
            this.KUL_ADI,
            this.LG_ISLEM,
            this.LG_ISLEMDETAY});
            this.grdview_list.CustomizationFormBounds = new System.Drawing.Rectangle(823, 521, 260, 232);
            this.grdview_list.GridControl = this.grd_list;
            this.grdview_list.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CAG_SURE", null, "Toplam Süre: {0:c}", "2"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CAG_SURE", null, "Ort. Süre: {0:c}", "3"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "IST_CALISMAID", null, "Sayı:{0}")});
            this.grdview_list.Name = "grdview_list";
            this.grdview_list.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.grdview_list.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.grdview_list.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.grdview_list.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.grdview_list.OptionsView.ShowAutoFilterRow = true;
            this.grdview_list.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.grdview_list.OptionsView.ShowFooter = true;
            this.grdview_list.OptionsView.ShowGroupedColumns = true;
            this.grdview_list.OptionsView.ShowGroupPanelColumnsAsSingleRow = true;
            this.grdview_list.OptionsView.ShowViewCaption = true;
            this.grdview_list.ViewCaption = "Log Kayıtları";
            // 
            // LG_TARIH
            // 
            this.LG_TARIH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LG_TARIH.AppearanceHeader.Options.UseFont = true;
            this.LG_TARIH.Caption = "Tarih";
            this.LG_TARIH.DisplayFormat.FormatString = "g";
            this.LG_TARIH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.LG_TARIH.FieldName = "LG_TARIH";
            this.LG_TARIH.Name = "LG_TARIH";
            this.LG_TARIH.OptionsColumn.AllowEdit = false;
            this.LG_TARIH.OptionsColumn.AllowFocus = false;
            this.LG_TARIH.OptionsColumn.FixedWidth = true;
            this.LG_TARIH.Visible = true;
            this.LG_TARIH.VisibleIndex = 0;
            this.LG_TARIH.Width = 98;
            // 
            // KUL_ADI
            // 
            this.KUL_ADI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KUL_ADI.AppearanceHeader.Options.UseFont = true;
            this.KUL_ADI.Caption = "Kullanıcı";
            this.KUL_ADI.FieldName = "KUL_ADI";
            this.KUL_ADI.Name = "KUL_ADI";
            this.KUL_ADI.OptionsColumn.AllowEdit = false;
            this.KUL_ADI.OptionsColumn.AllowFocus = false;
            this.KUL_ADI.OptionsColumn.FixedWidth = true;
            this.KUL_ADI.Visible = true;
            this.KUL_ADI.VisibleIndex = 1;
            this.KUL_ADI.Width = 80;
            // 
            // LG_ISLEM
            // 
            this.LG_ISLEM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LG_ISLEM.AppearanceHeader.Options.UseFont = true;
            this.LG_ISLEM.Caption = "İşlem";
            this.LG_ISLEM.FieldName = "LG_ISLEM";
            this.LG_ISLEM.Name = "LG_ISLEM";
            this.LG_ISLEM.OptionsColumn.AllowEdit = false;
            this.LG_ISLEM.OptionsColumn.AllowFocus = false;
            this.LG_ISLEM.Visible = true;
            this.LG_ISLEM.VisibleIndex = 2;
            this.LG_ISLEM.Width = 149;
            // 
            // LG_ISLEMDETAY
            // 
            this.LG_ISLEMDETAY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LG_ISLEMDETAY.AppearanceHeader.Options.UseFont = true;
            this.LG_ISLEMDETAY.Caption = "İşlem Detay";
            this.LG_ISLEMDETAY.FieldName = "LG_ISLEMDETAY";
            this.LG_ISLEMDETAY.Name = "LG_ISLEMDETAY";
            this.LG_ISLEMDETAY.OptionsColumn.AllowEdit = false;
            this.LG_ISLEMDETAY.OptionsColumn.AllowFocus = false;
            this.LG_ISLEMDETAY.Visible = true;
            this.LG_ISLEMDETAY.VisibleIndex = 3;
            this.LG_ISLEMDETAY.Width = 589;
            // 
            // ts_cagsure
            // 
            this.ts_cagsure.AutoHeight = false;
            this.ts_cagsure.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ts_cagsure.Mask.EditMask = "HH:mm:ss";
            this.ts_cagsure.Mask.UseMaskAsDisplayFormat = true;
            this.ts_cagsure.Name = "ts_cagsure";
            // 
            // LogList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 602);
            this.Controls.Add(this.grd_list);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Kayıtları";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_cagsure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.DateEdit dt2;
        private DevExpress.XtraEditors.SimpleButton btn_bul;
        private DevExpress.XtraEditors.DateEdit dt1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grd_list;
        private DevExpress.XtraGrid.Views.Grid.GridView grdview_list;
        private DevExpress.XtraGrid.Columns.GridColumn LG_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn KUL_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn LG_ISLEM;
        private DevExpress.XtraGrid.Columns.GridColumn LG_ISLEMDETAY;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit ts_cagsure;
    }
}