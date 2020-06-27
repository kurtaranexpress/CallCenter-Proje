using CallCenter.models;
using Dapper;
using Npgsql;
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
    public partial class IstekGonder : Form
    {
        NpgsqlConnection conn;
        CallCenterEntities veri = new CallCenterEntities();
        List<KULLANICICALISMALAR_V> kullanicicalismalarlist;
        public IstekGonder(bool adminmi) // arama yapmak için istek oluşturur.
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            
            txt_donem.Text = null;
            txt_ay.Text = null;
            txt_hafta.Text = null;

            if (adminmi == true)
            {
                //cmb_kulid.Properties.ValueMember = "KO_KULLANICIID";
                //cmb_kulid.Properties.DisplayMember = "KO_KULLANICIID";
                //cmb_kulid.Properties.DataSource = (from p in veri.OUT_KULLANICILAR_TBL select p).OrderBy(t => t.KO_KULLANICIID).ToList();
                
                cmb_kulid.Properties.ValueMember = "tc_kimlik_no";
                cmb_kulid.Properties.DisplayMember = "tc_kimlik_no";
                var kullist_out = (from p in veri.mv_tuik_personel select p).OrderBy(t => t.tc_kimlik_no).ToList();
                cmb_kulid.Properties.DataSource = kullist_out;

                //cmb_calismaid.Properties.ValueMember = "CO_CALISMAID";
                //cmb_calismaid.Properties.DisplayMember = "CO_CALISMAID";
                //using (conn = new NpgsqlConnection(AnaForm.cstr))
                //{
                //    conn.Open();
                //    cmb_calismaid.Properties.DataSource = (from p in veri.OUT_CALISMALAR_TBL select p).OrderBy(t => t.CO_CALISMAID).ToList();
                //}


                cmb_calismaid.Properties.ValueMember = "study_id";
                cmb_calismaid.Properties.DisplayMember = "study_id";
                var callist_out = (from p in veri.mv_study_name select p).OrderBy(t => t.study_id).ToList();
                cmb_calismaid.Properties.DataSource = callist_out;

                cmb_calismaid.Properties.Columns["CAL_CALISMAID"].Visible = false;
                cmb_calismaid.Properties.Columns["CAL_ADI"].Visible = false;
                //cmb_kulid.Focus();           
            }
            else
            {
                cmb_calismaid.Properties.ValueMember = "CAL_CALISMAID";
                cmb_calismaid.Properties.DisplayMember = "CAL_CALISMAID";
                using (conn = new NpgsqlConnection(AnaForm.cstr))
                {
                    conn.Open();
                    cmb_calismaid.Properties.DataSource = conn.Query<KULLANICICALISMALAR_V>("select * from public.\"KULLANICICALISMALAR_V\" WHERE (\"KC_KUL_ID\" = " + AnaForm.userid + ") ORDER BY \"CAL_CALISMAID\"").ToList();
                }
                cmb_calismaid.Properties.Columns["study_id"].Visible = false;
                cmb_calismaid.Properties.Columns["study_name"].Visible = false;
                lbl_kullaniciid.Visible = false;
                cmb_kulid.Visible = false;
                //cmb_calismaid.Focus();
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cmb_calismaid.Text == "")
            {
                MessageBox.Show("Lütfen Çalışma ID belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_calismaid.Focus();
                return;
            }

            //if (cmb_kulid.Text == "")
            //{
            //    MessageBox.Show("Lütfen Kullanıcı ID belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmb_kulid.Focus();
            //    return;
            //}

            if (txt_brmno.Text == "")
            {
                MessageBox.Show("Lütfen Birim No belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_brmno.Focus();
                return;
            }

            if (txt_altbrmno.Text == "")
            {
                MessageBox.Show("Lütfen Alt Birim No belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_altbrmno.Focus(); 
                return;
            }
            //if (txt_yil.Text == "")
            //{
            //    MessageBox.Show("Lütfen Referans Yıl belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_yil.Focus();
            //    return;
            //}


            if (txt_tel.Text.Contains("_"))
            {
                MessageBox.Show("Lütfen Telefon No belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tel.Focus();
                return;
            }

            string cumle = "";
            if (cmb_kulid.Visible == true )
            {
                cumle= "select * from public.\"KULLANICICALISMALAR_V\" WHERE (\"KUL_KULLANICIID\" = '" + cmb_kulid.EditValue.ToString() + "' and \"CAL_CALISMAID\" = '" + cmb_calismaid.EditValue.ToString() + "') ORDER BY \"CAL_CALISMAID\"";
            }
            else
            {
                cumle= "select * from public.\"KULLANICICALISMALAR_V\" WHERE (\"KC_KUL_ID\" = " + AnaForm.userid + " and \"CAL_CALISMAID\" = '" + cmb_calismaid.EditValue.ToString() + "') ORDER BY \"CAL_CALISMAID\"";
            }
            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                kullanicicalismalarlist = conn.Query<KULLANICICALISMALAR_V>(cumle).ToList();
            }

            if (kullanicicalismalarlist.Count() < 1)
            {
                MessageBox.Show("Çalışma ve kullanıcı bağlantısı bulunamadı...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_donem.Text == "")
            {
                //MessageBox.Show("Lütfen Referans Dönem belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txt_donem.Focus();
                //return;                
            }
            if (txt_ay.Text == "")
            {
                //MessageBox.Show("Lütfen Referans Ay belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txt_ay.Focus();
                //return;
            }
            if (txt_hafta.Text == "")
            {
                //MessageBox.Show("Lütfen Referans Hafta belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txt_hafta.Focus();
                //return;                
            }
            try
            {
                ISTEKLER_TBL  kayit;
                kayit = new ISTEKLER_TBL();

                kayit.IST_TARIH = AnaForm.tarihsaatgetir();
                kayit.IST_CALISMAID = cmb_calismaid.Text;
                kayit.IST_KULLANICIID = AnaForm.userkullaniciid; //cmb_kulid.Text;
                kayit.IST_BIRIMNO = Convert.ToInt32(txt_brmno.Text);
                kayit.IST_ALTBIRIMNO = Convert.ToInt32(txt_altbrmno.Text);
                if (txt_yil.Text != "" ) kayit.IST_REFYIL = Convert.ToInt32(txt_yil.Text);
                if (txt_donem.Text != "" && txt_donem.Text != "0") kayit.IST_REFDONEM = Convert.ToInt32(txt_donem.Text);
                if (txt_ay.Text != "" && txt_ay.Text != "0") kayit.IST_REFAY = Convert.ToInt32(txt_ay.Text);
                if (txt_hafta.Text != "" && txt_hafta.Text != "0") kayit.IST_REFHAFTA = Convert.ToInt32(txt_hafta.Text);
                kayit.IST_TELNO = txt_tel.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace(" ", "");
                    //txt_tel.Text;
                kayit.IST_IL = txt_il.Text ;
                kayit.IST_ACIKLAMA = txt_aciklama.Text ;
                kayit.IST_RANDEVUTERCIH = txt_randevutercih.Text;
                if (rd_cagri.Checked == true )
                {
                    kayit.IST_NEDIR = "C";
                }
                else
                {
                    kayit.IST_NEDIR = "R";
                }


                kayit.IST_ICERDEN = true;
                veri.ISTEKLER_TBL.Add(kayit);

                string calismaadi = cmb_calismaid.Text;
                
                var calisma = (from p in veri.CALISMALAR_TBL where p.CAL_SIL != true && p.CAL_CALISMAID == cmb_calismaid.Text select p).SingleOrDefault();                
                if (calisma != null)
                {
                    calismaadi = cmb_calismaid.Text + " " + calisma.CAL_ADI;
                }

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!",MessageBoxButtons.OK, MessageBoxIcon.Information );
                AnaForm.logkaydet("İstek", "Ekleme (" + calismaadi +")" + "("+ txt_tel.Text +")" );
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }
        
        private void txt_brmno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //if (e.KeyChar == (char)Keys.Back)

        }

        private void txt_altbrmno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_yil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_donem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_ay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_hafta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
