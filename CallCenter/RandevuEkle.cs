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
    public partial class RandevuEkle : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        public RandevuEkle()
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            schedulerDataStorage1.Labels.Mappings.Color = "RENK_HEX";
            schedulerDataStorage1.Labels.Mappings.DisplayName = "RENK_BASLIK";
            schedulerDataStorage1.Labels.Mappings.Id = "RENK_ID";
            schedulerDataStorage1.Labels.DataSource = veri.RENKLER_TBL.ToList().Where(t => t.RENK_AKTIF == true);

            edtLabel.Storage = schedulerDataStorage1;
            this.Load += RandevuEkle_Load;
        }

        private void RandevuEkle_Load(object sender, EventArgs e)
        {
            edtLabel.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dt_bitis.DateTime = edtStartDate.DateTime.Date.AddHours(edtStartTime.Time.Hour).AddMinutes(edtStartTime.Time.Minute).AddMinutes(AnaForm.randk);
            

            if (edtLabel.AppointmentLabel == null)
            {
                MessageBox.Show("Lütfen Durum belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (edtStartDate.DateTime.Date.AddHours(edtStartTime.Time.Hour).AddMinutes(edtStartTime.Time.Minute)< AnaForm.tarihsaatgetir())
            {
                MessageBox.Show("Geçmiş tarihe randevu alınamaz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //string sonuc = AnaForm.CalismaAktifPeriyotMu (dt_baslama.DateTime);
            //if (sonuc!= "")
            //{
            //    MessageBox.Show(sonuc, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (AnaForm.CalismaAktifPeriyotMu(edtStartDate.DateTime.Date.AddHours(edtStartTime.Time.Hour).AddMinutes(edtStartTime.Time.Minute), AnaForm.ist_id, AnaForm.cal_id, 0) == false)
            {
                return;
            }

            DateTime baslama = edtStartDate.DateTime.Date.AddHours(edtStartTime.Time.Hour).AddMinutes(edtStartTime.Time.Minute);
            DateTime bitis = edtEndDate.DateTime.Date.AddHours(edtEndTime.Time.Hour).AddMinutes(edtEndTime.Time.Minute);

            var dolumu = (from p in veri.RANDEVULAR_TBL where p.RAN_KUL_ID == AnaForm.userid && 
                          ((p.RAN_BASLAMATARIH>=baslama && p.RAN_BASLAMATARIH <= bitis) 
                          || ( p.RAN_BITISTARIH >= baslama && p.RAN_BITISTARIH <= bitis)
                    || (baslama >= p.RAN_BASLAMATARIH && baslama <= p.RAN_BITISTARIH)
                      || (bitis >= p.RAN_BASLAMATARIH && bitis <= p.RAN_BITISTARIH)

                          )

                          select p).ToList();
            if (dolumu.Count()>0)
            {
                MessageBox.Show(dolumu[0].RAN_BASLAMATARIH.ToString() + " - " + dolumu[0].RAN_BITISTARIH.ToString() + " aralığında randevunuz bulunmaktadır." , "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                RANDEVULAR_TBL ekle = new RANDEVULAR_TBL();

                ekle.RAN_IST_ID = AnaForm.ist_id;
                ekle.RAN_KUL_ID = AnaForm.userid;
                ekle.RAN_CAL_ID = AnaForm.cal_id;

                ekle.RAN_ACIKLAMA = tbDescription.Text;
                //ekle.RAN_BASLAMATARIH = edtStartDate.DateTime.AddHours(edtStartTime.Time.Hour).AddMinutes(edtStartTime.Time.Minute);
                //ekle.RAN_BITISTARIH = edtEndDate.DateTime.AddHours(edtEndTime.Time.Hour).AddMinutes(edtEndTime.Time.Minute);
                ekle.RAN_BASLAMATARIH = baslama;
                ekle.RAN_BITISTARIH = bitis;
                ekle.RAN_TELNO = tbSubject.Text;
                ekle.RAN_DURUMID = Convert.ToInt32(edtLabel.AppointmentLabel.Id);
                ekle.RAN_SEC = false;
                veri.RANDEVULAR_TBL.Add(ekle);
                veri.SaveChanges();


                var calisma = (from p in veri.CALISMALAR_TBL where p.CAL_ID == AnaForm.cal_id select p).SingleOrDefault();

                AnaForm.logkaydet("Randevu", "Ekleme (" + calisma.CAL_CALISMAID + " " + calisma.CAL_ADI +")");

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void dt_baslama_EditValueChanged(object sender, EventArgs e)
        {
            //dt_bitis.DateTime = dt_baslama.DateTime.AddMinutes(AnaForm.randk);
        }

        private void edtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            dt_bitis.DateTime = edtStartDate.DateTime.Date.AddHours(edtStartTime.Time.Hour).AddMinutes(edtStartTime.Time.Minute).AddMinutes(AnaForm.randk);
            
            edtEndDate.DateTime = dt_bitis.DateTime.Date ;
            edtEndTime.Time =  dt_bitis.DateTime ;
        }

        private void edtStartTime_EditValueChanged(object sender, EventArgs e)
        {
            dt_bitis.DateTime = edtStartDate.DateTime.Date.AddHours(edtStartTime.Time.Hour).AddMinutes(edtStartTime.Time.Minute).AddMinutes(AnaForm.randk);

            edtEndDate.DateTime = dt_bitis.DateTime.Date;
            edtEndTime.Time = dt_bitis.DateTime;

        }
    }
}
