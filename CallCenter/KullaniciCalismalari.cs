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
    public partial class KullaniciCalismalari : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        public int sayfakul_id = 0;

        List<CALISMALAR_TBL> calismalist;

        public KullaniciCalismalari(int kul_id, string KullaniciID, string kuladi) // seçilen kullanıcının görebildiği çalışmaları listeler. 
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            sayfakul_id = kul_id;
            lbl_kullanici.Text = KullaniciID + " " + kuladi;
            // grdview_list.ViewCaption = lbl_calisma.Text + " Çıkış Kodları";

            listele();
        }
        void listele()
        {
            calismalist = (from p in veri.CALISMALAR_TBL where p.CAL_SIL == false  select p).OrderBy(p => p.CAL_CALISMAID).ToList();
            var kulcalismalist = (from p in veri.KULLANICICALISMALAR_TBL where p.KC_KUL_ID == sayfakul_id select p).ToList();

            foreach (var item in kulcalismalist)
            {
                try   //silinen bir çalışma bu kullanıcıya atandıysa hata vermesin geçsin diye...
                {
                    calismalist.Where(k => k.CAL_ID == item.KC_CAL_ID).SingleOrDefault().CAL_SEC = true;
                }
                catch (Exception)
                {
                }
                
            }
            grd_list.DataSource = calismalist;           

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {

            CallCenterEntities veri2 = new CallCenterEntities();//çalışmalar tablosuna seç durumlarını kaydetmesin diye...
            veri2.Database.Connection.ConnectionString = AnaForm.cstr;
            try
            {
                foreach (var item in calismalist)
                {
                    var kayit = (from p in veri2.KULLANICICALISMALAR_TBL where p.KC_KUL_ID == sayfakul_id && p.KC_CAL_ID == item.CAL_ID select p).SingleOrDefault();
                    if (item.CAL_SEC == false && kayit != null)
                    {
                        veri2.KULLANICICALISMALAR_TBL.Remove(kayit);
                        veri2.SaveChanges();
                    }

                    if (item.CAL_SEC == true && kayit == null)
                    {
                        var ekle = new KULLANICICALISMALAR_TBL();
                        ekle.KC_KUL_ID = sayfakul_id;
                        ekle.KC_CAL_ID = item.CAL_ID;
                        veri2.KULLANICICALISMALAR_TBL.Add(ekle);
                        veri2.SaveChanges();
                    }
                }

                MessageBox.Show("Kaydedildi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm.logkaydet("Kullanıcı Çalışmaları", "Liste Düzenleme (" + lbl_kullanici.Text + ")");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
