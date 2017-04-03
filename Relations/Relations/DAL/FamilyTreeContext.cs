using Relations.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Relations.DAL
{
    public class FamilyTreeContext:DbContext
    {
        public FamilyTreeContext(): base("FamilyTreeContext")
        {

        }
        public DbSet<Relationships> Relationships { get; set; }

        public DbSet<Members> Members { get; set; }

        public DbSet<MemberRelationships> MembersRelationships { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberRelationships>()
                .HasRequired(m => m.Members)
                .WithMany(t => t.MemberMemberRelationships)
                .HasForeignKey(m => m.MembersID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MemberRelationships>()
                .HasRequired(m => m.Relatives)
                .WithMany(t => t.RelativeMemberRelationships)
                .HasForeignKey(m => m.RelativesID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Relationships>()
                .HasOptional(c => c.ReverseRelationship)
                .WithMany()
                .HasForeignKey(c => c.ReverseRelationshipId);
        }
    }
}