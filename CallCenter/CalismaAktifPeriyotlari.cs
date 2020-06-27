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
    public partial class CalismaAktifPeriyotlari : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        int cpid = 0;
        public int sayfacal_id = 0;

        public CalismaAktifPeriyotlari(int cal_id, string calismaID, string caladi)
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            sayfacal_id = cal_id;

            if (sayfacal_id == 0)
            {
                lbl_calisma.Visible = false; //bu durum gerçekleşmiyor zaten.
            }
            else
            {
                lbl_calisma.Text = calismaID + " " + caladi;
                grdview_list.ViewCaption = lbl_calisma.Text + " Aktif Periyotları";
            }

            listele();
            temizle();

        }

        private void btn_kaydet_Click(object sender, EventArgs e) // CALISMAPERIYOTLARI_TBL tablosuna kayıt atar ya da günceller.
        {

            if (dt_yil.Text == "" && dt_yil.Visible == true)
            {
                MessageBox.Show("Lütfen Çalışma Yılı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dt_yil.Focus();
                return;
            }
            if (sp_donem.Text == "" && sp_donem.Visible == true && sp_ay.Visible == false && sp_hafta.Visible == false) //ay ve haftada dönem zorunlu değil. tabi dönemlikte zorunlu
            {
                MessageBox.Show("Lütfen Dönem belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sp_donem.Focus();
                return;
            }

            if (sp_ay.Text == "" && sp_ay.Visible == true)
            {
                MessageBox.Show("Lütfen Ay belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sp_ay.Focus();
                return;
            }

            if (sp_hafta.Text == "" && sp_hafta.Visible == true)
            {
                MessageBox.Show("Lütfen Hafta belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sp_hafta.Focus();
                return;
            }


            if (tbl_referans_panel.Visible == true)
            {
                if (dt_manuel_basla.Text == "" && dt_manuel_basla.Visible == true)
                {
                    MessageBox.Show("Lütfen Manuel Başlama Tarihi belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dt_manuel_basla.Focus();
                    return;
                }

                if (dt_manuel_bitis.Text == "" && dt_manuel_bitis.Visible == true)
                {
                    MessageBox.Show("Lütfen Manuel Bitiş Tarihi belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dt_manuel_bitis.Focus();
                    return;
                }
            }
            if (dt_baslama.Text == "")
            {
                MessageBox.Show("Lütfen Başlama Tarihi belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt_baslama.Focus();
                return;
            }

            if (dt_bitis.Text == "")
            {
                MessageBox.Show("Lütfen Bitiş Tarihi belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt_bitis.Focus();
                return;
            }



            try
            {
                CALISMAPERIYOTLARI_TBL kayit;
                if (cpid == 0)
                {
                    kayit = new CALISMAPERIYOTLARI_TBL();
                }
                else
                {
                    kayit = (from p in veri.CALISMAPERIYOTLARI_TBL where p.CP_ID == cpid select p).SingleOrDefault();
                }
                if (dt_yil.Visible == true)
                {
                    kayit.CP_REFYIL = dt_yil.DateTime;
                }
                if (sp_donem.Visible == true && sp_donem.Text != null && sp_donem.Text != "" && sp_donem.Text != "0")
                {
                    kayit.CP_REFDONEM = Convert.ToInt32(sp_donem.Text);
                }
                else
                {
                    kayit.CP_REFDONEM = null;
                }

                if (sp_ay.Visible == true && sp_ay.Text != null && sp_ay.Text != "" && sp_ay.Text != "0")
                {
                    kayit.CP_REFAY = Convert.ToInt32(sp_ay.Text);
                }
                else
                {
                    kayit.CP_REFAY = null;
                }
                if (sp_hafta.Visible == true && sp_hafta.Text != null && sp_hafta.Text != "" && sp_hafta.Text != "0")
                {
                    kayit.CP_REFHAFTA = Convert.ToInt32(sp_hafta.Text);
                }
                else
                {
                    kayit.CP_REFHAFTA = null;
                }

                if (dt_manuel_basla.Visible == true)
                {
                    kayit.CP_REF_MA_BASLANGIC = dt_manuel_basla.DateTime;
                }
                if (dt_manuel_bitis.Visible == true)
                {
                    kayit.CP_REF_MA_BITIS = dt_manuel_bitis.DateTime;
                }
                kayit.CP_BASLAMATARIH = dt_baslama.DateTime;
                kayit.CP_BITISTARIH = dt_bitis.DateTime;
                kayit.CP_AKTIF = chk_aktif.Checked;
                kayit.CP_CAL_ID = sayfacal_id;

                if (cpid == 0) veri.CALISMAPERIYOTLARI_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cpid == 0)
                {
                    AnaForm.logkaydet("Çalışma Aktif Periyodu", "Ekleme (" + lbl_calisma.Text +")");
                }
                else
                {
                    AnaForm.logkaydet("Çalışma Aktif Periyodu", "Güncelleme (" + lbl_calisma.Text +")");
                }

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_duzenle_Click(object sender, EventArgs e) //CALISMAPERIYOTLARI_TBL deki kaydı getirir.
        {
            if (grdview_list.GetFocusedRow() == null) return;

            cpid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CP_ID"));

            dt_yil.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CP_REFYIL"));
            if (grdview_list.GetFocusedRowCellValue("CP_REFDONEM") != null) sp_donem.Text = Convert.ToString(grdview_list.GetFocusedRowCellValue("CP_REFDONEM"));
            sp_ay.Text = Convert.ToString(grdview_list.GetFocusedRowCellValue("CP_REFAY"));
            sp_hafta.Text = Convert.ToString(grdview_list.GetFocusedRowCellValue("CP_REFHAFTA"));
            dt_baslama.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CP_BASLAMATARIH"));
            dt_bitis.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CP_BITISTARIH"));
            dt_manuel_basla.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CP_REF_MA_BASLANGIC"));
            dt_manuel_bitis.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CP_REF_MA_BITIS"));
            chk_aktif.Checked = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("CP_AKTIF"));
        }

        private void button_sil_Click(object sender, EventArgs e) //CALISMAPERIYOTLARI_TBL den kayıt siler.
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
                cpid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CP_ID"));
                var kayit = (from p in veri.CALISMAPERIYOTLARI_TBL where p.CP_ID == cpid select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.CALISMAPERIYOTLARI_TBL.Remove(kayit);
                    veri.SaveChanges();
                }

                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm.logkaydet("Çalışma Aktif Periyodu", "Silme (" + lbl_calisma.Text+ ")");

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_yeni_Click(object sender, EventArgs e)
        {
            temizle();
        }

        void listele() //Çalışma Aktif Periyotları listeler. 
        {
            var sonuc = (from p in veri.CALISMAPERIYOTLARI_TBL where p.CP_CAL_ID == sayfacal_id select p).OrderBy(p => p.CP_BASLAMATARIH).ToList();
            grd_list.DataSource = sonuc;
        }

        void temizle() // Formdaki giriş componentlerini temizler.
        {
            dt_yil.Text = "";
            sp_donem.Text = null;
            sp_ay.Text = null;
            sp_hafta.Text = null;
            dt_baslama.Text = "";
            dt_bitis.Text = "";
            dt_manuel_basla.Text = "";
            dt_manuel_bitis.Text = "";
            chk_aktif.Checked = false;
            cpid = 0;
            dt_yil.Focus();
        }



        private void btn_yazdir_Click(object sender, EventArgs e) //Gridi yazdırır.
        {
            grd_list.ShowPrintPreview();
        }

    }
}
