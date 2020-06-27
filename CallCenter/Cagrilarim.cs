using CallCenter.models;
using Dapper;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Npgsql;
using System;
using System.Collections;
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
    public partial class Cagrilarim : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        List<CAGRIDETAYLAR_V> cagrilist;
        NpgsqlConnection conn;
        bool sayfaadmin ;

        TimeSpan topsure;
        TimeSpan topsuregrup;
        double topsuregrup4avg_dk;
        double ortalama_sn;
        int sayigrup4avg;
        //Nullable<System.DateTime> mintarih = null ;
        //Nullable<System.DateTime> makstarih = null;

        string querystring = "";
        public Cagrilarim(bool admin)
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            sayfaadmin = admin;

            try
            {
                DateTime simdi = AnaForm.tarihsaatgetir();
                simdi = new DateTime(simdi.Year, simdi.Month, simdi.Day, 0, 0, 0);

                dt1.DateTime = simdi;
                dt2.DateTime = simdi.AddDays(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata(1):" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            if (admin == false )
            {
                KUL_ADI.Visible = false;
            }
            else
            {
                grdview_list.Columns[0].Group();
            }

            listele();
        }

        private void grdview_list_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e) // timespan türündeki konuşma süresini hesaplar
        {
            GridView view = sender as GridView;
            int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start )
            {
                topsure = new TimeSpan(0, 0, 0);
                topsuregrup = new TimeSpan(0, 0, 0);
                topsuregrup4avg_dk = 0;
                sayigrup4avg = 0;
            }
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate )
            {
                switch (summaryID)
                {
                    case 1:
                        topsure += (TimeSpan)e.FieldValue;

                        //int abc = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "CAG_ID")); //başka bir kolonla işlem yapmak için böyle alabilirsin.
                        break;
                    case 2:
                        topsuregrup += (TimeSpan)e.FieldValue;                        
                        break;
                    case 3:
                        topsuregrup4avg_dk += ((TimeSpan)e.FieldValue).TotalMinutes;
                        sayigrup4avg += 1;
                        break;
                    default:
                        break;
                }
            }
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize )
            {
                switch (summaryID)
                {

                    case 1:
                        e.TotalValue = topsure;
                        break;
                    case 2:
                        e.TotalValue = topsuregrup;
                        break;
                    case 3:
                        //e.TotalValue = new TimeSpan(0,Convert.ToInt32(topsuregrup4avg / sayigrup4avg), 0) + " Dk.";
                        ortalama_sn = topsuregrup4avg_dk * 60 / sayigrup4avg;          
                        e.TotalValue = new TimeSpan(0, Convert.ToInt32(ortalama_sn)/60,Convert.ToInt32(ortalama_sn  % 60)) ; //dakikada; division için "/" sayı integer olunca küsüratı görmeden tam bölmeyi verdiği için  Convert.ToInt32(ortalama_sn)/60 şeklinde yazdım.
                        break;                        
                    default:
                        break;
                }
            }

        }

        private void ts_cagsure_EditValueChanged(object sender, EventArgs e)
        {
            grdview_list.PostEditor();
            grdview_list.UpdateTotalSummary();
        }
        
        private void btn_yazdir_Click(object sender, EventArgs e)
        {
            grd_list.ShowPrintPreview();
        }

        void listele()
        {
            try
            {
                if (sayfaadmin == true)
                {
                    var q = (from cagri in veri.CAGRILAR_TBL.Where(s => s.CAG_TARIH >= dt1.DateTime && s.CAG_TARIH <= dt2.DateTime)
                             join istek in veri.ISTEKLER_TBL on cagri.CAG_IST_ID equals istek.IST_ID
                             join calisma in veri.CALISMALAR_TBL on cagri.CAG_CAL_ID equals calisma.CAL_ID into c
                             from cc in c.DefaultIfEmpty()
                             join kullanici in veri.KULLANICILAR_TBL on cagri.CAG_KUL_ID equals kullanici.KUL_ID into k
                             from kk in k.DefaultIfEmpty()
                             join kullanici2 in veri.KULLANICILAR_TBL on istek.IST_KULLANICIID equals kullanici2.KUL_KULLANICIID into k2
                             from kk2 in k2.DefaultIfEmpty()
                             join cikiskodu in veri.CIKISKODLARI_TBL on cagri.CAG_CK_ID equals cikiskodu.CK_ID into ck
                             from cck in ck.DefaultIfEmpty()
                             join randevu in veri.RANDEVULAR_TBL on cagri.CAG_RAN_ID equals randevu.RAN_ID into ran
                             from rran in ran.DefaultIfEmpty()
                             orderby cagri.CAG_TARIH descending
                             select new
                             {
                                 cagri.CAG_ID,
                                 cagri.CAG_CAL_ID,
                                 cagri.CAG_KUL_ID,
                                 cagri.CAG_TARIH,
                                 cagri.CAG_TELNO,
                                 cagri.CAG_ACIKLAMA,
                                 cagri.CAG_CK_ID,
                                 cagri.CAG_SANTRALCIKISKODU,
                                 cagri.CAG_IST_ID,
                                 cagri.CAG_SURE,
                                 cagri.CAG_BASLAMA,
                                 cagri.CAG_BITIS,
                                 istek.IST_ID,
                                 istek.IST_TARIH,
                                 istek.IST_CALISMAID,
                                 istek.IST_KULLANICIID,
                                 istek.IST_BIRIMNO,
                                 istek.IST_ALTBIRIMNO,
                                 istek.IST_REFYIL,
                                 istek.IST_REFDONEM,
                                 istek.IST_REFAY,
                                 istek.IST_REFHAFTA,
                                 istek.IST_TELNO,
                                 istek.IST_IL,
                                 istek.IST_ACIKLAMA,
                                 istek.IST_RANDEVUTERCIH,
                                 istek.IST_NEDIR,
                                 istek.IST_OKUNDU,
                                 istek.IST_ICERDEN,
                                 istek.IST_KAPANMAZAMANI,
                                 cc.CAL_ADI,
                                 kk.KUL_ADI,
                                 kk.KUL_KULLANICIID,
                                 cck.CK_KOD,
                                 cck.CK_ACIKLAMA,
                                 KULADI2 = kk2.KUL_ADI,
                                 KULLANICIID2 = kk2.KUL_KULLANICIID,
                                 rran.RAN_BASLAMATARIH,
                                 rran.RAN_BITISTARIH,
                                 rran.RAN_TELNO,
                                 rran.RAN_ACIKLAMA,
                                 rran.RAN_ACMA,
                                 rran.RAN_KAPANMA
                             }).ToList();
                    grd_list.DataSource = q;
                }
                else
                {
                    var q = (from cagri in veri.CAGRILAR_TBL.Where(s => s.CAG_TARIH >= dt1.DateTime && s.CAG_TARIH <= dt2.DateTime && s.CAG_KUL_ID == AnaForm.userid)
                             join istek in veri.ISTEKLER_TBL on cagri.CAG_IST_ID equals istek.IST_ID
                             join calisma in veri.CALISMALAR_TBL on cagri.CAG_CAL_ID equals calisma.CAL_ID into c
                             from cc in c.DefaultIfEmpty()
                             join kullanici in veri.KULLANICILAR_TBL on cagri.CAG_KUL_ID equals kullanici.KUL_ID into k
                             from kk in k.DefaultIfEmpty()
                             join kullanici2 in veri.KULLANICILAR_TBL on istek.IST_KULLANICIID equals kullanici2.KUL_KULLANICIID into k2
                             from kk2 in k2.DefaultIfEmpty()
                             join cikiskodu in veri.CIKISKODLARI_TBL on cagri.CAG_CK_ID equals cikiskodu.CK_ID into ck
                             from cck in ck.DefaultIfEmpty()
                             join randevu in veri.RANDEVULAR_TBL on cagri.CAG_RAN_ID equals randevu.RAN_ID into ran
                             from rran in ran.DefaultIfEmpty()
                             orderby cagri.CAG_TARIH descending
                             select new
                             {
                                 cagri.CAG_ID,
                                 cagri.CAG_CAL_ID,
                                 cagri.CAG_KUL_ID,
                                 cagri.CAG_TARIH,
                                 cagri.CAG_TELNO,
                                 cagri.CAG_ACIKLAMA,
                                 cagri.CAG_CK_ID,
                                 cagri.CAG_SANTRALCIKISKODU,
                                 cagri.CAG_IST_ID,
                                 cagri.CAG_SURE,
                                 cagri.CAG_BASLAMA,
                                 cagri.CAG_BITIS,
                                 istek.IST_ID,
                                 istek.IST_TARIH,
                                 istek.IST_CALISMAID,
                                 istek.IST_KULLANICIID,
                                 istek.IST_BIRIMNO,
                                 istek.IST_ALTBIRIMNO,
                                 istek.IST_REFYIL,
                                 istek.IST_REFDONEM,
                                 istek.IST_REFAY,
                                 istek.IST_REFHAFTA,
                                 istek.IST_TELNO,
                                 istek.IST_IL,
                                 istek.IST_ACIKLAMA,
                                 istek.IST_RANDEVUTERCIH,
                                 istek.IST_NEDIR,
                                 istek.IST_OKUNDU,
                                 istek.IST_ICERDEN,
                                 istek.IST_KAPANMAZAMANI,
                                 cc.CAL_ADI,
                                 kk.KUL_ADI,
                                 kk.KUL_KULLANICIID,
                                 cck.CK_KOD,
                                 cck.CK_ACIKLAMA,
                                 KULADI2 = kk2.KUL_ADI,
                                 KULLANICIID2 = kk2.KUL_KULLANICIID,
                                 rran.RAN_BASLAMATARIH,
                                 rran.RAN_BITISTARIH,
                                 rran.RAN_TELNO,
                                 rran.RAN_ACIKLAMA,
                                 rran.RAN_ACMA,
                                 rran.RAN_KAPANMA
                             }).ToList();
                    grd_list.DataSource = q;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata(2):" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            grdview_list.ExpandAllGroups();
        }
        private void btn_bul_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btn_ses_Click(object sender, EventArgs e) //bu kullanıcıya ait ses kayıtlarını listeler.
        {
            SesKayitlari ses = new SesKayitlari(AnaForm.usersantralkodu);
            ses.ShowDialog();
        }
    }
}
