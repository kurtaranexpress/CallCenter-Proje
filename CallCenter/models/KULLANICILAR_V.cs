using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.models
{
    public  class KULLANICILAR_V
    {
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



        public Nullable<int> KUL_MIKROFONDUZEYI { get; set; }
        public Nullable<int> KUL_HOPARLORDUZEYI { get; set; }


        public string ROL_ANAROL { get; set; }
    }
}
