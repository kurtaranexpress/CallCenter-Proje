using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{
    class KULLANICICALISMALAR_V
    {
         public long KUL_ID { get; set; }
        public string KUL_ADI { get; set; }
        public string KUL_KULLANICIID { get; set; }
        public long CAL_ID { get; set; }
        public string CAL_ADI { get; set; }
        public string CAL_CALISMAID { get; set; }
        public long KC_ID { get; set; }
        public Nullable<long> KC_KUL_ID { get; set; }
        public Nullable<long> KC_CAL_ID { get; set; }
        public Nullable<bool> CAL_MANUELARAMA { get; set; }
        public Nullable<System.TimeSpan> CAL_RANDEVUARALIK { get; set; }

        public string ROL_ADI { get; set; }
    }
}
