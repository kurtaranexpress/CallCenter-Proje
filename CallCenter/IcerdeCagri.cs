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
    public partial class IcerdeCagri : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        public IcerdeCagri() // santral kullanıcılarının birbirini aramasını sağlar
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            cmb_kulid.Properties.ValueMember = "KUL_SANTRALUSERID";
            cmb_kulid.Properties.DisplayMember = "KUL_ADI";
            var kullist = (from p in veri.KULLANICILAR_TBL where p.KUL_SIL != true select p).OrderBy(t => t.KUL_ADI).ToList();
            cmb_kulid.Properties.DataSource = kullist;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (cmb_kulid.Text == "") return;

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
