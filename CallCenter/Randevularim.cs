using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraBars.Helpers;
using System.Collections.Generic;

namespace CallCenter
{
    public partial class Randevularim : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        bool durum = true;
        public static bool kapat = false;
        

        public Randevularim() //kullanıcıya ait randevuları listeler. 
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            InitSkinGallery();
            schedulerControl.Start = AnaForm.tarihsaatgetir();

            schedulerDataStorage1.AppointmentsInserted += SchedulerDataStorage1_AppointmentsInserted;
            schedulerDataStorage1.AppointmentsChanged += SchedulerDataStorage1_AppointmentsChanged;
            schedulerDataStorage1.AppointmentsDeleted += SchedulerDataStorage1_AppointmentsDeleted;

            schedulerDataStorage1.AppointmentInserting += SchedulerDataStorage1_AppointmentInserting;
            schedulerDataStorage1.AppointmentChanging += SchedulerDataStorage1_AppointmentChanging;

            

            schedulerDataStorage1.Appointments.Mappings.AppointmentId = "RAN_ID";
            schedulerDataStorage1.Appointments.Mappings.Description = "RAN_ACIKLAMA";
            schedulerDataStorage1.Appointments.Mappings.Start = "RAN_BASLAMATARIH";
            schedulerDataStorage1.Appointments.Mappings.End = "RAN_BITISTARIH";
            schedulerDataStorage1.Appointments.Mappings.Label = "RAN_DURUMID";
            schedulerDataStorage1.Appointments.Mappings.Subject = "RAN_TELNO";


            schedulerDataStorage1.Labels.Mappings.Color = "RENK_HEX";
            schedulerDataStorage1.Labels.Mappings.DisplayName = "RENK_BASLIK";
            schedulerDataStorage1.Labels.Mappings.Id = "RENK_ID";
            schedulerDataStorage1.Labels.DataSource = (from p in veri.RENKLER_TBL where p.RENK_AKTIF == true select p).ToList();


