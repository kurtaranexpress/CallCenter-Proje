using CallCenter.models;
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

namespace CallCenter.Raporlar
{
    public partial class PeriyodaGoreCagrilarRaporu : Form
    {
        NpgsqlConnection conn;
        CallCenterEntities veri = new CallCenterEntities();
        List<KULLANICICALISMALAR_V> kullanicicalismalarlist;
        int calid = 0;

        public PeriyodaGoreCagrilarRaporu()
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            cmb_periyotlar.Properties.ValueMember = "CP_ID";
            cmb_periyotlar.Properties.DisplayMember = "CP_TARIH";


            cmb_calismaid.Properties.ValueMember = "CAL_ID";
            cmb_calismaid.Properties.DisplayMember = "CAL_ADI";

            var calismalar = (from p in veri.CALISMALAR_TBL select p).OrderBy(p => p.CAL_CALISMAID).ToList();
            cmb_calismaid.Properties.DataSource = calismalar;
        }

        private void btn_bul_Click(object sender, EventArgs e)
        {
            if (cmb_calismaid.Text == "")
            {
                MessageBox.Show("Lütfen Çalışma seçiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_calismaid.Focus();
                return;
            }

            if (cmb_periyotlar.Text == "")
            {
                MessageBox.Show("Lütfen Çalışma Periyodu seçiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_periyotlar.Focus();
                return;
            }


        }

        private void cmb_calismaid_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                calid = Convert.ToInt32(cmb_calismaid.EditValue);
                var periyotlar = (from p in veri.CALISMAPERIYOTLARI_TBL where p.CP_CAL_ID == calid select new {p.CP_ID , CP_REFYIL =  p.CP_REFYIL.Value.Year , p.CP_REFAY,p.CP_REFDONEM,p.CP_REFHAFTA, p.CP_BASLAMATARIH, p.CP_BITISTARIH , p.CP_REF_MA_BASLANGIC , p.CP_REF_MA_BITIS, CP_TARIH=p.CP_BASLAMATARIH.ToString() + " - " +p.CP_BITISTARIH.ToString()  }).OrderBy(p => p.CP_BASLAMATARIH).ToList();
                cmb_periyotlar.Properties.DataSource = periyotlar;
            }
            catch (Exception ex)
            {

            }
        }

        private void cmb_periyotlar_EditValueChanged(object sender, EventArgs e)
        {
            int perid = Convert.ToInt32(cmb_periyotlar.EditValue);
            var secilenperiyot = (from p in veri.CALISMAPERIYOTLARI_TBL where p.CP_ID == perid select p).SingleOrDefault();
            txt_ref_yil.Text = secilenperiyot.CP_REFYIL.Value.Year.ToString();
            txt_ref_donem.Text = secilenperiyot.CP_REFDONEM.ToString();
            txt_ref_ay.Text = secilenperiyot.CP_REFAY.ToString();
            txt_ref_hafta.Text = secilenperiyot.CP_REFHAFTA.ToString();



        }
    }
}
