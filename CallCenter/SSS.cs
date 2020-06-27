using CallCenter.models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter
{
    public partial class SSS : Form
    {
        
        NpgsqlConnection conn; 
        CallCenterEntities veri = new CallCenterEntities();
        int ssid = 0;

        bool sayfaadminmi;

        public SSS(bool adminmi)
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;
            sayfaadminmi = adminmi;

            cmb_calismaid.Properties.ValueMember = "CAL_ID";
            cmb_calismaid.Properties.DisplayMember = "CAL_CALISMAID";
            var callist = (from p in veri.CALISMALAR_TBL select p).OrderBy(t => t.CAL_CALISMAID ).ToList();
            cmb_calismaid.Properties.DataSource = callist;

            listele();
            temizle();
        }

        
        void temizle() //formu temizler. 
        {
            ssid = 0;
            cmb_calismaid.EditValue = null;
            txt_soru.Text = "";
            txt_cevap.Text = "";
            chk_aktif.Checked = false;
            txt_soru.Focus();
        }

        private void btn_yeni_Click(object sender, EventArgs e) // formu temizler. 
        {
            temizle();
        }

        private void btn_yazdir_Click(object sender, EventArgs e) // gridi yazdırır. 
        {
            grd_list.ShowPrintPreview();
        }

        private void button_duzenle_Click(object sender, EventArgs e) // SSS_TBL deki kaydı görüntüler. 
        {
            if (grdview_list.GetFocusedRow() == null) return;

            ssid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("SS_ID"));
            if (grdview_list.GetFocusedRowCellValue("SS_CAL_ID") != null)
            {
                cmb_calismaid.EditValue  =grdview_list.GetFocusedRowCellValue("SS_CAL_ID");
            }
            else
            {
                cmb_calismaid.EditValue = null;
            }
            txt_soru.Text = grdview_list.GetFocusedRowCellValue("SS_SORU").ToString();
            txt_cevap.Text = grdview_list.GetFocusedRowCellValue("SS_CEVAP").ToString();
            chk_aktif.Checked = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("SS_AKTIF"));
        }

        private void btn_kaydet_Click(object sender, EventArgs e) // SSS_TBL deki kaydı günceller ya da yeni kayıt ekler. 
        {
            if (txt_soru.Text == "")
            {
                MessageBox.Show("Lütfen Soru belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soru.Focus();
                return;
            }

            if (txt_cevap.Text == "")
            {
                MessageBox.Show("Lütfen Cevap belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_cevap.Focus();
                return;
            }

            try
            {
                SSS_TBL kayit;
                if (ssid == 0)
                {
                    kayit = new SSS_TBL();
                }
                else
                {
                    kayit = (from p in veri.SSS_TBL where p.SS_ID == ssid select p).SingleOrDefault();

                }
                kayit.SS_SORU  = txt_soru.Text;
                kayit.SS_CEVAP = txt_cevap.Text;
                kayit.SS_CAL_ID = Convert.ToInt32 ( cmb_calismaid.EditValue );
                kayit.SS_AKTIF  = chk_aktif.Checked ;

                if (ssid == 0) veri.SSS_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!",MessageBoxButtons.OK, MessageBoxIcon.Information );

                int calid = Convert.ToInt32(cmb_calismaid.EditValue);
                var calisma  = (from p in veri.CALISMALAR_TBL where p.CAL_ID == calid select p).SingleOrDefault();

                if (ssid == 0)
                {
                    AnaForm.logkaydet("Sık Sorulan Sorular", "Ekleme (" + calisma.CAL_CALISMAID + " " + calisma.CAL_ADI + ")(" + txt_soru.Text +")");
                }
                else
                {
                    AnaForm.logkaydet("Sık Sorulan Sorular", "Güncelleme (" + calisma.CAL_CALISMAID + " " + calisma.CAL_ADI + ")(" + txt_soru.Text + ")");
                }


                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sil_Click(object sender, EventArgs e) //SSS_TBL deki kaydı siler. 
        {
            if (grdview_list.GetFocusedRow() == null) return;

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }

            try
            {
                ssid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("SS_ID"));
                var kayit = (from p in veri.SSS_TBL  where p.SS_ID == ssid select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.SSS_TBL.Remove(kayit);
                    veri.SaveChanges();
                }
                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnaForm.logkaydet("Sık Sorulan Sorular", "Silme (" + Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_CALISMAID")) + " " + Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_ADI")) +")(" +
                    Convert.ToString(grdview_list.GetFocusedRowCellValue("SS_SORU"))  + ")"
                    );
                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void listele() // SSS_TBL deki kayıtları listeler. 
        {

            string querystring = "select * from public.\"SSS_V\"";

            if (sayfaadminmi == false )
            {
                querystring = "select * from public.\"SSS_V\" where \"SS_AKTIF\"=TRUE";
            }

            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                grd_list.DataSource = conn.Query<SSS_V>(querystring).ToList();
            }

            
        }

        
        
    }
}
