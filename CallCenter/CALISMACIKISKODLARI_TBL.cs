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
    
    public partial class CALISMACIKISKODLARI_TBL
    {
        public long CCK_ID { get; set; }
        public Nullable<long> CCK_CAL_ID { get; set; }
        public Nullable<long> CCK_CK_ID { get; set; }
    
        public virtual CALISMALAR_TBL CALISMALAR_TBL { get; set; }
        public virtual CIKISKODLARI_TBL CIKISKODLARI_TBL { get; set; }
    }
}
