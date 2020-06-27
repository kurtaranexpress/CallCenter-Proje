using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{


    public partial class SSS_V
    {
        public long SS_ID { get; set; }
        public Nullable<long> SS_CAL_ID { get; set; }
        public string SS_SORU { get; set; }
        public string SS_CEVAP { get; set; }
        public string CAL_ADI { get; set; }
        public string CAL_CALISMAID{ get; set; }
        public Nullable<bool> SS_AKTIF { get; set; }

    }
}
