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
    public partial class RandevuAktar : Form
    {
        NpgsqlConnection conn;
        CallCenterEntities veri = new CallCenterEntities();
        List<KULLANICILAR_TBL> kullist;
        List<RANDEVUDETAYLAR_V> ranlist;
        public RandevuAktar()
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;
        }

        private void RandevuAktar_Load(object sender, EventArgs e) //kullanıcıları listeler
        {

            cmb_kullanici.Properties.ValueMember = "KUL_ID";
            cmb_kullanici.Properties.DisplayMember = "KUL_ADI";
            kullist = (from p in veri.KULLANICILAR_TBL select p).OrderBy(t => t.KUL_ADI).ToList();
            cmb_kullanici.Properties.DataSource = kullist;


            cmb_aktarilacakkullanici.Properties.ValueMember = "KUL_ID";
            cmb_aktarilacakkullanici.Properties.DisplayMember = "KUL_ADI";
            cmb_aktarilacakkullanici.Properties.DataSource = kullist.Where(s=>s.KUL_SIL != true);

            dt_1.DateTime = DateTime.Now;
            dt_2.DateTime = DateTime.Now.AddDays(1);



        }

        private void btn_listele_Click(object sender, EventArgs e) //seçilen kullanıcıların randevularını listeler.. 
        {

            if (cmb_kullanici.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcıyı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_kullanici.Focus();
                return;
            }

            string querystring = "";

            querystring = "select * from public.\"RANDEVUDETAYLAR_V\" ORDER BY \"RAN_BASLAMATARIH\" DESC";

            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                ranlist = conn.Query<RANDEVUDETAYLAR_V>(querystring).ToList().Where(t => t.RAN_KUL_ID == Convert.ToInt32(cmb_kullanici.EditValue) && t.RAN_BASLAMATARIH >= dt_1.DateTime && t.RAN_BASLAMATARIH <= dt_2.DateTime).ToList();
                grd_list.DataSource = ranlist;
            }

        }

        private void btn_aktar_Click(object sender, EventArgs e) // seçilen kullanıcının seçilen mesajlarını seçilen başka bir kullanıcıya aktarır. 
        {
            if (ranlist.Count() < 1)
            {
                MessageBox.Show("Lütfen aktarılacak randevuları listeleyiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ranlist.Where(t => t.RAN_SEC == true).Count() < 1)
            {
                MessageBox.Show("Lütfen aktarılacak randevuları seçiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmb_aktarilacakkullanici.Text == "")
            {
                MessageBox.Show("Lütfen aktarılacak kullanıcıyı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_aktarilacakkullanici.Focus();
                return;
            }

            if (Convert.ToInt32(cmb_aktarilacakkullanici.EditValue) == Convert.ToInt32(ranlist[0].RAN_KUL_ID))
            {
                MessageBox.Show("Seçtiğiniz kullanıcı, Aktarılacak kullanıcı ile aynı...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_aktarilacakkullanici.Focus();
                return;
            }


            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Randevular " + cmb_aktarilacakkullanici.Text + " kullanıcısına aktarılacaktır. Devam etmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }

            foreach (var item in ranlist.Where(t => t.RAN_SEC == true))
            {
                var kayit = (from p in veri.RANDEVULAR_TBL where p.RAN_ID == item.RAN_ID select p).SingleOrDefault();
                kayit.RAN_KUL_ID = Convert.ToInt32(cmb_aktarilacakkullanici.EditValue);
                veri.SaveChanges();
            }


            MessageBox.Show("Aktarım Tamamlandı...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            grd_list.DataSource = null;

            AnaForm.logkaydet("Randevu Aktarma ", "(" + cmb_kullanici.Text + "->" + cmb_aktarilacakkullanici.Text +")"); 

        }
    }
}
