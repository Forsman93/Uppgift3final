﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataBankEntities : DbContext
    {
        public DataBankEntities()
            : base("name=DataBankEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BackEndSkills> BackEndSkills { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CV> CV { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<EmploymentHistory> EmploymentHistory { get; set; }
        public virtual DbSet<Freelancer> Freelancer { get; set; }
        public virtual DbSet<FrontEndSkills> FrontEndSkills { get; set; }
        public virtual DbSet<Knowledge> Knowledge { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformation { get; set; }
    }
}