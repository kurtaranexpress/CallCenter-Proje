namespace CallCenter
{
    partial class RandevuEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandevuEkle));
            this.edtLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.lblLabel = new DevExpress.XtraEditors.LabelControl();
            this.tbDescription = new DevExpress.XtraEditors.MemoEdit();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.tbSubject = new DevExpress.XtraEditors.TextEdit();
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.lblEndTime = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.dt_bitis = new DevExpress.XtraEditors.DateEdit();
            this.edtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.edtEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.edtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.edtStartTime = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_bitis.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_bitis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtLabel
            // 
            this.edtLabel.Location = new System.Drawing.Point(93, 36);
            this.edtLabel.Name = "edtLabel";
            this.edtLabel.Properties.AccessibleName = "Label";
            this.edtLabel.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.edtLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtLabel.Size = new System.Drawing.Size(120, 20);
            this.edtLabel.Storage = this.schedulerDataStorage1;
            this.edtLabel.TabIndex = 51;
            // 
            // schedulerDataStorage1
            // 
            // 
            // 
            // 
            this.schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
            // 
            // lblLabel
            // 
            this.lblLabel.AccessibleName = "Label";
            this.lblLabel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblLabel.Appearance.Options.UseBackColor = true;
            this.lblLabel.Location = new System.Drawing.Point(13, 39);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(31, 13);
            this.lblLabel.TabIndex = 50;
            this.lblLabel.Text = "Etiket:";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.EditValue = "";
            this.tbDescription.Location = new System.Drawing.Point(13, 111);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Properties.AccessibleName = "Message";
            this.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.tbDescription.Size = new System.Drawing.Size(496, 223);
            this.tbDescription.TabIndex = 52;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AccessibleName = "Start time";
            this.lblStartTime.Location = new System.Drawing.Point(13, 63);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(72, 13);
            this.lblStartTime.TabIndex = 44;
            this.lblStartTime.Text = "Başlama Tarihi:";
            // 
            // tbSubject
            // 
            this.tbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSubject.EditValue = "";
            this.tbSubject.Location = new System.Drawing.Point(93, 11);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Properties.AccessibleName = "Subject";
            this.tbSubject.Size = new System.Drawing.Size(416, 20);
            this.tbSubject.TabIndex = 43;
            // 
            // lblSubject
            // 
            this.lblSubject.AccessibleName = "Subject";
            this.lblSubject.Location = new System.Drawing.Point(13, 13);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(56, 13);
            this.lblSubject.TabIndex = 42;
            this.lblSubject.Text = "Telefon No:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AccessibleName = "End time";
            this.lblEndTime.Location = new System.Drawing.Point(13, 88);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 13);
            this.lblEndTime.TabIndex = 47;
            this.lblEndTime.Text = "Bitiş Tarihi:";
            // 
            // btnOk
            // 
            this.btnOk.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.Appearance.Options.UseBackColor = true;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOk.Location = new System.Drawing.Point(461, 340);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(48, 48);
            this.btnOk.TabIndex = 54;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dt_bitis
            // 
            this.dt_bitis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_bitis.EditValue = null;
            this.dt_bitis.Location = new System.Drawing.Point(313, 88);
            this.dt_bitis.Name = "dt_bitis";
            this.dt_bitis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt_bitis.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt_bitis.Properties.Mask.EditMask = "g";
            this.dt_bitis.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dt_bitis.Properties.ReadOnly = true;
            this.dt_bitis.Size = new System.Drawing.Size(173, 20);
            this.dt_bitis.TabIndex = 56;
            this.dt_bitis.Visible = false;
            // 
            // edtStartDate
            // 
            this.edtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStartDate.EditValue = new System.DateTime(2019, 2, 19, 0, 0, 0, 0);
            this.edtStartDate.Location = new System.Drawing.Point(93, 62);
            this.edtStartDate.Name = "edtStartDate";
            this.edtStartDate.Properties.AccessibleName = "Start date";
            this.edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.edtStartDate.Size = new System.Drawing.Size(120, 20);
            this.edtStartDate.TabIndex = 57;
            this.edtStartDate.EditValueChanged += new System.EventHandler(this.edtStartDate_EditValueChanged);
            // 
            // edtEndTime
            // 
            this.edtEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEndTime.EditValue = new System.DateTime(2019, 2, 19, 0, 0, 0, 0);
            this.edtEndTime.Location = new System.Drawing.Point(219, 88);
            this.edtEndTime.Name = "edtEndTime";
            this.edtEndTime.Properties.AccessibleName = "End time";
            this.edtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEndTime.Properties.Mask.EditMask = "HH:mm";
            this.edtEndTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtEndTime.Properties.ReadOnly = true;
            this.edtEndTime.Size = new System.Drawing.Size(88, 20);
            this.edtEndTime.TabIndex = 60;
            // 
            // edtEndDate
            // 
            this.edtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEndDate.EditValue = new System.DateTime(2019, 2, 19, 0, 0, 0, 0);
            this.edtEndDate.Location = new System.Drawing.Point(93, 88);
            this.edtEndDate.Name = "edtEndDate";
            this.edtEndDate.Properties.AccessibleName = "End date";
            this.edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEndDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.edtEndDate.Properties.ReadOnly = true;
            this.edtEndDate.Size = new System.Drawing.Size(120, 20);
            this.edtEndDate.TabIndex = 59;
            // 
            // edtStartTime
            // 
            this.edtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStartTime.EditValue = new System.DateTime(2019, 2, 19, 0, 0, 0, 0);
            this.edtStartTime.Location = new System.Drawing.Point(219, 62);
            this.edtStartTime.Name = "edtStartTime";
            this.edtStartTime.Properties.AccessibleName = "Start time";
            this.edtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartTime.Properties.Mask.EditMask = "HH:mm";
            this.edtStartTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtStartTime.Size = new System.Drawing.Size(88, 20);
            this.edtStartTime.TabIndex = 58;
            this.edtStartTime.EditValueChanged += new System.EventHandler(this.edtStartTime_EditValueChanged);
            // 
            // RandevuEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 392);
            this.Controls.Add(this.edtStartDate);
            this.Controls.Add(this.edtEndTime);
            this.Controls.Add(this.edtEndDate);
            this.Controls.Add(this.edtStartTime);
            this.Controls.Add(this.dt_bitis);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.edtLabel);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblEndTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RandevuEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randevu Ekle";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.edtLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_bitis.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_bitis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected DevExpress.XtraEditors.LabelControl lblLabel;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.LabelControl lblSubject;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        public DevExpress.XtraEditors.MemoEdit tbDescription;
        public DevExpress.XtraEditors.TextEdit tbSubject;
        public DevExpress.XtraScheduler.UI.AppointmentLabelEdit edtLabel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.DateEdit dt_bitis;
        public DevExpress.XtraEditors.DateEdit edtStartDate;
        public DevExpress.XtraEditors.TimeEdit edtEndTime;
        public DevExpress.XtraEditors.DateEdit edtEndDate;
        public DevExpress.XtraEditors.TimeEdit edtStartTime;
    }
}