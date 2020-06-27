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
    public partial class KullaniciIzle : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        public KullaniciIzle()
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            var liste = (from p in veri.KULLANICILAR_TBL select p).OrderBy(t=>t.KUL_ADI).ToList();


        }
    }
}
