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
    public partial class CalismaKullanicilari : Form
    {

        public static NpgsqlConnection conn;
        List<KULLANICICALISMALAR_V> kullanicicalismaSecilen;

        public CalismaKullanicilari(int cal_id, string calismaID, string caladi) //Form açılırken seçilmiş olan çalışmayı kullanabilen kullanıcıları listeler.
        {
            InitializeComponent();
            
            lbl_calisma.Text = calismaID + " " + caladi;

            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                kullanicicalismaSecilen = conn.Query<KULLANICICALISMALAR_V>("select * from public.\"KULLANICICALISMALAR_V\" WHERE (\"CAL_CALISMAID\" = '" + calismaID + "') ORDER BY \"CAL_CALISMAID\"").ToList();
            }
            grd_list.DataSource = kullanicicalismaSecilen;
        }
    }
}
