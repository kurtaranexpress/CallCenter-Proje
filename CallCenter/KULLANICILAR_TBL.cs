//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CallCenter
{
    using System;
    using System.Collections.Generic;
    
    public partial class KULLANICILAR_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KULLANICILAR_TBL()
        {
            this.KULLANICICALISMALAR_TBL = new HashSet<KULLANICICALISMALAR_TBL>();
            this.RANDEVULAR_TBL = new HashSet<RANDEVULAR_TBL>();
        }
    
        public long KUL_ID { get; set; }
        public string KUL_ADI { get; set; }
        public string KUL_SIFRE { get; set; }
        public string KUL_SANTRALUSERID { get; set; }
        public string KUL_SANTRALSIFRE { get; set; }
        public Nullable<long> KUL_ROL_ID { get; set; }
        public string KUL_KULLANICIID { get; set; }
        public Nullable<bool> KUL_SEC { get; set; }
        public Nullable<bool> KUL_SIL { get; set; }
        public Nullable<System.DateTime> KUL_SILME_TARIH { get; set; }
        public Nullable<int> KUL_SILME_KUL_ID { get; set; }
        public Nullable<int> KUL_MIKROFONDUZEYI { get; set; }
        public Nullable<int> KUL_HOPARLORDUZEYI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KULLANICICALISMALAR_TBL> KULLANICICALISMALAR_TBL { get; set; }
        public virtual ROLLER_TBL ROLLER_TBL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RANDEVULAR_TBL> RANDEVULAR_TBL { get; set; }
    }
}
