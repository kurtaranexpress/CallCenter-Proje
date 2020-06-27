using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{
    class RANDEVUDETAYLAR_V
    {


        public long RAN_ID { get; set; }
        public Nullable<long> RAN_CAL_ID { get; set; }
        public Nullable<long> RAN_KUL_ID { get; set; }
        public Nullable<System.DateTime> RAN_BASLAMATARIH { get; set; }
        public Nullable<System.DateTime> RAN_BITISTARIH { get; set; }
        public string RAN_TELNO { get; set; }
        public string RAN_ACIKLAMA { get; set; }
        public Nullable<long> RAN_DURUMID { get; set; }
        public Nullable<long> RAN_IST_ID { get; set; }

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
        public long KUL_ID { get; set; }
        public string KUL_ADI { get; set; }
        public string KUL_SIFRE { get; set; }
        public string KUL_SANTRALUSERID { get; set; }
        public string KUL_SANTRALSIFRE { get; set; }
        public string KUL_KULLANICIID { get; set; }
        public long KUL_ROL_ID { get; set; }
        public bool KUL_SEC { get; set; }

        public bool KUL_SIL { get; set; }

        public Nullable<System.DateTime> KUL_SILME_TARIH { get; set; }

        public long KUL_SILME_KUL_ID { get; set; }



        public string ROL_ADI { get; set; }
        public int ROL_SIRA { get; set; }


        public long CAL_ID { get; set; }
        public string CAL_ADI { get; set; }
        public string CAL_PERIYOT { get; set; }
        public Nullable<System.DateTime> CAL_BASLAMATARIH { get; set; }
        public Nullable<System.DateTime> CAL_BITISTARIH { get; set; }
        public Nullable<System.TimeSpan> CAL_GUNBASLAMASAAT { get; set; }
        public Nullable<System.TimeSpan> CAL_GUNBITISSAAT { get; set; }
        public Nullable<System.TimeSpan> CAL_RANDEVUARALIK { get; set; }
        public Nullable<bool> CAL_MANUELARAMA { get; set; }
        public string CAL_CALISMAID { get; set; }
        public Nullable<System.DateTime> CAL_YIL { get; set; }
        public Nullable<bool> CAL_SEC { get; set; }
        public Nullable<bool> CAL_SIL { get; set; }
        public Nullable<System.DateTime> CAL_SILME_TARIH { get; set; }
        public Nullable<int> CAL_SILME_KUL_ID { get; set; }

        public bool RAN_SEC { get; set; }
        public Nullable<System.DateTime> RAN_ACMA { get; set; }
        public Nullable<System.DateTime> RAN_KAPANMA { get; set; }
        public Nullable<System.DateTime> IST_KAPANMAZAMANI { get; set; }

    }
}
