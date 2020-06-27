using SIPVoipSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter
{
    public partial class SesAyarlari : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        public CConfig phoneCfg;
        public SesAyarlari() // konuşmadaki ses ayarlarını yapar.
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            //Configure playback controls
            spkVolume.SetRange(0, 100);
            spkVolume.Value = AnaForm.AbtoPhone.PlaybackVolume;
            spkVolume.TickFrequency = 10;
            
            //Configure record controls
            micVolume.SetRange(0, 100);
            micVolume.Value = AnaForm.AbtoPhone.RecordVolume;
            micVolume.TickFrequency = 10;

            //Mute Speaker/Microphone
            muteSpeakerFlag.Checked = Convert.ToBoolean(AnaForm.AbtoPhone.PlaybackMuted) ? false : true;
            muteMicrophoneFlag.Checked = Convert.ToBoolean(AnaForm.AbtoPhone.RecordMuted) ? false : true ;

        }


        private void SpkVolume_Scroll(object sender, EventArgs e)
        { //anaformda bu ayarları userlogged'a sadece initialize de çekiyor, Bu yüzden userlogged u refresh etmeme gerek kalmıyor. cihazın ayarını değiştirip, vt ye de kaydedince sorunsuz çalışıyor.
            AnaForm.AbtoPhone.PlaybackVolume = spkVolume.Value;
            try
            {
                var kullanici = (from p in veri.KULLANICILAR_TBL where p.KUL_ID == AnaForm.userid select p).ToList();
                kullanici[0].KUL_HOPARLORDUZEYI = spkVolume.Value;
                veri.SaveChanges();
            }
            catch (Exception)
            {
            }
        }



        private void MicVolume_Scroll(object sender, EventArgs e)
        {
            AnaForm.AbtoPhone.RecordVolume = micVolume.Value;
            try
            {
                var kullanici = (from p in veri.KULLANICILAR_TBL where p.KUL_ID == AnaForm.userid select p).ToList();
                kullanici[0].KUL_MIKROFONDUZEYI = micVolume.Value;
                veri.SaveChanges();
            }
            catch (Exception)
            {
            }            
        }

        private void muteSoundCB_CheckedChanged(object sender, EventArgs e) //hoparlör
        {
            AnaForm.AbtoPhone.PlaybackMuted = muteSpeakerFlag.Checked ? 0 : 1;
        }

        private void muteMicCB_CheckedChanged(object sender, EventArgs e) //mikrofon
        {
            AnaForm.AbtoPhone.RecordMuted = muteMicrophoneFlag.Checked ? 0 : 1;
        }

        private void SesAyarlari_Load(object sender, EventArgs e)
        {
            //Fill play devices list
            int sdCount = phoneCfg.PlaybackDeviceCount;
            for (int i = 0; i < sdCount; i++) comboBoxPlayback.Items.Add(phoneCfg.get_PlaybackDevice(i));

            //Fill record devices list
            int rdCount = phoneCfg.RecordDeviceCount;
            for (int i = 0; i < rdCount; i++) comboBoxRecord.Items.Add(phoneCfg.get_RecordDevice(i));

            comboBoxPlayback.SelectedIndex = comboBoxPlayback.Items.IndexOf(phoneCfg.ActivePlaybackDevice);
            comboBoxRecord.SelectedIndex = comboBoxRecord.Items.IndexOf(phoneCfg.ActiveRecordDevice);

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            phoneCfg.ActivePlaybackDevice = (comboBoxPlayback.SelectedItem != null) ? comboBoxPlayback.SelectedItem.ToString() : "";
            phoneCfg.ActiveRecordDevice = (comboBoxRecord.SelectedItem != null) ? comboBoxRecord.SelectedItem.ToString() : "";


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
