﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FamilyMVC.Models
{
    public class FamilyMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FamilyMVCContext() : base("name=FamilyMVCContext")
        {
        }

        public System.Data.Entity.DbSet<FamilyMVC.Models.Relationships> Relationships { get; set; }

        public System.Data.Entity.DbSet<FamilyMVC.Models.Members> Members { get; set; }

        public System.Data.Entity.DbSet<FamilyMVC.Models.MembersRelationships> MembersRelationships { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembersRelationships>()
                .HasRequired(m => m.Members)
                .WithMany(t => t.MemberMembersRelationships)
                .HasForeignKey(m => m.MembersID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MembersRelationships>()
                .HasRequired(m => m.Relatives)
                .WithMany(t => t.RelativeMembersRelationships)
                .HasForeignKey(m => m.RelativesID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Relationships>()
                .HasOptional(c => c.ReverseRelationship)
                .WithMany()
                .HasForeignKey(c => c.ReverseRelationshipId);
        }

    }
}
