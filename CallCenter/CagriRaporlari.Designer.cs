namespace CallCenter
{
    partial class CagriRaporlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CagriRaporlari));
            this.btn_tumcagrilar = new System.Windows.Forms.Button();
            this.btn_cagrilar_periyot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_tumcagrilar
            // 
            this.btn_tumcagrilar.Location = new System.Drawing.Point(90, 59);
            this.btn_tumcagrilar.Name = "btn_tumcagrilar";
            this.btn_tumcagrilar.Size = new System.Drawing.Size(128, 32);
            this.btn_tumcagrilar.TabIndex = 0;
            this.btn_tumcagrilar.Text = "Tüm Çağrılar";
            this.btn_tumcagrilar.UseVisualStyleBackColor = true;
            this.btn_tumcagrilar.Click += new System.EventHandler(this.btn_tumcagrilar_Click);
            // 
            // btn_cagrilar_periyot
            // 
            this.btn_cagrilar_periyot.Location = new System.Drawing.Point(90, 97);
            this.btn_cagrilar_periyot.Name = "btn_cagrilar_periyot";
            this.btn_cagrilar_periyot.Size = new System.Drawing.Size(128, 32);
            this.btn_cagrilar_periyot.TabIndex = 1;
            this.btn_cagrilar_periyot.Text = "Periyoda Göre Çağrılar";
            this.btn_cagrilar_periyot.UseVisualStyleBackColor = true;
            this.btn_cagrilar_periyot.Click += new System.EventHandler(this.btn_cagrilar_periyot_Click);
            // 
            // CagriRaporlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 326);
            this.Controls.Add(this.btn_cagrilar_periyot);
            this.Controls.Add(this.btn_tumcagrilar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CagriRaporlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çağrı Raporları";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tumcagrilar;
        private System.Windows.Forms.Button btn_cagrilar_periyot;
    }
}