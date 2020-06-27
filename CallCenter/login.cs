using CallCenter.models;
using Dapper;
using DevExpress.XtraBars.Navigation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter
{
    public partial class login : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        public string guncelversiyon = "";

        public login()
        {
            InitializeComponent();
            var lines = File.ReadAllLines(Application.StartupPath + "\\db.txt");
            var line = lines[0];
            AnaForm.cstr = line;


            veri.Database.Connection.ConnectionString = AnaForm.cstr;
            //MessageBox.Show(Application.StartupPath);

            //for (var i = 0; i < lines.Length; i += 1)
            //{
            //var line = lines[i];
            // Process line
            //}

            
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            girisyap();
        }
        

        void girisyap()
        {
            if (txt_kuladi.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı ID belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_kuladi.Focus();
                return;
            }
            if (txt_sifre.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Şifrenizi belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_sifre.Focus();
                return;
            }
            try
            {
               

                var kayit = (from p in veri.KULLANICILAR_TBL where p.KUL_SIL != true && p.KUL_KULLANICIID == txt_kuladi.Text && p.KUL_SIFRE == txt_sifre.Text select p).SingleOrDefault();
                if (kayit != null)
                {
                    AnaForm anaform = new AnaForm(Convert.ToInt32(kayit.KUL_ID),guncelversiyon );
                    //this.Close();
                    this.Visible = false;                                       

                    anaform.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Kullanıcı ID-şifreniz yanlış...", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Veritabanı ayarlarını kontrol ediniz..., Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txt_sifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                girisyap();
            }
        }

        private void txt_kuladi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                girisyap();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

            try
            {
                List<GENELAYARLAR_TBL> ayarlar = (from p in veri.GENELAYARLAR_TBL select p).ToList();
                guncelversiyon = ayarlar[0].GA_VERSIYON.ToString();
                if (lbl_versiyonno.Text != guncelversiyon)
                {
                    MessageBox.Show("Lütfen programı güncelleyiniz! Güncel versiyon: '" + ayarlar[0].GA_GUNBASLAMASAAT.ToString() + "' 'dir.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_kuladi.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void login_Activated(object sender, EventArgs e)
        {
            

        }
    }
    }
