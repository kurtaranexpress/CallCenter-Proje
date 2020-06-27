namespace CallCenter
{
    partial class RandevularBekleyen
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandevularBekleyen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grd_list = new DevExpress.XtraGrid.GridControl();
            this.grdview_list = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KUL_KULLANICIID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAL_CALISMAID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAL_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IST_ALTBIRIMNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IST_BIRIMNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RAN_BASLAMATARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RAN_BITISTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IST_TELNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IST_IL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RAN_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RAN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RAN_IST_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.COLARA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonARA = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btn_yenile = new DevExpress.XtraEditors.SimpleButton();
            this.btn_yazdir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonARA)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_list
            // 
            this.grd_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_list.Location = new System.Drawing.Point(0, 0);
            this.grd_list.MainView = this.grdview_list;
            this.grd_list.Name = "grd_list";
            this.grd_list.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.buttonARA});
            this.grd_list.Size = new System.Drawing.Size(934, 602);
            this.grd_list.TabIndex = 15;
            this.grd_list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdview_list});
            // 
            // grdview_list
            // 
            this.grdview_list.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.grdview_list.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.grdview_list.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Transparent;
            this.grdview_list.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdview_list.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdview_list.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.grdview_list.Appearance.FocusedRow.Options.UseFont = true;
            this.grdview_list.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.grdview_list.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdview_list.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KUL_KULLANICIID,
            this.CAL_CALISMAID,
            this.CAL_ADI,
            this.IST_ALTBIRIMNO,
            this.IST_BIRIMNO,
            this.RAN_BASLAMATARIH,
            this.RAN_BITISTARIH,
            this.IST_TELNO,
            this.IST_IL,
            this.RAN_ACIKLAMA,
            this.RAN_ID,
            this.RAN_IST_ID,
            this.COLARA});
            this.grdview_list.CustomizationFormBounds = new System.Drawing.Rectangle(823, 521, 260, 232);
            this.grdview_list.GridControl = this.grd_list;
            this.grdview_list.Name = "grdview_list";
            this.grdview_list.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grdview_list.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.grdview_list.OptionsView.ShowAutoFilterRow = true;
            this.grdview_list.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.grdview_list.OptionsView.ShowFooter = true;
            this.grdview_list.OptionsView.ShowViewCaption = true;
            this.grdview_list.ViewCaption = "Randevular";
            // 
            // KUL_KULLANICIID
            // 
            this.KUL_KULLANICIID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KUL_KULLANICIID.AppearanceHeader.Options.UseFont = true;
            this.KUL_KULLANICIID.Caption = "Kullanıcı ID";
            this.KUL_KULLANICIID.FieldName = "KUL_KULLANICIID";
            this.KUL_KULLANICIID.Name = "KUL_KULLANICIID";
            this.KUL_KULLANICIID.OptionsColumn.AllowFocus = false;
            this.KUL_KULLANICIID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "KUL_KULLANICIID", "{0}")});
            this.KUL_KULLANICIID.Visible = true;
            this.KUL_KULLANICIID.VisibleIndex = 0;
            this.KUL_KULLANICIID.Width = 69;
            // 
            // CAL_CALISMAID
            // 
            this.CAL_CALISMAID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAL_CALISMAID.AppearanceHeader.Options.UseFont = true;
            this.CAL_CALISMAID.Caption = "Çalışma ID";
            this.CAL_CALISMAID.FieldName = "CAL_CALISMAID";
            this.CAL_CALISMAID.Name = "CAL_CALISMAID";
            this.CAL_CALISMAID.OptionsColumn.AllowEdit = false;
            this.CAL_CALISMAID.OptionsColumn.AllowFocus = false;
            this.CAL_CALISMAID.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.CAL_CALISMAID.Visible = true;
            this.CAL_CALISMAID.VisibleIndex = 1;
            this.CAL_CALISMAID.Width = 68;
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
            this.CAL_ADI.VisibleIndex = 2;
            this.CAL_ADI.Width = 76;
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
            this.IST_ALTBIRIMNO.Visible = true;
            this.IST_ALTBIRIMNO.VisibleIndex = 6;
            this.IST_ALTBIRIMNO.Width = 91;
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
            this.IST_BIRIMNO.Visible = true;
            this.IST_BIRIMNO.VisibleIndex = 7;
            this.IST_BIRIMNO.Width = 61;
            // 
            // RAN_BASLAMATARIH
            // 
            this.RAN_BASLAMATARIH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RAN_BASLAMATARIH.AppearanceHeader.Options.UseFont = true;
            this.RAN_BASLAMATARIH.Caption = "Baş. Tarih";
            this.RAN_BASLAMATARIH.DisplayFormat.FormatString = "g";
            this.RAN_BASLAMATARIH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RAN_BASLAMATARIH.FieldName = "RAN_BASLAMATARIH";
            this.RAN_BASLAMATARIH.Name = "RAN_BASLAMATARIH";
            this.RAN_BASLAMATARIH.OptionsColumn.AllowEdit = false;
            this.RAN_BASLAMATARIH.OptionsColumn.AllowFocus = false;
            this.RAN_BASLAMATARIH.Visible = true;
            this.RAN_BASLAMATARIH.VisibleIndex = 3;
            this.RAN_BASLAMATARIH.Width = 97;
            // 
            // RAN_BITISTARIH
            // 
            this.RAN_BITISTARIH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RAN_BITISTARIH.AppearanceHeader.Options.UseFont = true;
            this.RAN_BITISTARIH.Caption = "Bitiş Tarih";
            this.RAN_BITISTARIH.DisplayFormat.FormatString = "g";
            this.RAN_BITISTARIH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RAN_BITISTARIH.FieldName = "RAN_BITISTARIH";
            this.RAN_BITISTARIH.Name = "RAN_BITISTARIH";
            this.RAN_BITISTARIH.OptionsColumn.AllowFocus = false;
            this.RAN_BITISTARIH.Visible = true;
            this.RAN_BITISTARIH.VisibleIndex = 4;
            this.RAN_BITISTARIH.Width = 97;
            // 
            // IST_TELNO
            // 
            this.IST_TELNO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IST_TELNO.AppearanceHeader.Options.UseFont = true;
            this.IST_TELNO.Caption = "Tel. No";
            this.IST_TELNO.DisplayFormat.FormatString = "(999) 000 00 00";
            this.IST_TELNO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.IST_TELNO.FieldName = "IST_TELNO";
            this.IST_TELNO.Name = "IST_TELNO";
            this.IST_TELNO.OptionsColumn.AllowEdit = false;
            this.IST_TELNO.OptionsColumn.AllowFocus = false;
            this.IST_TELNO.Visible = true;
            this.IST_TELNO.VisibleIndex = 5;
            this.IST_TELNO.Width = 90;
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
            this.IST_IL.Visible = true;
            this.IST_IL.VisibleIndex = 8;
            this.IST_IL.Width = 51;
            // 
            // RAN_ACIKLAMA
            // 
            this.RAN_ACIKLAMA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RAN_ACIKLAMA.AppearanceHeader.Options.UseFont = true;
            this.RAN_ACIKLAMA.Caption = "Açıklama";
            this.RAN_ACIKLAMA.FieldName = "RAN_ACIKLAMA";
            this.RAN_ACIKLAMA.Name = "RAN_ACIKLAMA";
            this.RAN_ACIKLAMA.OptionsColumn.AllowEdit = false;
            this.RAN_ACIKLAMA.OptionsColumn.AllowFocus = false;
            this.RAN_ACIKLAMA.Visible = true;
            this.RAN_ACIKLAMA.VisibleIndex = 9;
            this.RAN_ACIKLAMA.Width = 139;
            // 
            // RAN_ID
            // 
            this.RAN_ID.Caption = "RAN_ID";
            this.RAN_ID.FieldName = "RAN_ID";
            this.RAN_ID.Name = "RAN_ID";
            // 
            // RAN_IST_ID
            // 
            this.RAN_IST_ID.Caption = "RAN_IST_ID";
            this.RAN_IST_ID.FieldName = "RAN_IST_ID";
            this.RAN_IST_ID.Name = "RAN_IST_ID";
            // 
            // COLARA
            // 
            this.COLARA.ColumnEdit = this.buttonARA;
            this.COLARA.Name = "COLARA";
            this.COLARA.OptionsColumn.FixedWidth = true;
            this.COLARA.Visible = true;
            this.COLARA.VisibleIndex = 10;
            this.COLARA.Width = 50;
            // 
            // buttonARA
            // 
            this.buttonARA.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.buttonARA.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.buttonARA.Name = "buttonARA";
            this.buttonARA.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.buttonARA.Click += new System.EventHandler(this.buttonARA_Click);
            // 
            // btn_yenile
            // 
            this.btn_yenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_yenile.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_yenile.Appearance.Options.UseBackColor = true;
            this.btn_yenile.ImageOptions.Image = global::CallCenter.Properties.Resources.refresh_16x16;
            this.btn_yenile.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_yenile.Location = new System.Drawing.Point(0, 0);
            this.btn_yenile.Name = "btn_yenile";
            this.btn_yenile.Size = new System.Drawing.Size(24, 24);
            this.btn_yenile.TabIndex = 16;
            this.btn_yenile.ToolTip = "Sayfayı Yenile";
            this.btn_yenile.Click += new System.EventHandler(this.btn_yenile_Click);
            // 
            // btn_yazdir
            // 
            this.btn_yazdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_yazdir.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_yazdir.Appearance.Options.UseBackColor = true;
            this.btn_yazdir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_yazdir.ImageOptions.Image")));
            this.btn_yazdir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_yazdir.Location = new System.Drawing.Point(910, 0);
            this.btn_yazdir.Name = "btn_yazdir";
            this.btn_yazdir.Size = new System.Drawing.Size(24, 24);
            this.btn_yazdir.TabIndex = 17;
            this.btn_yazdir.Click += new System.EventHandler(this.btn_yazdir_Click);
            // 
            // RandevularBekleyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 602);
            this.Controls.Add(this.btn_yazdir);
            this.Controls.Add(this.btn_yenile);
            this.Controls.Add(this.grd_list);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RandevularBekleyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bekleyen Randevular";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonARA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grd_list;
        private DevExpress.XtraGrid.Views.Grid.GridView grdview_list;
        private DevExpress.XtraGrid.Columns.GridColumn KUL_KULLANICIID;
        private DevExpress.XtraGrid.Columns.GridColumn CAL_CALISMAID;
        private DevExpress.XtraGrid.Columns.GridColumn CAL_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn IST_ALTBIRIMNO;
        private DevExpress.XtraGrid.Columns.GridColumn IST_BIRIMNO;
        private DevExpress.XtraGrid.Columns.GridColumn RAN_BASLAMATARIH;
        private DevExpress.XtraGrid.Columns.GridColumn RAN_BITISTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn IST_TELNO;
        private DevExpress.XtraGrid.Columns.GridColumn IST_IL;
        private DevExpress.XtraGrid.Columns.GridColumn RAN_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn RAN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn RAN_IST_ID;
        private DevExpress.XtraGrid.Columns.GridColumn COLARA;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonARA;
        public DevExpress.XtraEditors.SimpleButton btn_yenile;
        private DevExpress.XtraEditors.SimpleButton btn_yazdir;
    }
}