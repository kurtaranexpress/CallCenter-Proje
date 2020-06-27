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
    public partial class Kullanıcılar : Form
    {
        NpgsqlConnection conn;
        CallCenterEntities veri = new CallCenterEntities();
        List<KULLANICILAR_V> kullist;
        int kulid = 0;

        public Kullanıcılar() 
        {
            InitializeComponent();

            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            cmb_rol.Properties.ValueMember = "ROL_ID";
            cmb_rol.Properties.DisplayMember = "ROL_ADI";
            var roller = (from p in veri.ROLLER_TBL where p.ROL_AKTIF ==true select p).OrderBy(t=>t.ROL_SIRA).ToList();
            cmb_rol.Properties.DataSource = roller;
            

            cmb_kulid.Properties.ValueMember = "tc_kimlik_no";
            cmb_kulid.Properties.DisplayMember = "tc_kimlik_no";
            var kullist_out = (from p in veri.mv_tuik_personel select p).OrderBy(t => t.tc_kimlik_no).ToList();
            cmb_kulid.Properties.DataSource = kullist_out;

            listele();
            temizle();
        }
        

        void temizle() // formu temizler.
        {
            kulid = 0;
            cmb_kulid.EditValue  = null;
            cmb_rol.EditValue   = null;
            txt_kuladi.Text = "";
            txt_sifre.Text = "";
            txt_santralkuladi.Text = "";
            txt_santralsifre.Text = "";
            cmb_kulid.Focus();
        }

        private void btn_yeni_Click(object sender, EventArgs e) // formu temizler.
        {
            temizle();
        }

        private void btn_yazdir_Click(object sender, EventArgs e) // gridi yazdırır.
        {
            grd_list.ShowPrintPreview();
        }

        private void button_duzenle_Click(object sender, EventArgs e) // KULLANICILAR_TBL daki kaydı görüntüler.
        {
            if (grdview_list.GetFocusedRow() == null) return;
            try
            {
                kulid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("KUL_ID"));
                cmb_kulid.EditValue = grdview_list.GetFocusedRowCellValue("KUL_KULLANICIID").ToString();            
                cmb_rol.EditValue  = grdview_list.GetFocusedRowCellValue("KUL_ROL_ID"); //edit value verirsen listeyi filtrelemiyor, diğer seçenekleri sadece oka tıklayınca görüyor.
                //cmb_rol.Text = grdview_list.GetFocusedRowCellValue("ROL_ADI").ToString(); //text value verirsen listeyi o text e göre filtreliyor, değiştirmek isteyince sol alttaki çarpı ile listeyi sıfırlayıp getirmen gerekiyor.            
                txt_kuladi.Text = grdview_list.GetFocusedRowCellValue("KUL_ADI").ToString();
                txt_sifre.Text = grdview_list.GetFocusedRowCellValue("KUL_SIFRE").ToString();
                txt_santralkuladi.Text = grdview_list.GetFocusedRowCellValue("KUL_SANTRALUSERID").ToString();
                txt_santralsifre.Text = grdview_list.GetFocusedRowCellValue("KUL_SANTRALSIFRE").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                temizle();
            }
            
        }

        private void btn_kaydet_Click(object sender, EventArgs e) //KULLANICILAR_TBL a kayıt atar ya da günceller.
        {
            

            if (cmb_kulid.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı ID belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_kulid.Focus();
                return;
            }

            if (cmb_rol.Text == "")
            {
                MessageBox.Show("Lütfen Rol belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_rol.Focus();
                return;
            }

            if (txt_kuladi.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_kuladi.Focus();
                return;
            }

            if (txt_sifre.Text == "")
            {
                MessageBox.Show("Lütfen Şifre belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_sifre.Focus();
                return;
            }

            var varmi = (from p in veri.KULLANICILAR_TBL where p.KUL_KULLANICIID == cmb_kulid.Text && p.KUL_ID != kulid select p).SingleOrDefault();
            if (varmi != null)
            {
                string msj = "";
                if (varmi.KUL_SIL == true)
                {
                    msj = "Bu Kullanıcı ID daha önce silinmiştir, tanımlanamaz...";
                }
                else
                {
                    msj = "Aynı Kullanıcı ID birden fazla tanımlanamaz...";
                }
                MessageBox.Show(msj, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_kulid.Focus();
                return;
            }

            try
            {
                KULLANICILAR_TBL kayit;
                if (kulid == 0)
                {
                    kayit = new KULLANICILAR_TBL();
                    kayit.KUL_HOPARLORDUZEYI = 100;
                    kayit.KUL_MIKROFONDUZEYI = 100;
                }
                else
                {
                    kayit = (from p in veri.KULLANICILAR_TBL where p.KUL_ID == kulid select p).SingleOrDefault();
                }

                kayit.KUL_ADI = txt_kuladi.Text;
                kayit.KUL_SIFRE = txt_sifre.Text;
                kayit.KUL_SANTRALUSERID = txt_santralkuladi.Text;
                kayit.KUL_SANTRALSIFRE = txt_santralsifre.Text;
                kayit.KUL_ROL_ID = Convert.ToInt32 ( cmb_rol.EditValue);
                kayit.KUL_KULLANICIID = cmb_kulid.Text;
                kayit.KUL_SEC = false;
                kayit.KUL_SIL = false;
                
                if (kulid == 0) veri.KULLANICILAR_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!",MessageBoxButtons.OK, MessageBoxIcon.Information );

                if (kulid == 0)
                {
                    AnaForm.logkaydet("Kullanıcı", "Ekleme (" + cmb_kulid.Text + " " + txt_kuladi.Text +")");
                }
                else
                {
                    AnaForm.logkaydet("Kullanıcı", "Güncelleme (" + cmb_kulid.Text + " " + txt_kuladi.Text +")");
                }

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sil_Click(object sender, EventArgs e) //  KULLANICILAR_TBL den kayıt siler.
        {
            if (grdview_list.GetFocusedRow() == null) return;

            if (Convert.ToInt32(grdview_list.GetFocusedRowCellValue("KUL_ID")) == AnaForm.userid)
            {
                MessageBox.Show("Kendi kullanıcınızı silemezsiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }                                             

            if (Convert.ToString(grdview_list.GetFocusedRowCellValue("ROL_ANAROL")) == "Admin")
            {                
                List<KULLANICILAR_V> kullistsorgu;
                using (conn = new NpgsqlConnection(AnaForm.cstr))
                {
                    conn.Open();
                    kullistsorgu = conn.Query<KULLANICILAR_V>("select * from public.\"KULLANICILAR_V\" where \"KUL_SIL\"=FALSE  and \"ROL_ANAROL\"='Admin' and \"KUL_ID\"<> " + Convert.ToInt32(grdview_list.GetFocusedRowCellValue("KUL_ID")) + "").ToList();
                }

                if (kullistsorgu.Count()==0) //silmek istediği admin anarollü kullanıcıdan başka, admin anarollü kullanıcı yok.
                {
                    MessageBox.Show("En az bir Admin Ana Rolü olmalı, bu yüzden silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }

            try
            {
                kulid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("KUL_ID"));
                var kayit = (from p in veri.KULLANICILAR_TBL where p.KUL_ID == kulid select p).SingleOrDefault();
                if (kayit != null)
                {
                    //veri.KULLANICILAR_TBL.Remove(kayit);
                    //veri.SaveChanges();

                    kayit.KUL_SIL = true;
                    kayit.KUL_SILME_TARIH = AnaForm.tarihsaatgetir();
                    kayit.KUL_SILME_KUL_ID = AnaForm.userid;
                    veri.SaveChanges();
                }
                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm.logkaydet("Kullanıcı", "Silme (" +  Convert.ToString(grdview_list.GetFocusedRowCellValue("KUL_KULLANICIID")) + " " + Convert.ToString(grdview_list.GetFocusedRowCellValue("KUL_ADI")) + ")");

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void listele() // KULLANICILAR_TBL deki kayıtları listeler.
        {
            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                kullist  = conn.Query<KULLANICILAR_V>("select * from public.\"KULLANICILAR_V\" where \"KUL_SIL\"=FALSE").ToList();
                grd_list.DataSource = kullist;
            }
        }

        private void button_kulcalismalari_Click(object sender, EventArgs e) // seçilen kullanıcının görebildiği kayıtları listeler.
        {
            KullaniciCalismalari  cck = new KullaniciCalismalari(Convert.ToInt32(grdview_list.GetFocusedRowCellValue("KUL_ID")), Convert.ToString(grdview_list.GetFocusedRowCellValue("KUL_KULLANICIID")), grdview_list.GetFocusedRowCellValue("KUL_ADI").ToString());
            cck.ShowDialog();
        }

        private void cmb_kulid_EditValueChanged(object sender, EventArgs e) // seçilen kullanıcının adını text e getirir.
        {
            try
            {
                txt_kuladi.Text = (from p in veri.mv_tuik_personel where p.tc_kimlik_no == cmb_kulid.EditValue.ToString() select p).SingleOrDefault().adsoyad;
            }
            catch (Exception)
            {
            }
        }
    }
}
