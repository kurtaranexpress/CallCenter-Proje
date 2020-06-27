namespace CallCenter
{
    partial class KullaniciCalismalari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciCalismalari));
            this.CAL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CAL_SEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAL_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAL_CALISMAID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grd_list = new DevExpress.XtraGrid.GridControl();
            this.grdview_list = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_kullanici = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buton_duzenle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.buton_sil = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_list)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buton_duzenle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buton_sil)).BeginInit();
            this.SuspendLayout();
            // 
            // CAL_ID
            // 
            this.CAL_ID.Caption = "CK_ID";
            this.CAL_ID.FieldName = "CAL_ID";
            this.CAL_ID.Name = "CAL_ID";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CAL_SEC
            // 
            this.CAL_SEC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAL_SEC.AppearanceHeader.Options.UseFont = true;
            this.CAL_SEC.Caption = "Seç";
            this.CAL_SEC.ColumnEdit = this.repositoryItemCheckEdit1;
            this.CAL_SEC.FieldName = "CAL_SEC";
            this.CAL_SEC.Name = "CAL_SEC";
            this.CAL_SEC.OptionsColumn.FixedWidth = true;
            this.CAL_SEC.Visible = true;
            this.CAL_SEC.VisibleIndex = 0;
            this.CAL_SEC.Width = 30;
            // 
            // CAL_ADI
            // 
            this.CAL_ADI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAL_ADI.AppearanceHeader.Options.UseFont = true;
            this.CAL_ADI.Caption = "Çalışma Adı";
            this.CAL_ADI.FieldName = "CAL_ADI";
            this.CAL_ADI.Name = "CAL_ADI";
            this.CAL_ADI.Visible = true;
            this.CAL_ADI.VisibleIndex = 2;
            this.CAL_ADI.Width = 343;
            // 
            // CAL_CALISMAID
            // 
            this.CAL_CALISMAID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CAL_CALISMAID.AppearanceHeader.Options.UseFont = true;
            this.CAL_CALISMAID.Caption = "Çalışma ID";
            this.CAL_CALISMAID.FieldName = "CAL_CALISMAID";
            this.CAL_CALISMAID.Name = "CAL_CALISMAID";
            this.CAL_CALISMAID.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.CAL_CALISMAID.Visible = true;
            this.CAL_CALISMAID.VisibleIndex = 1;
            this.CAL_CALISMAID.Width = 83;
            // 
            // grd_list
            // 
            this.grd_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_list.Location = new System.Drawing.Point(0, 30);
            this.grd_list.MainView = this.grdview_list;
            this.grd_list.Name = "grd_list";
            this.grd_list.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grd_list.Size = new System.Drawing.Size(474, 516);
            this.grd_list.TabIndex = 55;
            this.grd_list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdview_list});
            // 
            // grdview_list
            // 
            this.grdview_list.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CAL_CALISMAID,
            this.CAL_ADI,
            this.CAL_SEC,
            this.CAL_ID});
            this.grdview_list.CustomizationFormBounds = new System.Drawing.Rectangle(823, 521, 260, 232);
            this.grdview_list.GridControl = this.grd_list;
            this.grdview_list.Name = "grdview_list";
            this.grdview_list.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grdview_list.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.grdview_list.OptionsView.ShowAutoFilterRow = true;
            this.grdview_list.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.grdview_list.OptionsView.ShowViewCaption = true;
            this.grdview_list.ViewCaption = "Çalışmalar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_kaydet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 546);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 56);
            this.panel1.TabIndex = 54;
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kaydet.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_kaydet.Appearance.Options.UseBackColor = true;
            this.btn_kaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_kaydet.ImageOptions.Image")));
            this.btn_kaydet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_kaydet.Location = new System.Drawing.Point(423, 5);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(48, 48);
            this.btn_kaydet.TabIndex = 39;
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // lbl_kullanici
            // 
            this.lbl_kullanici.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kullanici.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_kullanici.Appearance.Options.UseFont = true;
            this.lbl_kullanici.Appearance.Options.UseForeColor = true;
            this.lbl_kullanici.Appearance.Options.UseTextOptions = true;
            this.lbl_kullanici.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_kullanici.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.lbl_kullanici.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_kullanici.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbl_kullanici.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lbl_kullanici.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_kullanici.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_kullanici.Location = new System.Drawing.Point(0, 0);
            this.lbl_kullanici.MinimumSize = new System.Drawing.Size(0, 30);
            this.lbl_kullanici.Name = "lbl_kullanici";
            this.lbl_kullanici.Size = new System.Drawing.Size(474, 30);
            this.lbl_kullanici.TabIndex = 53;
            this.lbl_kullanici.Text = "Kullanıcı: 0001 - abc def";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Gün Başlama Saati";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 63;
            // 
            // buton_duzenle
            // 
            this.buton_duzenle.AutoHeight = false;
            this.buton_duzenle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.buton_duzenle.Name = "buton_duzenle";
            this.buton_duzenle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // buton_sil
            // 
            this.buton_sil.AutoHeight = false;
            this.buton_sil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.buton_sil.Name = "buton_sil";
            this.buton_sil.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // KullaniciCalismalari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 602);
            this.Controls.Add(this.grd_list);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_kullanici);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KullaniciCalismalari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Çalışmaları";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_list)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buton_duzenle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buton_sil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn CAL_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn CAL_SEC;
        private DevExpress.XtraGrid.Columns.GridColumn CAL_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn CAL_CALISMAID;
        private DevExpress.XtraGrid.GridControl grd_list;
        private DevExpress.XtraGrid.Views.Grid.GridView grdview_list;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private DevExpress.XtraEditors.LabelControl lbl_kullanici;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buton_duzenle;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buton_sil;
    }
}