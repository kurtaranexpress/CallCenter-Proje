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
    public partial class GenelCalismaAraliklari : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        int ctid = 0;
        public int sayfacal_id = 0;

        public GenelCalismaAraliklari(int cal_id, string calismaID, string caladi)  // genel ya da çalışmaya ait tatil/ek mesaileri listeler
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            sayfacal_id = cal_id;
            

            if (sayfacal_id == 0)
            {
                lbl_calisma.Visible = false;
            }
            else
            {
                lbl_calisma.Text = calismaID + " " + caladi;
                //grdview_list.ViewCaption = lbl_calisma.Text + " Tatil/Ek Mesai Listesi";
                //this.Text = lbl_calisma.Text + " Tatil/Ek Mesai Listesi";
                this.Text ="Çalışma Tatil/Ek Mesai Listesi";
            }
            listele();
        }

        private void button_duzenle_Click(object sender, EventArgs e) // CALISMATAKVIMI_TBL deki kaydı görüntüler.
        {
            if (grdview_list.GetFocusedRow() == null) return;

            txt_adi.Text = grdview_list.GetFocusedRowCellValue(grdview_list.Columns["CT_ADI"]).ToString(); //bu da çalışıyor
            ctid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CT_ID"));
            txt_adi.Text = grdview_list.GetFocusedRowCellValue("CT_ADI").ToString();
            dt_1.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CT_BASLAMA"));
            dt_2.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CT_BITIS"));
            chk_calis.Checked = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("CT_CALIS"));
        }

        private void button_sil_Click(object sender, EventArgs e) // CALISMATAKVIMI_TBL den kayıt siler.
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
                ctid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CT_ID"));
                var kayit = (from p in veri.CALISMATAKVIMI_TBL where p.CT_ID == ctid select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.CALISMATAKVIMI_TBL.Remove(kayit);
                    veri.SaveChanges();

                }
                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (sayfacal_id == 0) 
                {
                    AnaForm.logkaydet("Genel Tatil/Ek Mesai", "Silme (" + Convert.ToString(grdview_list.GetFocusedRowCellValue("CT_ADI")) +")");
                }
                else
                {
                    AnaForm.logkaydet("Tatil/Ek Mesai", "Silme (" + Convert.ToString(grdview_list.GetFocusedRowCellValue("CT_ADI")) + ")" + "(" + lbl_calisma.Text +")" );
                }

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_kaydet_Click(object sender, EventArgs e) // CALISMATAKVIMI_TBL a kayıt atar.
        {
            if (txt_adi.Text == "")
            {
                MessageBox.Show("Lütfen Tatil/Ek Mesai Adı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_adi.Focus();
                return;
            }
            if (Convert.ToDateTime(dt_1.DateTime) >= Convert.ToDateTime(dt_2.DateTime))
            {
                MessageBox.Show("Bitiş tarihi, başlama tarihinden küçük ya da eşit olamaz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt_2.Focus();
                return;
            }

            try
            {
                CALISMATAKVIMI_TBL kayit;
                if (ctid == 0)
                {
                    kayit = new CALISMATAKVIMI_TBL();
                }
                else
                {
                    kayit = (from p in veri.CALISMATAKVIMI_TBL where p.CT_ID == ctid select p).SingleOrDefault();

                }
                
                if (sayfacal_id != 0) //genel ise null kalır ct_cal_id
                {
                    kayit.CT_CAL_ID = sayfacal_id; //bu bir defa gelir bir daha değişmez.
                }
                kayit.CT_ADI = txt_adi.Text;
                kayit.CT_BASLAMA = dt_1.DateTime;
                kayit.CT_BITIS = dt_2.DateTime;
                kayit.CT_CALIS = chk_calis.Checked;

                if (ctid == 0) veri.CALISMATAKVIMI_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!",MessageBoxButtons.OK, MessageBoxIcon.Information );

                string islem = "";
                islem = ctid == 0 ? "Ekleme " : "Güncelleme ";              

                if (sayfacal_id == 0) //genel ise null kalır ct_cal_id
                {
                    AnaForm.logkaydet("Genel Tatil/Ek Mesai", islem + "(" + txt_adi.Text +")" ); 
                }
                else
                {
                    AnaForm.logkaydet("Tatil/Ek Mesai", islem + "(" + txt_adi.Text + ")" + "(" + lbl_calisma.Text +")" );
                }

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_yeni_Click(object sender, EventArgs e) // formu temizler.
        {
            temizle();
        }

        void listele() // genel ya da bir çalışmaya ait tatil/ek mesaileri listeler.
        {
            List<CALISMATAKVIMI_TBL> sonuc;
            if (sayfacal_id == 0)
            {
                sonuc = (from p in veri.CALISMATAKVIMI_TBL select p).OrderBy(p => p.CT_BASLAMA).ToList();
            }
            else
            {
                sonuc = (from p in veri.CALISMATAKVIMI_TBL where p.CT_CAL_ID == sayfacal_id select p).OrderBy(p => p.CT_BASLAMA).ToList();
            }
            grd_list.DataSource = sonuc;
        }

        void temizle() //formu temizler.
        {
            txt_adi.Text = "";
            dt_1.Text = "";
            dt_2.Text = "";
            chk_calis.Checked = false;
            ctid = 0;
            txt_adi.Focus();
        }


        private void btn_yazdir_Click(object sender, EventArgs e) // gridi yazdırır.
        {
            grd_list.ShowPrintPreview();
        }
        
    }
}
