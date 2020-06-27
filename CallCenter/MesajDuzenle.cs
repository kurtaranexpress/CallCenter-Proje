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
    public partial class MesajDuzenle : Form
    {
        int sayfamsjid = 0; 
        CallCenterEntities veri = new CallCenterEntities();

        public MesajDuzenle(int msjid) // MESAJLAR_TBL deki kaydın düzenlenmesini sağlar.
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;
            sayfamsjid = msjid;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var kayit = (from p in veri.MESAJLAR_TBL where p.MSJ_ID == sayfamsjid select p).SingleOrDefault();
            if (kayit != null)
            {
                kayit.MSJ_MESAJ = txt_mesaj.Text;
                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
