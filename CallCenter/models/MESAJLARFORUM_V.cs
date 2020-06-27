using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{
    class MESAJLARFORUM_V
    {
        



        public long MSJ_ID { get; set; }
        public Nullable<long> MSJ_KUL_ID { get; set; }
        public Nullable<long> MSJ_FR_ID { get; set; }
        public Nullable<System.DateTime> MSJ_TARIH { get; set; }
        public string MSJ_MESAJ { get; set; }


        public long KUL_ID { get; set; }
        public string KUL_ADI { get; set; }
        public string KUL_KULLANICIID { get; set; }

    }
}
