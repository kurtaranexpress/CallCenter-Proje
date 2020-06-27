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
    public partial class RandevularList : Form
    {
        CallCenterEntities veri = new CallCenterEntities();

        public RandevularList() //Belirtilen tarih aralığındaki randevuları listeler. 
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            DateTime simdi = AnaForm.tarihsaatgetir();
            simdi = new DateTime(simdi.Year, simdi.Month, simdi.Day, 0, 0, 0);
            dt1.DateTime = simdi;
            dt2.DateTime = simdi.AddDays(1);

            listele();            

        }
        void listele()
        {

            var q = (from randevu in veri.RANDEVULAR_TBL.Where(s => s.RAN_BASLAMATARIH >= dt1.DateTime && s.RAN_BASLAMATARIH <= dt2.DateTime)
                     join istek in veri.ISTEKLER_TBL on randevu.RAN_IST_ID equals istek.IST_ID into i
                     from ii in i.DefaultIfEmpty()
                     join kullanici in veri.KULLANICILAR_TBL on randevu.RAN_KUL_ID equals kullanici.KUL_ID into k
                     from kk in k.DefaultIfEmpty()
                     join calisma in veri.CALISMALAR_TBL on randevu.RAN_CAL_ID equals calisma.CAL_ID into c
                     from cc in c.DefaultIfEmpty()
                     orderby randevu.RAN_BASLAMATARIH
                     select new
                     {
                         randevu.RAN_ID,
                         randevu.RAN_CAL_ID,
                         randevu.RAN_KUL_ID,
                         randevu.RAN_BASLAMATARIH,
                         randevu.RAN_BITISTARIH,
                         randevu.RAN_TELNO,
                         randevu.RAN_ACIKLAMA,
                         randevu.RAN_DURUMID,
                         randevu.RAN_IST_ID,
                         ii.IST_ID,
                         ii.IST_TARIH,
                         ii.IST_CALISMAID,
                         ii.IST_KULLANICIID,
                         ii.IST_BIRIMNO,
                         ii.IST_ALTBIRIMNO,
                         ii.IST_REFYIL,
                         ii.IST_REFDONEM,
                         ii.IST_REFAY,
                         ii.IST_REFHAFTA,
                         ii.IST_TELNO,
                         ii.IST_IL,
                         ii.IST_ACIKLAMA,
                         ii.IST_RANDEVUTERCIH,
                         ii.IST_NEDIR,
                         ii.IST_OKUNDU,
                         ii.IST_ICERDEN,
                         kk.KUL_ID,
                         kk.KUL_ADI,
                         kk.KUL_SIFRE,
                         kk.KUL_SANTRALUSERID,
                         kk.KUL_SANTRALSIFRE,
                         kk.KUL_ROL_ID,
                         kk.KUL_KULLANICIID,
                         kk.KUL_SEC,
                         kk.KUL_SIL,
                         kk.KUL_SILME_TARIH,
                         kk.KUL_SILME_KUL_ID,
                         cc.CAL_ID,
                         cc.CAL_ADI,
                         cc.CAL_PERIYOT,
                         cc.CAL_BASLAMATARIH,
                         cc.CAL_BITISTARIH,
                         cc.CAL_GUNBASLAMASAAT,
                         cc.CAL_GUNBITISSAAT,
                         cc.CAL_RANDEVUARALIK,
                         cc.CAL_MANUELARAMA,
                         cc.CAL_CALISMAID,
                         cc.CAL_YIL,
                         cc.CAL_SEC,
                         cc.CAL_SIL,
                         cc.CAL_SILME_TARIH,
                         cc.CAL_SILME_KUL_ID,
                         randevu.RAN_SEC,
                         randevu.RAN_ACMA,
                         randevu.RAN_KAPANMA,
                         ii.IST_KAPANMAZAMANI
                     }).ToList();
            grd_list.DataSource = q;
            
        }
        private void btn_yazdir_Click(object sender, EventArgs e)
        {
            grd_list.ShowPrintPreview();
        }

        private void btn_bul_Click(object sender, EventArgs e)
        {
            listele();

            

        }
    }
}
