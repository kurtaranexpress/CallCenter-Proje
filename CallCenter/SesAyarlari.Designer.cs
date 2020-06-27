namespace CallCenter
{
    partial class SesAyarlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SesAyarlari));
            this.muteMicrophoneFlag = new System.Windows.Forms.CheckBox();
            this.muteSpeakerFlag = new System.Windows.Forms.CheckBox();
            this.micVolume = new System.Windows.Forms.TrackBar();
            this.spkVolume = new System.Windows.Forms.TrackBar();
            this.comboBoxPlayback = new System.Windows.Forms.ComboBox();
            this.comboBoxRecord = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.micVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // muteMicrophoneFlag
            // 
            this.muteMicrophoneFlag.AutoSize = true;
            this.muteMicrophoneFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.muteMicrophoneFlag.Location = new System.Drawing.Point(19, 74);
            this.muteMicrophoneFlag.Name = "muteMicrophoneFlag";
            this.muteMicrophoneFlag.Size = new System.Drawing.Size(90, 17);
            this.muteMicrophoneFlag.TabIndex = 7;
            this.muteMicrophoneFlag.Text = "Mikrofon Sesi";
            this.muteMicrophoneFlag.UseVisualStyleBackColor = true;
            this.muteMicrophoneFlag.CheckedChanged += new System.EventHandler(this.muteMicCB_CheckedChanged);
            // 
            // muteSpeakerFlag
            // 
            this.muteSpeakerFlag.AutoSize = true;
            this.muteSpeakerFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.muteSpeakerFlag.Location = new System.Drawing.Point(19, 24);
            this.muteSpeakerFlag.Name = "muteSpeakerFlag";
            this.muteSpeakerFlag.Size = new System.Drawing.Size(89, 17);
            this.muteSpeakerFlag.TabIndex = 5;
            this.muteSpeakerFlag.Text = "Hoparlör Sesi";
            this.muteSpeakerFlag.UseVisualStyleBackColor = true;
            this.muteSpeakerFlag.CheckedChanged += new System.EventHandler(this.muteSoundCB_CheckedChanged);
            // 
            // micVolume
            // 
            this.micVolume.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.micVolume.Location = new System.Drawing.Point(134, 69);
            this.micVolume.Maximum = 100;
            this.micVolume.Name = "micVolume";
            this.micVolume.Size = new System.Drawing.Size(152, 45);
            this.micVolume.TabIndex = 8;
            this.micVolume.TickFrequency = 10;
            this.micVolume.Scroll += new System.EventHandler(this.MicVolume_Scroll);
            // 
            // spkVolume
            // 
            this.spkVolume.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.spkVolume.Location = new System.Drawing.Point(134, 19);
            this.spkVolume.Maximum = 100;
            this.spkVolume.Name = "spkVolume";
            this.spkVolume.Size = new System.Drawing.Size(150, 45);
            this.spkVolume.TabIndex = 6;
            this.spkVolume.TickFrequency = 10;
            this.spkVolume.Scroll += new System.EventHandler(this.SpkVolume_Scroll);
            // 
            // comboBoxPlayback
            // 
            this.comboBoxPlayback.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayback.FormattingEnabled = true;
            this.comboBoxPlayback.Location = new System.Drawing.Point(86, 131);
            this.comboBoxPlayback.Name = "comboBoxPlayback";
            this.comboBoxPlayback.Size = new System.Drawing.Size(220, 21);
            this.comboBoxPlayback.TabIndex = 10;
            this.comboBoxPlayback.Visible = false;
            // 
            // comboBoxRecord
            // 
            this.comboBoxRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecord.FormattingEnabled = true;
            this.comboBoxRecord.Location = new System.Drawing.Point(86, 158);
            this.comboBoxRecord.Name = "comboBoxRecord";
            this.comboBoxRecord.Size = new System.Drawing.Size(220, 21);
            this.comboBoxRecord.TabIndex = 12;
            this.comboBoxRecord.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hoparlör:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mikrofon:";
            this.label4.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.Appearance.Options.UseBackColor = true;
            this.buttonCancel.Appearance.Options.UseTextOptions = true;
            this.buttonCancel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonCancel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.buttonCancel.ImageOptions.Image = global::CallCenter.Properties.Resources.cancel_32x322;
            this.buttonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(174, 203);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 40);
            this.buttonCancel.TabIndex = 72;
            this.buttonCancel.ToolTip = "İptal";
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonOK.Appearance.Options.UseBackColor = true;
            this.buttonOK.Appearance.Options.UseTextOptions = true;
            this.buttonOK.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonOK.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.buttonOK.ImageOptions.Image = global::CallCenter.Properties.Resources.apply_32x32;
            this.buttonOK.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.buttonOK.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonOK.Location = new System.Drawing.Point(86, 203);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(80, 40);
            this.buttonOK.TabIndex = 71;
            this.buttonOK.ToolTip = "Kaydet";
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // SesAyarlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 115);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxPlayback);
            this.Controls.Add(this.comboBoxRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.muteMicrophoneFlag);
            this.Controls.Add(this.muteSpeakerFlag);
            this.Controls.Add(this.micVolume);
            this.Controls.Add(this.spkVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SesAyarlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ses Ayarları";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SesAyarlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.micVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox muteMicrophoneFlag;
        private System.Windows.Forms.CheckBox muteSpeakerFlag;
        private System.Windows.Forms.TrackBar micVolume;
        private System.Windows.Forms.TrackBar spkVolume;
        private System.Windows.Forms.ComboBox comboBoxPlayback;
        private System.Windows.Forms.ComboBox comboBoxRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonOK;
    }
}