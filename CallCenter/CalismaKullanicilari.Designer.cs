namespace CallCenter
{
    partial class CalismaKullanicilari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalismaKullanicilari));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grd_list = new DevExpress.XtraGrid.GridControl();
            this.grdview_list = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KUL_KULLANICIID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KUL_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ROL_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button_duzenle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.button_sil = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.button_calismaaraliklari = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.button_aktifperiyotlari = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lbl_calisma = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_duzenle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_sil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_calismaaraliklari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_aktifperiyotlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_list
            // 
            this.grd_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_list.Location = new System.Drawing.Point(0, 30);
            this.grd_list.MainView = this.grdview_list;
            this.grd_list.Name = "grd_list";
            this.grd_list.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.button_duzenle,
            this.button_sil,
            this.button_calismaaraliklari,
            this.button_aktifperiyotlari,
            this.repositoryItemCheckEdit1});
            this.grd_list.Size = new System.Drawing.Size(474, 572);
            this.grd_list.TabIndex = 54;
            this.grd_list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdview_list});
            // 
            // grdview_list
            // 
            this.grdview_list.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KUL_KULLANICIID,
            this.KUL_ADI,
            this.CK_ID,
            this.ROL_ADI});
            this.grdview_list.CustomizationFormBounds = new System.Drawing.Rectangle(823, 521, 260, 232);
            this.grdview_list.GridControl = this.grd_list;
            this.grdview_list.Name = "grdview_list";
            this.grdview_list.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grdview_list.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.grdview_list.OptionsView.ShowAutoFilterRow = true;
            this.grdview_list.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.grdview_list.OptionsView.ShowViewCaption = true;
            this.grdview_list.ViewCaption = "Kullanıcılar";
            // 
            // KUL_KULLANICIID
            // 
            this.KUL_KULLANICIID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KUL_KULLANICIID.AppearanceHeader.Options.UseFont = true;
            this.KUL_KULLANICIID.Caption = "Kullanıcı ID";
            this.KUL_KULLANICIID.FieldName = "KUL_KULLANICIID";
            this.KUL_KULLANICIID.Name = "KUL_KULLANICIID";
            this.KUL_KULLANICIID.OptionsColumn.AllowEdit = false;
            this.KUL_KULLANICIID.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.KUL_KULLANICIID.Visible = true;
            this.KUL_KULLANICIID.VisibleIndex = 0;
            this.KUL_KULLANICIID.Width = 83;
            // 
            // KUL_ADI
            // 
            this.KUL_ADI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KUL_ADI.AppearanceHeader.Options.UseFont = true;
            this.KUL_ADI.Caption = "Kullanıcı Adı";
            this.KUL_ADI.FieldName = "KUL_ADI";
            this.KUL_ADI.Name = "KUL_ADI";
            this.KUL_ADI.OptionsColumn.AllowEdit = false;
            this.KUL_ADI.Visible = true;
            this.KUL_ADI.VisibleIndex = 1;
            this.KUL_ADI.Width = 343;
            // 
            // CK_ID
            // 
            this.CK_ID.Caption = "CK_ID";
            this.CK_ID.FieldName = "CK_ID";
            this.CK_ID.Name = "CK_ID";
            // 
            // ROL_ADI
            // 
            this.ROL_ADI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ROL_ADI.AppearanceHeader.Options.UseFont = true;
            this.ROL_ADI.Caption = "Rolü";
            this.ROL_ADI.FieldName = "ROL_ADI";
            this.ROL_ADI.Name = "ROL_ADI";
            this.ROL_ADI.OptionsColumn.AllowEdit = false;
            this.ROL_ADI.Visible = true;
            this.ROL_ADI.VisibleIndex = 2;
            // 
            // button_duzenle
            // 
            this.button_duzenle.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.button_duzenle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.button_duzenle.Name = "button_duzenle";
            this.button_duzenle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // button_sil
            // 
            this.button_sil.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.button_sil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.button_sil.Name = "button_sil";
            this.button_sil.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // button_calismaaraliklari
            // 
            this.button_calismaaraliklari.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.button_calismaaraliklari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.button_calismaaraliklari.Name = "button_calismaaraliklari";
            this.button_calismaaraliklari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // button_aktifperiyotlari
            // 
            this.button_aktifperiyotlari.AutoHeight = false;
            editorButtonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions4.Image")));
            this.button_aktifperiyotlari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.button_aktifperiyotlari.Name = "button_aktifperiyotlari";
            this.button_aktifperiyotlari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // lbl_calisma
            // 
            this.lbl_calisma.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_calisma.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_calisma.Appearance.Options.UseFont = true;
            this.lbl_calisma.Appearance.Options.UseForeColor = true;
            this.lbl_calisma.Appearance.Options.UseTextOptions = true;
            this.lbl_calisma.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_calisma.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.lbl_calisma.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_calisma.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbl_calisma.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lbl_calisma.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_calisma.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_calisma.Location = new System.Drawing.Point(0, 0);
            this.lbl_calisma.MinimumSize = new System.Drawing.Size(0, 30);
            this.lbl_calisma.Name = "lbl_calisma";
            this.lbl_calisma.Size = new System.Drawing.Size(474, 30);
            this.lbl_calisma.TabIndex = 53;
            this.lbl_calisma.Text = "Çalışma: ABC000123 - İSTİHDAM ORANI";
            // 
            // CalismaKullanicilari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 602);
            this.Controls.Add(this.grd_list);
            this.Controls.Add(this.lbl_calisma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalismaKullanicilari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çalışma Kullanıcıları";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_duzenle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_sil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_calismaaraliklari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_aktifperiyotlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grd_list;
        private DevExpress.XtraGrid.Views.Grid.GridView grdview_list;
        private DevExpress.XtraGrid.Columns.GridColumn KUL_KULLANICIID;
        private DevExpress.XtraGrid.Columns.GridColumn KUL_ADI;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn CK_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit button_duzenle;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit button_sil;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit button_calismaaraliklari;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit button_aktifperiyotlari;
        private DevExpress.XtraEditors.LabelControl lbl_calisma;
        private DevExpress.XtraGrid.Columns.GridColumn ROL_ADI;
    }
}