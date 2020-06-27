using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{
    class CALISMACIKISKODLARI_V
    {
        public long CK_ID { get; set; }
        public string CK_KOD { get; set; }
        public string CK_ACIKLAMA { get; set; }
        public Nullable<bool> CK_SEC { get; set; }
        public long CCK_ID { get; set; }
        public Nullable<long> CCK_CAL_ID { get; set; }
        public Nullable<long> CCK_CK_ID { get; set; }
    }
}
