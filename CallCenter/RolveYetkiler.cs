using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Sql;


namespace CallCenter
{
    public partial class RolveYetkiler : Form
    {
        CallCenterEntities veri = new CallCenterEntities();
        List<YETKIACIKLAMALAR_TBL> yetkiaciklama;
        int rolid = 0;

        int secilensira = 0;
        ///hiyerarşiyi kaldır:
        //int oncekisira = 0;
        //List<YETKILER_TBL> oncekiyetkiler;
        ///hiyerarşiyi kaldır.
        List<YETKILER_TBL> yetkiler;

        public RolveYetkiler()
        {
            InitializeComponent();
            veri.Database.Connection.ConnectionString = AnaForm.cstr;

            ///hiyerarşiyi kaldır:
            btn_up.Visible = false;
            btn_down.Visible = false;
            grdview_list.Columns["ROL_SIRA"].Visible = false;
            ///hiyerarşiyi kaldır.
            ///
            listele();

            yetkiaciklama = (from p in veri.YETKIACIKLAMALAR_TBL select p).ToList();
            tl_yetkiler.ExpandAll();
        }

        void listele() //ROLLER_TBL yi listeler
        {
            var sonuc = (from p in veri.ROLLER_TBL select p).OrderBy(p => p.ROL_SIRA).ToList();
            grd_list.DataSource = sonuc;
        }

        void temizle() //formu temizler.
        {
            rolid = 0;
            txt_roladi.Text = "";
            txt_aciklama.Text = "";
            txt_rolsira.Text = "";
            chk_aktif.Checked = false;
            txt_roladi.Focus();
        }
        private void button_duzenle_Click(object sender, EventArgs e) //ROLLER_TBL deki kaydı görüntüler
        {
            if (grdview_list.GetFocusedRow() == null) return;

            rolid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("ROL_ID"));
            txt_roladi.Text = grdview_list.GetFocusedRowCellValue("ROL_ADI").ToString();
            txt_aciklama.Text = grdview_list.GetFocusedRowCellValue("ROL_ACIKLAMA").ToString();
            chk_aktif.Checked = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("ROL_AKTIF"));
            //txt_rolsira.Text = grdview_list.GetFocusedRowCellValue("ROL_SIRA").ToString();

            switch (grdview_list.GetFocusedRowCellValue("ROL_ANAROL").ToString())
            {
                case "Admin":
                    rd_admin.Checked = true;
                    break;
                case "Şef":
                    rd_sef.Checked = true;
                    break;
                case "Operatör":
                    rd_operator.Checked = true;
                    break;
                case "Diğer":
                    rd_diger.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void button_sil_Click(object sender, EventArgs e) // ROLLER_TBL den kayıt siler. 
        {
            if (grdview_list.GetFocusedRow() == null) return;
            
            
            
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.No)
            {
                return;
            }





            try
            {
                string roladi = Convert.ToString(grdview_list.GetFocusedRowCellValue("ROL_ADI"));                
                int rolsirano = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("ROL_SIRA"));
                rolid = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("ROL_ID"));

