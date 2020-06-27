namespace CallCenter
{
    partial class Cagrilarim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cagrilarim));
            this.btn_yazdir = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dt2 = new DevExpress.XtraEditors.DateEdit();
            this.btn_bul = new DevExpress.XtraEditors.SimpleButton();
            this.dt1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_ses = new DevExpress.XtraEditors.SimpleButton();
            this.grd_list = new DevExpress.XtraGrid.GridControl();
            this.grdview_list = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IST_CALISMAID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAL_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IST_ALTBIRIMNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IST_BIRIMNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAG_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAG_TELNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IST_IL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAG_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAG_SURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ts_cagsure = new DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit();
            this.CK_KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CK_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAG_SANTRALCIKISKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RAN_BASLAMATARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KULADI2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KUL_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
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
            // btn_yazdir
            // 
            this.btn_yazdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_yazdir.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_yazdir.Appearance.Options.UseBackColor = true;
            this.btn_yazdir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_yazdir.ImageOptions.Image")));
            this.btn_yazdir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_yazdir.Location = new System.Drawing.Point(1060, 46);
            this.btn_yazdir.Name = "btn_yazdir";
            this.btn_yazdir.Size = new System.Drawing.Size(24, 24);
            this.btn_yazdir.TabIndex = 16;
            this.btn_yazdir.Click += new System.EventHandler(this.btn_yazdir_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dt2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_bul, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dt1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_ses, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 46);
            this.tableLayoutPanel1.TabIndex = 51;
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
            this.dt2.Size = new System.Drawing.Size(115, 20);
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
            // btn_ses
            // 
            this.btn_ses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ses.ImageOptions.Image = global::CallCenter.Properties.Resources.audiocontent_32x32;
            this.btn_ses.Location = new System.Drawing.Point(1041, 3);
            this.btn_ses.Name = "btn_ses";
            this.btn_ses.Size = new System.Drawing.Size(40, 40);
            this.btn_ses.TabIndex = 21;
            this.btn_ses.ToolTip = "Ses Kayıtları";
            this.btn_ses.Click += new System.EventHandler(this.btn_ses_Click);
            // 
            // grd_list
            // 
            this.grd_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_list.Location = new System.Drawing.Point(0, 46);
            this.grd_list.MainView = this.grdview_list;
            this.grd_list.Name = "grd_list";
            this.grd_list.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ts_cagsure});
            this.grd_list.Size = new System.Drawing.Size(1084, 556);
            this.grd_list.TabIndex = 52;
            this.grd_list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdview_list});
            // 
            // grdview_list
            // 
            this.grdview_list.AppearancePrint.GroupFooter.Options.UseTextOptions = true;
            this.grdview_list.AppearancePrint.GroupFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdview_list.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IST_CALISMAID,
            this.CAL_ADI,
            this.IST_ALTBIRIMNO,
            this.IST_BIRIMNO,
            this.CAG_TARIH,
            this.CAG_TELNO,
            this.IST_IL,
            this.CAG_ACIKLAMA,
            this.CAG_SURE,
            this.CK_KOD,
            this.CK_ACIKLAMA,
            this.CAG_SANTRALCIKISKODU,
            this.RAN_BASLAMATARIH,
            this.KULADI2,
            this.KUL_ADI});
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
            this.grdview_list.ViewCaption = "Çağrılar";
            this.grdview_list.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grdview_list_CustomSummaryCalculate);
            // 
            // IST_CALISMAID
            // 
            this.IST_CALISMAID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IST_CALISMAID.AppearanceHeader.Options.UseFont = true;
            this.IST_CALISMAID.Caption = "Çalışma ID";
            this.IST_CALISMAID.FieldName = "IST_CALISMAID";
            this.IST_CALISMAID.Name = "IST_CALISMAID";
            this.IST_CALISMAID.OptionsColumn.AllowEdit = false;
            this.IST_CALISMAID.OptionsColumn.AllowFocus = false;
            this.IST_CALISMAID.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.IST_CALISMAID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "IST_CALISMAID", "{0}")});
            this.IST_CALISMAID.Visible = true;
            this.IST_CALISMAID.VisibleIndex = 0;
            this.IST_CALISMAID.Width = 59;
            // 
            // CAL_ADI
            // 
            this.CAL_ADI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAL_ADI.AppearanceHeader.Options.UseFont = true;
            this.CAL_ADI.Caption = "Çalışma Adı";
            this.CAL_ADI.FieldName = "CAL_ADI";
            this.CAL_ADI.Name = "CAL_ADI";
            this.CAL_ADI.OptionsColumn.AllowEdit = false;
            this.CAL_ADI.OptionsColumn.AllowFocus = false;
            this.CAL_ADI.Visible = true;
            this.CAL_ADI.VisibleIndex = 1;
            this.CAL_ADI.Width = 67;
            // 
            // IST_ALTBIRIMNO
            // 
            this.IST_ALTBIRIMNO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IST_ALTBIRIMNO.AppearanceHeader.Options.UseFont = true;
            this.IST_ALTBIRIMNO.Caption = "Alt Birim No";
            this.IST_ALTBIRIMNO.FieldName = "IST_ALTBIRIMNO";
            this.IST_ALTBIRIMNO.Name = "IST_ALTBIRIMNO";
            this.IST_ALTBIRIMNO.OptionsColumn.AllowEdit = false;
            this.IST_ALTBIRIMNO.OptionsColumn.AllowFocus = false;
            this.IST_ALTBIRIMNO.OptionsColumn.FixedWidth = true;
            this.IST_ALTBIRIMNO.Visible = true;
            this.IST_ALTBIRIMNO.VisibleIndex = 5;
            this.IST_ALTBIRIMNO.Width = 64;
            // 
            // IST_BIRIMNO
            // 
            this.IST_BIRIMNO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IST_BIRIMNO.AppearanceHeader.Options.UseFont = true;
            this.IST_BIRIMNO.Caption = "Birim No";
            this.IST_BIRIMNO.FieldName = "IST_BIRIMNO";
            this.IST_BIRIMNO.Name = "IST_BIRIMNO";
            this.IST_BIRIMNO.OptionsColumn.AllowEdit = false;
            this.IST_BIRIMNO.OptionsColumn.AllowFocus = false;
            this.IST_BIRIMNO.OptionsColumn.FixedWidth = true;
            this.IST_BIRIMNO.Visible = true;
            this.IST_BIRIMNO.VisibleIndex = 4;
            this.IST_BIRIMNO.Width = 60;
            // 
            // CAG_TARIH
            // 
            this.CAG_TARIH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAG_TARIH.AppearanceHeader.Options.UseFont = true;
            this.CAG_TARIH.Caption = "Tarih";
            this.CAG_TARIH.DisplayFormat.FormatString = "g";
            this.CAG_TARIH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CAG_TARIH.FieldName = "CAG_TARIH";
            this.CAG_TARIH.Name = "CAG_TARIH";
            this.CAG_TARIH.OptionsColumn.AllowEdit = false;
            this.CAG_TARIH.OptionsColumn.AllowFocus = false;
            this.CAG_TARIH.OptionsColumn.FixedWidth = true;
            this.CAG_TARIH.Visible = true;
            this.CAG_TARIH.VisibleIndex = 2;
            this.CAG_TARIH.Width = 100;
            // 
            // CAG_TELNO
            // 
            this.CAG_TELNO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAG_TELNO.AppearanceHeader.Options.UseFont = true;
            this.CAG_TELNO.Caption = "Tel. No";
            this.CAG_TELNO.DisplayFormat.FormatString = "0 999 999 99 99";
            this.CAG_TELNO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.CAG_TELNO.FieldName = "CAG_TELNO";
            this.CAG_TELNO.Name = "CAG_TELNO";
            this.CAG_TELNO.OptionsColumn.AllowEdit = false;
            this.CAG_TELNO.OptionsColumn.AllowFocus = false;
            this.CAG_TELNO.OptionsColumn.FixedWidth = true;
            this.CAG_TELNO.Visible = true;
            this.CAG_TELNO.VisibleIndex = 3;
            this.CAG_TELNO.Width = 70;
            // 
            // IST_IL
            // 
            this.IST_IL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IST_IL.AppearanceHeader.Options.UseFont = true;
            this.IST_IL.Caption = "İl";
            this.IST_IL.FieldName = "IST_IL";
            this.IST_IL.Name = "IST_IL";
            this.IST_IL.OptionsColumn.AllowEdit = false;
            this.IST_IL.OptionsColumn.AllowFocus = false;
            this.IST_IL.OptionsColumn.FixedWidth = true;
            this.IST_IL.Visible = true;
            this.IST_IL.VisibleIndex = 6;
            this.IST_IL.Width = 80;
            // 
            // CAG_ACIKLAMA
            // 
            this.CAG_ACIKLAMA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAG_ACIKLAMA.AppearanceHeader.Options.UseFont = true;
            this.CAG_ACIKLAMA.Caption = "Açıklama";
            this.CAG_ACIKLAMA.FieldName = "CAG_ACIKLAMA";
            this.CAG_ACIKLAMA.Name = "CAG_ACIKLAMA";
            this.CAG_ACIKLAMA.OptionsColumn.AllowEdit = false;
            this.CAG_ACIKLAMA.OptionsColumn.AllowFocus = false;
            this.CAG_ACIKLAMA.Visible = true;
            this.CAG_ACIKLAMA.VisibleIndex = 7;
            this.CAG_ACIKLAMA.Width = 72;
            // 
            // CAG_SURE
            // 
            this.CAG_SURE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAG_SURE.AppearanceHeader.Options.UseFont = true;
            this.CAG_SURE.Caption = "Süre";
            this.CAG_SURE.ColumnEdit = this.ts_cagsure;
            this.CAG_SURE.FieldName = "CAG_SURE";
            this.CAG_SURE.Name = "CAG_SURE";
            this.CAG_SURE.OptionsColumn.AllowEdit = false;
            this.CAG_SURE.OptionsColumn.AllowFocus = false;
            this.CAG_SURE.OptionsColumn.FixedWidth = true;
            this.CAG_SURE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CAG_SURE", "{0:c}", "1")});
            this.CAG_SURE.Visible = true;
            this.CAG_SURE.VisibleIndex = 8;
            this.CAG_SURE.Width = 65;
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
            // CK_KOD
            // 
            this.CK_KOD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CK_KOD.AppearanceHeader.Options.UseFont = true;
            this.CK_KOD.Caption = "Çıkış Kodu";
            this.CK_KOD.FieldName = "CK_KOD";
            this.CK_KOD.Name = "CK_KOD";
            this.CK_KOD.OptionsColumn.AllowEdit = false;
            this.CK_KOD.OptionsColumn.AllowFocus = false;
            this.CK_KOD.OptionsColumn.FixedWidth = true;
            this.CK_KOD.Visible = true;
            this.CK_KOD.VisibleIndex = 9;
            this.CK_KOD.Width = 65;
            // 
            // CK_ACIKLAMA
            // 
            this.CK_ACIKLAMA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CK_ACIKLAMA.AppearanceHeader.Options.UseFont = true;
            this.CK_ACIKLAMA.Caption = "Çıkış Açıklama";
            this.CK_ACIKLAMA.FieldName = "CK_ACIKLAMA";
            this.CK_ACIKLAMA.Name = "CK_ACIKLAMA";
            this.CK_ACIKLAMA.OptionsColumn.AllowEdit = false;
            this.CK_ACIKLAMA.OptionsColumn.AllowFocus = false;
            this.CK_ACIKLAMA.Visible = true;
            this.CK_ACIKLAMA.VisibleIndex = 10;
            this.CK_ACIKLAMA.Width = 67;
            // 
            // CAG_SANTRALCIKISKODU
            // 
            this.CAG_SANTRALCIKISKODU.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAG_SANTRALCIKISKODU.AppearanceHeader.Options.UseFont = true;
            this.CAG_SANTRALCIKISKODU.Caption = "Santral Çıkış Kodu";
            this.CAG_SANTRALCIKISKODU.FieldName = "CAG_SANTRALCIKISKODU";
            this.CAG_SANTRALCIKISKODU.Name = "CAG_SANTRALCIKISKODU";
            this.CAG_SANTRALCIKISKODU.OptionsColumn.AllowEdit = false;
            this.CAG_SANTRALCIKISKODU.OptionsColumn.AllowFocus = false;
            this.CAG_SANTRALCIKISKODU.Visible = true;
            this.CAG_SANTRALCIKISKODU.VisibleIndex = 11;
            this.CAG_SANTRALCIKISKODU.Width = 58;
            // 
            // RAN_BASLAMATARIH
            // 
            this.RAN_BASLAMATARIH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RAN_BASLAMATARIH.AppearanceHeader.Options.UseFont = true;
            this.RAN_BASLAMATARIH.Caption = "Randevu Tarihi";
            this.RAN_BASLAMATARIH.DisplayFormat.FormatString = "g";
            this.RAN_BASLAMATARIH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RAN_BASLAMATARIH.FieldName = "RAN_BASLAMATARIH";
            this.RAN_BASLAMATARIH.Name = "RAN_BASLAMATARIH";
            this.RAN_BASLAMATARIH.OptionsColumn.AllowEdit = false;
            this.RAN_BASLAMATARIH.OptionsColumn.AllowFocus = false;
            this.RAN_BASLAMATARIH.OptionsColumn.FixedWidth = true;
            this.RAN_BASLAMATARIH.Visible = true;
            this.RAN_BASLAMATARIH.VisibleIndex = 12;
            this.RAN_BASLAMATARIH.Width = 100;
            // 
            // KULADI2
            // 
            this.KULADI2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KULADI2.AppearanceHeader.Options.UseFont = true;
            this.KULADI2.Caption = "Kullanıcı (İstek)";
            this.KULADI2.FieldName = "KULADI2";
            this.KULADI2.Name = "KULADI2";
            this.KULADI2.OptionsColumn.AllowEdit = false;
            this.KULADI2.OptionsColumn.AllowFocus = false;
            this.KULADI2.ToolTip = "İsteği Oluşturan Kullanıcı";
            this.KULADI2.Visible = true;
            this.KULADI2.VisibleIndex = 13;
            this.KULADI2.Width = 61;
            // 
            // KUL_ADI
            // 
            this.KUL_ADI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KUL_ADI.AppearanceHeader.Options.UseFont = true;
            this.KUL_ADI.Caption = "Kullanıcı (Arayan)";
            this.KUL_ADI.FieldName = "KUL_ADI";
            this.KUL_ADI.Name = "KUL_ADI";
            this.KUL_ADI.OptionsColumn.AllowEdit = false;
            this.KUL_ADI.OptionsColumn.AllowFocus = false;
            this.KUL_ADI.Visible = true;
            this.KUL_ADI.VisibleIndex = 14;
            this.KUL_ADI.Width = 78;
            // 
            // Cagrilarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 602);
            this.Controls.Add(this.btn_yazdir);
            this.Controls.Add(this.grd_list);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cagrilarim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çağrılar";
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
        private DevExpress.XtraEditors.SimpleButton btn_yazdir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.DateEdit dt2;
        private DevExpress.XtraEditors.SimpleButton btn_bul;
        private DevExpress.XtraEditors.DateEdit dt1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grd_list;
        private DevExpress.XtraGrid.Views.Grid.GridView grdview_list;
        private DevExpress.XtraGrid.Columns.GridColumn IST_CALISMAID;
        private DevExpress.XtraGrid.Columns.GridColumn CAL_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn IST_ALTBIRIMNO;
        private DevExpress.XtraGrid.Columns.GridColumn IST_BIRIMNO;
        private DevExpress.XtraGrid.Columns.GridColumn CAG_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn CAG_TELNO;
        private DevExpress.XtraGrid.Columns.GridColumn IST_IL;
        private DevExpress.XtraGrid.Columns.GridColumn CAG_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn CAG_SURE;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit ts_cagsure;
        private DevExpress.XtraGrid.Columns.GridColumn CK_KOD;
        private DevExpress.XtraGrid.Columns.GridColumn CK_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn CAG_SANTRALCIKISKODU;
        private DevExpress.XtraGrid.Columns.GridColumn RAN_BASLAMATARIH;
        private DevExpress.XtraGrid.Columns.GridColumn KULADI2;
        private DevExpress.XtraGrid.Columns.GridColumn KUL_ADI;
        private DevExpress.XtraEditors.SimpleButton btn_ses;
    }
}