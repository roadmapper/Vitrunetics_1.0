﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vitrunetics
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VitruneticsContext : DbContext
    {
        public VitruneticsContext()
            : base("name=VitruneticsContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseRegimen> ExerciseRegimen1 { get; set; }
        public DbSet<ExerciseSequence> ExerciseSequences { get; set; }
        public DbSet<ExerciseStep> ExerciseSteps { get; set; }
        public DbSet<Joint> Joints { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientRegimen> PatientRegimen1 { get; set; }
        public DbSet<Regimen> Regimen1 { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
    }
}