                if (Convert.ToString(grdview_list.GetFocusedRowCellValue("ROL_ANAROL")) == "Admin")
                {
                    int adminroller = (from p in veri.ROLLER_TBL where p.ROL_ANAROL == "Admin" && p.ROL_ID != rolid select p).Count();
                    if (adminroller == 0) //silmek istediği admin anarolünden başka, admin anarolü yok.
                    {
                        MessageBox.Show("En az bir Admin Ana Rolü olmalı, bu yüzden silinemez...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                var kullanicivarmi = (from p in veri.KULLANICILAR_TBL where p.KUL_ROL_ID  == rolid select p).SingleOrDefault();
                if (kullanicivarmi != null)
                {
                    MessageBox.Show("Bu rolde tanımlı kullanıcı(lar) bulunmakta, rol silinemez");
                    return;
                }

                    

                var kayit = (from p in veri.ROLLER_TBL where p.ROL_ID == rolid select p).SingleOrDefault();
                if (kayit != null)
                {
                    veri.ROLLER_TBL.Remove(kayit);
                    veri.SaveChanges();
                }

                var yetki = (from p in veri.YETKILER_TBL  where p.YET_ROLSIRANO == rolsirano select p).SingleOrDefault();
                if (yetki != null)
                {
                    veri.YETKILER_TBL.Remove(yetki);
                    veri.SaveChanges();
                }

                MessageBox.Show("Silindi");
                AnaForm.logkaydet("Rol", "Silme (" + roladi  +")");

                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinemedi, Hata:" + ex.Message);
            }
        }
        


        private void btn_kaydet_Click(object sender, EventArgs e)  // ROLLER_TBL ye kayıt atar ya da günceller. 
        {
            

            if (txt_roladi.Text == "")
            {
                MessageBox.Show("Lütfen Rol belirtiniz");
                txt_roladi.Focus();
                return;
            }

            //if (txt_rolsira.Text == "")
            //{
            //    MessageBox.Show("Lütfen Rol hiyerarşisi belirtiniz");
            //    txt_rolsira.Focus();
            //    return;
            //}

            //int rolsira = Convert.ToInt16(txt_rolsira.Text);
            //var varmi = (from p in veri.ROLLER_TBL where p.ROL_SIRA == rolsira && p.ROL_ID != rolid select p).ToList();
            //if (varmi.Count > 0)
            //{
            //    MessageBox.Show("Sıra No kullanımda, lütfen düzeltiniz");
            //    return;
            //}

            var varmiad = (from p in veri.ROLLER_TBL where p.ROL_ADI == txt_roladi.Text && p.ROL_ID != rolid select p).ToList();
            if (varmiad.Count() > 0)
            {
                MessageBox.Show("Bu rol kullanımda, lütfen düzeltiniz");
                return;
            }

            try
            {
                string islem;
                string anarol = "Diğer";

                if (rd_admin.Checked == true)
                {
                    anarol = "Admin";
                }
                else if (rd_sef.Checked)
                {
                    anarol = "Şef";
                }
                else if (rd_operator.Checked)
                {
                    anarol = "Operatör";
                }

                var kayit = (from p in veri.ROLLER_TBL where p.ROL_ID == rolid select p).SingleOrDefault();
                if (kayit == null)
                {
                    islem = "Ekleme ";          
                    int sonno = (from p in veri.ROLLER_TBL select p.ROL_SIRA).Max();

                    ROLLER_TBL satir = new ROLLER_TBL();
                    satir.ROL_ADI = txt_roladi.Text;
                    satir.ROL_ACIKLAMA = txt_aciklama.Text;
                    satir.ROL_SIRA = Convert.ToInt16(sonno + 1); //Convert.ToInt16(txt_rolsira.Text);
                    satir.ROL_AKTIF = chk_aktif.Checked;
                    satir.ROL_ANAROL = anarol;
                    veri.ROLLER_TBL.Add(satir);

                    

                    ///hiyerarşiyi kaldır: oncekiyetkiler = (from p in veri.YETKILER_TBL where p.YET_ROLSIRANO == sonno select p).ToList();
                    ///aşağısı da defaultta tüm yetkileri sıfır verir, gridte üzerine gelince yetkileri kullanıcı seçer.
                    YETKILER_TBL yetkiekle = new YETKILER_TBL();
                    yetkiekle.YET_ROLSIRANO = Convert.ToInt16(sonno + 1);
                    yetkiekle.Y_YONETIM = false; //oncekiyetkiler[0].Y_YONETIM.Value;
                    yetkiekle.Y_GENELAYARLAR = false; // oncekiyetkiler[0].Y_GENELAYARLAR.Value;
                    yetkiekle.Y_RANDEVUDURUMLARI = false; //oncekiyetkiler[0].Y_RANDEVUDURUMLARI.Value;
                    yetkiekle.Y_CIKISKODLARI = false; //oncekiyetkiler[0].Y_CIKISKODLARI.Value;
                    yetkiekle.Y_GENELTAKVIM = false; //oncekiyetkiler[0].Y_GENELTAKVIM.Value;
                    yetkiekle.Y_CALISMALAR = false; //oncekiyetkiler[0].Y_CALISMALAR.Value;
                    yetkiekle.Y_CALISMAISLEMLERI = false; //oncekiyetkiler[0].Y_CALISMAISLEMLERI.Value;
                    yetkiekle.Y_ROLVEYETKILER = false; //oncekiyetkiler[0].Y_ROLVEYETKILER.Value;
                    yetkiekle.Y_KULLANICILAR = false; //oncekiyetkiler[0].Y_KULLANICILAR.Value;
                    yetkiekle.Y_KULLANICICALISMALARI = false; //oncekiyetkiler[0].Y_KULLANICICALISMALARI.Value;
                    yetkiekle.Y_SSS = false; //oncekiyetkiler[0].Y_SSS.Value;
                    yetkiekle.Y_FORUMISLEMLERI = false; //oncekiyetkiler[0].Y_FORUMISLEMLERI.Value;
                    yetkiekle.Y_ISTEKEKLEADMIN = false; //oncekiyetkiler[0].Y_ISTEKEKLEADMIN.Value;
                    yetkiekle.Y_RANDEVUAKTAR = false; //oncekiyetkiler[0].Y_RANDEVUAKTAR.Value;
                    yetkiekle.Y_RAPOR = false; //oncekiyetkiler[0].Y_RAPOR.Value;
                    yetkiekle.Y_RANDEVULAR = false; //oncekiyetkiler[0].Y_RANDEVULAR.Value;
                    yetkiekle.Y_CAGRILAR = false; //oncekiyetkiler[0].Y_CAGRILAR.Value;
                    yetkiekle.Y_SESKAYDIBUL = false; //oncekiyetkiler[0].Y_SESKAYDIBUL.Value;
                    yetkiekle.Y_SESDINLE = false; //oncekiyetkiler[0].Y_SESDINLE.Value;
                    yetkiekle.Y_SESDISAAKTAR = false; //oncekiyetkiler[0].Y_SESDISAAKTAR.Value;
                    yetkiekle.Y_ISTEKLER = false; //oncekiyetkiler[0].Y_ISTEKLER.Value;
                    yetkiekle.Y_LOGLAR = false; //oncekiyetkiler[0].Y_LOGLAR.Value;
                    yetkiekle.Y_KULLANICIIZLE = false; //oncekiyetkiler[0].Y_KULLANICIIZLE.Value;
                    yetkiekle.Y_OPERATOR = false; //oncekiyetkiler[0].Y_OPERATOR.Value;
                    yetkiekle.Y_RANDEVULARIM = false; //oncekiyetkiler[0].Y_RANDEVULARIM.Value;
                    yetkiekle.Y_CAGRILARIM = false; //oncekiyetkiler[0].Y_CAGRILARIM.Value;
                    yetkiekle.Y_MESAJLARIM = false; //oncekiyetkiler[0].Y_MESAJLARIM.Value;
                    yetkiekle.Y_FORUMKULLAN = false; //oncekiyetkiler[0].Y_FORUMKULLAN.Value;
                    yetkiekle.Y_YARDIM = false; //oncekiyetkiler[0].Y_YARDIM.Value;
                    yetkiekle.Y_ISTEKEKLEOPERATOR = false; //oncekiyetkiler[0].Y_ISTEKEKLEOPERATOR.Value;
                    yetkiekle.Y_CAGRIYAP = false; //oncekiyetkiler[0].Y_CAGRIYAP.Value;
                    yetkiekle.Y_RANDEVUOLUSTUR = false; //oncekiyetkiler[0].Y_RANDEVUOLUSTUR.Value;
                    yetkiekle.Y_BEKLEMEYEAL = false; //oncekiyetkiler[0].Y_BEKLEMEYEAL.Value;
                    yetkiekle.Y_AKTAR = false; //oncekiyetkiler[0].Y_AKTAR.Value;
                    veri.YETKILER_TBL.Add(yetkiekle);
                    //veri.SaveChanges();
                }
                else
                {
                    islem = "Güncelleme ";
                    kayit.ROL_ADI = txt_roladi.Text;
                    kayit.ROL_ACIKLAMA = txt_aciklama.Text;
                    kayit.ROL_AKTIF = chk_aktif.Checked;
                    kayit.ROL_ANAROL = anarol;
                    //kayit.ROL_SIRA = Convert.ToInt16(txt_rolsira.Text);
                }

                MessageBox.Show(veri.SaveChanges() > 0 ? "Kaydedildi" : "Değişiklik yok!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnaForm.logkaydet("Rol", islem + " (" + txt_roladi.Text +")" );

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_yeni_Click(object sender, EventArgs e) //formu temizler. 
        {
            temizle();
        }



        private void btn_yetkikaydet_Click(object sender, EventArgs e) // seçilen rolun yetkilerini günceller. 
        {

            if (grdview_list.GetFocusedRow() == null) return;

            //bool a = tl_yetkiler.NodesIterator.All.Where(t => Convert.ToString(t.Tag) == "Y_YONETIM").SingleOrDefault().Checked;

            var yetkiler = (from p in veri.YETKILER_TBL where p.YET_ROLSIRANO == secilensira select p).ToList();
            yetkiler[0].Y_YONETIM = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Yönetim").SingleOrDefault().Checked;
            yetkiler[0].Y_GENELAYARLAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Genel Ayarlar").SingleOrDefault().Checked;
            yetkiler[0].Y_RANDEVUDURUMLARI = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Randevu Durumları").SingleOrDefault().Checked;
            yetkiler[0].Y_CIKISKODLARI = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Çıkış Kodları (Ekle/Sil/Güncelle)").SingleOrDefault().Checked;
            yetkiler[0].Y_GENELTAKVIM = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Genel Çalışma Takvimi (Ekle/Sil/Güncelle)").SingleOrDefault().Checked;
            yetkiler[0].Y_CALISMALAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Çalışma İşlemleri(Ekle/Güncelle/Sil)").SingleOrDefault().Checked;
            yetkiler[0].Y_CALISMAISLEMLERI = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Çalışma İşlemleri(Aktif Periyot/Çıkış Kodları/Çalışma Aralıkları)").SingleOrDefault().Checked;
            yetkiler[0].Y_ROLVEYETKILER = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Rol ve Yetkiler(Ekle/Sil/Güncelle)").SingleOrDefault().Checked;
            yetkiler[0].Y_KULLANICILAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Kullanıcılar(Ekle/Sil/Güncelle)").SingleOrDefault().Checked;
            yetkiler[0].Y_KULLANICICALISMALARI = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Kullanıcı Çalışmaları Tanımlama").SingleOrDefault().Checked;
            yetkiler[0].Y_SSS = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Sık Sorulan Sorular(Ekle/Sil/Güncelle)").SingleOrDefault().Checked;
            yetkiler[0].Y_FORUMISLEMLERI = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Forum İşlemleri").SingleOrDefault().Checked;
            yetkiler[0].Y_ISTEKEKLEADMIN = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "İstek Ekle" && t.ParentNode.GetDisplayText(0) == "Yönetim").SingleOrDefault().Checked;
            yetkiler[0].Y_RANDEVUAKTAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Randevu Aktarma").SingleOrDefault().Checked;
            yetkiler[0].Y_RAPOR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Rapor").SingleOrDefault().Checked;
            yetkiler[0].Y_RANDEVULAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Randevu Raporu").SingleOrDefault().Checked;
            yetkiler[0].Y_CAGRILAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Çağrı Raporu").SingleOrDefault().Checked;
            yetkiler[0].Y_SESKAYDIBUL = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Ses Kayıtları Listele").SingleOrDefault().Checked;
            yetkiler[0].Y_SESDINLE = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Ses Kaydı Dinle").SingleOrDefault().Checked;
            yetkiler[0].Y_SESDISAAKTAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Ses Kaydı Dışa Aktar").SingleOrDefault().Checked;
            yetkiler[0].Y_ISTEKLER = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "İstek Raporu").SingleOrDefault().Checked;
            yetkiler[0].Y_LOGLAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Log Kayıtları").SingleOrDefault().Checked;
            yetkiler[0].Y_KULLANICIIZLE = false; //tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Kullanıcı İzleme").SingleOrDefault().Checked;
            yetkiler[0].Y_OPERATOR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Operatör İşlemleri").SingleOrDefault().Checked;
            yetkiler[0].Y_RANDEVULARIM = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Randevularım").SingleOrDefault().Checked;
            yetkiler[0].Y_CAGRILARIM = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Çağrılarım").SingleOrDefault().Checked;
            yetkiler[0].Y_MESAJLARIM = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Mesajlarım").SingleOrDefault().Checked;
            yetkiler[0].Y_FORUMKULLAN = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Forum").SingleOrDefault().Checked;
            yetkiler[0].Y_YARDIM = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Yardım").SingleOrDefault().Checked;
            yetkiler[0].Y_ISTEKEKLEOPERATOR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "İstek Ekle" && t.ParentNode.GetDisplayText(0) == "Operatör İşlemleri").SingleOrDefault().Checked;
            yetkiler[0].Y_CAGRIYAP = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Çağrı Yap").SingleOrDefault().Checked;
            yetkiler[0].Y_RANDEVUOLUSTUR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Randevu Oluştur").SingleOrDefault().Checked;
            yetkiler[0].Y_BEKLEMEYEAL = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Beklemeye Al").SingleOrDefault().Checked;
            yetkiler[0].Y_AKTAR = tl_yetkiler.NodesIterator.All.Where(t => t.GetDisplayText(0) == "Çağrıyı Aktar").SingleOrDefault().Checked;

            veri.SaveChanges();
            AnaForm.logkaydet("Yetki", "Düzenleme (" + Convert.ToString(grdview_list.GetFocusedRowCellValue("ROL_ADI")) +")");

            //****************
            ///hiyerarşiyi kaldır:
            //#region usteyansit
            //int sec_sira = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("ROL_SIRA"));            
            //if (sec_sira == (from p in veri.ROLLER_TBL select p.ROL_SIRA).Min())
            //{
            //    MessageBox.Show("Kaydedildi");
            //    return; //Seçilen Rol zaten en üst seviyede...
            //}
            //List<YETKILER_TBL> degisyetkiler = (from p in veri.YETKILER_TBL where p.YET_ROLSIRANO < sec_sira select p).ToList();
            //for (int i = 0; i < degisyetkiler.Count(); i++)
            //{
            //    int sira = Convert.ToInt32(degisyetkiler[i].YET_ROLSIRANO);
            //    var upd = (from p in veri.YETKILER_TBL where p.YET_ROLSIRANO == sira select p).ToList();
            //    foreach (var item in tl_yetkiler.GetAllCheckedNodes())
            //    {
            //        switch (item.GetDisplayText(0))
            //        {
            //            case "Operatör İşlemleri":
            //                upd[0].Y_OPERATOR = true;
            //                break;
            //            case "Çağrı Yap":
            //                upd[0].Y_CAGRIYAP = true;
            //                break;
            //            case "Randevu Oluştur":
            //                upd[0].Y_RANDEVUOLUSTUR = true;
            //                break;
            //            case "Beklemeye Al":
            //                upd[0].Y_BEKLEMEYEAL = true;
            //                break;
            //            case "Çağrıyı Aktar":
            //                upd[0].Y_AKTAR = true;
            //                break;
            //            case "Randevularım":
            //                upd[0].Y_RANDEVULARIM = true;
            //                break;
            //            case "Çağrılarım":
            //                upd[0].Y_CAGRILARIM = true;
            //                break;
            //            case "Mesajlarım":
            //                upd[0].Y_MESAJLARIM = true;
            //                break;
            //            case "Forum":
            //                upd[0].Y_FORUMKULLAN = true;
            //                break;
            //            case "Yardım":
            //                upd[0].Y_YARDIM = true;
            //                break;
            //            case "İstek Ekle":
            //                if (item.ParentNode.GetDisplayText(0) == "Operatör İşlemleri")
            //                {
            //                    upd[0].Y_ISTEKEKLEOPERATOR = true;
            //                }
            //                else if (item.ParentNode.GetDisplayText(0) == "Yönetim")
            //                {
            //                    upd[0].Y_ISTEKEKLEADMIN = true;
            //                }
            //                break;
            //            case "Rapor":
            //                upd[0].Y_RAPOR = true;
            //                break;
            //            case "Randevu Raporu":
            //                upd[0].Y_RANDEVULAR = true;
            //                break;
            //            case "Çağrı Raporu":
            //                upd[0].Y_CAGRILAR = true;
            //                break;
            //            case "Ses Kayıtları Listele":
            //                upd[0].Y_SESKAYDIBUL = true;
            //                break;
            //            case "Ses Kaydı Dinle":
            //                upd[0].Y_SESDINLE = true;
            //                break;
            //            case "Ses Kaydı Dışa Aktar":
            //                upd[0].Y_SESDISAAKTAR = true;
            //                break;
            //            case "İstek Raporu":
            //                upd[0].Y_ISTEKLER = true;
            //                break;
            //            case "Log Kayıtları":
            //                upd[0].Y_LOGLAR = true;
            //                break;
            //            case "Kullanıcı İzleme":
            //                upd[0].Y_KULLANICIIZLE = true;
            //                break;
            //            case "Yönetim":
            //                upd[0].Y_YONETIM = true;
            //                break;
            //            case "Genel Ayarlar":
            //                upd[0].Y_GENELAYARLAR = true;
            //                break;
            //            case "Randevu Durumları":
            //                upd[0].Y_RANDEVUDURUMLARI = true;
            //                break;
            //            case "Çıkış Kodları (Ekle/Sil/Güncelle)":
            //                upd[0].Y_CIKISKODLARI = true;
            //                break;
            //            case "Genel Çalışma Takvimi (Ekle/Sil/Güncelle)":
            //                upd[0].Y_GENELTAKVIM = true;
            //                break;
            //            case "Çalışma İşlemleri(Ekle/Güncelle/Sil)":
            //                upd[0].Y_CALISMALAR = true;
            //                break;
            //            case "Çalışma İşlemleri(Aktif Periyot/Çıkış Kodları/Çalışma Aralıkları)":
            //                upd[0].Y_CALISMAISLEMLERI = true;
            //                break;
            //            case "Rol ve Yetkiler(Ekle/Sil/Güncelle)":
            //                upd[0].Y_ROLVEYETKILER = true;
            //                break;
            //            case "Kullanıcılar(Ekle/Sil/Güncelle)":
            //                upd[0].Y_KULLANICILAR = true;
            //                break;
            //            case "Kullanıcı Çalışmaları Tanımlama":
            //                upd[0].Y_KULLANICICALISMALARI = true;
            //                break;
            //            case "Sık Sorulan Sorular(Ekle/Sil/Güncelle)":
            //                upd[0].Y_SSS = true;
            //                break;
            //            case "Forum İşlemleri":
            //                upd[0].Y_FORUMISLEMLERI = true;
            //                break;
            //            case "Randevu Aktarma":
            //                upd[0].Y_RANDEVUAKTAR = true;
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    veri.SaveChanges();
            //}
            //#endregion usteyansit
            ///hiyerarşiyi kaldır.
            ///
            MessageBox.Show("Kaydedildi");
            //****************
        }


        private void tl_yetkiler_MouseClick(object sender, MouseEventArgs e) // başlığı seçilen yetkinin alt başlıkları da seçilir 
        {            

            TreeList treeList = sender as TreeList;
            TreeListHitInfo hitInfo = treeList.CalcHitInfo(e.Location);

            if (hitInfo.Node != null)
            {
                TreeListNode node = hitInfo.Node;

                if (Convert.ToBoolean(node.Tag) == false)
                {
                    return;
                }

                //TreeListNode parentNode = node.ParentNode;
                //if (parentNode != null)
                //foreach (TreeListNode childNode in parentNode.Nodes)
                //MessageBox.Show(childNode.GetDisplayText(0));                

                if (node.HasChildren)
                {
                    foreach (TreeListNode item2 in node.Nodes)
                    {
                        if (Convert.ToBoolean(item2.Tag) == false)
                        {
                            //return;
                        }
                        else
                        {
                            item2.Checked = node.Checked;
                        }
                        
                    }
                }
            }
        }

        private void tl_yetkiler_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e) // seçilen yetkinin açıklamasını gösterir.
        {
            try
            {
                string yetki = "";

                switch (e.Node.GetDisplayText(0))
                {
                    case "Operatör İşlemleri":
                        yetki = "Y_OPERATOR";
                        break;
                    case "Çağrı Yap":
                        yetki = "Y_CAGRIYAP";
                        break;
                    case "Randevu Oluştur":
                        yetki = "Y_RANDEVUOLUSTUR";
                        break;
                    case "Beklemeye Al":
                        yetki = "Y_BEKLEMEYEAL";
                        break;
                    case "Çağrıyı Aktar":
                        yetki = "Y_AKTAR";
                        break;
                    case "Randevularım":
                        yetki = "Y_RANDEVULARIM";
                        break;
                    case "Çağrılarım":
                        yetki = "Y_CAGRILARIM";
                        break;
                    case "Mesajlarım":
                        yetki = "Y_MESAJLARIM";
                        break;
                    case "Forum":
                        yetki = "Y_FORUMKULLAN";
                        break;
                    case "Yardım":
                        yetki = "Y_YARDIM";
                        break;
                    case "İstek Ekle":
                        if (e.Node.ParentNode.GetDisplayText(0) == "Operatör İşlemleri")
                        {
                            yetki = "Y_ISTEKEKLEOPERATOR";
                        }
                        else if (e.Node.ParentNode.GetDisplayText(0) == "Yönetim")
                        {
                            yetki = "Y_ISTEKEKLEADMIN";
                        }
                        break;
                    case "Rapor":
                        yetki = "Y_RAPOR";
                        break;
                    case "Randevu Raporu":
                        yetki = "Y_RANDEVULAR";
                        break;
                    case "Çağrı Raporu":
                        yetki = "Y_CAGRILAR";
                        break;
                    case "Ses Kayıtları Listele":
                        yetki = "Y_SESKAYDIBUL";
                        break;
                    case "Ses Kaydı Dinle":
                        yetki = "Y_SESDINLE";
                        break;
                    case "Ses Kaydı Dışa Aktar":
                        yetki = "Y_SESDISAAKTAR";
                        break;
                    case "İstek Raporu":
                        yetki = "Y_ISTEKLER";
                        break;
                    case "Log Kayıtları":
                        yetki = "Y_LOGLAR";
                        break;
                    case "Kullanıcı İzleme":
                        yetki = "Y_KULLANICIIZLE";
                        break;
                    case "Yönetim":
                        yetki = "Y_YONETIM";
                        break;
                    case "Genel Ayarlar":
                        yetki = "Y_GENELAYARLAR";
                        break;
                    case "Randevu Durumları":
                        yetki = "Y_RANDEVUDURUMLARI";
                        break;
                    case "Çıkış Kodları (Ekle/Sil/Güncelle)":
                        yetki = "Y_CIKISKODLARI";
                        break;
                    case "Genel Çalışma Takvimi (Ekle/Sil/Güncelle)":
                        yetki = "Y_GENELTAKVIM";
                        break;
                    case "Çalışma İşlemleri(Ekle/Güncelle/Sil)":
                        yetki = "Y_CALISMALAR";
                        break;
                    case "Çalışma İşlemleri(Aktif Periyot/Çıkış Kodları/Çalışma Aralıkları)":
                        yetki = "Y_CALISMAISLEMLERI";
                        break;
                    case "Rol ve Yetkiler(Ekle/Sil/Güncelle)":
                        yetki = "Y_ROLVEYETKILER";
                        break;
                    case "Kullanıcılar(Ekle/Sil/Güncelle)":
                        yetki = "Y_KULLANICILAR";
                        break;
                    case "Kullanıcı Çalışmaları Tanımlama":
                        yetki = "Y_KULLANICICALISMALARI";
                        break;
                    case "Sık Sorulan Sorular(Ekle/Sil/Güncelle)":
                        yetki = "Y_SSS";
                        break;
                    case "Forum İşlemleri":
                        yetki = "Y_FORUMISLEMLERI";
                        break;
                    case "Randevu Aktarma":
                        yetki = "Y_RANDEVUAKTAR";
                        break;
                    default:
                        break;
                }

                //e.Node.Tag.ToString()
                lbl_yetkiaciklama.Text = yetkiaciklama.Where(t => t.YA_YETKI == yetki).SingleOrDefault().YA_YETKIACIKLAMA;
            }
            catch (Exception)
            {
            }
        }

