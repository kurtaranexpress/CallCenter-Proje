using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{
    class MESAJLARTUM_V
    {


        public long MSJ_ID { get; set; }
        public Nullable<System.DateTime> MSJ_TARIH { get; set; }
        public string MSJ_MESAJ { get; set; }
        public bool  MSJ_OKUNDU { get; set; }


        public string gonderenkuladi { get; set; }

        public string alankuladi { get; set; }

        public string gonderenkullaniciid { get; set; }

        public string alankullaniciid { get; set; }

        public long gonderenkulid { get; set; }
        public long alankulid { get; set; }

        
    }
}
