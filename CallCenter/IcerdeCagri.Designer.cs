namespace CallCenter
{
    partial class IcerdeCagri
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
            this.cmb_kulid = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_kulid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_kulid
            // 
            this.cmb_kulid.Location = new System.Drawing.Point(6, 9);
            this.cmb_kulid.Name = "cmb_kulid";
            this.cmb_kulid.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmb_kulid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_kulid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KUL_ADI", "Kullanıcı Adı"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KUL_SANTRALUSERID", "Santral Kodu")});
            this.cmb_kulid.Properties.NullText = "";
            this.cmb_kulid.Size = new System.Drawing.Size(250, 20);
            this.cmb_kulid.TabIndex = 69;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.Appearance.Options.UseBackColor = true;
            this.buttonCancel.Appearance.Options.UseTextOptions = true;
            this.buttonCancel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonCancel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.buttonCancel.ImageOptions.Image = global::CallCenter.Properties.Resources.cancel_32x326;
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(146, 39);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(42, 42);
            this.buttonCancel.TabIndex = 71;
            this.buttonCancel.ToolTip = "İptal";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonOK.Appearance.Options.UseBackColor = true;
            this.buttonOK.Appearance.Options.UseTextOptions = true;
            this.buttonOK.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonOK.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.buttonOK.ImageOptions.Image = global::CallCenter.Properties.Resources.phone;
            this.buttonOK.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonOK.Location = new System.Drawing.Point(83, 39);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(42, 42);
            this.buttonOK.TabIndex = 70;
            this.buttonOK.ToolTip = "Ara";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // IcerdeCagri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 90);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.cmb_kulid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IcerdeCagri";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "İç Haberleşme";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.cmb_kulid.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonOK;
        public DevExpress.XtraEditors.LookUpEdit cmb_kulid;
    }
}