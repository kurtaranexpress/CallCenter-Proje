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
    public partial class CikisKodlari : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        
        int ck_id = 0;

        public CikisKodlari()
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;
            listele();
            temizle();
        }

        void listele() // CIKISKODLARI_TBL yi listeler
        {
            var sonuc = (from p in veri.CIKISKODLARI_TBL select p).OrderBy(p => p.CK_ID ).ToList();
            grd_list.DataSource = sonuc;
        }
        

        void temizle() // Formdaki giriş kutularını temizler.
        {
            txt_kod.Text = "";
            txt_aciklama.Text = "";
            chk_aktif.Checked = false;
            ck_id = 0;
            txt_kod.Focus();
        }

        private void btn_yeni_Click(object sender, EventArgs e) // yeni çıkış kodu oluşturmak için nesneleri temizler.
        {
            temizle();
        }

        private void btn_yazdir_Click(object sender, EventArgs e) //gridi yazdırır.
        {
            grd_list.ShowPrintPreview();
        }


        private void btn_kaydet_Click(object sender, EventArgs e) // CIKISKODLARI_TBL a kayıt atar ya da kayıt günceller
        {
            if (txt_kod.Text == "")
            {
                MessageBox.Show("Lütfen Çıkış Kodu belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_kod.Focus();
                return;
            }

            try
            {
                CIKISKODLARI_TBL kayit;
                if (ck_id == 0)
                {
                    kayit = new CIKISKODLARI_TBL();                    
                }
                else
                {
                    kayit = (from p in veri.CIKISKODLARI_TBL where p.CK_ID == ck_id select p).SingleOrDefault();                    
                    
                }
                kayit.CK_KOD = txt_kod.Text;
                kayit.CK_ACIKLAMA = txt_aciklama.Text;
                kayit.CK_AKTIF = chk_aktif.Checked;
                kayit.CK_SEC = false;

                if (ck_id == 0) veri.CIKISKODLARI_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!",MessageBoxButtons.OK, MessageBoxIcon.Information );

                if (ck_id == 0)
                {
                    AnaForm.logkaydet("Çıkış Kodu", "Ekleme (" + txt_kod.Text + ")");
                }
                else
                {
                    AnaForm.logkaydet("Çıkış Kodu", "Güncelleme (" + txt_kod.Text +")");
                }

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void button_duzenle_Click(object sender, EventArgs e) //seçilen çıkış kodu bilgilerini görüntüler.
        {
            if (grdview_list.GetFocusedRow() == null) return;
            
            ck_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CK_ID"));
            txt_kod.Text = grdview_list.GetFocusedRowCellValue("CK_KOD").ToString();
            txt_aciklama.Text = grdview_list.GetFocusedRowCellValue("CK_ACIKLAMA").ToString();
            chk_aktif.Checked = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("CK_AKTIF"));
        }

        private void button_sil_Click(object sender, EventArgs e) //CIKISKODLARI_TBL dan kayıt siler.
        {
            if (grdview_list.GetFocusedRow() == null) return;

            ck_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CK_ID"));

            int cagrikontrol = (from p in veri.CAGRILAR_TBL  where p.CAG_CK_ID == ck_id select p).ToList().Count();
            if (cagrikontrol > 0)
            {
                MessageBox.Show("Çağrı(lar)da kullanılmış çıkış kodu silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int calismackkontrol = (from p in veri.CALISMACIKISKODLARI_TBL where p.CCK_CK_ID == ck_id select p).ToList().Count();
            if (calismackkontrol > 0)
            {
                MessageBox.Show("Çalışma(lar)a atanmış çıkış kodu silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }

            try
            {
                string kod = Convert.ToString(grdview_list.GetFocusedRowCellValue("CK_KOD"));
                var kayit = (from p in veri.CIKISKODLARI_TBL where p.CK_ID == ck_id select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.CIKISKODLARI_TBL.Remove(kayit);
                    veri.SaveChanges();
                }
                
                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm.logkaydet("Çıkış Kodu", "Silme (" + kod + ")");
                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
    }
}
