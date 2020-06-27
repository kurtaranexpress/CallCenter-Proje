namespace CallCenter
{
	partial class TransferAddrForm
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
			if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferAddrForm));
            this.cmb_kulid = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_kulid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_kulid
            // 
            this.cmb_kulid.Location = new System.Drawing.Point(5, 10);
            this.cmb_kulid.Name = "cmb_kulid";
            this.cmb_kulid.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmb_kulid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_kulid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KUL_ADI", "Kullanýcý Adý"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KUL_KULLANICIID", "Kullanýcý ID")});
            this.cmb_kulid.Properties.NullText = "";
            this.cmb_kulid.Size = new System.Drawing.Size(250, 20);
            this.cmb_kulid.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.Appearance.Options.UseBackColor = true;
            this.buttonCancel.Appearance.Options.UseTextOptions = true;
            this.buttonCancel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonCancel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.buttonCancel.ImageOptions.Image = global::CallCenter.Properties.Resources.cancel_32x325;
            this.buttonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(145, 40);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(42, 42);
            this.buttonCancel.TabIndex = 68;
            this.buttonCancel.ToolTip = "Ýptal";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonOK.Appearance.Options.UseBackColor = true;
            this.buttonOK.Appearance.Options.UseTextOptions = true;
            this.buttonOK.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonOK.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.buttonOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.ImageOptions.Image")));
            this.buttonOK.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.buttonOK.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonOK.Location = new System.Drawing.Point(82, 40);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(42, 42);
            this.buttonOK.TabIndex = 67;
            this.buttonOK.ToolTip = "Aktar";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // TransferAddrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 90);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.cmb_kulid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferAddrForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aktar:";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.cmb_kulid.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
        public DevExpress.XtraEditors.LookUpEdit cmb_kulid;
        private DevExpress.XtraEditors.SimpleButton buttonOK;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
    }
}