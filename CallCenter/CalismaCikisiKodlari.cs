using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Collections.ObjectModel ;

namespace CallCenter
{
    public partial class CalismaCikisiKodlari : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        public int sayfacal_id = 0;

        List<CIKISKODLARI_TBL> kodlist;// = new List<CIKISKODLARI_TBL> ();
        
        public CalismaCikisiKodlari(int cal_id, string calismaID, string caladi)
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            sayfacal_id = cal_id;
            
            lbl_calisma.Text = calismaID + " " + caladi; 
            
            listele();
        }

        void listele() //Seçilen çalışmaya ait çıkış kodlarını listeler
        {
            kodlist = (from p in veri.CIKISKODLARI_TBL where p.CK_AKTIF == true select p).OrderBy(p => p.CK_ID).ToList();
            var calismakodlist = (from p in veri.CALISMACIKISKODLARI_TBL where p.CCK_CAL_ID == sayfacal_id select p).ToList();

            foreach (var item in calismakodlist)
            {
                kodlist.Where(k => k.CK_ID == item.CCK_CK_ID).SingleOrDefault().CK_SEC = true;
            }
            grd_list.DataSource = kodlist;            
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {

            CallCenterEntities veri2 = new CallCenterEntities();//çıkış kodları tablosuna seç durumlarını kaydetmesin diye...
            veri2.Database.Connection.ConnectionString = AnaForm.cstr;
            try
            {
                foreach (var item in kodlist)
                {
                    var kayit = (from p in veri2.CALISMACIKISKODLARI_TBL where p.CCK_CAL_ID == sayfacal_id && p.CCK_CK_ID == item.CK_ID select p).SingleOrDefault();
                    if (item.CK_SEC == false && kayit != null )
                    {
                        veri2.CALISMACIKISKODLARI_TBL.Remove(kayit);
                        veri2.SaveChanges();
                    }

                    if (item.CK_SEC == true && kayit == null )
                    {
                        var ekle = new CALISMACIKISKODLARI_TBL();                    
                        ekle.CCK_CAL_ID  = sayfacal_id;
                        ekle.CCK_CK_ID = item.CK_ID;
                        veri2.CALISMACIKISKODLARI_TBL.Add(ekle);
                        veri2.SaveChanges();
                    }
                }

                MessageBox.Show("Kaydedildi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AnaForm.logkaydet("Çalışma Çıkış Kodları", "Liste Düzenleme (" + lbl_calisma.Text +")");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
