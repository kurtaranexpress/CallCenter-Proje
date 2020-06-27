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
    public partial class Istekler : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        int istid;
        public Istekler() // arama yapmak için oluşturulmuş istekleri listeler.
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            DateTime simdi = AnaForm.tarihsaatgetir();
            simdi = new DateTime(simdi.Year, simdi.Month, simdi.Day, 0, 0, 0);
            dt1.DateTime = simdi;
            dt2.DateTime = simdi.AddDays(1);

            listele();

        }

        void listele() // ISTEKLER_TBL deki kayıtları görüntüler.
        {
            var sonuc = (from p in veri.ISTEKLER_TBL where p.IST_TARIH > dt1.DateTime && p.IST_TARIH <dt2.DateTime select p).OrderBy(p => p.IST_TARIH).ToList();
            grd_list.DataSource = sonuc;
        }
        private void button_sil_Click(object sender, EventArgs e) // ISTEKLER_TBL den kayıt siler.
        {
            if (grdview_list.GetFocusedRow() == null) return;
            istid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("IST_ID"));

            int rankontrol = (from p in veri.RANDEVULAR_TBL where p.RAN_IST_ID == istid select p).ToList().Count();
            if (rankontrol > 0)
            {
                MessageBox.Show("İstek için randevu oluşturulmuş silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int cagkontrol = (from p in veri.CAGRILAR_TBL where p.CAG_IST_ID == istid select p).ToList().Count();
            if (cagkontrol > 0)
            {
                MessageBox.Show("İstek için çağrı oluşturulmuş silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var kayit = (from p in veri.ISTEKLER_TBL where p.IST_ID == istid select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.ISTEKLER_TBL.Remove(kayit);
                    veri.SaveChanges();
                }

                MessageBox.Show("Silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_bul_Click(object sender, EventArgs e) // seçilen tarihe göre istekleri listeler.
        {
            listele();
        }

        private void btn_yazdir_Click(object sender, EventArgs e) // gridi yazdırır.
        {
            grd_list.ShowPrintPreview();
        }
    }
}
