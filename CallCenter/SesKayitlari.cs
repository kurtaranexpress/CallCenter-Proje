using CallCenter.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter
{
    public partial class SesKayitlari : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        List<dosyalar> sesdosyalari;

        string sayfa_santralkodu;

        public SesKayitlari(string sntkodu)
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;
            sayfa_santralkodu = sntkodu;

            if (AnaForm.kullaniciyetkileri[0].Y_SESDINLE == false) { btn_dinle.Visible = false; }
            if (AnaForm.kullaniciyetkileri[0].Y_SESDISAAKTAR == false) { btn_indir.Visible = false; }


            dt2.DateTime = AnaForm.tarihsaatgetir();
            dt1.DateTime = dt2.DateTime.AddHours(-1);

            try
            {
                var sonuc = (from p in veri.GENELAYARLAR_TBL select p).ToList();
                txt_sunucu.Text = sonuc[0].GA_FTP_IP;
                txt_ftpkul.Text = sonuc[0].GA_FTP_KULLANICI;
                txt_ftpsifre.Text = sonuc[0].GA_FTP_SIFRE;
                txt_ftpdizin.Text = sonuc[0].GA_FTP_DIZIN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ftp Bilgileri Alınamadı, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //listele();

        }

        void yeni()
        {
            List<dosyalar> sesdosyalari = new List<dosyalar>();



            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txt_sunucu.Text + "/" + txt_ftpdizin.Text + "/");
            if (request == null)
            {
                return;
            }

            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(txt_ftpkul.Text, txt_ftpsifre.Text);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string pattern = @"^(\d+-\d+-\d+\s+\d+:\d+(?:AM|PM))\s+(<DIR>|\d+)\s+(.+)$";
            Regex regex = new Regex(pattern);
            IFormatProvider culture = CultureInfo.GetCultureInfo("en-us");

            while (!reader.EndOfStream)
            {
                try
                {

                    string line = reader.ReadLine();
                    Match match = regex.Match(line);
                    DateTime modified =
                       DateTime.ParseExact(
                           match.Groups[1].Value, "MM-dd-yy  hh:mmtt", culture, DateTimeStyles.None);
                    long size = (match.Groups[2].Value != "<DIR>") ? long.Parse(match.Groups[2].Value) : 0;
                    string name = match.Groups[3].Value;


                    dosyalar dosya = new dosyalar();
                    dosya.dosyaadi = name;
                    dosya.tarihi = modified;

                    string arayan = "";
                    int len = dosya.dosyaadi.IndexOf("_") <= 0 ? 0 : dosya.dosyaadi.IndexOf("_");

                    if (dosya.dosyaadi != null)
                    {
                        arayan = dosya.dosyaadi.Substring(0, len);
                    }

                    if (dosya.tarihi >= dt1.DateTime && dosya.tarihi <= dt2.DateTime && (sayfa_santralkodu == arayan || sayfa_santralkodu == ""))
                    {
                        sesdosyalari.Add(dosya);
                    }

                    //Console.WriteLine(
                    //    "{0,-16} size = {1,9}  modified = {2}",
                    //    name, size, modified.ToString("yyyy-MM-dd HH:mm"));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            grd_list.DataSource = sesdosyalari;

        }
        void yeni2()
        {
            try
            {
                List<dosyalar> sesdosyalari = new List<dosyalar>();

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txt_sunucu.Text + "/" + txt_ftpdizin.Text + "/");
                if (request == null)
                {
                    return;
                }

                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(txt_ftpkul.Text, txt_ftpsifre.Text);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);


                string pattern =
                        @"^([\w-]+)\s+(\d+)\s+(\w+)\s+(\w+)\s+(\d+)\s+" +
                        @"(\w+\s+\d+\s+\d+|\w+\s+\d+\s+\d+:\d+)\s+(.+)$";
                Regex regex = new Regex(pattern);
                IFormatProvider culture = CultureInfo.GetCultureInfo("en-us");
                string[] hourMinFormats =
                    new[] { "MMM dd HH:mm", "MMM dd H:mm", "MMM d HH:mm", "MMM d H:mm" };
                string[] yearFormats =
                    new[] { "MMM dd yyyy", "MMM d yyyy" };



                while (!reader.EndOfStream)
                {
                    try
                    {

                        //string line = "-rw-rw-rw- 1 ftp ftp      250858 May 31 14:56      303_____19280_AI_50600_003124875632_4543000_00e43fa - Copy - Copy - Copy (6).wav";//reader.ReadLine();
                        string line = reader.ReadLine();
                        Match match = regex.Match(line);
                                               
                        DateTime modified;
                        string s = Regex.Replace(match.Groups[6].Value, @"\s+", " ");
                        if (s.IndexOf(':') >= 0)
                        {
                            modified = DateTime.ParseExact(s, hourMinFormats, culture, DateTimeStyles.None);
                        }
                        else
                        {
                            modified = DateTime.ParseExact(s, yearFormats, culture, DateTimeStyles.None);
                        }
                        string name = match.Groups[7].Value;

                        dosyalar dosya = new dosyalar();
                        dosya.dosyaadi = name;
                        dosya.tarihi = modified;

                        string arayan = "";
                        int len = dosya.dosyaadi.IndexOf("_") <= 0 ? 0 : dosya.dosyaadi.IndexOf("_");

                        if (dosya.dosyaadi != null)
                        {
                            arayan = dosya.dosyaadi.Substring(0, len);
                        }

                        if (dosya.tarihi >= dt1.DateTime && dosya.tarihi <= dt2.DateTime && (sayfa_santralkodu == arayan || sayfa_santralkodu == ""))
                        {
                            sesdosyalari.Add(dosya);
                        }
                        
                        //Console.WriteLine(
                        //    "{0,-16} size = {1,9}  modified = {2}",
                        //    name, size, modified.ToString("yyyy-MM-dd HH:mm"));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                grd_list.DataSource = sesdosyalari;
            }
            catch (Exception exx)
            {
                MessageBox.Show("Bağlantı sağlanamadı. " + exx.ToString());
            }
        }

        void yeni3()
        {
            try
            {
                List<dosyalar> sesdosyalari = new List<dosyalar>();

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txt_sunucu.Text + "/" + txt_ftpdizin.Text + "/");
                if (request == null)
                {
                    return;
                }

                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(txt_ftpkul.Text, txt_ftpsifre.Text);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                while (!reader.EndOfStream)
                {
                    try
                    {
                        dosyalar dosya = new dosyalar();

                        //string name = "3015_____191202_181537_AI_50600_003124875632_4543000_00e43fa - Copy - Copy - Copy(6).wav";//reader.ReadLine();
                        string name = reader.ReadLine();
                        dosya.dosyaadi = name;

                        string arayan = "";
                        int len = dosya.dosyaadi.IndexOf("_") <= 0 ? 0 : dosya.dosyaadi.IndexOf("_");

                        int yil = Convert.ToInt32("20" + name.Substring(len + 5, 2));
                        int ay = Convert.ToInt32(name.Substring(len + 7, 2));
                        int gun = Convert.ToInt32(name.Substring(len + 9, 2));
                        int saat = Convert.ToInt32(name.Substring(len + 12, 2));
                        int dk = Convert.ToInt32(name.Substring(len + 14, 2));
                        int sn = Convert.ToInt32(name.Substring(len + 16, 2));

                        dosya.tarihi = new DateTime(yil, ay, gun, saat, dk, sn);

                        if (dosya.dosyaadi != null)
                        {
                            arayan = dosya.dosyaadi.Substring(0, len);
                        }

                        if (dosya.tarihi >= dt1.DateTime && dosya.tarihi <= dt2.DateTime && (sayfa_santralkodu == arayan || sayfa_santralkodu == ""))
                        {
                            sesdosyalari.Add(dosya);
                        }

                        //Console.WriteLine(
                        //    "{0,-16} size = {1,9}  modified = {2}",
                        //    name, size, modified.ToString("yyyy-MM-dd HH:mm"));

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                }

                grd_list.DataSource = sesdosyalari;
            }
            catch (Exception exx)
            {
                MessageBox.Show("Bağlantı sağlanamadı. " + exx.ToString());
            }
        }

        void listele() // ses kayıtlarını listeler. 
        {
            try
            {
                List<dosyalar> sesdosyalari = new List<dosyalar>();


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txt_sunucu.Text + "/" + txt_ftpdizin.Text + "/");
                if (request == null)
                {
                    return;
                }

                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(txt_ftpkul.Text, txt_ftpsifre.Text);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);


                while (!reader.EndOfStream)
                {
                    dosyalar dosya = new dosyalar();

                    dosya.dosyaadi = reader.ReadLine();
                    //abc.tarihi = response.LastModified.ToString();
                    dosya.tarihi = response.LastModified;

                    FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(txt_sunucu.Text + "/" + txt_ftpdizin.Text + "/" + dosya.dosyaadi);
                    request2.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                    request2.Credentials = new NetworkCredential(txt_ftpkul.Text, txt_ftpsifre.Text);
                    FtpWebResponse response2 = (FtpWebResponse)request2.GetResponse();
                    //item.tarihi = response2.LastModified.ToString();
                    dosya.tarihi = response2.LastModified;

                    string arayan = "";
                    int len = dosya.dosyaadi.IndexOf("_") <= 0 ? 0 : dosya.dosyaadi.IndexOf("_");


                    if (dosya.dosyaadi != null)
                    {
                        arayan = dosya.dosyaadi.Substring(0, len);
                    }


                    if (dosya.tarihi >= dt1.DateTime && dosya.tarihi <= dt2.DateTime && (sayfa_santralkodu == arayan || sayfa_santralkodu == ""))
                    {
                        sesdosyalari.Add(dosya);
                    }
                }

                foreach (var item in sesdosyalari)
                {
                    FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(txt_sunucu.Text + "/" + txt_ftpdizin.Text + "/" + item.dosyaadi);
                    request2.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                    request2.Credentials = new NetworkCredential(txt_ftpkul.Text, txt_ftpsifre.Text);
                    FtpWebResponse response2 = (FtpWebResponse)request2.GetResponse();
                    //item.tarihi = response2.LastModified.ToString();
                    item.tarihi = response2.LastModified;
                }
                grd_list.DataSource = sesdosyalari.OrderByDescending(t => t.tarihi);   //sesdosyalari.Where(t => t.tarihi >= dt1.DateTime && t.tarihi <= dt2.DateTime).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_bul_Click(object sender, EventArgs e)
        {
            //listele();
            //yeni();
            yeni2();
            //yeni3();
        }

        private void btn_dinle_Click(object sender, EventArgs e) //ses kaydını oynatmak için hazırlar.
        {

            try
            {
                //string filename = Convert.ToString(dataGridView1.CurrentRow.Cells["dosyaadi"].FormattedValue);
                string filename = Convert.ToString(grdview_list.GetFocusedRowCellValue("dosyaadi"));

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txt_sunucu.Text + "/" + txt_ftpdizin.Text + "/" + filename);
                request.Credentials = new NetworkCredential(txt_ftpkul.Text, txt_ftpsifre.Text);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(Application.StartupPath + "\\" + "SesFiles\\" + filename))
                {
                    byte[] buffer = new byte[10240];
                    int read;

                    lbl_bilgi.Text = "Hazırlanıyor...";
                    btn_dinle.Enabled = false;
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        this.Refresh();
                    }
                }

                //btn_dinle.Text = "Dosyayı Dinle";
                lbl_bilgi.Text = "";
                btn_dinle.Enabled = true;
                axWindowsMediaPlayer1.URL = Application.StartupPath + "\\" + "SesFiles\\" + filename;
                //axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_indir_Click(object sender, EventArgs e) // ses kaydını indirir.
        {
            try
            {
                string filename = Convert.ToString(grdview_list.GetFocusedRowCellValue("dosyaadi"));

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txt_sunucu.Text + "/" + txt_ftpdizin.Text + "/" + filename);
                    request.Credentials = new NetworkCredential(txt_ftpkul.Text, txt_ftpsifre.Text);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;

                    using (Stream ftpStream = request.GetResponse().GetResponseStream())
                    using (Stream fileStream = File.Create(fbd.SelectedPath + "\\" + filename))

                    {
                        byte[] buffer = new byte[10240];
                        int read;

                        btn_indir.Enabled = false;
                        while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, read);

                            //btn_indir.Text = fileStream.Position.ToString();
                            lbl_bilgi.Text = fileStream.Position.ToString();
                            this.Refresh();
                        }
                    }
                }

                btn_indir.Enabled = true;
                //btn_indir.Text = "Dosya İndir";
                lbl_bilgi.Text = "";
                MessageBox.Show("İndirme İşlemi tamamlandı", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void SesKayitlari_FormClosing(object sender, FormClosingEventArgs e) // dinlemek için inen ses kayıtlarını siler. 
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            var files = Directory.GetFiles(Application.StartupPath + "\\" + "SesFiles");

            foreach (var item in files)
                try
                {
                    File.Delete(item);
                }
                catch (Exception)
                {
                }


        }
        public static Regex FtpListDirectoryDetailsRegex = new Regex(@".*(?<month>(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\s*(?<day>[0-9]*)\s*(?<yearTime>([0-9]|:)*)\s*(?<fileName>.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }
}
