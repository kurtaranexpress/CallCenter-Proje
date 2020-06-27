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
    public partial class GenelAyarlar : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        int br_id = 0;
        ColorDialog Renk = new ColorDialog();
        public GenelAyarlar() //Genel ayarları gösterir
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            try
            {
                var sonuc = (from p in veri.GENELAYARLAR_TBL select p).ToList();
                tsp_gunbaslamasaati.EditValue = sonuc[0].GA_GUNBASLAMASAAT.ToString();
                tsp_gunbitissaati.EditValue = sonuc[0].GA_GUNBITISSAAT.ToString();
                chk_cumartesicalis.Checked = Convert.ToBoolean(sonuc[0].GA_CUMARTESICALIS);
                chk_pazarcalis.Checked = Convert.ToBoolean(sonuc[0].GA_PAZARCALIS);
                txt_baslik.Text = sonuc[0].GA_ANASAYFA_BASLIK;
                txt_domainadi.Text = sonuc[0].GA_CIHAZIP;
                tsp_yaklasanrandk.EditValue = sonuc[0].GA_YAKLASANRANDEVUDK.ToString();                
                txt_sunucu.Text = sonuc[0].GA_FTP_IP;
                txt_ftpkul.Text = sonuc[0].GA_FTP_KULLANICI;
                txt_ftpsifre.Text = sonuc[0].GA_FTP_SIFRE;
                txt_ftpdizin.Text = sonuc[0].GA_FTP_DIZIN;

                if (sonuc[0].GA_RANDEVUISTEKSAYFA == "TAKVIM")
                {
                    rd_ranlist.Checked = true;
                }
                else
                {
                    rd_ranekle.Checked = true; ;
                }
                listele(); //RENKLER İÇİN
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler Alınamadı, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e) // GENELAYARLAR_TBL deki kaydı günceller.
        {

            if ((TimeSpan)tsp_gunbaslamasaati.EditValue >= (TimeSpan)tsp_gunbitissaati.EditValue)
            {
                MessageBox.Show("Gün bitiş saati, başlama saatinden küçük ya da eşit olamaz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tsp_gunbitissaati.Focus();
                return;
            }
            try
            {
                var sonuc = (from p in veri.GENELAYARLAR_TBL select p).ToList();
                sonuc[0].GA_GUNBASLAMASAAT = (TimeSpan) tsp_gunbaslamasaati.EditValue;
                sonuc[0].GA_GUNBITISSAAT = (TimeSpan)tsp_gunbitissaati.EditValue;
                sonuc[0].GA_CUMARTESICALIS = chk_cumartesicalis.Checked;
                sonuc[0].GA_PAZARCALIS = chk_pazarcalis.Checked;
                sonuc[0].GA_ANASAYFA_BASLIK = txt_baslik.Text;
                sonuc[0].GA_CIHAZIP = txt_domainadi.Text;
                sonuc[0].GA_YAKLASANRANDEVUDK = (TimeSpan)tsp_yaklasanrandk.EditValue;
                
                sonuc[0].GA_FTP_IP = txt_sunucu.Text;
                sonuc[0].GA_FTP_KULLANICI = txt_ftpkul.Text;
                sonuc[0].GA_FTP_SIFRE = txt_ftpsifre.Text;
                sonuc[0].GA_FTP_DIZIN = txt_ftpdizin.Text;
                
                if (rd_ranlist.Checked == true )
                {
                    sonuc[0].GA_RANDEVUISTEKSAYFA = "TAKVIM";
                }
                else
                {
                    sonuc[0].GA_RANDEVUISTEKSAYFA = "EKLE";
                }

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!",MessageBoxButtons.OK, MessageBoxIcon.Information );                

                Application.OpenForms["AnaForm"].Text = txt_baslik.Text;


                AnaForm.logkaydet("Genel Ayarlar", "Güncelleme");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void temizle() // Formu temizler
        {
            br_id = 0;
            txt_kod.BackColor = Color.White;
            Renk.Color = Color.White;
            txt_kod.Text = "";
            ts_sure1.EditValue = "00:00";
            ts_sure2.EditValue = "00:00";
            ts_sure1.Focus();
        }
        
        private void btn_yeni_Click(object sender, EventArgs e) // RANDEVULISTERENKLERI_TBL a kayıt atmak için nesneleri temizler.
        {
            temizle();
        }
        private void button_sil_Click(object sender, EventArgs e) //RANDEVULISTERENKLERI_TBL den kayıt siler.
        {
            if (grdview_list.GetFocusedRow() == null) return;
            br_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("BR_ID"));            

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }

            try
            {
                var kayit = (from p in veri.RANDEVULISTERENKLERI_TBL where p.BR_ID == br_id select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.RANDEVULISTERENKLERI_TBL.Remove(kayit);
                    veri.SaveChanges();
                }

                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm.logkaydet("Bekleyen Randevu Renkleri", "Liste Düzenleme ");

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_duzenle_Click(object sender, EventArgs e) // RANDEVULISTERENKLERI_TBL deki kaydın görüntülenmesini sağlar.
        {
            if (grdview_list.GetFocusedRow() == null) return;

            br_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("BR_ID"));
            txt_kod.BackColor = Color.FromArgb(Convert.ToInt32(grdview_list.GetFocusedRowCellValue("BR_RENKKODU").ToString()));
            Renk.Color = ColorTranslator.FromHtml(grdview_list.GetFocusedRowCellValue("BR_RENKKODU").ToString());
            ts_sure1.EditValue = grdview_list.GetFocusedRowCellValue("BR_SURE1").ToString();
            ts_sure2.EditValue = grdview_list.GetFocusedRowCellValue("BR_SURE2").ToString();
        }

        private void btn_surekaydet_Click(object sender, EventArgs e) //  RANDEVULISTERENKLERI_TBL a kayıt atar ya da günceller.
        {
            var aralikvarmi = (from p in veri.RANDEVULISTERENKLERI_TBL where p.BR_ID != br_id &&
                               (
                               (p.BR_SURE1 >= (TimeSpan)ts_sure1.EditValue && p.BR_SURE1 <= (TimeSpan)ts_sure2.EditValue)
                                || (p.BR_SURE2 >= (TimeSpan)ts_sure1.EditValue && p.BR_SURE2 <= (TimeSpan)ts_sure2.EditValue)
                  || ((TimeSpan)ts_sure1.EditValue >= p.BR_SURE1 && (TimeSpan)ts_sure1.EditValue <= p.BR_SURE2)
                      || ((TimeSpan)ts_sure2.EditValue >= p.BR_SURE1 && (TimeSpan)ts_sure2.EditValue <= p.BR_SURE2)
                                )
                               select p).ToList();

            if (aralikvarmi.Count() > 0)
            {
                MessageBox.Show(aralikvarmi[0].BR_SURE1.ToString() + " - " + aralikvarmi[0].BR_SURE2.ToString() + " aralığında tanım bulunmaktadır.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ts_sure1.Focus();
                return;
            }
            
            try
            {
                RANDEVULISTERENKLERI_TBL kayit;
                if (br_id == 0)
                {
                    kayit = new RANDEVULISTERENKLERI_TBL();
                }
                else
                {
                    kayit = (from p in veri.RANDEVULISTERENKLERI_TBL where p.BR_ID == br_id select p).SingleOrDefault();

                }
                //Renk.Color.ToArgb().ToString()
                kayit.BR_RENKKODU = Renk.Color.ToArgb().ToString();
                kayit.BR_SURE1 = (TimeSpan)ts_sure1.EditValue;
                kayit.BR_SURE2 = (TimeSpan)ts_sure2.EditValue;


                if (br_id == 0) veri.RANDEVULISTERENKLERI_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm.logkaydet("Bekleyen Randevu Renkleri", "Liste Düzenleme " );
                

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_kod_Enter(object sender, EventArgs e) //renk seçtirme için renk bloğunu gösterir.
        {
            Renk.FullOpen = true;
            Renk.ShowDialog();
            txt_kod.BackColor = Renk.Color;
            ts_sure1.Focus();
        }

        void listele() // RANDEVULISTERENKLERI_TBL deki kayıtları listeler.
        {
            var sonuc = (from p in veri.RANDEVULISTERENKLERI_TBL select p).OrderBy(p => p.BR_SURE1).ToList();
            grd_list.DataSource = sonuc;
            grdview_list.RowCellStyle += Grdview_list_RowCellStyle;
        }

        private void Grdview_list_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e) // renklerin gridte görüntülenmesini sağlar.
        {
            if (e.Column.FieldName == "BR_RENKKODU")
            {
                e.Appearance.BackColor = Color.FromArgb(Convert.ToInt32(grdview_list.GetRowCellValue(e.RowHandle, "BR_RENKKODU")));
                e.Appearance.ForeColor = Color.FromArgb(Convert.ToInt32(grdview_list.GetRowCellValue(e.RowHandle, "BR_RENKKODU")));
            }
        }
    }
}
