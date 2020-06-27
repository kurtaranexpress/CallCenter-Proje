using CallCenter.models;
using Dapper;
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

namespace CallCenter
{
    public partial class LogList : Form
    {
        DateTime simdi;
        NpgsqlConnection conn;
        public LogList() // LOGLIST_V tablosundaki kayıtları görüntüler.
        {
            InitializeComponent();
            //veri.Database.Connection.ConnectionString = AnaForm.cstr;
            DateTime simdi = AnaForm.tarihsaatgetir();
            simdi = new DateTime(simdi.Year, simdi.Month, simdi.Day, 0, 0, 0);

            dt1.DateTime = simdi;
            dt2.DateTime = simdi.AddDays(1);
            listele();
        }

        void listele()
        {
            string querystring = "select * from public.\"LOGLIST_V\" WHERE \"LG_TARIH\"::timestamp >= '" + dt1.DateTime + "'::timestamp and \"LG_TARIH\"::timestamp <= '" + dt2.DateTime + "'::timestamp ORDER BY \"LG_TARIH\" DESC";

            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                grd_list.DataSource =  conn.Query<LOGLIST_V>(querystring).ToList();
                
            }
        }

        private void btn_bul_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
