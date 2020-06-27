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
    public partial class Calismalar : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        int  cal_id = 0;

        public Calismalar() 
        {
            InitializeComponent();

            veri.Database.Connection.ConnectionString = AnaForm.cstr;           

            cmb_calismaid.Properties.ValueMember = "study_id";
            cmb_calismaid.Properties.DisplayMember = "study_id";
            var callist_out = (from p in veri.mv_study_name select p).OrderBy(t => t.study_id).ToList();
            cmb_calismaid.Properties.DataSource = callist_out;
            
            listele();
            temizle();
        }
        

        private void btn_kaydet_Click(object sender, EventArgs e)  // CALISMALAR_TBL ye kayıt ekler ya da günceller
        {
            string calismaid = "";
            if (cmb_periyot.Text == "Manuel Aralık")
            {
                calismaid = txt_mancalismaid.Text;
            }
            else
            {
                calismaid = cmb_calismaid.Text;
            }

            if (calismaid == "")
            {
                MessageBox.Show("Lütfen Çalışma ID belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                if (cmb_periyot.Text == "Manuel Aralık")
                {
                    txt_mancalismaid.Focus(); ;
                }
                else
                {
                    cmb_calismaid.Focus();
                }
                return;
            }

            var varmi = (from p in veri.CALISMALAR_TBL where p.CAL_CALISMAID == calismaid && p.CAL_ID != cal_id select p).SingleOrDefault();                            
            if (varmi!= null)
            {
                string msj = "";
                if (varmi.CAL_SIL == true)
                {
                    msj = "Bu Çalışma ID daha önce silinmiştir, tanımlanamaz";
                }
                else
                {
                    msj = "Aynı Çalışma ID birden fazla tanımlanamaz...";
                }

                MessageBox.Show(msj, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (cmb_periyot.Text == "Manuel Aralık")
                {
                    txt_mancalismaid.Focus(); ;
                }
                else
                {
                    cmb_calismaid.Focus();
                }
                return;
            }

            if (txt_adi.Text == "")
            {
                MessageBox.Show("Lütfen Çalışma Adı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_adi.Focus();
                return;
            }

            if (dt_yili.Text == "")
            {
                MessageBox.Show("Lütfen Çalışma Yılı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt_yili.Focus();
                return;
            }
            if (cmb_periyot.Text == "")
            {
                MessageBox.Show("Lütfen Çalışma Periyodu belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_periyot.Focus();
                return;
            }
            if (dt_baslama.Text == "" )
            {
                MessageBox.Show("Lütfen Başlama Tarihi belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt_baslama.Focus();
                return;
            }

            if (dt_bitis.Text =="")
            {
                MessageBox.Show("Lütfen Bitiş Tarihi belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt_bitis.Focus();
                return;
            }

            if (Convert.ToDateTime(dt_baslama.DateTime) >= Convert.ToDateTime(dt_bitis.DateTime))
            {
                MessageBox.Show("Bitiş Tarihi, Başlama Tarihinden küçük ya da eşit olamaz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt_bitis.Focus();
                return;
            }


            //if (tsp_gunbaslamasaati.EditValue == null )
            //{
            //    MessageBox.Show("Lütfen Gün Başlama Saati belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tsp_gunbaslamasaati.Focus();
            //    return;
            //}

            //if (tsp_gunbitissaati.EditValue == null)
            //{
            //    MessageBox.Show("Lütfen Gün Bitiş Saati belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tsp_gunbitissaati.Focus();
            //    return;
            //}

            if (t_randevudk.EditValue == null)
            {
                MessageBox.Show("Lütfen Randevu Aralığı belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                t_randevudk.Focus();
                return;
            }

            if (tsp_gunbaslamasaati.EditValue != null && tsp_gunbitissaati.EditValue != null)
            {
                if ((TimeSpan)tsp_gunbaslamasaati.EditValue >= (TimeSpan)tsp_gunbitissaati.EditValue)
                {
                    MessageBox.Show("Gün Bitiş Saati, Başlama Saatinden küçük ya da eşit olamaz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tsp_gunbitissaati.Focus();
                    return;
                }
            }
            


            try
            {

                CALISMALAR_TBL kayit;
                if (cal_id == 0)
                {
                    kayit = new CALISMALAR_TBL();
                }
                else
                {
                    kayit = (from p in veri.CALISMALAR_TBL where p.CAL_ID == cal_id select p).SingleOrDefault();
                }
                kayit.CAL_CALISMAID = calismaid; //cmb_calismaid.Text;
                kayit.CAL_ADI = txt_adi.Text;
                kayit.CAL_PERIYOT = cmb_periyot.Text;
                kayit.CAL_YIL =dt_yili.DateTime;
                kayit.CAL_BASLAMATARIH = dt_baslama.DateTime;
                kayit.CAL_BITISTARIH = dt_bitis.DateTime;
                if (tsp_gunbaslamasaati.EditValue != null) kayit.CAL_GUNBASLAMASAAT = (TimeSpan)tsp_gunbaslamasaati.EditValue;
                if (tsp_gunbitissaati.EditValue != null) kayit.CAL_GUNBITISSAAT = (TimeSpan)tsp_gunbitissaati.EditValue;
                kayit.CAL_RANDEVUARALIK = (TimeSpan)t_randevudk.EditValue;
                kayit.CAL_MANUELARAMA = chk_manuelara.Checked;
                kayit.CAL_SEC = false;
                kayit.CAL_SIL = false;

                if (cal_id == 0) veri.CALISMALAR_TBL.Add(kayit);

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!",MessageBoxButtons.OK, MessageBoxIcon.Information );
                if (cal_id == 0)
                {
                    AnaForm.logkaydet("Çalışma", "Ekleme (" + calismaid + " " + txt_adi.Text+")");
                }
                else
                {
                    AnaForm.logkaydet("Çalışma", "Güncelleme (" + calismaid + " " + txt_adi.Text +")");
                }                

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void button_duzenle_Click(object sender, EventArgs e) //CALISMALAR_TBL deki kaydın görüntülenmesini sağlar.
        {
            if (grdview_list.GetFocusedRow() == null) return;

            //txt_adi.Text = grdview_list.GetFocusedRowCellValue(grdview_list.Columns["GT_ADI"]).ToString(); //bu da çalışıyor

            cal_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CAL_ID"));

            cmb_periyot.Text = grdview_list.GetFocusedRowCellValue("CAL_PERIYOT").ToString();

            if (grdview_list.GetFocusedRowCellValue("CAL_PERIYOT").ToString() == "Manuel Aralık")
            {
                txt_mancalismaid.Text = grdview_list.GetFocusedRowCellValue("CAL_CALISMAID").ToString();
            }
            else
            {
                cmb_calismaid.EditValue = grdview_list.GetFocusedRowCellValue("CAL_CALISMAID").ToString(); //CAL_CALISMAID YI KENDI GETİRECEK
            }

            
            txt_adi.Text = grdview_list.GetFocusedRowCellValue("CAL_ADI").ToString();
            dt_baslama.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CAL_BASLAMATARIH"));
            dt_bitis.DateTime = Convert.ToDateTime(grdview_list.GetFocusedRowCellValue("CAL_BITISTARIH"));

            if (grdview_list.GetFocusedRowCellValue("CAL_GUNBASLAMASAAT") != null)
            {
                tsp_gunbaslamasaati.EditValue = grdview_list.GetFocusedRowCellValue("CAL_GUNBASLAMASAAT").ToString();
            }
            if (grdview_list.GetFocusedRowCellValue("CAL_GUNBITISSAAT") != null)
            {
                tsp_gunbitissaati.EditValue = grdview_list.GetFocusedRowCellValue("CAL_GUNBITISSAAT").ToString();
            }
            t_randevudk.EditValue = grdview_list.GetFocusedRowCellValue("CAL_RANDEVUARALIK").ToString();
            chk_manuelara.Checked = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("CAL_MANUELARAMA"));
            dt_yili.DateTime = Convert.ToDateTime(  grdview_list.GetFocusedRowCellValue("CAL_YIL"));
        }

        private void button_sil_Click(object sender, EventArgs e) //CALISMALAR_TBL den seçilen kaydı siler.
        {
            if (grdview_list.GetFocusedRow() == null) return;
            cal_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CAL_ID"));

            string calcalismaid = Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_CALISMAID"));

            int istekkontrol = (from p in veri.ISTEKLER_TBL where p.IST_OKUNDU != true && p.IST_CALISMAID == calcalismaid  select p).ToList().Count() ;
            if (istekkontrol>0)
            {
                MessageBox.Show("Çalışmaya ait bekleyen istek mevcut, silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime bugun = AnaForm.tarihsaatgetir();
            int randevukontrol = (from p in veri.RANDEVULAR_TBL where p.RAN_CAL_ID == cal_id &&  p.RAN_BASLAMATARIH >bugun select p).ToList().Count();
            if (randevukontrol > 0)
            {
                MessageBox.Show("Çalışmaya ait randevular mevcut, silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var kayit = (from p in veri.CALISMALAR_TBL where p.CAL_ID == cal_id select p).SingleOrDefault();
                if (kayit != null)
                {
                    //veri.CALISMALAR_TBL.Remove(kayit);
                    //veri.SaveChanges();

                    kayit.CAL_SIL = true;
                    kayit.CAL_SILME_TARIH = AnaForm.tarihsaatgetir();
                    kayit.CAL_SILME_KUL_ID = AnaForm.userid;
                    veri.SaveChanges();
                }

                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnaForm.logkaydet("Çalışma", "Silme " + calcalismaid + " (" + Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_ADI")) +")");

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
                
        void listele()
        {
            var sonuc = (from p in veri.CALISMALAR_TBL where p.CAL_SIL == false  select p).OrderBy(p => p.CAL_CALISMAID ).ToList();
            grd_list.DataSource = sonuc;
        }

        void temizle()
        {
            cmb_calismaid.EditValue = null; 
            txt_adi.Text = "";
            dt_yili.Text = "";
            cmb_periyot.Text = "";
            dt_baslama.Text = "";
            dt_bitis.Text = "";
            tsp_gunbaslamasaati.EditValue  = null ;
            tsp_gunbitissaati.EditValue  = null;
            t_randevudk.EditValue = null;
            chk_manuelara.Checked = false;
            

            cal_id = 0;
            txt_adi.Focus();
        }
        
        

        private void btn_yazdir_Click(object sender, EventArgs e) // Gridi yazdırır.
        {
            grd_list.ShowPrintPreview();
        }

        private void button_calismaaraliklari_Click(object sender, EventArgs e) // Seçilen çalışmaya ait tatil/ek mesai leri listeler.
        {
            if (grdview_list.GetFocusedRow() == null) return;
            GenelCalismaAraliklari ca = new GenelCalismaAraliklari(Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CAL_ID")), Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_CALISMAID")), grdview_list.GetFocusedRowCellValue("CAL_ADI").ToString());
            ca.ShowDialog();
        }
        
        private void button_aktifperiyotlari_Click(object sender, EventArgs e) // Seçilen çalışmaya ait aktif periyotları listeler.
        {
            CalismaAktifPeriyotlari cap = new CalismaAktifPeriyotlari(Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CAL_ID")), Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_CALISMAID")), grdview_list.GetFocusedRowCellValue("CAL_ADI").ToString());

            string caseperiyot = Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_PERIYOT"));

            switch (caseperiyot)
            {                
                case "Yıllık":
                    cap.lbl_sp_donem.Visible = false;
                    cap.sp_donem.Visible = false;
                    cap.lbl_sp_ay.Visible = false;
                    cap.sp_ay.Visible = false;
                    cap.lbl_sp_hafta.Visible = false;
                    cap.sp_hafta.Visible = false;
                    cap.tbl_manuel_panel.Visible = false;
                    break;
                case "Dönemlik":
                    cap.lbl_sp_ay.Visible = false;
                    cap.sp_ay.Visible = false;
                    cap.lbl_sp_hafta.Visible = false;
                    cap.sp_hafta.Visible = false;
                    cap.tbl_manuel_panel.Visible = false;
                    break;
                case "Aylık":
                    cap.lbl_sp_hafta.Visible = false;
                    cap.sp_hafta.Visible = false;
                    cap.tbl_manuel_panel.Visible = false;
                    break;
                case "Haftalık":
                    cap.tbl_manuel_panel.Visible = false;
                    break;
                case "Manuel Aralık":
                    cap.tbl_referans_panel.Visible = false;
                    break;
                //default:
                //    break;
            }
            cap.ShowDialog();
        }


        private void button_cikiskodlari_Click(object sender, EventArgs e) //Seçilen çalışmaya ait çıkış kodlarını listeler.
        {
            CalismaCikisiKodlari cck = new CalismaCikisiKodlari(Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CAL_ID")), Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_CALISMAID")), grdview_list.GetFocusedRowCellValue("CAL_ADI").ToString());
            cck.ShowDialog();
        }

        private void cmb_calismaid_EditValueChanged(object sender, EventArgs e)  // seçilen çalışmaid nin adını tablodan çekip, text e atar.
        {
            try
            {
                txt_adi.Text  = (from p in veri.mv_study_name where p.study_id == cmb_calismaid.EditValue.ToString() select p).SingleOrDefault().study_name ;
            }
            catch (Exception)
            {
            }
        }

        private void cmb_periyot_SelectedIndexChanged(object sender, EventArgs e) //periyot tipi değiştiğinde çalışmaid nin giriş şekli değişir. 
        {

            if (cmb_periyot.Text == "Manuel Aralık")
            {
                txt_mancalismaid.Visible = true;
                cmb_calismaid.Visible = false;
            }
            else
            {
                txt_mancalismaid.Visible = false;
                cmb_calismaid.Visible = true;
            }
            
        }

        private void button_operatorler_Click(object sender, EventArgs e) //Seçilen çalışmayı kullanabilen kullanıcıları listeler.
        {
            CalismaKullanicilari  cks = new CalismaKullanicilari(Convert.ToInt32(grdview_list.GetFocusedRowCellValue("CAL_ID")), Convert.ToString(grdview_list.GetFocusedRowCellValue("CAL_CALISMAID")), grdview_list.GetFocusedRowCellValue("CAL_ADI").ToString());
            cks.ShowDialog();
        }

        private void grd_list_Click(object sender, EventArgs e)
        {

        }
    }
}
