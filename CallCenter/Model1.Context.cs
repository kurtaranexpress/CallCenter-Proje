﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CallCenterEntities : DbContext
    {
        public CallCenterEntities()
            : base("name=CallCenterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CALISMACIKISKODLARI_TBL> CALISMACIKISKODLARI_TBL { get; set; }
        public virtual DbSet<CALISMALAR_TBL> CALISMALAR_TBL { get; set; }
        public virtual DbSet<CALISMAPERIYOTLARI_TBL> CALISMAPERIYOTLARI_TBL { get; set; }
        public virtual DbSet<CALISMATAKVIMI_TBL> CALISMATAKVIMI_TBL { get; set; }
        public virtual DbSet<CIKISKODLARI_TBL> CIKISKODLARI_TBL { get; set; }
        public virtual DbSet<FORUMKONULARI_TBL> FORUMKONULARI_TBL { get; set; }
        public virtual DbSet<GENELTAKVIM_TBL> GENELTAKVIM_TBL { get; set; }
        public virtual DbSet<KULLANICICALISMALAR_TBL> KULLANICICALISMALAR_TBL { get; set; }
        public virtual DbSet<MESAJALICILARI_TBL> MESAJALICILARI_TBL { get; set; }
        public virtual DbSet<MESAJLAR_TBL> MESAJLAR_TBL { get; set; }
        public virtual DbSet<RENKLER_TBL> RENKLER_TBL { get; set; }
        public virtual DbSet<ROLLER_TBL> ROLLER_TBL { get; set; }
        public virtual DbSet<SSS_TBL> SSS_TBL { get; set; }
        public virtual DbSet<YETKIACIKLAMALAR_TBL> YETKIACIKLAMALAR_TBL { get; set; }
        public virtual DbSet<YETKILER_TBL> YETKILER_TBL { get; set; }
        public virtual DbSet<KULLANICILAR_TBL> KULLANICILAR_TBL { get; set; }
        public virtual DbSet<ISTEKLER_TBL> ISTEKLER_TBL { get; set; }
        public virtual DbSet<CAGRILAR_TBL> CAGRILAR_TBL { get; set; }
        public virtual DbSet<RANDEVULAR_TBL> RANDEVULAR_TBL { get; set; }
        public virtual DbSet<RANDEVULISTERENKLERI_TBL> RANDEVULISTERENKLERI_TBL { get; set; }
        public virtual DbSet<GENELAYARLAR_TBL> GENELAYARLAR_TBL { get; set; }
        public virtual DbSet<LOG_TBL> LOG_TBL { get; set; }
        public virtual DbSet<mv_study_name> mv_study_name { get; set; }
        public virtual DbSet<mv_tuik_personel> mv_tuik_personel { get; set; }
    }
}
