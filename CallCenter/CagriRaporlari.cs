using CallCenter.Raporlar;
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
    public partial class CagriRaporlari : Form
    {
        bool sayfaadmin = false;
        public CagriRaporlari(bool admin)
        {
            InitializeComponent();

            sayfaadmin = admin;
        }

        private void btn_tumcagrilar_Click(object sender, EventArgs e)
        {
            Cagrilarim cag = new Cagrilarim(sayfaadmin);
            cag.ShowDialog();
        }

        private void btn_cagrilar_periyot_Click(object sender, EventArgs e)
        {
            PeriyodaGoreCagrilarRaporu cagrilar_periyot = new PeriyodaGoreCagrilarRaporu();
            cagrilar_periyot.ShowDialog();

        }
    }
}
