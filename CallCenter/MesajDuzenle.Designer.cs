namespace CallCenter
{
    partial class MesajDuzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MesajDuzenle));
            this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
            this.txt_mesaj = new DevExpress.XtraEditors.MemoEdit();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mesaj.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonOK.Appearance.Options.UseBackColor = true;
            this.buttonOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_mesajgonder.ImageOptions.Image")));
            this.buttonOK.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonOK.Location = new System.Drawing.Point(358, 142);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(48, 48);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.ToolTip = "Kaydet";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // txt_mesaj
            // 
            this.txt_mesaj.EditValue = "";
            this.txt_mesaj.Location = new System.Drawing.Point(12, 12);
            this.txt_mesaj.Name = "txt_mesaj";
            this.txt_mesaj.Properties.MaxLength = 3000;
            this.txt_mesaj.Properties.NullValuePrompt = "Mesaj";
            this.txt_mesaj.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_mesaj.Size = new System.Drawing.Size(448, 124);
            this.txt_mesaj.TabIndex = 10;
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
            this.buttonCancel.Location = new System.Drawing.Point(412, 142);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(48, 48);
            this.buttonCancel.TabIndex = 72;
            this.buttonCancel.ToolTip = "İptal";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // MesajDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 198);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.txt_mesaj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MesajDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesaj Düzenle";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.txt_mesaj.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonOK;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        public DevExpress.XtraEditors.MemoEdit txt_mesaj;
    }
}