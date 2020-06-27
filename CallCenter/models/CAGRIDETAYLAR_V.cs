using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{
    class CAGRIDETAYLAR_V
    {
        public long CAG_ID { get; set; }
        public Nullable<long> CAG_CAL_ID { get; set; }
        public Nullable<long> CAG_KUL_ID { get; set; }
        public Nullable<System.DateTime> CAG_TARIH { get; set; }
        public string CAG_TELNO { get; set; }
        public string CAG_ACIKLAMA { get; set; }
        public Nullable<long> CAG_CK_ID { get; set; }
        public string CAG_SANTRALCIKISKODU { get; set; }
        public Nullable<long> CAG_IST_ID { get; set; }

        public Nullable<System.TimeSpan> CAG_SURE { get; set; }
        public Nullable<System.DateTime> CAG_BASLAMA { get; set; }
        public Nullable<System.DateTime> CAG_BITIS { get; set; }
        public long IST_ID { get; set; }
        public Nullable<System.DateTime> IST_TARIH { get; set; }
        public string IST_CALISMAID { get; set; }
        public string IST_KULLANICIID { get; set; }
        public Nullable<long> IST_BIRIMNO { get; set; }
        public Nullable<long> IST_ALTBIRIMNO { get; set; }
        public Nullable<int> IST_REFYIL { get; set; }
        public Nullable<int> IST_REFDONEM { get; set; }
        public Nullable<int> IST_REFAY { get; set; }
        public Nullable<int> IST_REFHAFTA { get; set; }
        public string IST_TELNO { get; set; }
        public string IST_IL { get; set; }
        public string IST_ACIKLAMA { get; set; }
        public string IST_RANDEVUTERCIH { get; set; }
        public string IST_NEDIR { get; set; }
        public Nullable<bool> IST_OKUNDU { get; set; }
        public Nullable<bool> IST_ICERDEN { get; set; }
        public Nullable<System.DateTime> IST_KAPANMAZAMANI { get; set; }
        public string CAL_ADI { get; set; }        
        public string KUL_ADI { get; set; }
        public string KUL_KULLANICIID { get; set; }
        public string CK_KOD { get; set; }
        public string CK_ACIKLAMA { get; set; }

        public string KULADI2 { get; set; }
        public string KULLANICIID2 { get; set; }



        public Nullable<System.DateTime> RAN_BASLAMATARIH { get; set; }
        public Nullable<System.DateTime> RAN_BITISTARIH { get; set; }
        public string RAN_TELNO { get; set; }
        public string RAN_ACIKLAMA { get; set; }
        public Nullable<System.DateTime> RAN_ACMA { get; set; }





    }

}
