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
    public partial class RandevuDurumlari : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        int renk_id = 0;
        ColorDialog Renk = new ColorDialog();

        public RandevuDurumlari() //randevu etiketlerini listeler. 
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            //ColorDialog Renk = new ColorDialog();
            listele();
            temizle();
        }

        void listele() //randevu etiketlerini listeler. 

        {
            var sonuc = (from p in veri.RENKLER_TBL select p).OrderBy(p => p.RENK_BASLIK).ToList();
            grd_list.DataSource = sonuc;
            grdview_list.RowCellStyle += Grdview_list_RowCellStyle;            
        }

      

        private void Grdview_list_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e) // gridin renk göstermesini sağlar. 
        {
            //e.Appearance.BackColor = Color.FromArgb(Convert.ToInt32(e.CellValue));
            if (e.Column.FieldName == "RENK_GOSTER" )
            {               
                e.Appearance.BackColor = Color.FromArgb(Convert.ToInt32(grdview_list.GetRowCellValue(e.RowHandle,"RENK_KOD") ));
            }
        }

        void temizle() // formu temizler. 
        {
            renk_id = 0;
            txt_kod.BackColor = Color.White;
            Renk.Color = Color.White;
            txt_kod.Text = "";
            chk_aktif.Checked = false;
            txt_aciklama.Text = "";
            txt_aciklama.Focus();
        }

        private void btn_yeni_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btn_kaydet_Click(object sender, EventArgs e) // RENKLER_TBL ye kayıt atar ya da günceller.
        {
            //if (txt_kod.Text == "")
            //{
            //    MessageBox.Show("Lütfen Renk Kodu belirtiniz");
            //    txt_kod.Focus();
            //    return;
            //}

            if (txt_aciklama.Text == "")
            {
                MessageBox.Show("Lütfen Açıklama belirtiniz");
                txt_aciklama.Focus();
                return;
            }

            try
            {
                RENKLER_TBL kayit;
                if (renk_id == 0)
                {
                    kayit = new RENKLER_TBL();
                }
                else
                {
                    kayit = (from p in veri.RENKLER_TBL where p.RENK_ID == renk_id select p).SingleOrDefault();
                }
                //Renk.Color.ToArgb().ToString()
                kayit.RENK_KOD = Renk.Color.ToArgb().ToString();

                // kayit.RENK_KOD = ColorTranslator.ToHtml(Renk.Color); // "#FF" + String.Format("{0:X2}{1:X2}{2:X2}", Renk.Color.B, Renk.Color.G, Renk.Color.R);
                kayit.RENK_HEX = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                      Renk.Color.A,
                      Renk.Color.R,
                      Renk.Color.G,
                      Renk.Color.B);
                kayit.RENK_BASLIK = txt_aciklama.Text;

                kayit.RENK_AKTIF = chk_aktif.Checked;

                if (renk_id == 0) veri.RENKLER_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!",MessageBoxButtons.OK, MessageBoxIcon.Information );

                AnaForm.logkaydet("Randevu Durumları", "Liste Düzenleme");

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_duzenle_Click(object sender, EventArgs e) // RENKLER_TBL deki kaydın görüntülenmesini sağlar. 
        {
            if (grdview_list.GetFocusedRow() == null) return;

            renk_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("RENK_ID"));
            txt_kod.BackColor = Color.FromArgb(Convert.ToInt32(grdview_list.GetFocusedRowCellValue("RENK_KOD").ToString()));
            //Renk.Color = Color.FromArgb(Convert.ToInt32(grdview_list.GetFocusedRowCellValue("RENK_KOD").ToString()));
            Renk.Color = ColorTranslator.FromHtml(grdview_list.GetFocusedRowCellValue("RENK_KOD").ToString());
            txt_aciklama.Text = grdview_list.GetFocusedRowCellValue("RENK_BASLIK").ToString();
            chk_aktif.Checked = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("RENK_AKTIF"));
        }

        private void button_sil_Click(object sender, EventArgs e) // RENKLER_TBL deki kaydı görüntüler.
        {
            if (grdview_list.GetFocusedRow() == null) return;
            renk_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("RENK_ID"));

            int rankontrol = (from p in veri.RANDEVULAR_TBL where p.RAN_DURUMID == renk_id select p).ToList().Count();
            if (rankontrol > 0)
            {
                MessageBox.Show("Randevu(lar)da kullanılmış renk silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var kayit = (from p in veri.RENKLER_TBL where p.RENK_ID == renk_id select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.RENKLER_TBL.Remove(kayit);
                    veri.SaveChanges();
                }

                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_yazdir_Click(object sender, EventArgs e) //gridi yazdırır. 
        {
            grd_list.ShowPrintPreview();
        }
        private void txt_kod_Enter(object sender, EventArgs e) // renk seçimi için renk bloğunu açar. 
        {            
            Renk.FullOpen = true;
            Renk.ShowDialog();
            txt_kod.BackColor = Renk.Color;
            txt_aciklama.Focus();
        }

        
    }
}
