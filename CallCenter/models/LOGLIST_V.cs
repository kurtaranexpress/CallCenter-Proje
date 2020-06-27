using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{
    class LOGLIST_V
    {
        public long LG_ID { get; set; }
        public Nullable<System.DateTime> LG_TARIH { get; set; }
        public Nullable<long> LG_KUL_ID { get; set; }
        public string LG_ISLEM { get; set; }
        public string LG_ISLEMDETAY { get; set; }

        public string KUL_ADI { get; set; }
        public string KUL_KULLANICIID { get; set; }
    }
}