            schedulerControl.DataStorage = schedulerDataStorage1;
            schedulerControl.RefreshData();

        }
        
        void listele()
        {
            var abc = (from p in veri.RANDEVULAR_TBL where p.RAN_KAPANMA == null && p.RAN_KUL_ID == AnaForm.userid select p).ToList();
            schedulerDataStorage1.Appointments.DataSource = abc;
            schedulerControl.DataStorage = schedulerDataStorage1;
        }
        private void SchedulerDataStorage1_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e)
        {
            
            AdvPersistentObjectCancelEventArgs advArgs = (AdvPersistentObjectCancelEventArgs)e;
            
            if (advArgs.PropertyName  == "Start" || advArgs.PropertyName == "End")
            {
               


                DevExpress.XtraScheduler.Internal.Implementations.AppointmentItem apt = (DevExpress.XtraScheduler.Internal.Implementations.AppointmentItem)e.Object;
                int id = Convert.ToInt32(apt.Id);

                if (advArgs.PropertyName == "Start")
                {
                    if (Convert.ToDateTime(advArgs.NewValue) < AnaForm.tarihsaatgetir())
                    {
                        durum = false; //eğer start hatalı ise end e bakmam. ama end field ini de güncellemeyip dönmesi için e.cancel=true yapmam gerektiği için.
                        e.Cancel = true;
                    }
                    else if (AnaForm.CalismaAktifPeriyotMu(Convert.ToDateTime(advArgs.NewValue), 0, 0, Convert.ToInt32(apt.Id)) == false)
                    {
                        durum = false;
                        e.Cancel = true;
                    }
                }
                if (advArgs.PropertyName == "End")
                {
                    if (durum == false)
                    {
                        durum = true;
                        e.Cancel = true;
                    }
                }




            }

            
        }

        private void SchedulerDataStorage1_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
        {
            //DevExpress.XtraScheduler.Internal.Implementations.AppointmentItem apt = (DevExpress.XtraScheduler.Internal.Implementations.AppointmentItem)e.Object;
            //MessageBox.Show(apt.Start.ToString());
            
        }

        private void SchedulerDataStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            AppointmentBaseCollection appts = (AppointmentBaseCollection)e.Objects;
            foreach (Appointment apt in appts)
            {

                int id = Convert.ToInt32(apt.Id);
                var kayıt = (from inc in veri.RANDEVULAR_TBL  where inc.RAN_ID == id select inc).SingleOrDefault();
                kayıt.RAN_KAPANMA = AnaForm.tarihsaatgetir();
                //veri.RANDEVULAR_TBL.Remove(kayıt);
                veri.SaveChanges();


                int calid = Convert.ToInt32(kayıt.RAN_CAL_ID);
                int istid = Convert.ToInt32(kayıt.RAN_IST_ID);
                var calisma = (from p in veri.CALISMALAR_TBL where p.CAL_ID == calid select p).SingleOrDefault();
                var istek = (from p in veri.ISTEKLER_TBL where p.IST_ID == istid select p).SingleOrDefault();
                AnaForm.logkaydet("Randevu", "Silme (" + calisma.CAL_CALISMAID + " " + calisma.CAL_ADI + ")(" + istek.IST_TELNO + ")"  );

            }
        }

        private void SchedulerDataStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            AppointmentBaseCollection appts = (AppointmentBaseCollection)e.Objects;
            foreach (Appointment apt in appts)
            {
                int id = Convert.ToInt32(apt.Id);
                var kayıt = (from inc in veri.RANDEVULAR_TBL where inc.RAN_ID == id select inc).SingleOrDefault();

                kayıt.RAN_ACIKLAMA = apt.Description;
                kayıt.RAN_BASLAMATARIH = apt.Start;
                kayıt.RAN_BITISTARIH = apt.End;
                kayıt.RAN_TELNO = apt.Subject;
                kayıt.RAN_DURUMID = Convert.ToInt32(apt.LabelKey); //apt.LabelId yerine  apt.LabelKey yazdırdı
                veri.SaveChanges();
                
                int calid = Convert.ToInt32(kayıt.RAN_CAL_ID);
                var calisma = (from p in veri.CALISMALAR_TBL where p.CAL_ID == calid select p).SingleOrDefault();
                AnaForm.logkaydet("Randevu", "Düzenleme (" + calisma.CAL_CALISMAID + " " + calisma.CAL_ADI + ")(" + apt.Subject + ")");
            }            
        }

        private void SchedulerDataStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            AppointmentBaseCollection appts = (AppointmentBaseCollection)e.Objects;

            //for (int i = 0; i < appts.Count(); i++)
            //{
            //    appts.Remove(appts[i]);
            //}
            foreach (Appointment apt in appts)
            {
                //appts.Remove(apt);
                RANDEVULAR_TBL ekle = new RANDEVULAR_TBL();

                ekle.RAN_IST_ID = AnaForm.ist_id;
                ekle.RAN_KUL_ID = AnaForm.userid;
                ekle.RAN_CAL_ID = AnaForm.cal_id;

                ekle.RAN_ACIKLAMA = apt.Description;
                ekle.RAN_BASLAMATARIH = apt.Start;
                ekle.RAN_BITISTARIH = apt.End;
                ekle.RAN_TELNO = apt.Subject;
                ekle.RAN_DURUMID = Convert.ToInt32(apt.LabelKey);
                ekle.RAN_SEC = false;
                veri.RANDEVULAR_TBL.Add(ekle);
                veri.SaveChanges();
                //schedulerDataStorage1.Appointments.DataSource = veri.RANDEVULAR_TBL.ToList();
                              
                var calisma = (from p in veri.CALISMALAR_TBL where p.CAL_ID == AnaForm.cal_id select p).SingleOrDefault();
                AnaForm.logkaydet("Randevu", "Ekleme (" + calisma.CAL_CALISMAID + " " + calisma.CAL_ADI + ")(" + apt.Subject + ")");

                listele();
            }
            
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            
            //Bunu showingten önce yapmazsam enddate i default olan yarım saat sonrasına atıyor.
            if (e.Appointment.Id != null) //güncellemedir.
            {
                //MessageBox.Show(e.Appointment.Id.ToString());
                //MessageBox.Show(e.Appointment.Duration.ToString());
                int id = Convert.ToInt32(e.Appointment.Id);
                var randevu = (from inc in veri.RANDEVULAR_TBL where inc.RAN_ID == id select inc).SingleOrDefault();
                var calisma = (from p in veri.CALISMALAR_TBL where p.CAL_SIL != true && p.CAL_ID == randevu.RAN_CAL_ID select p).SingleOrDefault();

                e.Appointment.Duration = new TimeSpan(0, Convert.ToInt32(calisma.CAL_RANDEVUARALIK.Value.TotalMinutes), 0);

            }
            else //eklemedir.
            {
                if (AnaForm.cal_id != 0)
                {
                    e.Appointment.Duration = new TimeSpan(0, AnaForm.randk, 0);
                }
                //MessageBox.Show("null");
            }



            
            CustomAppointmentForm form = new CustomAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
            kapat = false;
            
            
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

            if (kapat== true )
            {
                this.Close();
                kapat = false;
            }

        }

        private void Randevularim_Load(object sender, EventArgs e)
        {
            listele();

            
        }

        private void schedulerControl_VisibleIntervalChanged(object sender, EventArgs e)
        {
            
        }

        private void schedulerControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Clear(); //right clicki kaldırır.
        }
    }
}
