namespace CallCenter
{
    partial class IstekGonder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IstekGonder));
            this.cmb_calismaid = new DevExpress.XtraEditors.LookUpEdit();
            this.cmb_kulid = new DevExpress.XtraEditors.LookUpEdit();
            this.lbl_kullaniciid = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_brmno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_altbrmno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txt_il = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txt_aciklama = new DevExpress.XtraEditors.MemoEdit();
            this.txt_randevutercih = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            this.rd_randevu = new System.Windows.Forms.RadioButton();
            this.rd_cagri = new System.Windows.Forms.RadioButton();
            this.txt_tel = new DevExpress.XtraEditors.TextEdit();
            this.txt_hafta = new DevExpress.XtraEditors.SpinEdit();
            this.txt_ay = new DevExpress.XtraEditors.SpinEdit();
            this.txt_donem = new DevExpress.XtraEditors.SpinEdit();
            this.txt_yil = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_calismaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_kulid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_brmno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_altbrmno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_il.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_randevutercih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_hafta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_donem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_yil.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_yil.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_calismaid
            // 
            this.cmb_calismaid.Location = new System.Drawing.Point(123, 35);
            this.cmb_calismaid.Name = "cmb_calismaid";
            this.cmb_calismaid.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmb_calismaid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_calismaid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CAL_CALISMAID", "Çalışma ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("study_id", "Çalışma ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CAL_ADI", "Çalışma Adı"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("study_name", "Çalışma Adı")});
            this.cmb_calismaid.Properties.NullText = "";
            this.cmb_calismaid.Size = new System.Drawing.Size(172, 20);
            this.cmb_calismaid.TabIndex = 1;
            // 
            // cmb_kulid
            // 
            this.cmb_kulid.Location = new System.Drawing.Point(123, 9);
            this.cmb_kulid.Name = "cmb_kulid";
            this.cmb_kulid.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmb_kulid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_kulid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tc_kimlik_no", "Kullanıcı ID")});
            this.cmb_kulid.Properties.NullText = "";
            this.cmb_kulid.Size = new System.Drawing.Size(172, 20);
            this.cmb_kulid.TabIndex = 0;
            // 
            // lbl_kullaniciid
            // 
            this.lbl_kullaniciid.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kullaniciid.Appearance.Options.UseFont = true;
            this.lbl_kullaniciid.Location = new System.Drawing.Point(15, 12);
            this.lbl_kullaniciid.Name = "lbl_kullaniciid";
            this.lbl_kullaniciid.Size = new System.Drawing.Size(65, 13);
            this.lbl_kullaniciid.TabIndex = 135;
            this.lbl_kullaniciid.Text = "Kullanıcı ID:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(15, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 136;
            this.labelControl1.Text = "Çalışma ID:";
            // 
            // txt_brmno
            // 
            this.txt_brmno.Location = new System.Drawing.Point(123, 61);
            this.txt_brmno.Name = "txt_brmno";
            this.txt_brmno.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_brmno.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_brmno.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txt_brmno.Size = new System.Drawing.Size(172, 20);
            this.txt_brmno.TabIndex = 2;
            this.txt_brmno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_brmno_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(15, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 138;
            this.labelControl3.Text = "Birim No:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(15, 90);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 13);
            this.labelControl4.TabIndex = 140;
            this.labelControl4.Text = "Alt Birim No:";
            // 
            // txt_altbrmno
            // 
            this.txt_altbrmno.EditValue = "";
            this.txt_altbrmno.Location = new System.Drawing.Point(123, 87);
            this.txt_altbrmno.Name = "txt_altbrmno";
            this.txt_altbrmno.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_altbrmno.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_altbrmno.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txt_altbrmno.Size = new System.Drawing.Size(172, 20);
            this.txt_altbrmno.TabIndex = 3;
            this.txt_altbrmno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_altbrmno_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(15, 116);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(41, 13);
            this.labelControl5.TabIndex = 142;
            this.labelControl5.Text = "Ref. Yıl:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(15, 142);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(68, 13);
            this.labelControl6.TabIndex = 144;
            this.labelControl6.Text = "Ref. Dönem:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(15, 168);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(43, 13);
            this.labelControl7.TabIndex = 146;
            this.labelControl7.Text = "Ref. Ay:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(15, 194);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(59, 13);
            this.labelControl8.TabIndex = 148;
            this.labelControl8.Text = "Ref. Hafta:";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(15, 218);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(42, 13);
            this.labelControl9.TabIndex = 150;
            this.labelControl9.Text = "Telefon";
            // 
            // txt_il
            // 
            this.txt_il.Location = new System.Drawing.Point(123, 243);
            this.txt_il.Name = "txt_il";
            this.txt_il.Properties.MaxLength = 255;
            this.txt_il.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_il.Size = new System.Drawing.Size(172, 20);
            this.txt_il.TabIndex = 9;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(15, 244);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(11, 13);
            this.labelControl10.TabIndex = 152;
            this.labelControl10.Text = "İl:";
            // 
            // txt_aciklama
            // 
            this.txt_aciklama.Location = new System.Drawing.Point(123, 269);
            this.txt_aciklama.Name = "txt_aciklama";
            this.txt_aciklama.Properties.MaxLength = 255;
            this.txt_aciklama.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_aciklama.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_aciklama.Size = new System.Drawing.Size(172, 48);
            this.txt_aciklama.TabIndex = 10;
            // 
            // txt_randevutercih
            // 
            this.txt_randevutercih.Location = new System.Drawing.Point(123, 323);
            this.txt_randevutercih.Name = "txt_randevutercih";
            this.txt_randevutercih.Properties.MaxLength = 255;
            this.txt_randevutercih.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_randevutercih.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_randevutercih.Size = new System.Drawing.Size(172, 48);
            this.txt_randevutercih.TabIndex = 11;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(15, 271);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(55, 13);
            this.labelControl11.TabIndex = 155;
            this.labelControl11.Text = "Açıklama:";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(15, 324);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(91, 13);
            this.labelControl12.TabIndex = 156;
            this.labelControl12.Text = "Randevu Tercih:";
            // 
            // btn_ok
            // 
            this.btn_ok.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_ok.Appearance.Options.UseBackColor = true;
            this.btn_ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.ImageOptions.Image")));
            this.btn_ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_ok.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_ok.ImageOptions.SvgImage")));
            this.btn_ok.Location = new System.Drawing.Point(123, 413);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(172, 30);
            this.btn_ok.TabIndex = 14;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // rd_randevu
            // 
            this.rd_randevu.AutoSize = true;
            this.rd_randevu.Location = new System.Drawing.Point(226, 380);
            this.rd_randevu.Name = "rd_randevu";
            this.rd_randevu.Size = new System.Drawing.Size(69, 17);
            this.rd_randevu.TabIndex = 13;
            this.rd_randevu.Text = "Randevu";
            this.rd_randevu.UseVisualStyleBackColor = true;
            // 
            // rd_cagri
            // 
            this.rd_cagri.AutoSize = true;
            this.rd_cagri.Checked = true;
            this.rd_cagri.Location = new System.Drawing.Point(123, 380);
            this.rd_cagri.Name = "rd_cagri";
            this.rd_cagri.Size = new System.Drawing.Size(49, 17);
            this.rd_cagri.TabIndex = 12;
            this.rd_cagri.TabStop = true;
            this.rd_cagri.Text = "Çağrı";
            this.rd_cagri.UseVisualStyleBackColor = true;
            // 
            // txt_tel
            // 
            this.txt_tel.EditValue = "";
            this.txt_tel.Location = new System.Drawing.Point(123, 217);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_tel.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_tel.Properties.Mask.EditMask = "0 999 999 99 99";
            this.txt_tel.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txt_tel.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txt_tel.Size = new System.Drawing.Size(172, 20);
            this.txt_tel.TabIndex = 8;
            this.txt_tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tel_KeyPress);
            // 
            // txt_hafta
            // 
            this.txt_hafta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_hafta.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_hafta.Location = new System.Drawing.Point(123, 191);
            this.txt_hafta.Name = "txt_hafta";
            this.txt_hafta.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txt_hafta.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_hafta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_hafta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_hafta.Properties.Mask.EditMask = "d";
            this.txt_hafta.Properties.MaxValue = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.txt_hafta.Size = new System.Drawing.Size(172, 20);
            this.txt_hafta.TabIndex = 7;
            // 
            // txt_ay
            // 
            this.txt_ay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ay.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_ay.Location = new System.Drawing.Point(123, 165);
            this.txt_ay.Name = "txt_ay";
            this.txt_ay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txt_ay.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_ay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_ay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_ay.Properties.Mask.EditMask = "d";
            this.txt_ay.Properties.MaxValue = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txt_ay.Size = new System.Drawing.Size(172, 20);
            this.txt_ay.TabIndex = 6;
            // 
            // txt_donem
            // 
            this.txt_donem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_donem.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_donem.Location = new System.Drawing.Point(123, 139);
            this.txt_donem.Name = "txt_donem";
            this.txt_donem.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txt_donem.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_donem.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_donem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_donem.Properties.Mask.EditMask = "d";
            this.txt_donem.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txt_donem.Size = new System.Drawing.Size(172, 20);
            this.txt_donem.TabIndex = 5;
            // 
            // txt_yil
            // 
            this.txt_yil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_yil.EditValue = null;
            this.txt_yil.Location = new System.Drawing.Point(123, 113);
            this.txt_yil.Name = "txt_yil";
            this.txt_yil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_yil.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_yil.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy";
            this.txt_yil.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txt_yil.Properties.CalendarTimeProperties.EditFormat.FormatString = "yyyy";
            this.txt_yil.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txt_yil.Properties.CalendarTimeProperties.Mask.EditMask = "yyyy";
            this.txt_yil.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = true;
            this.txt_yil.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.txt_yil.Properties.DisplayFormat.FormatString = "yyyy";
            this.txt_yil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txt_yil.Properties.EditFormat.FormatString = "yyyy";
            this.txt_yil.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txt_yil.Properties.Mask.EditMask = "yyyy";
            this.txt_yil.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txt_yil.Properties.ShowToday = false;
            this.txt_yil.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.txt_yil.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.txt_yil.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.txt_yil.Size = new System.Drawing.Size(172, 20);
            this.txt_yil.TabIndex = 4;
            // 
            // IstekGonder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 454);
            this.Controls.Add(this.txt_yil);
            this.Controls.Add(this.txt_hafta);
            this.Controls.Add(this.txt_ay);
            this.Controls.Add(this.txt_donem);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.rd_cagri);
            this.Controls.Add(this.rd_randevu);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txt_randevutercih);
            this.Controls.Add(this.txt_aciklama);
            this.Controls.Add(this.txt_il);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_altbrmno);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_brmno);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lbl_kullaniciid);
            this.Controls.Add(this.cmb_kulid);
            this.Controls.Add(this.cmb_calismaid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IstekGonder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İstek Gönder";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.cmb_calismaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_kulid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_brmno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_altbrmno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_il.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_randevutercih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_hafta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_donem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_yil.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_yil.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cmb_calismaid;
        private DevExpress.XtraEditors.LookUpEdit cmb_kulid;
        private DevExpress.XtraEditors.LabelControl lbl_kullaniciid;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_brmno;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_altbrmno;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit txt_il;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.MemoEdit txt_aciklama;
        private DevExpress.XtraEditors.MemoEdit txt_randevutercih;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btn_ok;
        private System.Windows.Forms.RadioButton rd_randevu;
        private System.Windows.Forms.RadioButton rd_cagri;
        private DevExpress.XtraEditors.TextEdit txt_tel;
        public DevExpress.XtraEditors.SpinEdit txt_hafta;
        public DevExpress.XtraEditors.SpinEdit txt_ay;
        public DevExpress.XtraEditors.SpinEdit txt_donem;
        private DevExpress.XtraEditors.DateEdit txt_yil;
    }
}