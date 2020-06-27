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
    public partial class Forum : Form
    {
        NpgsqlConnection conn;
        CallCenterEntities veri = new CallCenterEntities();

        List<FORUMKONULARI_TBL> forumlist;

        int frid = 0;
        int msjid = 0;
        bool sayfaadminmi = false;

        public Forum(bool adminmi)
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            sayfaadminmi = adminmi;

            listele();
            temizle();

        }
        private void button_duzenle_Click(object sender, EventArgs e) //FORUMKONULARI_TBL deki kaydı görüntüler
        {
            if (grdview_list.GetFocusedRow() == null) return;

            frid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("FR_ID"));
            txt_konu.Text = grdview_list.GetFocusedRowCellValue("FR_ADI").ToString();
            txt_aciklama.Text = grdview_list.GetFocusedRowCellValue("FR_ACIKLAMA").ToString();
            chk_aktif.Checked = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("FR_AKTIF"));
        }

        private void btn_kaydet_Click(object sender, EventArgs e) // FORUMKONULARI_TBL ye kayıt atar ya da kayıt günceller.
        {
            if (txt_konu.Text == "")
            {
                MessageBox.Show("Lütfen Konu belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_konu.Focus();
                return;
            }

            try
            {
                FORUMKONULARI_TBL kayit;
                if (frid == 0)
                {
                    kayit = new FORUMKONULARI_TBL();
                }
                else
                {
                    kayit = (from p in veri.FORUMKONULARI_TBL where p.FR_ID == frid select p).SingleOrDefault();
                }
                kayit.FR_ADI = txt_konu.Text;
                kayit.FR_ACIKLAMA = txt_aciklama.Text;
                kayit.FR_AKTIF = chk_aktif.Checked;

                if (frid == 0) veri.FORUMKONULARI_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (frid == 0)
                {
                    AnaForm.logkaydet("Forum Konusu", "Ekleme (" + txt_konu.Text +")");
                }
                else
                {
                    AnaForm.logkaydet("Forum Konusu", "Güncelleme (" + txt_konu.Text + ")");
                }

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sil_Click(object sender, EventArgs e) // FORUMKONULARI_TBL den kayıt siler
        {
            if (grdview_list.GetFocusedRow() == null) return;

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Foruma ait tüm mesajlar silinecektir.Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }

            try
            {
                frid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("FR_ID"));
                var kayit = (from p in veri.FORUMKONULARI_TBL where p.FR_ID == frid select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.FORUMKONULARI_TBL.Remove(kayit);
                    veri.SaveChanges();
                }
                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm.logkaydet("Forum Konusu", "Silme (" + Convert.ToString(grdview_list.GetFocusedRowCellValue("FR_ADI")) +")");

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_yeni_Click(object sender, EventArgs e) // formdaki nesneleri temizler.
        {
            temizle();
        }

        private void btn_yazdir_Click(object sender, EventArgs e) // forum konuları gridini yazdırır.
        {
            grd_list.ShowPrintPreview();
        }

        private void btn_yazdir2_Click(object sender, EventArgs e) // forum mesajlarını yazdırır.
        {
            grd_mesaj.ShowPrintPreview();
        }

        void temizle() // formu temizler
        {
            chk_aktif.Checked = false;
            txt_konu.Text = "";
            txt_aciklama.Text = "";
            frid = 0;
            txt_konu.Focus();
        }
        private void btn_mesajgonder_Click(object sender, EventArgs e) // MESAJLAR_TBL ye kayıt atar.
        {
            if (forumlist.Count() < 1)
            {
                MessageBox.Show("Kayıtlı konu yok...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mesaj.Focus();
                return;
            }

            if (grdview_list.GetFocusedRow() == null)
            {
                MessageBox.Show("Kayıtlı konu yok...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mesaj.Focus();
                return;

            }


            if (txt_mesaj.Text == "")
            {
                MessageBox.Show("Lütfen mesajınızı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mesaj.Focus();
                return;
            }

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Mesajınız '" + grdview_list.GetFocusedRowCellValue("FR_ADI").ToString().ToUpper() + "' başlığında listelenecektir. Devam etmek istiyor musunuz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }


            if (grdview_list.GetFocusedRow() == null) return;
            try
            {
                MESAJLAR_TBL kayit;
                kayit = new MESAJLAR_TBL();
                kayit.MSJ_KUL_ID = AnaForm.userid;
                kayit.MSJ_FR_ID = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("FR_ID"));
                kayit.MSJ_TARIH = AnaForm.tarihsaatgetir();
                kayit.MSJ_MESAJ = txt_mesaj.Text;
                kayit.MSJ_OKUNDU = false;
                if (frid == 0) veri.MESAJLAR_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Gönderildi" : "Gönderilemedi!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                AnaForm.logkaydet("Forum Mesajı", "Gönderme (" + grdview_list.GetFocusedRowCellValue("FR_ADI").ToString() + ")");

                listelemesajlar();
                txt_mesaj.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void listele() // Forum konularını listeler
        {
            if (sayfaadminmi == true)
            {
                forumlist = (from p in veri.FORUMKONULARI_TBL select p).OrderBy(p => p.FR_ADI).ToList();
            }
            else
            {
                forumlist = (from p in veri.FORUMKONULARI_TBL where p.FR_AKTIF == true select p).OrderBy(p => p.FR_ADI).ToList();
            }
            grd_list.DataSource = forumlist;
        }

        private void grdview_list_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) // seçili forum değiştikçe o formun mesajlarını listeler.
        {
            listelemesajlar();
        }

        void listelemesajlar() // seçilen formun mesajlarını listeler
        {
            if (grdview_list.GetFocusedRow() == null) return;
            string querystring = "select * from public.\"MESAJLARFORUM_V\" WHERE \"MSJ_FR_ID\" = " + Convert.ToInt32(grdview_list.GetFocusedRowCellValue("FR_ID"));

            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                grd_mesaj.DataSource = conn.Query<MESAJLARFORUM_V>(querystring).ToList();
            }
            grdview_mesaj.ViewCaption = grdview_list.GetFocusedRowCellValue("FR_ADI").ToString() + " Mesajları";

        }

        private void txt_forumdaara_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_mesajdaara_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_mesajdaara_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_forumdaara_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button_msjduzenle_Click(object sender, EventArgs e) // seçili mesajı düzenleme ekranını açar
        {
            if (grdview_mesaj.GetFocusedRow() == null) return;            

            MesajDuzenle dlg = new CallCenter.MesajDuzenle(Convert.ToInt32(grdview_mesaj.GetFocusedRowCellValue("MSJ_ID")));
            dlg.txt_mesaj.Text = grdview_mesaj.GetFocusedRowCellValue("MSJ_MESAJ").ToString();
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            AnaForm.logkaydet("Forum Mesajı", "Güncelleme (" + grdview_list.GetFocusedRowCellValue("FR_ADI").ToString() +")" );

            listelemesajlar();
        }

        private void button_msjsil_Click(object sender, EventArgs e) // seçili mesajı siler.
        {
            if (grdview_mesaj.GetFocusedRow() == null) return;

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili mesaj silinecektir.Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }

            try
            {
                msjid  = Convert.ToInt32(grdview_mesaj.GetFocusedRowCellValue("MSJ_ID"));
                var kayit = (from p in veri.MESAJLAR_TBL where p.MSJ_ID == msjid select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.MESAJLAR_TBL.Remove(kayit);
                    veri.SaveChanges();
                }
                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm.logkaydet("Forum Mesajı", "Silme (" + grdview_list.GetFocusedRowCellValue("FR_ADI").ToString() +")") ;

                listelemesajlar();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
