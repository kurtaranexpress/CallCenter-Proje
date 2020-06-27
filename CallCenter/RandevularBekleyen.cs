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
    public partial class RandevularBekleyen : Form
    {
        List<RANDEVULISTERENKLERI_TBL> renkler;
        CallCenterEntities veri = new CallCenterEntities();
        bool sayfaalarm = false;
        DateTime simdi;
        DateTime yaklasansaat;
        public RandevularBekleyen(bool alarm) //yaklaşan randevuları listeler. 
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;
            sayfaalarm = alarm;
            
            renkler = (from p in veri.RANDEVULISTERENKLERI_TBL select p).OrderBy(p => p.BR_SURE1).ToList();

            listele();
        }

        void listele()
        {
            simdi = AnaForm.tarihsaatgetir();
            simdi = new DateTime(simdi.Year, simdi.Month, simdi.Day, simdi.Hour, simdi.Minute, 0);
            

            if (sayfaalarm) //geciken ve yaklaşanları gösteririm sadece.
            {
                yaklasansaat = simdi.AddMinutes(AnaForm.yaklasanrandevudk); //genel ayarlardan tanımlanan yaklaşan dk kalan lardaki randevuları da listeye almak için   
                this.Text = "Geciken ve Yaklaşan Randevularım";
                grdview_list.ViewCaption = "Geciken ve Yaklaşan Randevularım";
            }
            else //geciken ve 24 saatlik kayıtları gösteririm.
            {
                yaklasansaat = simdi.AddDays(1); //24 saat kalan kayıtlar için
                
                this.Text = "Günlük Randevularım";
                grdview_list.ViewCaption = "Günlük Randevularım";
            }

            var q = (from randevu in veri.RANDEVULAR_TBL.Where(s => s.RAN_BASLAMATARIH <= yaklasansaat && s.RAN_KAPANMA == null && s.RAN_KUL_ID == AnaForm.userid)
                     join istek in veri.ISTEKLER_TBL on randevu.RAN_IST_ID equals istek.IST_ID into i
                     from ii in i.DefaultIfEmpty()
                     join kullanici in veri.KULLANICILAR_TBL on randevu.RAN_KUL_ID equals kullanici.KUL_ID into k
                     from kk in k.DefaultIfEmpty()
                     join calisma in veri.CALISMALAR_TBL on randevu.RAN_CAL_ID equals calisma.CAL_ID into c
                     from cc in c.DefaultIfEmpty()
                     orderby randevu.RAN_BASLAMATARIH
                     select new
                     {
                         kk.KUL_KULLANICIID,
                         cc.CAL_CALISMAID,
                         cc.CAL_ADI,
                         ii.IST_ALTBIRIMNO,
                         ii.IST_BIRIMNO,
                         randevu.RAN_BASLAMATARIH,
                         randevu.RAN_BITISTARIH,
                         ii.IST_TELNO,
                         ii.IST_IL,
                         randevu.RAN_ACIKLAMA,
                         randevu.RAN_ID,
                         randevu.RAN_IST_ID
                     }).ToList();
            grd_list.DataSource = q;
            grdview_list.RowStyle += Grdview_list_RowStyle;

           
        }

        private void Grdview_list_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e) // kalan saate göre grid satırını renklendirir.
        {
            
            simdi = AnaForm.tarihsaatgetir();
            simdi = new DateTime(simdi.Year, simdi.Month, simdi.Day, simdi.Hour, simdi.Minute, 0);

            if (e.RowHandle >= 0)
            {
                DateTime satirtarih = Convert.ToDateTime(grdview_list.GetRowCellValue(e.RowHandle, "RAN_BASLAMATARIH"));
                
                if (satirtarih < AnaForm.tarihsaatgetir())
                {
                    var geciken = renkler.Where(p => p.BR_SURE1 == new TimeSpan(0, 0, 0) && p.BR_SURE2 == new TimeSpan(0, 0, 0)).ToList();
                    if (geciken.Count() > 0)
                    {
                        e.Appearance.BackColor = Color.FromArgb(Convert.ToInt32(geciken[0].BR_RENKKODU));
                    }
                }
                else
                {
                    TimeSpan kalansaat = satirtarih.Subtract(simdi);
                    var renk = renkler.Where(p => p.BR_SURE1 <= kalansaat && p.BR_SURE2 >= kalansaat).ToList();
                    if (renk.Count() > 0)
                    {
                        e.Appearance.BackColor = Color.FromArgb(Convert.ToInt32(renk[0].BR_RENKKODU));
                    }
                }
            }

        }

        private void buttonARA_Click(object sender, EventArgs e) // arama yapmak için bilgileri anaform a gönderir. 
        {
            if (grdview_list.GetFocusedRow() == null) return;
            if (AnaForm.ist_id != 0)
            {
                MessageBox.Show("Kapatılmamış bir istek bulunmaktadır...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AnaForm.ist_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("RAN_IST_ID"));
            AnaForm.ran_id = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("RAN_ID"));
            AnaForm.msj = "Randevu Saati:" + Convert.ToString(grdview_list.GetFocusedRowCellValue("RAN_BASLAMATARIH"));
            this.Close();
        }

        private void btn_yenile_Click(object sender, EventArgs e) // listeyi günceller
        {
            listele();
        }

        private void btn_yazdir_Click(object sender, EventArgs e) // gridi yazdırır. 
        {
            grd_list.ShowPrintPreview();
        }
    }
}