        private void grdview_list_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) //seçilen rolün yetkilerini listeler. 
        {

            ///hiyerarşiyi kaldır
            
            if (grdview_list.GetFocusedRow() == null) return;
                       
            try
            {
                secilensira = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("ROL_SIRA"));
                yetkiler = (from p in veri.YETKILER_TBL where p.YET_ROLSIRANO == secilensira select p).ToList();

                //if (secilensira == (from p in veri.ROLLER_TBL select p.ROL_SIRA).Max())
                //{
                //    oncekiyetkiler = null;
                //}
                //else
                //{
                //    oncekisira = (from p in veri.ROLLER_TBL where p.ROL_SIRA > secilensira select p.ROL_SIRA).Min();
                //    oncekiyetkiler = (from p in veri.YETKILER_TBL where p.YET_ROLSIRANO == oncekisira select p).ToList();
                //}


                ////TreeList tl_yetkiler = new TreeList();
                ////tl_yetkiler.CustomDrawNodeCell += tl_yetkiler_CustomDrawNodeCell;
                abc();

            }
            catch (Exception ex)
            {
            }

        }


        private void btn_down_Click(object sender, EventArgs e) // rol hiyerarşisini değiştirir. 
        {
            degis(false); ///hiyerarşiyi kaldır: visible false yapıldı yukarda
        }

        private void btn_up_Click(object sender, EventArgs e) // rol hiyerarşisini değiştirir.
        {
            degis(true);///hiyerarşiyi kaldır: visible false yapıldı yukarda
        }

        void degis(bool up) // rol hiyerarşisini değiştirir.
        {
            if (grdview_list.GetFocusedRow() == null) return;

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Yetkiler değişecektir. Devam etmek istiyor musunuz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.No)
            {
                return;
            }


            try
            {
                int sec_sira = Convert.ToInt32(grdview_list.GetFocusedRowCellValue("ROL_SIRA"));
                string sec_roladi = grdview_list.GetFocusedRowCellValue("ROL_ADI").ToString();
                string sec_aciklama = grdview_list.GetFocusedRowCellValue("ROL_ACIKLAMA").ToString();
                bool sec_aktif = Convert.ToBoolean(grdview_list.GetFocusedRowCellValue("ROL_AKTIF"));                

                int diger_sira = 0;
                if (up == true)
                {
                    if (sec_sira == (from p in veri.ROLLER_TBL select p.ROL_SIRA).Min())
                    {
                        MessageBox.Show("Seçilen Rol zaten en üst seviyede...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    diger_sira = (from p in veri.ROLLER_TBL where p.ROL_SIRA < sec_sira select p.ROL_SIRA).Max();
                }
                else
                {
                    if (sec_sira == (from p in veri.ROLLER_TBL select p.ROL_SIRA).Max())
                    {
                        MessageBox.Show("Seçilen Rol zaten en alt seviyede...", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    diger_sira = (from p in veri.ROLLER_TBL where p.ROL_SIRA > sec_sira select p.ROL_SIRA).Min();
                }


                var diger_kayit = (from p in veri.ROLLER_TBL where p.ROL_SIRA == diger_sira select p).ToList();
                string diger_roladi = diger_kayit[0].ROL_ADI;
                string diger_aciklama = diger_kayit[0].ROL_ACIKLAMA;
                bool diger_aktif = Convert.ToBoolean(diger_kayit[0].ROL_AKTIF);


                var rolsec = (from p in veri.ROLLER_TBL where p.ROL_SIRA == sec_sira select p).ToList();
                rolsec[0].ROL_ADI = diger_roladi ;
                rolsec[0].ROL_ACIKLAMA = diger_aciklama;
                rolsec[0].ROL_AKTIF = diger_aktif;
                veri.SaveChanges();

                var roldiger = (from p in veri.ROLLER_TBL where p.ROL_SIRA == diger_sira  select p).ToList();
                roldiger[0].ROL_ADI = sec_roladi ;
                roldiger[0].ROL_ACIKLAMA = sec_aciklama;
                roldiger[0].ROL_AKTIF = sec_aktif;
                veri.SaveChanges();

                listele();

                MessageBox.Show("Kaydedildi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydedilemedi, Hata:" + ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tl_yetkiler_BeforeCheckNode(object sender, CheckNodeEventArgs e) // üst altın yetkisine sahiptir mantığı ile, alta ait olan yetkiler üstte kaldırılamaz. 
        {

            ///hiyerarşiyi kaldır:
            //TreeList treeList = sender as TreeList;
            
            
            //if (e.Node != null)
            //{

            //    if (Convert.ToBoolean(e.Node.Tag) == false)
            //    {
                    
            //        e.CanCheck = false;
            //        return;
            //    }

            //    //TreeListNode parentNode = node.ParentNode;
            //    //if (parentNode != null)
            //    //foreach (TreeListNode childNode in parentNode.Nodes)
            //    //MessageBox.Show(childNode.GetDisplayText(0));                

            //    if (e.Node.HasChildren)
            //    {
            //        foreach (TreeListNode item2 in e.Node.Nodes)
            //        {
            //            if (Convert.ToBoolean(item2.Tag) == false)
            //            {
            //                //return;
            //            }
            //            else
            //            {
            //                item2.Checked = e.Node.Checked;
            //            }
            //        }
            //    }
            //}
        }

        void abc() //seçilen rolün altındaki rol yetkileri işaretlenir. 
        {
            ///hiyerarşiyi kaldır. oncekiyetkilere o satırı pasif etmek için giriyordurk. artık öyle bir duruma gerek yok.
            foreach (var item in tl_yetkiler.NodesIterator.All)
            {
                switch (item.GetDisplayText(0))
                {
                    case "Operatör İşlemleri":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_OPERATOR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_OPERATOR == true) { item.Checked = true; } else { item.Checked = false; }
                        //tl_yetkiler.RefreshNode(item);
                        break;
                    case "Çağrı Yap":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_CAGRIYAP == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_CAGRIYAP == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Randevu Oluştur":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_RANDEVUOLUSTUR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_RANDEVUOLUSTUR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Beklemeye Al":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_BEKLEMEYEAL == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_BEKLEMEYEAL == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Çağrıyı Aktar":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_AKTAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_AKTAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Randevularım":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_RANDEVULARIM == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_RANDEVULARIM == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Çağrılarım":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_CAGRILARIM == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_CAGRILARIM == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Mesajlarım":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_MESAJLARIM == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_MESAJLARIM == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Forum":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_FORUMKULLAN == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_FORUMKULLAN == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Yardım":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_YARDIM == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_YARDIM == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "İstek Ekle":
                        if (item.ParentNode.GetDisplayText(0) == "Operatör İşlemleri")
                        {
                            //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_ISTEKEKLEOPERATOR == true) { item.Tag = false; } else { item.Tag = true; } }
                            if (yetkiler[0].Y_ISTEKEKLEOPERATOR == true) { item.Checked = true; } else { item.Checked = false; }
                        }
                        else if (item.ParentNode.GetDisplayText(0) == "Yönetim")
                        {
                            //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_ISTEKEKLEADMIN == true) { item.Tag = false; } else { item.Tag = true; } }
                            if (yetkiler[0].Y_ISTEKEKLEADMIN == true) { item.Checked = true; } else { item.Checked = false; }
                        }
                        break;
                    case "Rapor":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_RAPOR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_RAPOR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Randevu Raporu":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_RANDEVULAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_RANDEVULAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Çağrı Raporu":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_CAGRILAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_CAGRILAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Ses Kayıtları Listele":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_SESKAYDIBUL == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_SESKAYDIBUL == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Ses Kaydı Dinle":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_SESDINLE == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_SESDINLE == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Ses Kaydı Dışa Aktar":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_SESDISAAKTAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_SESDISAAKTAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "İstek Raporu":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_ISTEKLER == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_ISTEKLER == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Log Kayıtları":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_LOGLAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_LOGLAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Kullanıcı İzleme":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_KULLANICIIZLE == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_KULLANICIIZLE == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Yönetim":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_YONETIM == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_YONETIM == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Genel Ayarlar":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_GENELAYARLAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_GENELAYARLAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Randevu Durumları":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_RANDEVUDURUMLARI == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_RANDEVUDURUMLARI == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Çıkış Kodları (Ekle/Sil/Güncelle)":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_CIKISKODLARI == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_CIKISKODLARI == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Genel Çalışma Takvimi (Ekle/Sil/Güncelle)":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_GENELTAKVIM == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_GENELTAKVIM == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Çalışma İşlemleri(Ekle/Güncelle/Sil)":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_CALISMALAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_CALISMALAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Çalışma İşlemleri(Aktif Periyot/Çıkış Kodları/Çalışma Aralıkları)":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_CALISMAISLEMLERI == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_CALISMAISLEMLERI == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Rol ve Yetkiler(Ekle/Sil/Güncelle)":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_ROLVEYETKILER == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_ROLVEYETKILER == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Kullanıcılar(Ekle/Sil/Güncelle)":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_KULLANICILAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_KULLANICILAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Kullanıcı Çalışmaları Tanımlama":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_KULLANICICALISMALARI == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_KULLANICICALISMALARI == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Sık Sorulan Sorular(Ekle/Sil/Güncelle)":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_SSS == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_SSS == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Forum İşlemleri":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_FORUMISLEMLERI == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_FORUMISLEMLERI == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    case "Randevu Aktarma":
                        //if (oncekiyetkiler == null) { item.Tag = true; } else { if (oncekiyetkiler[0].Y_RANDEVUAKTAR == true) { item.Tag = false; } else { item.Tag = true; } }
                        if (yetkiler[0].Y_RANDEVUAKTAR == true) { item.Checked = true; } else { item.Checked = false; }
                        break;
                    default:
                        break;
                }
            }
            //tl_yetkiler.Focus(); //cellstyle ı harekete geçirmiş oluyoruz. //hiyerarşi olmadığı için pasif etmeye gerek kalmıyor
        }
        
        private void tl_yetkiler_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e) // altın yetkileri gri gösterilir.
        {
            ///hiyerarşiyi kaldır:
            //hiyerarşi olmadığı için pasif etmeye gerek kalmıyor
            //switch (Convert.ToBoolean(e.Node.Tag))
            //{
            //    case false:
            //        e.Appearance.ForeColor = Color.Gray;
            //        break;
            //    case true:
            //        e.Appearance.ForeColor = Color.Black  ;
            //        break;
            //    default:
            //        break;
            //}

        }
    }
}
