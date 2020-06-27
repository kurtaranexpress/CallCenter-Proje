using CallCenter.models;
using Dapper;
using DevExpress.XtraGrid.Views.Grid;
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

    public partial class Mesajlarım : Form
    {
        NpgsqlConnection conn;
        CallCenterEntities veri = new CallCenterEntities();
        List<KULLANICILAR_V> kullist;
        List<MESAJLARTUM_V> mesajlarlist;
        bool sayfaokunmayanlar;
        string querystring = "";

        //bu formda ilk açınca okunmamış msj varsa   o kişiler gelir, hangi kişi seçiliyse ondan gelen okunmamış mesaj listelenir. Ben herhangi bir şekilde mesaj atarsam artık sayfa okunmamış modundan çıkar, o kişiye gönderdiğim ve bana gelenler -daha öncekiler dahil - listelenir.
        public Mesajlarım(bool okunmayanlar)  //kullanıcıya ait mesajları listeler
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            cmb_calisma.Properties.ValueMember = "CAL_ID";
            cmb_calisma.Properties.DisplayMember = "CAL_ADI";
            var callist = (from p in veri.CALISMALAR_TBL select p).OrderBy(t => t.CAL_ADI).ToList();
            cmb_calisma.Properties.DataSource = callist;


            //kod ile select kolonu eklemek için; ben propertiesten yaptım.
            //grdview_list.OptionsSelection.MultiSelect = true;
            //grdview_list.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

            sayfaokunmayanlar = okunmayanlar;
            listele(false); 
            this.Load += Mesajlarım_Load;
            this.FormClosing += Mesajlarım_FormClosing;
        }

        private void Mesajlarım_FormClosing(object sender, FormClosingEventArgs e) //bu form açık iken mesajları kontrol eden timeri kapatır. 
        {
            timer_mesajlarim.Stop();
        }

        private void Mesajlarım_Load(object sender, EventArgs e)//bu form açık iken mesajları kontrol eden timeri açar.
        {
            timer_mesajlarim.Start();
        }

        void listele(bool calismadanmi) //kullanıcılar listesini getirir.
        {
            if (calismadanmi == true)
            {
                querystring = "SELECT* FROM public.\"KULLANICILAR_V\" WHERE \"KUL_ID\" IN (SELECT \"KC_KUL_ID\" from public.\"KULLANICICALISMALAR_TBL\" where \"KC_CAL_ID\"= " + Convert.ToInt32(cmb_calisma.EditValue) + ")";
            }
            else
            {
                if (sayfaokunmayanlar == true)
                {
                    querystring = "select * from public.\"KULLANICILAR_V\" WHERE \"KUL_ID\" in (select \"gonderenkulid\" from public.\"MESAJLARTUM_V\" WHERE (\"MSJ_OKUNDU\" <>TRUE) and (\"alankulid\" = " + AnaForm.userid + "))";
                }
                else
                {
                    querystring = "select * from public.\"KULLANICILAR_V\" WHERE  \"KUL_ID\" <> " + AnaForm.userid + "";
                }
            }
            
            //\"ROL_ANAROL\"='Operatör' and

            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                kullist = conn.Query<KULLANICILAR_V>(querystring).ToList();
                grd_list.DataSource = kullist;
            }
            listelemesajlar();
        }

        private void grdview_list_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)//seçilen kullanıcı ya ait mesajları listeler.
        {
            listelemesajlar();
        }

        void listelemesajlar()//seçilen kullanıcı ya ait mesajları listeler.
        {
            if (grdview_list.GetFocusedRow() == null) return;
            if (sayfaokunmayanlar == true )
            {
                DateTime  simdi = AnaForm.tarihsaatgetir();
                querystring = "select * from public.\"MESAJLARTUM_V\" WHERE (\"MSJ_OKUNDU\" <>TRUE) and (\"gonderenkulid\" = " + Convert.ToInt32(grdview_list.GetFocusedRowCellValue("KUL_ID")) + "  and \"alankulid\" = " + AnaForm.userid + ")";
                this.Text = "Okunmamış Mesajlarım";
                grdview_list.ViewCaption = "Okunmamış Mesajlarım";
            }
            else
            {
                querystring = "select * from public.\"MESAJLARTUM_V\" WHERE (\"gonderenkulid\" = " + AnaForm.userid + "  and \"alankulid\" = " + Convert.ToInt32(grdview_list.GetFocusedRowCellValue("KUL_ID")) + ") or (\"gonderenkulid\" = " + Convert.ToInt32(grdview_list.GetFocusedRowCellValue("KUL_ID")) + "  and \"alankulid\" = " + AnaForm.userid + ")";
                this.Text = "Mesajlarım";
                grdview_list.ViewCaption = "Mesajlarım";
            }
            
            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                mesajlarlist = conn.Query<MESAJLARTUM_V>(querystring).OrderByDescending(t=>t.MSJ_TARIH).ToList();                
                grd_mesaj.DataSource = mesajlarlist;
            }
            grdview_mesaj.RowStyle += Grdview_mesaj_RowStyle;
        }

        private void Grdview_mesaj_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e) // gelen mesajların renkli görünmesini sağlar.
        {
            if (grdview_mesaj.GetFocusedRow() == null) return;
            if (e.RowHandle <= 0)
            {
                return;
            }

            if (grdview_mesaj.GetRowCellValue(e.RowHandle, "gonderenkuladi").ToString() != AnaForm.useradi)
            {
                //e.Appearance.BackColor = Color.Aquamarine;
                //#25D366
                e.Appearance.BackColor =System.Drawing.ColorTranslator.FromHtml("#dcf8c6");
            }
        }
        

        private void btn_mesajgonder_Click(object sender, EventArgs e) // MESAJLAR_TBL ye kayıt atar.
        {
            if (kullist == null )
            {
                return;
            }

            int secilen = kullist.Where(p => p.KUL_SEC == true).Count();

            if (secilen == 0)
            {
                MessageBox.Show("Lütfen mesaj göndermek istediğiniz kullanıcı(ları) seçiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txt_mesaj.Text == "")
            {
                MessageBox.Show("Lütfen mesajınızı belirtiniz");
                txt_mesaj.Focus();
                return;
            }

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Mesajınız " + secilen + " kişiye gönderilecektir. Devam etmek istiyor musunuz?", "Uyarı!", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.No)
            {
                return;
            }


            CallCenterEntities veri2 = new CallCenterEntities(); //kullanıcılar tablosuna seç durumlarını kaydetmesin diye...
            veri2.Database.Connection.ConnectionString = AnaForm.cstr;

            try
            {                
                MESAJLAR_TBL kayit;
                kayit = new MESAJLAR_TBL();
                kayit.MSJ_KUL_ID = AnaForm.userid;
                //kayit.MSJ_FR_ID = 0;
                kayit.MSJ_TARIH = AnaForm.tarihsaatgetir(); //DateTime.Now;
                kayit.MSJ_MESAJ = txt_mesaj.Text;
                kayit.MSJ_OKUNDU = false;
                veri2.MESAJLAR_TBL.Add(kayit);
                veri2.SaveChanges();

                //kul_sec field inden çalışıyordu:
                //foreach (var item in kullist.Where(p => p.KUL_SEC == true).ToList())
                //{
                //    MESAJALICILARI_TBL alici= new MESAJALICILARI_TBL();
                //    alici.MA_ALICI_KUL_ID = item.KUL_ID;
                //    alici.MA_MSJ_ID = kayit.MSJ_ID;
                //    veri2.MESAJALICILARI_TBL.Add(alici);
                //    veri2.SaveChanges();
                //}
                //kul_sec field inden çalışıyordu.

                int[] selectedRowHandles = grdview_list.GetSelectedRows();
                if (selectedRowHandles.Length > 0)
                {
                    for (int i = 0; i < selectedRowHandles.Length; i++)
                    {// MessageBox.Show(grdview_list.GetRowCellDisplayText(selectedRowHandles[i], KULADI).ToString());

                        MESAJALICILARI_TBL alici = new MESAJALICILARI_TBL();
                        alici.MA_ALICI_KUL_ID = Convert.ToInt32( grdview_list.GetRowCellDisplayText(selectedRowHandles[i], KUL_ID));
                        alici.MA_MSJ_ID = kayit.MSJ_ID;
                        veri2.MESAJALICILARI_TBL.Add(alici);
                        veri2.SaveChanges();
                    }
                }

                MessageBox.Show("Gönderildi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AnaForm.logkaydet("Mesaj", "Gönderme ");

                txt_mesaj.Text = "";
                //foreach (var item in kullist.Where(p => p.KUL_SEC == true).ToList())
                //{
                //    item.KUL_SEC = false;
                //}
                //mesajlaşma devam ediyor olabilir, seçimini kendisi kaldırsın.
                sayfaokunmayanlar = false;
                listelemesajlar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gönderme Tamamlanamadı, Hata:" + ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void txt_mesajdaara_EditValueChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void timer_mesajlarim_Tick(object sender, EventArgs e) // mesajları kontrol eder. 
        {
            listelemesajlar();
        }

        //select all koyunca gerek kalmadı
        //private void grdview_list_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) // üzerine tıklanan kullanıcının 'seç' durumunu değiştirir.
        //{
            //if (grdview_list.GetFocusedRow() == null) return;

            //grdview_list.SetFocusedRowCellValue("KUL_SEC", !Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("KUL_SEC")));
        //}

        private void btn_kulgetir_Click(object sender, EventArgs e)
        {
            if (cmb_calisma.Text != "")
            {
                listele(true);
            }
        }

        private void btn_tumkullanicilar_Click(object sender, EventArgs e)
        {
            //test etmek için kullandım.
            //int[] selectedRowHandles = grdview_list.GetSelectedRows();
            //if (selectedRowHandles.Length > 0)
            //{
            //    for (int i = 0; i < selectedRowHandles.Length; i++)
            //    {MessageBox.Show(grdview_list.GetRowCellDisplayText(selectedRowHandles[i], KUL_ID)).ToString();

                  
            //    }
            //}


            cmb_calisma.EditValue = null;
            listele(false) ;
        }

        private void grdview_list_ColumnFilterChanged(object sender, EventArgs e)
        {
            //GridView view = sender as GridView;

            //if (view.FocusedColumn.Name == "KUL_SEC")
            //{
            //    bool  secim = Convert.ToBoolean ( view.FocusedValue) ;

            //    //MessageBox.Show(x.ToString());

            //    for (int i = 0; i < grdview_list.RowCount; i++)
            //    {
            //        grdview_list.SetRowCellValue(i, grdview_list.Columns["KUL_SEC"], secim);
            //    }
            //}
        }


        void secilisatirlar()
        {
            int[] selectedRowHandles = grdview_list.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                for (int i = 0; i < selectedRowHandles.Length; i++)
                    MessageBox.Show(grdview_list.GetRowCellDisplayText(selectedRowHandles[i], KULADI).ToString());
            }
        }

        private void grd_list_Click(object sender, EventArgs e)
        {

        }
    }
}
