namespace CallCenter
{
	partial class IncomingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNo = new DevExpress.XtraEditors.SimpleButton();
            this.buttonYes = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxCaller = new System.Windows.Forms.Label();
            this.textBoxLine = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arayan:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hat:";
            // 
            // buttonNo
            // 
            this.buttonNo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonNo.Appearance.Options.UseBackColor = true;
            this.buttonNo.Appearance.Options.UseTextOptions = true;
            this.buttonNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.buttonNo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonNo.ImageOptions.Image")));
            this.buttonNo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.buttonNo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonNo.Location = new System.Drawing.Point(160, 70);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(80, 40);
            this.buttonNo.TabIndex = 70;
            this.buttonNo.ToolTip = "Kapat";
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonYes.Appearance.Options.UseBackColor = true;
            this.buttonYes.Appearance.Options.UseTextOptions = true;
            this.buttonYes.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonYes.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.buttonYes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonYes.ImageOptions.Image")));
            this.buttonYes.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.buttonYes.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonYes.Location = new System.Drawing.Point(70, 70);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(80, 40);
            this.buttonYes.TabIndex = 69;
            this.buttonYes.ToolTip = "Cevapla";
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // textBoxCaller
            // 
            this.textBoxCaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCaller.Location = new System.Drawing.Point(48, 16);
            this.textBoxCaller.Name = "textBoxCaller";
            this.textBoxCaller.Size = new System.Drawing.Size(199, 13);
            this.textBoxCaller.TabIndex = 71;
            this.textBoxCaller.Text = "Arayan";
            // 
            // textBoxLine
            // 
            this.textBoxLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxLine.Location = new System.Drawing.Point(48, 42);
            this.textBoxLine.Name = "textBoxLine";
            this.textBoxLine.Size = new System.Drawing.Size(199, 13);
            this.textBoxLine.TabIndex = 72;
            this.textBoxLine.Text = "Hat";
            // 
            // IncomingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 122);
            this.Controls.Add(this.textBoxLine);
            this.Controls.Add(this.textBoxCaller);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncomingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gelen Çaðrý";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton buttonNo;
        private DevExpress.XtraEditors.SimpleButton buttonYes;
        public System.Windows.Forms.Label textBoxCaller;
        public System.Windows.Forms.Label textBoxLine;
    }
}