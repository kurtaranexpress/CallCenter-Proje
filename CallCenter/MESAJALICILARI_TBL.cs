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
    
    public partial class MESAJALICILARI_TBL
    {
        public long MA_ID { get; set; }
        public Nullable<long> MA_MSJ_ID { get; set; }
        public Nullable<long> MA_ALICI_KUL_ID { get; set; }
    
        public virtual MESAJLAR_TBL MESAJLAR_TBL { get; set; }
    }
}