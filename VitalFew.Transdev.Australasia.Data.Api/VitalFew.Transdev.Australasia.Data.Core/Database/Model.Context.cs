﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VitalFew.Transdev.Australasia.Data.Core.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<VF_API_CATALOG_CLIENTS> VF_API_CATALOG_CLIENTS { get; set; }
        public virtual DbSet<VF_API_CLIENT_OBJECTS> VF_API_CLIENT_OBJECTS { get; set; }
        public virtual DbSet<VF_DATA_PROVIDER> VF_DATA_PROVIDER { get; set; }
    }
}
