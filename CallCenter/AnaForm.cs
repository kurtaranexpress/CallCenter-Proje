using CallCenter.models;
using Dapper;
using DevExpress.XtraBars.Navigation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace CallCenter
{
    using DevExpress.XtraEditors;
    using SIPVoipSDK;
    using System.Collections;
    using System.Text.RegularExpressions;
    using System.Threading;
    using ConnectionInfo = KeyValuePair<int, string>;
    using ConnectionsTbl = Dictionary<int, string>;



    public partial class AnaForm : Form
    {
        public static string cstr; //= "Host=localhost;Port=5432;Username=postgres;Password=1881;Database=CallCenter";
        public static int userid = 0;
        public static string userkullaniciid = "";
        public static string useradi = "ysm";
        public static int userrolid = 0;
        public static string userroladi = "operatör";
        public static string usersantralkodu = "";

        Nullable<System.DateTime> cag_baslama = null;
        Nullable<System.DateTime> cag_bitis = null;
        Nullable<System.TimeSpan> cag_sure = new TimeSpan(0, 0, 0);
        string cag_cikiskodu = "";
        int cag_lineid = 0;
        int cag_conid = 0;

        public static int ist_id = 0;
        public static int cal_id = 0;
        public static int ran_id = 0;
        string randevuisteksayfa = "";
        public static int randk = 0;
        public static string description = "";
        public static string telno = "";
        string istektip = "";
        public static NpgsqlConnection conn;
        CallCenterEntities veri = new CallCenterEntities();

        public static List<YETKILER_TBL> kullaniciyetkileri;
        List<KULLANICICALISMALAR_V> kullanicicalismaSecilen;
        List<CALISMACIKISKODLARI_V> calismacikiskodlist;
        List<KULLANICILAR_V> userlogged;

        List<MESAJLARTUM_V> mesajlarlist;
        List<RANDEVULAR_TBL> bekleyenrandevular;
        List<ISTEKLER_TBL> bekleyenistekler;

        bool msjkontrolet = true;
        public static string domainname = "";

        ArrayList m_lineConnections = new ArrayList();
        public static CAbtoPhone AbtoPhone = new CAbtoPhone();
        private int m_curLineId = 1;

        public const int LineCount = 3;

        int gecikenran = 0;
        int yaklasanran = 0;
        public static string msj = "";
        public static int yaklasanrandevudk = 0;
        string sayfaversiyon="";

        public AnaForm(int kulid, string versiyon)
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            sayfaversiyon = versiyon;

            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                userlogged = conn.Query<KULLANICILAR_V>("select * from public.\"KULLANICILAR_V\" WHERE (\"KUL_ID\" = " + kulid + ")").ToList();
            }
            AnaForm.userid = Convert.ToInt32(userlogged[0].KUL_ID);
            AnaForm.userkullaniciid = userlogged[0].KUL_KULLANICIID;
            AnaForm.userrolid = Convert.ToInt32(userlogged[0].KUL_ROL_ID);
            AnaForm.useradi = userlogged[0].KUL_ADI;
            AnaForm.userroladi = userlogged[0].ROL_ADI;
            Int16 rolsira = Convert.ToInt16(userlogged[0].ROL_SIRA);
            AnaForm.kullaniciyetkileri = (from p in veri.YETKILER_TBL where p.YET_ROLSIRANO == rolsira select p).ToList();

            lbl_bilgi.Text = AnaForm.useradi + " " + AnaForm.userroladi;
            lblsantralkodu.Text = userlogged[0].KUL_SANTRALUSERID;
            usersantralkodu = lblsantralkodu.Text;

            baslikal();

            cmb_cikiskodlari.Properties.ValueMember = "CK_ID";
            cmb_cikiskodlari.Properties.DisplayMember = "CK_KOD";

            gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            stateIndicatorComponent1.StateIndex = 0; //1:kırmızı, 2:sarı, 3:yeşil //0:pasif gri
            //timeEdit1.Properties.Buttons.Clear();
            this.Load += AnaForm_Load;
            temizle();
            //timer_istek.Start();

            //4load


            //Displ initial status
            displayNotifyMsg("Başlıyor..."); //Initializing

            //Configure phone
            bool bRes = ConfigurePhone();
            if (!bRes)
            {
                return;
            }


            //Make lines
            for (int i = 1; i <= LineCount; ++i) m_lineConnections.Add(new LineInfo(i));
            buttonLine1.Tag = 1; buttonLine2.Tag = 2; buttonLine3.Tag = 3;

            AbtoPhone.PlaybackVolume = Convert.ToInt32(userlogged[0].KUL_HOPARLORDUZEYI);
            AbtoPhone.RecordVolume = Convert.ToInt32(userlogged[0].KUL_MIKROFONDUZEYI);

            AcceptButton = btn_ara_kapat;

            
        }


        private LineInfo GetCurLine()
        {
            return (LineInfo)m_lineConnections[m_curLineId - 1];
        }
        void baslikal()
        {
            var sonuc = (from p in veri.GENELAYARLAR_TBL select p).ToList();
            domainname = sonuc[0].GA_CIHAZIP;
            this.Text = sayfaversiyon + " " + sonuc[0].GA_ANASAYFA_BASLIK ;
            randevuisteksayfa = sonuc[0].GA_RANDEVUISTEKSAYFA;
            yaklasanrandevudk = Convert.ToInt32(sonuc[0].GA_YAKLASANRANDEVUDK.Value.TotalMinutes);
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            if (kullaniciyetkileri[0].Y_GENELAYARLAR == false
            && kullaniciyetkileri[0].Y_RANDEVUDURUMLARI == false
            && kullaniciyetkileri[0].Y_CIKISKODLARI == false
            && kullaniciyetkileri[0].Y_GENELTAKVIM == false
            && kullaniciyetkileri[0].Y_CALISMALAR == false
            && kullaniciyetkileri[0].Y_ROLVEYETKILER == false
            && kullaniciyetkileri[0].Y_KULLANICILAR == false
            && kullaniciyetkileri[0].Y_SSS == false
            && kullaniciyetkileri[0].Y_FORUMISLEMLERI == false
            && kullaniciyetkileri[0].Y_ISTEKEKLEADMIN == false
            && kullaniciyetkileri[0].Y_RANDEVUAKTAR == false)
            {
                acc_menu.Elements.Remove((AccordionControlElement)btn_ayarlar);
                acc_menu.Refresh();
            }

            if (kullaniciyetkileri[0].Y_RANDEVULAR == false &&
            kullaniciyetkileri[0].Y_CAGRILAR == false &&
            kullaniciyetkileri[0].Y_SESKAYDIBUL == false &&
            kullaniciyetkileri[0].Y_ISTEKLER == false &&
            kullaniciyetkileri[0].Y_LOGLAR == false &&
            kullaniciyetkileri[0].Y_KULLANICIIZLE == false)
            {
                acc_menu.Elements.Remove((AccordionControlElement)btn_rapor);
                acc_menu.Refresh();
            }

            if (kullaniciyetkileri[0].Y_RANDEVULARIM == false &&
            kullaniciyetkileri[0].Y_CAGRILARIM == false &&
            kullaniciyetkileri[0].Y_MESAJLARIM == false &&
            kullaniciyetkileri[0].Y_FORUMKULLAN == false &&
            kullaniciyetkileri[0].Y_YARDIM == false &&
            kullaniciyetkileri[0].Y_ISTEKEKLEOPERATOR == false)
            {
                acc_menu.Elements.Remove((AccordionControlElement)btn_operator);
                acc_menu.Refresh();
            }


            if (kullaniciyetkileri[0].Y_GENELAYARLAR == false) { btn_genelayarlar.Visible = false; accordionControlSeparator18.Visible = false; }
            if (kullaniciyetkileri[0].Y_RANDEVUDURUMLARI == false) { btn_randevudurumlari.Visible = false; accordionControlSeparator19.Visible = false; }
            if (kullaniciyetkileri[0].Y_CIKISKODLARI == false) { btn_cikiskodlari.Visible = false; accordionControlSeparator20.Visible = false; }
            if (kullaniciyetkileri[0].Y_GENELTAKVIM == false) { btn_genelcalismatakvimi.Visible = false; accordionControlSeparator21.Visible = false; }
            if (kullaniciyetkileri[0].Y_CALISMALAR == false) { btn_calismalar.Visible = false; accordionControlSeparator22.Visible = false; }
            if (kullaniciyetkileri[0].Y_ROLVEYETKILER == false) { btn_rolveyetkiler.Visible = false; accordionControlSeparator23.Visible = false; }
            if (kullaniciyetkileri[0].Y_KULLANICILAR == false) { btn_kullanicilar.Visible = false; accordionControlSeparator24.Visible = false; }
            if (kullaniciyetkileri[0].Y_SSS == false) { btn_sss.Visible = false; accordionControlSeparator25.Visible = false; }
            if (kullaniciyetkileri[0].Y_FORUMISLEMLERI == false) { btn_forum.Visible = false; accordionControlSeparator26.Visible = false; }
            if (kullaniciyetkileri[0].Y_ISTEKEKLEADMIN == false) { btn_istekgonderadmin.Visible = false; accordionControlSeparator27.Visible = false; }
            if (kullaniciyetkileri[0].Y_RANDEVUAKTAR == false) { btn_randevuaktar.Visible = false; accordionControlSeparator28.Visible = false; }

            if (kullaniciyetkileri[0].Y_RANDEVULAR == false) { btn_randevulist.Visible = false; accordionControlSeparator9.Visible = false; }
            if (kullaniciyetkileri[0].Y_CAGRILAR == false) { btn_cagrilist.Visible = false; accordionControlSeparator8.Visible = false; }
            if (kullaniciyetkileri[0].Y_SESKAYDIBUL == false) { btn_seskayitlari.Visible = false; accordionControlSeparator10.Visible = false; }
            if (kullaniciyetkileri[0].Y_ISTEKLER == false) { btn_isteklist.Visible = false; accordionControlSeparator7.Visible = false; }
            if (kullaniciyetkileri[0].Y_LOGLAR == false) { btn_loglist.Visible = false; accordionControlSeparator5.Visible = false; }
            if (kullaniciyetkileri[0].Y_KULLANICIIZLE == false) { btn_kullaniciizle.Visible = false; accordionControlSeparator6.Visible = false; }

            if (kullaniciyetkileri[0].Y_RANDEVULARIM == false) { btn_randevularim.Visible = false; accordionControlSeparator2.Visible = false;btn_yaklasanrandevularim.Visible = false;  accordionControlSeparator35.Visible = false;}
            if (kullaniciyetkileri[0].Y_CAGRILARIM == false) { btn_cagrilarim.Visible = false; accordionControlSeparator4.Visible = false; }
            if (kullaniciyetkileri[0].Y_MESAJLARIM == false) { btn_mesajlarim.Visible = false; accordionControlSeparator3.Visible = false; }
            if (kullaniciyetkileri[0].Y_FORUMKULLAN == false) { btn_forumgor.Visible = false; accordionControlSeparator16.Visible = false; }
            if (kullaniciyetkileri[0].Y_YARDIM == false) { btn_yardim.Visible = false; accordionControlSeparator17.Visible = false; }
            if (kullaniciyetkileri[0].Y_ISTEKEKLEOPERATOR == false) { btn_istekgonder.Visible = false; accordionControlSeparator33.Visible = false; }
            if (kullaniciyetkileri[0].Y_CAGRIYAP == false)
            {
                btn_ara_kapat.Visible = false;
                btn_beklet_al.Visible = false;
                btn_aktar.Visible = false;
                btn_konferans.Visible = false;
                btn_expand.Visible = false;
                btn_backspace.Visible = false;
                btn_kaydetbitir.Visible = false;
                btn_kaydetdevamet.Visible = false;
                txt_aciklama.Visible = false;
                cmb_cikiskodlari.Visible = false;
                buttonLine1.Visible = false;
                buttonLine2.Visible = false;
                buttonLine3.Visible = false;
            }
            else
            {
                if (kullaniciyetkileri[0].Y_BEKLEMEYEAL == false) { btn_beklet_al.Visible = false; }
                if (kullaniciyetkileri[0].Y_AKTAR == false) { btn_aktar.Visible = false; btn_konferans.Visible = false; }
            }
            if (kullaniciyetkileri[0].Y_RANDEVUOLUSTUR == false) { btn_yenirandevu.Visible = false; }


            mesajvarmi();
            randevuvarmi();
    }

        private void btn_randevularim_Click(object sender, EventArgs e)
        {
            try
            {
                Randevularim ranlist = new Randevularim();
                ranlist.ShowDialog();

            }
            catch (Exception ex)
            {

            }

        }

        private void btn_calismalar_Click(object sender, EventArgs e)
        {
            Calismalar cal = new Calismalar();

            if (AnaForm.kullaniciyetkileri[0].Y_CALISMAISLEMLERI == false)
            {
                cal.COLTAKVIMI.Visible = false;
                cal.COLPERIYOTLARI.Visible = false;
                cal.COLCIKISKODLARI.Visible = false;
            }

            cal.ShowDialog();
        }

        private void btn_cikiskodlari_Click(object sender, EventArgs e)
        {
            CikisKodlari ck = new CikisKodlari();
            ck.ShowDialog();
        }

        private void btn_periyotlar_Click(object sender, EventArgs e)
        {
            //Periyotlar per = new Periyotlar();
            //per.ShowDialog();
        }

        private void btn_genelayarlar_Click(object sender, EventArgs e)
        {
            GenelAyarlar ga = new GenelAyarlar();
            ga.ShowDialog();
            //ga.FormClosed += Ga_FormClosed;
        }

        //private void Ga_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    baslikal();
        //}

        private void btn_sss_Click(object sender, EventArgs e)
        {
            SSS sss = new SSS(true);
            sss.ShowDialog();
        }

        private void btn_forum_Click(object sender, EventArgs e)
        {
            Forum forum = new Forum(true);
            forum.ShowDialog();
        }

        private void btn_genelcalismatakvimi_Click(object sender, EventArgs e)
        {
            GenelCalismaAraliklari gca = new GenelCalismaAraliklari(0, "", "");
            gca.ShowDialog();
        }

        private void btn_yardim_Click(object sender, EventArgs e)
        {
            SSS sss = new SSS(false);
            sss.panel1.Visible = false;
            sss.COLSIL.Visible = false;
            sss.COLDUZENLE.Visible = false;
            sss.btn_yeni.Visible = false;
            sss.ShowDialog();
        }

        private void btn_cagrilarim_Click(object sender, EventArgs e)
        {
            Cagrilarim cag = new Cagrilarim(false);            
            cag.ShowDialog();
        }

        private void btn_forumgor_Click(object sender, EventArgs e)
        {
            Forum forum = new Forum(false);
            forum.panel1.Visible = false;
            forum.COLDUZENLE.Visible = false;
            forum.COLSIL.Visible = false;
            forum.COL_MSJDUZENLE.Visible = false;
            forum.COL_MSJSIL.Visible = false;
            forum.FR_AKTIF.Visible = false;
            forum.btn_yeni.Visible = false;
            forum.ShowDialog();
        }

        private void btn_seskayitlari_Click(object sender, EventArgs e)
        {
            SesKayitlari ses = new SesKayitlari("");
            ses.ShowDialog();
        }

        private void btn_rolveyetkiler_Click(object sender, EventArgs e)
        {
            RolveYetkiler rvy = new RolveYetkiler();
            rvy.ShowDialog();
        }

        private void btn_kullanicilar_Click(object sender, EventArgs e)
        {
            Kullanıcılar kul = new Kullanıcılar();

            if (AnaForm.kullaniciyetkileri[0].Y_KULLANICICALISMALARI == false)
            {
                kul.COLCALISMALARI.Visible = false;
            }

            kul.ShowDialog();
        }

        private void btn_istekgonderadmin_Click(object sender, EventArgs e)
        {
            IstekGonder stek = new CallCenter.IstekGonder(true);
            stek.ShowDialog();
        }

        private void btn_istekgonder_Click(object sender, EventArgs e)
        {
            IstekGonder stek = new CallCenter.IstekGonder(false);
            stek.ShowDialog();
        }


        private void btn_expand_Click(object sender, EventArgs e)
        {
            btn_expand.Visible = false; //panel7 contains
            pnl_tuslar.Visible = true; //panel7 contains
            btn_backspace.Visible = true;
        }

        private void btn_narrow_Click(object sender, EventArgs e)
        {
            btn_expand.Visible = true;
            pnl_tuslar.Visible = false;
            btn_backspace.Visible = false;
        }

        private void btn_randevudurumlari_Click(object sender, EventArgs e)
        {
            RandevuDurumlari rand = new CallCenter.RandevuDurumlari();
            rand.ShowDialog();
        }

        private void timeristek_Tick(object sender, EventArgs e)
        {
            istekgetir();
        }
        void mesajvarmi()
        {
            string querystring = "select * from public.\"MESAJLARTUM_V\" WHERE  ( \"alankulid\" = " + AnaForm.userid + " and \"MSJ_OKUNDU\" <>TRUE)";
            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                mesajlarlist = conn.Query<MESAJLARTUM_V>(querystring).ToList();

                if (mesajlarlist.Count > 0)
                {
                    if (btn_mesajvar.Text != mesajlarlist.Count.ToString())
                    {
                        try
                        {
                            SoundPlayer player = new SoundPlayer();
                            string path = Application.StartupPath + "\\notify.wav"; // Çalmasini istediginiz ses dosyasinin yolu
                            player.SoundLocation = path;
                            player.Play();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    
                    btn_mesajvar.Visible = true;

                    if (btn_mesajvar.Text != mesajlarlist.Count.ToString())
                    {
                        alertControl_Mesaj.Show(this, "Yeni Mesaj", mesajlarlist.Count.ToString() + " Okunmamış mesajınız var", Properties.Resources.New_message_32  );
                        btn_mesajvar.Text = mesajlarlist.Count.ToString();
                    }
                }
            }
        }

        void istekgetir()
        {
            if (ran_id == 0) //istekten
            {
                bekleyenistekler = (from p in veri.ISTEKLER_TBL where p.IST_OKUNDU != true && p.IST_KULLANICIID == userkullaniciid select p).OrderBy(t => t.IST_TARIH).ToList();
            }
            else //randevudan
            {
                var rand = (from p in veri.RANDEVULAR_TBL where p.RAN_ID == AnaForm.ran_id select p).ToList();
                rand[0].RAN_ACMA = AnaForm.tarihsaatgetir();
                veri.SaveChanges();
                bekleyenistekler = (from p in veri.ISTEKLER_TBL where p.IST_ID == ist_id select p).ToList();
            }

            if (bekleyenistekler.Count() < 1)
            {
                if (ran_id != 0)
                {
                    MessageBox.Show("İstek bulunamadı...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ran_id = 0;
                }
                return;
            }

            if (bekleyenistekler[0].IST_TELNO.ToString().Length == 10) //harzemliden 10 numeric karakter geliyor.
            {
                bekleyenistekler[0].IST_TELNO = "0" + bekleyenistekler[0].IST_TELNO; //vt ye standart 11 karakter gönderiyoruz.
                veri.SaveChanges();
            }            
            
            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                kullanicicalismaSecilen = conn.Query<KULLANICICALISMALAR_V>("select * from public.\"KULLANICICALISMALAR_V\" WHERE (\"KC_KUL_ID\" = " + AnaForm.userid + " and \"CAL_CALISMAID\" = '" + bekleyenistekler[0].IST_CALISMAID.ToString() + "') ORDER BY \"CAL_CALISMAID\"").ToList();
            }

            ist_id = Convert.ToInt32(bekleyenistekler[0].IST_ID);
            timer_istek.Stop();

            if (kullanicicalismaSecilen.Count() < 1)
            {
                istekkapat();
                MessageBox.Show("Çalışma ve kullanıcı bağlantısı bulunamadı...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cal_id = Convert.ToInt32(kullanicicalismaSecilen[0].CAL_ID);

            if (bekleyenistekler[0].IST_NEDIR == "C" || ran_id != 0)
            {
                if (CalismaAktifPeriyotMu(AnaForm.tarihsaatgetir(), AnaForm.ist_id, AnaForm.cal_id, 0) == false)
                {
                    istekkapat();
                    return;
                }
            }

            txt_telno.Properties.Mask.EditMask = "0 999 999 99 99";// "(999) 000 00 00"; // başında 0 olması gerekiyormuş
            txt_telno.ReadOnly = true;
            //cmb_calismaid.EditValue = cal_id;
            //cmb_calismaid.Enabled = false;
            randk = Convert.ToInt32(kullanicicalismaSecilen[0].CAL_RANDEVUARALIK.Value.TotalMinutes);
            txt_telno.Text = bekleyenistekler[0].IST_TELNO.ToString();
            lbl_telno.Text = bekleyenistekler[0].IST_TELNO.ToString();
            lbl_calismaid.Text = bekleyenistekler[0].IST_CALISMAID;
            lbl_calismaadi.Text = kullanicicalismaSecilen[0].CAL_ADI;
            lbl_birimno.Text = bekleyenistekler[0].IST_BIRIMNO.ToString();
            lbl_altbirimno.Text = bekleyenistekler[0].IST_ALTBIRIMNO.ToString();
            lbl_il.Text = bekleyenistekler[0].IST_IL;
            lbl_randevutercih.Text = bekleyenistekler[0].IST_RANDEVUTERCIH;
            lbl_aciklama.Text = bekleyenistekler[0].IST_ACIKLAMA;
            lbl_refyil.Text = bekleyenistekler[0].IST_REFYIL.ToString();
            lbl_refdonem.Text = bekleyenistekler[0].IST_REFDONEM.ToString();
            lbl_refay.Text = bekleyenistekler[0].IST_REFAY.ToString();
            lbl_refhafta.Text = bekleyenistekler[0].IST_REFHAFTA.ToString();

            description = "Çalışma ID:" + lbl_calismaid.Text + Environment.NewLine + "Çalışma Adı:" + lbl_calismaadi.Text + Environment.NewLine + "Birim No:" + lbl_birimno.Text + Environment.NewLine + "Alt Birim No:" + lbl_altbirimno.Text + Environment.NewLine + "Ref. Yıl:" + lbl_refyil.Text + Environment.NewLine + "Ref. Dönem:" + lbl_refdonem.Text + Environment.NewLine + "Ref. Ay:" + lbl_refay.Text + Environment.NewLine + "Ref. Hafta:" + lbl_refhafta.Text;
            telno = lbl_telno.Text;

            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                calismacikiskodlist = conn.Query<CALISMACIKISKODLARI_V>("select * from public.\"CALISMACIKISKODLARI_V\" WHERE (\"CCK_CAL_ID\" = " + AnaForm.cal_id + ")").ToList();
                cmb_cikiskodlari.Properties.DataSource = calismacikiskodlist;
            }

            cagrigetir();
            btn_yenirandevu.Enabled = true; //çağrı da olsa randevu almak isteyebilir.

            if (bekleyenistekler[0].IST_NEDIR == "C" || ran_id != 0) 
            {
                btn_ara_kapat.Enabled = true;
                cmb_cikiskodlari.Enabled = true;
                txt_aciklama.Enabled = true;
                btn_kaydetbitir.Enabled = true;
                if (kullanicicalismaSecilen[0].CAL_MANUELARAMA == true)
                {
                    btn_kaydetdevamet.Enabled = true;
                    //btn_expand.Enabled = true; bunu ilk numarayı kaydettikten sonra getireceksin.
                }
                else
                {
                    btn_kaydetdevamet.Enabled = false;
                    btn_expand.Enabled = false;
                }
            }
            else
            {
                istektip = "R";
                istektenrandevu();
            }
            
        }

        void cagrigetir()
        {
            if (rd_tel.Checked == true)
            {
                using (conn = new NpgsqlConnection(AnaForm.cstr))
                {
                    conn.Open();
                    grd_aramalist.DataSource = conn.Query<CAGRIDETAYLAR_V>("select * from public.\"CAGRIDETAYLAR_V\" WHERE (\"CAG_CAL_ID\" = " + AnaForm.cal_id + "  and \"CAG_TELNO\" = '" + lbl_telno.Text + "') ORDER BY \"CAG_TARIH\" DESC").ToList();
                }
            }
            else if (rd_brmno.Checked == true)
            {
                using (conn = new NpgsqlConnection(AnaForm.cstr))
                {
                    conn.Open();
                    grd_aramalist.DataSource = conn.Query<CAGRIDETAYLAR_V>("select * from public.\"CAGRIDETAYLAR_V\" WHERE (\"CAG_CAL_ID\" = " + AnaForm.cal_id + "  and \"IST_BIRIMNO\" = " + lbl_birimno.Text + ") ORDER BY \"CAG_TARIH\" DESC").ToList();
                }
            }
            else if (rd_altbrmno.Checked == true)
            {
                using (conn = new NpgsqlConnection(AnaForm.cstr))
                {
                    conn.Open();
                    grd_aramalist.DataSource = conn.Query<CAGRIDETAYLAR_V>("select * from public.\"CAGRIDETAYLAR_V\" WHERE (\"CAG_CAL_ID\" = " + AnaForm.cal_id + "  and \"IST_ALTBIRIMNO\" = " + lbl_altbirimno.Text + ") ORDER BY \"CAG_TARIH\" DESC").ToList();
                }
            }

        }

        private void btn_yenirandevu_Click(object sender, EventArgs e)
        {
            istektenrandevu();
        }


        void istektenrandevu()
        {

            if (randevuisteksayfa == "TAKVIM")
            {
                Randevularim takvimistekten = new Randevularim();

                takvimistekten.ShowDialog();
                if (istektip == "R")// çağrı esnasında da randevu ekranını açmış olabilir. Ve çağrıda kaydet bitir ile kapatılır istek.Sadece randevu olunca bir randevu oluşturması sonrası kapatılır.
                {
                    istekkapat();
                }
            }
            else
            {
                RandevuEkle randevuistekten = new RandevuEkle();
                //randevuistekten.edtStartDate.DateTime = AnaForm.tarihsaatgetir().Date;
                //randevuistekten.edtStartTime.Time = AnaForm.tarihsaatgetir().Date;
                //randevuistekten.edtEndDate.DateTime = AnaForm.tarihsaatgetir().AddMinutes(randk);
                //randevuistekten.edtEndTime.Time = AnaForm.tarihsaatgetir().Date.AddMinutes(randk);

                //randevuistekten.dt_baslama.DateTime = AnaForm.tarihsaatgetir();
                randevuistekten.edtStartDate.DateTime = AnaForm.tarihsaatgetir().Date;
                randevuistekten.edtStartTime.Time = AnaForm.tarihsaatgetir();


                randevuistekten.tbSubject.Text = txt_telno.Text;
                randevuistekten.tbDescription.Text = description;
                randevuistekten.ShowDialog();
                if (istektip == "R") // çağrı esnasında da randevu ekranını açmış olabilir. Ve çağrıda kaydet bitir ile kapatılır istek. Sadece randevu olunca bir randevu oluşturması sonrası kapatılır.
                {
                    istekkapat();
                }

            }
        }
        void istekkapat()
        {
            if (ist_id == 0) return;

            if (ran_id == 0)  //istekten gelmiştir isteği kapatırım.
            {
                try
                {
                    var istek = (from p in veri.ISTEKLER_TBL where p.IST_ID == ist_id select p).SingleOrDefault();
                    istek.IST_OKUNDU = true;
                    istek.IST_KAPANMAZAMANI = tarihsaatgetir();
                    veri.SaveChanges();


                    //bu iki satır çağrı yapmadan kapattığında arama butonunun da pasifleşmesini sağlar
                    ist_id = 0; //henüz temizleme yapmadığı için isteği açık görmesin diye şimdi sıfırlıyorum, zaten temizlede de sıfırlanacak
                    LineInfo lnInfo = GetCurLine();
                    ChageControlsState(lnInfo);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("İstek kapatılamadı, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //randevudan gelmiştir, randevuyu kapatırım.
            {
                try
                {
                    var rand = (from p in veri.RANDEVULAR_TBL where p.RAN_ID == ran_id select p).SingleOrDefault();
                    rand.RAN_KAPANMA = tarihsaatgetir();
                    veri.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Randevu kapatılamadı, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            temizle(); //timerı tekrar başlatıyor
        }

        void temizle()
        {
            istektip = "";
            ist_id = 0;
            ran_id = 0;
            cal_id = 0;
            randk = 0;
            description = "";
            telno = "";

            timer_istek.Start();
            timer_randevu.Start();
            //cmb_calismaid.Enabled = true;
            grd_aramalist.DataSource = null;
            cmb_cikiskodlari.EditValue = null;
            cmb_cikiskodlari.Properties.DataSource = null;
            txt_aciklama.Text = "";

            //arama butonları sadece form loadta enabled false olur, sonra çağrı hareketlerine göre changecontrolstate in içinde enabled true/false olur. çünkü başka bir hatta arama varsa vs ben sırf isteği kapattım diye buton enabled false yapamam.

            cmb_cikiskodlari.Enabled = false;
            txt_aciklama.Enabled = false;
            btn_kaydetbitir.Enabled = false;
            btn_kaydetdevamet.Enabled = false;
            btn_yenirandevu.Enabled = false;
            btn_expand.Enabled = false;
            pnl_tuslar.Visible = false;
            btn_backspace.Visible = false;

            txt_telno.Text = "";
            lbl_telno.Text = "";
            lbl_calismaid.Text = "";
            lbl_calismaadi.Text = "";
            lbl_birimno.Text = "";
            lbl_altbirimno.Text = "";
            lbl_il.Text = "";
            lbl_randevutercih.Text = "";
            lbl_aciklama.Text = "";
            lbl_refyil.Text = "";
            lbl_refdonem.Text = "";
            lbl_refay.Text = "";
            lbl_refhafta.Text = "";


            txt_telno.Properties.Mask.EditMask = null;
            txt_telno.ReadOnly = true;
            //this.txt_telno.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            //this.txt_telno.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void btn_kaydetbitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_cikiskodlari.Text == "")
                {
                    MessageBox.Show("Lütfen Çıkış Kodu belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmb_cikiskodlari.Focus();
                    return;
                }
                cagrikaydet();
                istekkapat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_kaydetdevamet_Click(object sender, EventArgs e)
        {
            if (cmb_cikiskodlari.Text == "")
            {
                MessageBox.Show("Lütfen Çıkış Kodu belirtiniz...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_cikiskodlari.Focus();
                return;
            }

            try
            {
                cagrikaydet();

                txt_telno.Text = "";
                btn_expand.Enabled = true;
                btn_expand.Visible = false; //btn_kaydetdevamet butonu(bu buton) aktif değildir manuel arama yoksa.bu yüzden burda kontrole gerek yok. //yani expand visible false ve pnl_tuslar visible true yapıp numara çevirmesini sağlamış oluyoruz.
                pnl_tuslar.Visible = true;
                btn_backspace.Visible = true;
                txt_telno.Properties.Mask.EditMask = "0 999 999 99 99";
                txt_telno.ReadOnly = false;
                lbl_telno.Text = "";

                cmb_cikiskodlari.EditValue = null;
                txt_aciklama.Text = "";

                btn_ara_kapat.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cagrikaydet()
        {
            try
            {
                LineInfo lnInfo = GetCurLine();

                CAGRILAR_TBL kayit;
                kayit = new CAGRILAR_TBL();
                kayit.CAG_IST_ID = ist_id;
                kayit.CAG_CAL_ID = cal_id;
                kayit.CAG_KUL_ID = userid;
                kayit.CAG_TARIH = AnaForm.tarihsaatgetir();
                kayit.CAG_TELNO = lbl_telno.Text;
                kayit.CAG_ACIKLAMA = txt_aciklama.Text;
                kayit.CAG_CK_ID = Convert.ToInt32(cmb_cikiskodlari.EditValue);
                kayit.CAG_SANTRALCIKISKODU = cag_cikiskodu;
                kayit.CAG_SURE = cag_sure;
                kayit.CAG_BASLAMA = cag_baslama;
                kayit.CAG_BITIS = cag_bitis;
                kayit.CAG_RAN_ID = ran_id;

                veri.CAGRILAR_TBL.Add(kayit);
                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cağrı değerlerini sıfırlarım diğer çağrıda yenilerini almak için.
                cag_baslama = null;
                cag_bitis = null;
                cag_sure = new TimeSpan(0, 0, 0);
                cag_cikiskodu = "";
                cag_lineid = 0;
                cag_conid = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region tuslar

        private void DTFM_Click(object sender, EventArgs e)
        {
            SimpleButton b = (SimpleButton)sender;
            if (lbl_telno.Text.Length >= 11) return;
            lbl_telno.Text = lbl_telno.Text + b.Tag;


            bool bDtmfSent = false;

            while (!bDtmfSent)
            {
                try
                {
                    //AbtoPhone.SendTone(b.Text);
                    AbtoPhone.SendToneEx(Convert.ToInt32(b.Tag), 200, 1, 1, 0);
                    bDtmfSent = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }

        }

        private void txt_telno_KeyUp(object sender, KeyEventArgs e)
        {
            lbl_telno.Text = txt_telno.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace(" ", "");
        }
        #endregion tuslar



        public static bool CalismaAktifPeriyotMu(DateTime istenenbaslama, int istid, int calid, int ranid)
        {
            //AnaForm.userid;

            CallCenterEntities veri = new CallCenterEntities();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            if (ranid != 0) //eğer aktif bir istekten değil de randevudan geliyorsa istid o randevudan çekilir. bu if ten sonraki herşey bu idlerle yürüyor zaten.
            {
                istid = Convert.ToInt32((from p in veri.RANDEVULAR_TBL where p.RAN_ID == ranid select p).SingleOrDefault().RAN_IST_ID); //eğer istek anında ya da değil, istek anındaysa bu istekten farklı bir randevuyu güncellerse o randevunun istek -dolayısıyla çalışma- bilgilerine göre kontrol edebilmek için.                
            }

            if (istid == 0)
            {
                MessageBox.Show("İstek bulunamadı!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var istek = (from p in veri.ISTEKLER_TBL where p.IST_ID == istid select p).SingleOrDefault();
            if (istek == null)
            {
                MessageBox.Show("İstek bulunamadı!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ranid != 0) //eğer aktif bir istekten değil de randevudan geliyorsa calid o randevudan çekilir. 
            {
                calid = Convert.ToInt32((from p in veri.CALISMALAR_TBL where p.CAL_CALISMAID == istek.IST_CALISMAID select p).SingleOrDefault().CAL_ID);
            }

            string msjek = Environment.NewLine + " İstek Kullanıcı ID: " + istek.IST_KULLANICIID + Environment.NewLine + " İstek Çalışma ID: " + istek.IST_CALISMAID + Environment.NewLine + " İstek Tarih:" + istek.IST_TARIH + "";
            var calisma = (from p in veri.CALISMALAR_TBL where p.CAL_SIL != true && p.CAL_ID == calid select p).SingleOrDefault();
            if (calisma == null)
            {
                MessageBox.Show("Çalışma bulunamadı!" + msjek, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var genelayarlar = (from p in veri.GENELAYARLAR_TBL select p).ToList();

            TimeSpan baslamasaat;
            TimeSpan bitirmesaat;
            if (calisma.CAL_GUNBASLAMASAAT != null)
            {
                baslamasaat = (TimeSpan)calisma.CAL_GUNBASLAMASAAT;
            }
            else
            {
                baslamasaat = (TimeSpan)genelayarlar[0].GA_GUNBASLAMASAAT;
            }
            if (calisma.CAL_GUNBITISSAAT != null)
            {
                bitirmesaat = (TimeSpan)calisma.CAL_GUNBITISSAAT;
            }
            else
            {
                bitirmesaat = (TimeSpan)genelayarlar[0].GA_GUNBITISSAAT;
            }            

            bool geneltatilvarmi = (from p in veri.CALISMATAKVIMI_TBL where p.CT_CALIS == false && p.CT_CAL_ID == null && p.CT_BASLAMA <= istenenbaslama && p.CT_BITIS >= istenenbaslama select p).ToList().Count > 0 ? true : false;
            bool calismatatilvarmi = (from p in veri.CALISMATAKVIMI_TBL where p.CT_CALIS == false && p.CT_CAL_ID == calid && p.CT_BASLAMA <= istenenbaslama && p.CT_BITIS >= istenenbaslama select p).ToList().Count > 0 ? true : false;
            bool genelmesaivarmi = (from p in veri.CALISMATAKVIMI_TBL where p.CT_CALIS == true && p.CT_CAL_ID == null && p.CT_BASLAMA <= istenenbaslama && p.CT_BITIS >= istenenbaslama select p).ToList().Count > 0 ? true : false;
            bool calismamesaivarmi = (from p in veri.CALISMATAKVIMI_TBL where p.CT_CALIS == true && p.CT_CAL_ID == calid && p.CT_BASLAMA <= istenenbaslama && p.CT_BITIS >= istenenbaslama select p).ToList().Count > 0 ? true : false;

            if (calismamesaivarmi == true || genelmesaivarmi == true)
            {
                return true;
            }
            else if (calismatatilvarmi == true)
            {
                MessageBox.Show("Çalışma tatilde!" + msjek, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (geneltatilvarmi == true)
            {
                MessageBox.Show("Genel Tatil!" + msjek, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (istenenbaslama.TimeOfDay < baslamasaat || istenenbaslama.TimeOfDay > bitirmesaat) //Ek mesai yok ise çalışma saatleri içinde mi bakmak gerekiyor çünkü anket tarihi aralık olarak veriliyor, gün başlama ve bitişi varsa çalışmadan yoksa genel ayarlardan alıyorum.            
            {
                MessageBox.Show("Çalışma Saatleri içerisinde değil!" + msjek, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (istek.IST_REFDONEM == 0)
            {
                istek.IST_REFDONEM = null;
            }
            if (istek.IST_REFAY == 0)
            {
                istek.IST_REFAY = null;
            }
            if (istek.IST_REFHAFTA == 0)
            {
                istek.IST_REFHAFTA = null;
            }
            veri.SaveChanges();

            var calismaperiyot = (from p in veri.CALISMAPERIYOTLARI_TBL
                                  where p.CP_CAL_ID == calid
                                        && p.CP_REFYIL.Value.Year == istek.IST_REFYIL
                                        && p.CP_REFDONEM == istek.IST_REFDONEM 
                                        && p.CP_REFAY == istek.IST_REFAY
                                        && p.CP_REFHAFTA == istek.IST_REFHAFTA
                                        && p.CP_AKTIF == true
                                  select p).SingleOrDefault();
            if (calismaperiyot == null)
            {
                MessageBox.Show("Çalışma Periyodunda değil!" + msjek, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (istenenbaslama < calismaperiyot.CP_BASLAMATARIH || istenenbaslama > calismaperiyot.CP_BITISTARIH) //çalışma saatleri içinde değilse mesai de olsa arayamaz ki...
            {
                MessageBox.Show("Çalışma Periyodunda değil!" + msjek, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int gun = (int)istenenbaslama.DayOfWeek;
            if (gun == 6 && genelayarlar[0].GA_CUMARTESICALIS != true)
            {
                MessageBox.Show("Cumartesi çalışılmaz!" + msjek, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (gun == 0 && genelayarlar[0].GA_PAZARCALIS != true)
            {
                MessageBox.Show("Pazar çalışılmaz!" + msjek, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }

        private void btn_randevulist_Click(object sender, EventArgs e)
        {
            RandevularList randl = new RandevularList();
            randl.ShowDialog();
        }

        private void rd_tel_CheckedChanged(object sender, EventArgs e)
        {
            cagrigetir();
        }

        private void rd_brmno_CheckedChanged(object sender, EventArgs e)
        {
            cagrigetir();
        }

        private void rd_altbrmno_CheckedChanged(object sender, EventArgs e)
        {
            cagrigetir();
        }


        private void btn_mesajlarim_Click(object sender, EventArgs e)
        {
            mesajac();
        }

        private void btn_mesajvar_Click(object sender, EventArgs e)
        {
            mesajac();          
        }

        void mesajac()
        {
            if (btn_mesajvar.Visible == true )
            {
                msjkontrolet = false;
            }
            Mesajlarım msj = new Mesajlarım(btn_mesajvar.Visible); //okunmamış mesaj varsa btn_mesajvar.visible=true olur
            msj.ShowDialog();

            CallCenterEntities veri2 = new CallCenterEntities();
            veri2.Database.Connection.ConnectionString = AnaForm.cstr;
            foreach (var item in mesajlarlist)
            {
                var kayit = (from p in veri2.MESAJLAR_TBL where p.MSJ_ID == item.MSJ_ID select p).SingleOrDefault();
                kayit.MSJ_OKUNDU = true;
                veri2.SaveChanges();
            }
            msjkontrolet = true;
            btn_mesajvar.Text = "0";
            btn_mesajvar.Visible = false;
        }
        
        private void btn_cagrilist_Click(object sender, EventArgs e)
        {
            CagriRaporlari cag = new CagriRaporlari(true);
            cag.ShowDialog();
        }


        public static DateTime tarihsaatgetir()
        {

            string querystring = "select * from public.\"SUAN_V\"";

            using (AnaForm.conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                return conn.Query<SUAN_V>(querystring).ToList()[0].suan;
            }
        }

        private void btn_randevuaktar_Click(object sender, EventArgs e)
        {
            RandevuAktar ranaktar = new RandevuAktar();
            ranaktar.ShowDialog();
        }

        private void btn_isteklist_Click(object sender, EventArgs e)
        {
            Istekler ists = new Istekler();
            ists.ShowDialog();
        }

        private void btn_loglist_Click(object sender, EventArgs e)
        {
            LogList lls = new LogList();
            lls.ShowDialog();
        }

        private void btn_kullaniciizle_Click(object sender, EventArgs e)
        {

            //LineInfo lnInfo = GetCurLine();
            //MessageBox.Show( lnInfo.m_callTime.ToString());

            //     int subscriptionIdB = AbtoPhone.Subscriptions.SubscribePresence("303");

            //MessageBox.Show("Yapım aşamasında");
            //KullaniciIzle kuliz = new KullaniciIzle();
            //kuliz.ShowDialog();
        }

        private void AnaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private bool GetSelectedConnection(out int connectionId)
        {
            //Check connections count
            connectionId = 0;
            int count = activeConnListbox.Items.Count;
            if (count == 0) return false;

            //Get sel connection
            int selectedIndex = activeConnListbox.SelectedIndex;
            if (selectedIndex == -1) selectedIndex = count - 1;

            //Get conn id
            connectionId = ((ConnListBoxItem)activeConnListbox.Items[selectedIndex]).handle;
            return true;
        }

        private void displayNotifyMsg(string msg)
        {
            notificationsListBox.Items.Add(msg);
            notificationsListBox.TopIndex = notificationsListBox.Items.Count - 1;//scrol down
        }

        private void ChageControlsState(LineInfo li)
        {
            ChageLineCaption(li);

            if (li.m_bCallEstablished || li.m_bCalling) { btn_ara_kapat.Enabled = true; btn_ara_kapat.Image = CallCenter.Properties.Resources.ico_kapat;
                btn_expand.Enabled = false;
                pnl_tuslar.Visible = false;
            }
            else { btn_ara_kapat.Enabled = false; btn_ara_kapat.Image = CallCenter.Properties.Resources.ico_ara; }

            if (li.m_bCallHeld) { btn_beklet_al.Image = CallCenter.Properties.Resources.ico_hattaal; }
            else { btn_beklet_al.Image = CallCenter.Properties.Resources.ico_beklet; }

            if (li.m_bCallEstablished)
            {
                btn_beklet_al.Enabled = true;
                btn_aktar.Enabled = true;
                btn_konferans.Enabled = true;
            }
            else
            {
                btn_beklet_al.Enabled = false;
                btn_aktar.Enabled = false;
                btn_konferans.Enabled = false;
            }

            callDurationLabel.Visible = li.m_bCallEstablished;
            callDurationLabel.Text = li.m_callTimeStr;

            btn_backspace.Enabled = li.m_bCallEstablished || li.m_bCalling ? false : true;

            //UInputLabel.Text = li.m_usrInputStr;

            #region ek 
            //hatlar arasında gezince, henüz görüşme yoksa, bekleyen istek olsa bile arama butonu pasif oluyordu. Onun için bu kontrolü yapmak lazım:
            if (ist_id != 0 && istektip != "R" && cag_conid == 0) //istek varsa; çağrı ise; henüz cağrı yap a basmadıysa
            {
                if (li.m_conn.Keys.Count() == 0)
                {
                    btn_ara_kapat.Enabled = true;
                }
            }
            #endregion ek
        }

        public class LineInfo
        {
            public LineInfo(int id)
            {
                m_id = id;
                m_conn = new ConnectionsTbl();
                m_bCalling = false;
                m_bCallEstablished = false;
                m_bCallHeld = false;
                m_bCallPlayStarted = false;
                m_usrInputStr = "";
            }

            public ConnectionsTbl m_conn;
            public int m_id;
            public int m_lastConnId;
            public bool m_bCalling;
            public bool m_bCallEstablished;
            public bool m_bCallHeld;
            public bool m_bCallPlayStarted;
            public string m_usrInputStr;
            public System.Windows.Forms.Timer m_callDurationTimer;
            public TimeSpan m_callTime;
            public string m_callTimeStr;
        }

        protected bool ConfigurePhone()
        {
            //Assign event handlers
            AnaForm.AbtoPhone.OnInitialized += new _IAbtoPhoneEvents_OnInitializedEventHandler(AbtoPhone_OnInitialized);
            AnaForm.AbtoPhone.OnLineSwiched += new _IAbtoPhoneEvents_OnLineSwichedEventHandler(AbtoPhone_OnLineSwiched);
            AnaForm.AbtoPhone.OnEstablishedCall += new _IAbtoPhoneEvents_OnEstablishedCallEventHandler(AbtoPhone_OnEstablishedCall);
            AnaForm.AbtoPhone.OnIncomingCall += new _IAbtoPhoneEvents_OnIncomingCallEventHandler(AbtoPhone_OnIncomingCall);
            AnaForm.AbtoPhone.OnClearedCall += new _IAbtoPhoneEvents_OnClearedCallEventHandler(AbtoPhone_OnClearedCall);
            AnaForm.AbtoPhone.OnRegistered += new _IAbtoPhoneEvents_OnRegisteredEventHandler(AbtoPhone_OnRegistered);
            AnaForm.AbtoPhone.OnEstablishedConnection += new _IAbtoPhoneEvents_OnEstablishedConnectionEventHandler(AbtoPhone_OnEstablishedConnection);
            AnaForm.AbtoPhone.OnClearedConnection += new _IAbtoPhoneEvents_OnClearedConnectionEventHandler(AbtoPhone_OnClearedConnection);
            AnaForm.AbtoPhone.OnToneReceived += new _IAbtoPhoneEvents_OnToneReceivedEventHandler(AbtoPhone_OnToneReceived);
            AnaForm.AbtoPhone.OnPhoneNotify += new _IAbtoPhoneEvents_OnPhoneNotifyEventHandler(AbtoPhone_OnPhoneNotify);
            AnaForm.AbtoPhone.OnRemoteAlerting2 += new _IAbtoPhoneEvents_OnRemoteAlerting2EventHandler(AbtoPhone_OnRemoteAlerting2);
            AnaForm.AbtoPhone.OnSubscribeStatus += new _IAbtoPhoneEvents_OnSubscribeStatusEventHandler(AbtoPhone_OnSubscribeStatus);
            AnaForm.AbtoPhone.OnSubscriptionNotify += new _IAbtoPhoneEvents_OnSubscriptionNotifyEventHandler(AbtoPhone_OnSubscriptionNotify);

            //Get config
            CConfig phoneCfg = AbtoPhone.Config;

            //Manual set needed values
            phoneCfg.ListenPort = 5060;
            // phoneCfg.StunServer = "stun.l.google.com:19302";


            phoneCfg.RegDomain = domainname; //"10.0.0.12";//your domain
            phoneCfg.RegUser = userlogged[0].KUL_SANTRALUSERID; //"302";//your user name
            phoneCfg.RegPass = userlogged[0].KUL_SANTRALSIFRE; //"BUNEZaCqbk3n";//your password
            phoneCfg.RegExpire = 300;
            //Specify License key
            phoneCfg.LicenseUserId = "{Licensed_for_Turksat-A527-044A-9AC9A63D-E2FD-1AC3-2B95-71CE19A3A3F1}";
            phoneCfg.LicenseKey = "{vFwRYnP5oP46xpRibsOFZOVvl3bk7s++3L9bZU+H28WlMCzQqreG2hsegCV4H1qVWehQIeAc99Ze2Lxt/UDGvw==}";

            try
            {
                //Apply modified config
                AbtoPhone.ApplyConfig();

                AbtoPhone.Initialize();
            }
            catch (Exception e)
            {
                displayNotifyMsg("Yapılandırma Hatası: " + e.Message);
                return false;
            }

            return true;
        }

        private void AbtoPhone_OnInitialized(string Msg)
        {
            if (Msg.Contains("Initialized."))
            {
                Msg = "Başladı.";
            }
            else
            {
                Msg = "Bir sorun oluştu.";
            }

            displayNotifyMsg(Msg);

            //if (Msg.Contains("FAILED"))
            //BeginInvoke(new ActivateSDK_Delegate(activateSDK_Click), this, null);
        }

        private void AbtoPhone_OnLineSwiched(int lineId)
        {
            //Display line as pressed button
            HighlightCurLine(m_curLineId, lineId);

            //Remember
            m_curLineId = lineId;

            //Display connections of cur line
            LineInfo lnInfo = GetCurLine();
            DisplayConnectionsAll(lnInfo);

            //Show/Hide call controls
            ChageControlsState(lnInfo);
        }

        private void AbtoPhone_OnIncomingCall(string adress, int lineId)
        {
            //Show form
            IncomingForm dlg = new IncomingForm();
            // MessageBox.Show(adress.IndexOf("sip:").ToString());

            string santalkullanicikodu = adress.Substring(adress.IndexOf("sip:"), adress.IndexOf("@") - adress.IndexOf("sip:")).Replace("sip:", "");

            var kullanici = veri.KULLANICILAR_TBL.Where(t => t.KUL_SANTRALUSERID == santalkullanicikodu).ToList();
            if (kullanici.Count() > 0)
            {
                dlg.textBoxCaller.Text = kullanici[0].KUL_ADI; // adres; sip:302@10.0.0.13 şeklinde geliyor ve bize sadece 302 lazım.
            }
            else
            {
                dlg.textBoxCaller.Text = santalkullanicikodu;
            }

            dlg.textBoxLine.Text = "Hat-" + lineId.ToString();

            //AbtoPhone.Config.VideoCallEnabled = 0;//Answer audio or video
            //AbtoPhone.ApplyConfig();

            if (dlg.ShowDialog(this) == DialogResult.Yes) AbtoPhone.AnswerCallLine(lineId);
            else AbtoPhone.RejectCallLine(lineId);
        }

        private void AbtoPhone_OnRegistered(string Msg)
        {
            //displayNotifyMsg(Msg);
            //stateIndicatorComponent1.StateIndex = 0; //1:kırmızı, 2:sarı, 3:yeşil //0:pasif gri

            if (Msg.Contains("Registration success"))
            {
                stateIndicatorComponent1.StateIndex = 3;
            }
            else
            {
                stateIndicatorComponent1.StateIndex = 1;
            }
        }

        private void AbtoPhone_OnToneReceived(int tone, int connectionId, int lineId)
        {
            LineInfo lnInfo = GetLine(lineId);

            StringBuilder sb = new StringBuilder();
            sb.Append(lnInfo.m_usrInputStr);
            sb.Append((char)tone);
            lnInfo.m_usrInputStr = sb.ToString();

            //if (lineId == m_curLineId) UInputLabel.Text = lnInfo.m_usrInputStr;
        }


        private void AbtoPhone_OnPhoneNotify(string message)
        {
            if (message.Contains("Registred As:"))
            {
                message = message.Replace("Registered As:", "Giriş yapıldı:");
                displayNotifyMsg(message);
            }

            //displayNotifyMsg(message);
            ////"Redirect Success. Connection: x";
            ////"Redirect Failure. Connection: x Status y";
            //Match match = Regex.Match(message, @"Redirect.*Connection: \d+");
            //if (match.Success)
            //{
            //    string connIdStr = Regex.Match(match.Value, @"\d+").Value;
            //    AbtoPhone.HangUp(int.Parse(connIdStr));
            //}
        }
        private void AbtoPhone_OnRemoteAlerting2(int ConnectionId, int lineid, int responseCode, string reasonMsg)
        {
            string str = ""; //"Remote alerting: " + responseCode.ToString() + " " + reasonMsg;

            if (responseCode.ToString().Contains("100"))
            {
                str = "Deniyor...";
            }
            else if (responseCode.ToString().Contains("180"))
            {
                str = "Çalıyor...";
            }

            displayNotifyMsg(str);
        }


        void AbtoPhone_OnSubscribeStatus(int subscriptionId, int statusCode, string statusMsg)

        {
            //string str = string.Format("OnVoiceMail: Not supported. StatusCode: {0}", statusCode);
            //displayNotifyMsg(str);
            displayNotifyMsg("Durum Kodu: " + statusCode);
        }

        void AbtoPhone_OnSubscriptionNotify(int subscriptionId, string StateStr, string NotifyStr)
        {
            string str = ""; //string.Format("OnVoiceMail: {0}", StateStr);
            if (StateStr.Contains("Available"))
            {
                displayNotifyMsg("Abone Çevrimiçi");
            }
        }


        private void lineBtn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int lineId = (int)b.Tag;

            AbtoPhone.SetCurrentLine(lineId);

        }
        private void HighlightCurLine(int prevCurLine, int newCurLine)
        {
            Button prevBut = getLineButton(prevCurLine);
            Button newBut = getLineButton(newCurLine);

            prevBut.Font = new Font(prevBut.Font.FontFamily, prevBut.Font.Size, prevBut.Font.Style ^ FontStyle.Bold);
            newBut.Font = new Font(newBut.Font.FontFamily, newBut.Font.Size, newBut.Font.Style | FontStyle.Bold);
        }

        private Button getLineButton(int lineId)
        {
            switch (lineId)
            {
                case 1: return buttonLine1;
                case 2: return buttonLine2;
                case 3: return buttonLine3;
            }
            return buttonLine1;
        }


        private void DisplayConnectionsAll(LineInfo lnInfo)
        {
            activeConnListbox.Items.Clear();
            foreach (ConnectionInfo it in lnInfo.m_conn) DisplayConnection(it);
        }

        private LineInfo GetLine(int lineId)
        {
            return (LineInfo)m_lineConnections[lineId - 1];
        }

        private void startCallDurationTimer(LineInfo lnInfo)
        {
            if (lnInfo.m_callDurationTimer == null)
            {
                lnInfo.m_callDurationTimer = new System.Windows.Forms.Timer();
                lnInfo.m_callDurationTimer.Tick += new EventHandler(OnCallDurationTimerEvent);
                lnInfo.m_callDurationTimer.Tag = lnInfo.m_id;
                lnInfo.m_callDurationTimer.Interval = 1000;
            }

            lnInfo.m_callTime = new TimeSpan(0, 0, 0);
            lnInfo.m_callTimeStr = "Çağrı Süresi: 00:00:00";

            lnInfo.m_callDurationTimer.Start();
        }


        private void ChageLineCaption(LineInfo li)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Line");
            sb.Append(li.m_id);
            //if (li.m_bCallEstablished) sb.Insert(0, "[x]");


            if (li.m_bCallEstablished)
            {

                getLineButton(li.m_id).BackColor = Color.Red;
            }
            else
            {

                getLineButton(li.m_id).BackColor = SystemColors.Control;

            }

            //getLineButton(li.m_id).Text = sb.ToString();

        }


        private void DisplayConnection(ConnectionInfo ci)
        {
            int itemIndex = activeConnListbox.Items.Add(new ConnListBoxItem(ci.Key, ci.Value));
            activeConnListbox.SelectedIndex = itemIndex;
        }


        private void RemoveConnection(int connectionId)
        {
            foreach (ConnListBoxItem t in activeConnListbox.Items)
            {
                if (t.handle == connectionId) { activeConnListbox.Items.Remove(t); break; }
            }

            int count = activeConnListbox.Items.Count;
            if (count >= 1) activeConnListbox.SelectedIndex = count - 1;
        }



        private void OnCallDurationTimerEvent(object sender, EventArgs e)
        {
            //Get timer
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
            if (sender == null) return;
            int lineId = (int)timer.Tag;

            //Get line info
            LineInfo lnInfo = GetLine(lineId);
            if (lnInfo == null) return;

            //Increment duration
            lnInfo.m_callTime = lnInfo.m_callTime.Add(new TimeSpan(0, 0, 1));
            lnInfo.m_callTimeStr = "Çağrı Süresi: " + lnInfo.m_callTime.ToString();

            //Display current duration
            if (lineId == m_curLineId) callDurationLabel.Text = lnInfo.m_callTimeStr;
        }
        public class ConnListBoxItem
        {
            public int handle;
            public string connection;

            public ConnListBoxItem(int _handle, string _connection)
            {
                handle = _handle;
                connection = _connection;
            }

            public override string ToString()
            {
                return this.connection;
            }
        }

        private void btn_aktar_Click(object sender, EventArgs e)
        {
            //Get transfer addr
            TransferAddrForm dlg = new TransferAddrForm();
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            //Transfer call
            AbtoPhone.TransferCall(dlg.cmb_kulid.EditValue.ToString());
        }

        private void btn_konferans_Click(object sender, EventArgs e)
        {

            //Get line Id
            JoinForm dlg = new JoinForm();
            dlg.m_curLineId = m_curLineId;
            dlg.m_selLineId = 0;
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            //Check same line
            if (dlg.m_selLineId == m_curLineId) return;

            //Check selected line
            LineInfo selLineInfo = GetLine(dlg.m_selLineId);
            LineInfo curLineInfo = GetCurLine();
            if (!selLineInfo.m_bCallEstablished) return;

            //Append
            foreach (ConnectionInfo it in selLineInfo.m_conn) curLineInfo.m_conn.Add(it.Key, it.Value);
            selLineInfo.m_conn.Clear();

            //Displ
            DisplayConnectionsAll(curLineInfo);

            //Join
            AbtoPhone.JoinToCurrentCall(dlg.m_selLineId);
        }

        private void btn_beklet_al_Click(object sender, EventArgs e)
        {
            LineInfo lnInfo = GetCurLine();

            //Hold/retrieve
            AbtoPhone.HoldRetrieveCall(lnInfo.m_id);
            //Thread.Sleep(5000);
            //Change button caption
            //btn_beklet_al.Text = lnInfo.m_bCallHeld ? "Hold" : "Retrieve";

            if (lnInfo.m_bCallHeld)
            {
                btn_beklet_al.Image = CallCenter.Properties.Resources.ico_beklet;

            }
            else
            {
                btn_beklet_al.Image = CallCenter.Properties.Resources.ico_hattaal;
            }

            //Change flag
            lnInfo.m_bCallHeld = !lnInfo.m_bCallHeld;
        }

        private void btn_ara_kapat_Click(object sender, EventArgs e)
        {
            arakapat("");
        }

        void arakapat(string aranacakno) //aranacak no dolu ise;iç haberleşmeden gelen tel no dur yoksa istekten dir.
        {
            LineInfo lnInfo = GetCurLine();

            if (lnInfo.m_bCallEstablished || lnInfo.m_bCalling)
            {
                //HangUp
                int connectionId;
                if (GetSelectedConnection(out connectionId) == true) AbtoPhone.HangUp(connectionId);
                else AbtoPhone.HangUpLastCall();
            }
            else
            {

                //Get addr
                string address ="0" + lbl_telno.Text;
                if (aranacakno != "")
                {
                    address = aranacakno;
                }

                if (address.Length == 0) return;

                ////Append addr to combo
                //int idx = AddressBox.FindString(address, -1);
                //if (idx == -1) AddressBox.Items.Add(address);

                //Set status
                displayNotifyMsg("Arıyor..."); //Calling

                //Set flag, Cange controls state
                lnInfo.m_bCalling = true;
                ChageControlsState(lnInfo);

                //Start call without video
                //AbtoPhone.Config.VideoCallEnabled = 0;
                //AbtoPhone.ApplyConfig();

                //Start call and get assigned connectionId
                int connId = AbtoPhone.StartCall2(address);
                if (address == "0" + lbl_telno.Text)
                {
                    cag_conid = connId;
                }
            }

        }
        private void btn_backspace_Click(object sender, EventArgs e)
        {
            if (lbl_telno.Text.Length != 0)
            {
                lbl_telno.Text = lbl_telno.Text.Substring(0, lbl_telno.Text.Length - 1);
            }
            //txt_telno.Text = lbl_telno.Text;
        }

        private void lbl_telno_TextChanged(object sender, EventArgs e)
        {
            txt_telno.Text = lbl_telno.Text;
        }

        private void btn_sesayarlari_Click(object sender, EventArgs e)
        {
            //hatdurumlari();
            //SesAyarlari sesayar = new SesAyarlari();
            //sesayar.ShowDialog();



            //Get cfg values
            CConfig phoneCfg = AbtoPhone.Config;

            //Create and show dlg
            SesAyarlari cfgDlg = new SesAyarlari();
            cfgDlg.phoneCfg = phoneCfg;

            if (cfgDlg.ShowDialog(this) != DialogResult.OK)
            {
                AbtoPhone.CancelConfig();
                return;
            }

            //Apply new values
            AbtoPhone.ApplyConfig();

            //Store
            //phoneCfg.Store(cfgFileName);            
        }

        private void btn_icerdecagri_Click(object sender, EventArgs e)
        {
            LineInfo lnInfo = GetCurLine();
            TimeSpan x = lnInfo.m_callTime;

            if (lnInfo.m_bCallEstablished || lnInfo.m_bCalling)
            {
                MessageBox.Show("Hattasınız,Devam etmek istiyorsanız boş bir hatta geçiniz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IcerdeCagri dlg = new CallCenter.IcerdeCagri();
            if (dlg.ShowDialog(this) != DialogResult.OK) return;
            
            //txt_telno.ReadOnly = true;
            //txt_telno.Text = dlg.cmb_kulid.EditValue.ToString();
            //lbl_telno.Text = dlg.cmb_kulid.EditValue.ToString();

            arakapat(dlg.cmb_kulid.EditValue.ToString());
        }


        private void AbtoPhone_OnEstablishedConnection(string addrFrom, string addrTo, int connectionId, int lineId)
        {
            LineInfo lnInfo = GetLine(lineId);
            string addr = lnInfo.m_bCalling ? addrTo : addrFrom;
            lnInfo.m_conn.Add(connectionId, addr);
            lnInfo.m_lastConnId = connectionId;

            if (lineId == m_curLineId) DisplayConnection(new ConnectionInfo(connectionId, addr));

            #region ek_estcon
            //string arananno = addrTo.Substring(addrTo.IndexOf("sip:"), addrTo.IndexOf("@") - addrTo.IndexOf("sip:")).Replace("sip:", "");
            //if (arananno == lbl_telno.Text && lbl_telno.Text !="") //EĞER BAĞLANTI BAŞLAYAN TEL NO İSTEKTEKİ NO/KAYDETDEAMETTEN GİRİLEN NO İSE
            if (cag_conid != 0 && cag_conid == connectionId)
            {
                cag_baslama = tarihsaatgetir();
            }
            #endregion ek_estcon
        }
        private void AbtoPhone_OnEstablishedCall(string adress, int lineId)
        {
            //Update line state
            LineInfo lnInfo = GetLine(lineId);
            lnInfo.m_usrInputStr = "";
            lnInfo.m_bCallEstablished = true;
            lnInfo.m_bCalling = false;

            //Start call duration timer
            startCallDurationTimer(lnInfo);

            //Update controls (only when it's cur line event)
            if (lineId == m_curLineId)
            {
                //Display status
                //displayNotifyMsg(adress);
                if (adress.Contains("Call Established on Line"))
                {
                    displayNotifyMsg("Çağrı başladı. Hat-" + lineId.ToString());
                }

                //Cange controls state
                ChageControlsState(lnInfo);
            }
            else
            {
                ChageLineCaption(lnInfo);
            }
        }

        private void AbtoPhone_OnClearedConnection(int connectionId, int lineId)
        {
            LineInfo lnInfo = GetLine(lineId);
            #region ek_clrcon
            if (connectionId == cag_conid && cag_conid != 0)
            {
                cag_lineid = lineId; //bu atamayı establishedcon da değil burada yapıyor olmamın sebebi; başka bir hattaki arama kapanınca da buraya düşme ihtimali(aslında bu ihtimal yok galiba) ya da join var ise diğer arama kapanınca call olayında bu çağrı kapanmış gibi olmasın diye.
                //yani cag_lineid sadece OnClearedConnection ve OnClearedCall arasında hareket eder. OnClearedConnection'da değer alıp OnClearedCall da kontrol edilerek sıfırlanır.
                //bu call olayı benim çağrımın call olayı demek için burada atama yapıyorum. connectionid den takip edersem doğru sonuç verir, sadce lineid den takip edersem join vb de doğru sonuç vermez.
            }
            #endregion ek_clrcon

            lnInfo.m_conn.Remove(connectionId);
            lnInfo.m_lastConnId = 0;
            if (lineId == m_curLineId) RemoveConnection(connectionId);
        }

        private void AbtoPhone_OnClearedCall(string Msg, int status, int lineId)
        {
            //Update line state
            LineInfo lnInfo = GetLine(lineId);
            lnInfo.m_usrInputStr = "";
            lnInfo.m_bCallEstablished = false;
            lnInfo.m_bCalling = false;
            lnInfo.m_callTimeStr = "";
            if (lnInfo.m_callDurationTimer != null) lnInfo.m_callDurationTimer.Stop();


            #region ek_clrcall
            if (cag_lineid == lineId && cag_lineid != 0)
            {
                cag_bitis = tarihsaatgetir();
                cag_sure = lnInfo.m_callTime;
                cag_cikiskodu = cihazkodugetir(status);
            }
            cag_lineid = 0;
            lnInfo.m_callTime = new TimeSpan(0, 0, 0); //kendisi sıfırlamıyor, ben sıfırladım. diğer çağrı başarısız ise eski çağrının sn sini almamak için.
            #endregion ek_clrcall

            //Update controls (only when it's cur line event)
            if (lineId == m_curLineId)
            {
                //Display status
                //displayNotifyMsg(Msg + ". Status: " + status.ToString());                
                displayNotifyMsg(cihazkodugetir(status) + ". Hat-" + m_curLineId.ToString());

                //Cange controls state
                ChageControlsState(lnInfo);
            }
            else
            {
                ChageLineCaption(lnInfo);
            }

            //MessageBox.Show("clearedCall");

        }

        public string cihazkodugetir(int status)
        {
            switch (status)
            {
                case 0: msj = "0-Konuşma bitti"; break;
                case 400: msj = "400-Geçersiz istek"; break; //Bad request
                case 401: msj = "401-Yetki yok"; break; //Unauthorized
                case 402: msj = "402-Ödeme gerekli"; break; // Payment required 
                case 403: msj = "403-Yasak"; break; //Forbidden
                case 404: msj = "404-Bulunamadı"; break; //
                case 405: msj = "405-İzin verilmeyen yöntem"; break; //Method not allowed
                case 406: msj = "406-Kabul edilemez"; break; //Not acceptable
                case 407: msj = "407-Proxy Kimlik Doğrulaması gerekli"; break; //Proxy Authentication required
                case 408: msj = "408-İstek zaman aşımına uğradı"; break; //Request timeout
                case 410: msj = "410-Gitti"; break; //Gone
                case 413: msj = "413-Girilen veri çok fazla"; break; //Request entity too large
                case 414: msj = "414-İstek-URI çok uzun"; break; //Request - URI too long
                case 415: msj = "415-Desteklenmeyen medya türü"; break; //Unsupported media type
                case 416: msj = "416-Desteklenmeyen URI şeması"; break; //Unsupported URI scheme
                case 420: msj = "420-Geçersiz uzantı"; break; //Bad extension
                case 421: msj = "421-Uzantı gerekli"; break; //Extension required
                case 423: msj = "423-Aralık çok kısa"; break; //Interval too brief
                case 480: msj = "480-Geçici olarak kullanım dışı"; break; //Temporarily unavailable
                case 481: msj = "481-Çağrı/İşlem mevcut değil"; break; //Call / transaction does not exist
                case 482: msj = "482-Döngü algılandı"; break; //Loop detected
                case 483: msj = "483-Çok fazla sekme"; break; //Too many hops
                case 484: msj = "484-Adres eksik"; break; //Address incomplete
                case 485: msj = "485-Belirsiz"; break; //Ambiguous
                case 486: msj = "486-Meşgul"; break; //Busy here
                case 487: msj = "487-İstek sonlandırıldı"; break; //Request terminated
                case 488: msj = "488-Kabul edilemez"; break; //Not Acceptable Here
                case 500: msj = "500-Sunucu iç hatası"; break; //Server internal error
                case 501: msj = "501-Uygulanmadı"; break; //Not implemented
                case 502: msj = "502-Kötü ağ geçidi"; break; //Bad gateway
                case 503: msj = "503-Hizmet kullanılamıyor"; break; //Service unavailable
                case 504: msj = "504-Ağ Geçidi zaman aşımı"; break; //Gateway time-out
                case 505: msj = "505-Sürüm desteklenmiyor"; break; //Version not supported
                case 513: msj = "513-Mesaj çok büyük"; break; //Message too large
                case 600: msj = "600-Her yer meşgul"; break; //Busy everywhere
                case 603: msj = "603-Düşüş"; break; //Decline
                case 604: msj = "604-Hiçbir yerde yok"; break; //Does not exist anywhere
                case 606: msj = "606-Kabul edilemez"; break; //Not acceptable
                default: msj = "Bilinmeyen hata"; break;
            }

            return msj;
        }

        void hatdurumlari()
        {
            int x = m_curLineId; //aktif hat id si(1-2-3)
            foreach (LineInfo item in m_lineConnections) //m_lineconnections: 3 hattı tutan array
            {
                foreach (var item2 in item.m_conn) //m_conn: hangi hat aktif ise onunn connectionları "ConnectionsTbl" tipinde. Join ise birden fazla connection vardır. getselectedconnection() aktif hattın, seçili conidsini "connectionId"'ye atar.
                {
                    int kk = item2.Key;
                    string deger = item2.Value; //sip:302@10.0.0.12 vb
                }
            }

            //return;
            //////////////

            LineInfo a1 = (LineInfo)m_lineConnections[0];
            int s1 = a1.m_conn.Keys.Count();

            LineInfo a2 = (LineInfo)m_lineConnections[1];
            int s2 = a2.m_conn.Keys.Count();

            LineInfo a3 = (LineInfo)m_lineConnections[2];
            int s3 = a3.m_conn.Keys.Count();


            foreach (var item in a3.m_conn) //m_conn: hangi hat aktif ise onunn connectionları "ConnectionsTbl" tipinde. Join ise birden fazla connection vardır. getselectedconnection() aktif hattın, seçili conidsini "connectionId"'ye atar.
            {
                int kk = item.Key;
                string deger = item.Value; //sip:302@10.0.0.12 vb
            }
            return;
            //////////////

            // int x = AbtoPhone.Subscriptions.SubscribePresence("10@10.0.0.12");

            //int y = AbtoPhone.Subscriptions.SubscribePresence("304@10.0.0.13");
            //AbtoPhone.Subscriptions.

            //AbtoPhone.IsLineOccupied(3);
            //AbtoPhone.IsPhoneBusy();

            //MessageBox.Show(x.ToString() );
            //MessageBox.Show(AbtoPhone.Subscriptions.SubscribePresence("304").ToString());

            //AbtoPhone.Subscriptions.UnSubscribePresence 
            //AbtoPhone.Subscriptions.subsc
        }

        private void timer_randevu_Tick(object sender, EventArgs e)
        {
            if (msjkontrolet == true)
            {
                mesajvarmi();
            }
            randevuvarmi();
        }

        void randevuvarmi()
        {
            DateTime simdi = tarihsaatgetir();
            DateTime yaklasansaat = simdi.AddMinutes(yaklasanrandevudk); //genel ayarlardan tanımlanan yaklaşan dk kalan lardaki randevuları da listeye almak için
            bekleyenrandevular = (from p in veri.RANDEVULAR_TBL where p.RAN_KAPANMA == null && p.RAN_BASLAMATARIH <= yaklasansaat && p.RAN_KUL_ID == userid select p).OrderBy(t => t.RAN_BASLAMATARIH).ToList();

            if (bekleyenrandevular.Count > 0)
            {
                if (btn_randevuvar.Text != bekleyenrandevular.Count.ToString())
                {
                    try
                    {
                        SoundPlayer player = new SoundPlayer();
                        string path = Application.StartupPath + "\\notify.wav"; // Çalmasini istediginiz ses dosyasinin yolu
                        player.SoundLocation = path;
                        player.Play();
                    }
                    catch (Exception)
                    {
                    }
                }

                btn_randevuvar.Visible = true;
                if (btn_randevuvar.Text != bekleyenrandevular.Count.ToString())
                {
                    gecikenran = bekleyenrandevular.Where(p => p.RAN_BASLAMATARIH <= simdi).ToList().Count();
                    yaklasanran = bekleyenrandevular.Where(p => p.RAN_BASLAMATARIH > simdi && p.RAN_BASLAMATARIH <= yaklasansaat).ToList().Count();

                    msj = gecikenran.ToString() + " Geciken randevunuz, " + Environment.NewLine + yaklasanran.ToString() + " Yaklaşan randevunuz var";
                    if (gecikenran == 0)
                    {
                        msj = yaklasanran.ToString() + " Yaklaşan randevunuz var";
                    }
                    if (yaklasanran == 0)
                    {
                        msj = gecikenran.ToString() + " Geciken randevunuz var";
                    }

                    alertControl_Randevu.Show(this, "Hatırlatma", msj, Properties.Resources.AlarmClock48);
                    btn_randevuvar.Text = bekleyenrandevular.Count.ToString();
                }
            }
            else
            {
                btn_randevuvar.Text = "";
                btn_randevuvar.Visible = false;
            }
        }

        private void btn_randevuvar_Click(object sender, EventArgs e)
        {
            bekleyenrandevularlistele(true);
        }

        private void alertControl_Randevu_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            bekleyenrandevularlistele(true);
        }

        void bekleyenrandevularlistele(bool alarm)
        {   
            //btn_randevuvar.Visible true ise geciken/yaklaşan randevu vardır.
            RandevularBekleyen ranbek = new CallCenter.RandevularBekleyen(alarm);
            ranbek.ShowDialog();
            if (ran_id != 0)  //ordan ara butonuna bastıysa
            {
                istekgetir();
                notificationsListBox.Items.Add(msj);
            }
        }
                
        private void alertControl_Mesaj_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            mesajac();
        }

        private void btn_yaklasanrandevularim_Click(object sender, EventArgs e)
        {
            bekleyenrandevularlistele(false );
        }
        //public class baglantilar
        //{
        //    public int conid { get; set; }
        //    public int lineid { get; set; }
        //    public string fromadress { get; set; }
        //    public string toadress { get; set; }
        //    public string statuscode { get; set; }
        //    public Nullable<TimeSpan>  sure { get; set; }
        //}

        //List<baglantilar> aktifbaglantilarim = new List<baglantilar>();
        ////
        //CallCenter.AnaForm.baglantilar bag = new CallCenter.AnaForm.baglantilar();
        //bag.conid = connectionId;
        //    bag.lineid = lineId;
        //    bag.fromadress = addrFrom.Substring(addrFrom.IndexOf("sip:"), addrFrom.IndexOf("@") - addrFrom.IndexOf("sip:")).Replace("sip:", "");
        //bag.toadress = addrTo.Substring(addrTo.IndexOf("sip:"), addrTo.IndexOf("@") - addrTo.IndexOf("sip:")).Replace("sip:", "");
        //bag.sure = null;
        //    bag.statuscode = "";
        //    aktifbaglantilarim.Add(bag);

        public static void logkaydet(string islem,string islemdetay)
        {
            CallCenterEntities veri = new CallCenter.CallCenterEntities();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            LOG_TBL kayit;
            kayit = new LOG_TBL();
            kayit.LG_KUL_ID = AnaForm.userid;
            kayit.LG_TARIH = AnaForm.tarihsaatgetir(); //DateTime.Now;
            kayit.LG_ISLEM = islem;
            kayit.LG_ISLEMDETAY = islemdetay ;
            veri.LOG_TBL.Add(kayit);
            veri.SaveChanges();

        }

        void bagimsizcagrigetir()
        {
            //telnoyu texte eşitle
            using (conn = new NpgsqlConnection(AnaForm.cstr))
            {
                conn.Open();
                //  \"CAG_CAL_ID\" = " + AnaForm.cal_id + "  and kaldırdım?
                grd_aramalist.DataSource = conn.Query<CAGRIDETAYLAR_V>("select * from public.\"CAGRIDETAYLAR_V\" WHERE ( \"CAG_TELNO\" = '" + txt_telara.Text + "') ORDER BY \"CAG_TARIH\" DESC").ToList();
            }

            txt_telara.Text = txt_telara.Text.Trim();

        }

        private void txt_telara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bagimsizcagrigetir();
                
            }
        }

        private void txt_telara_KeyUp(object sender, KeyEventArgs e)
        {

        }


        //private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        bagimsizcagrigetir();
        //    }

        //}

    }
}
