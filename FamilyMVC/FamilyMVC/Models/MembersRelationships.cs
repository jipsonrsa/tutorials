using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FamilyMVC.Models
{
    public class MembersRelationships
    {
        [Key]
        public int MembersRelationshipsID { get; set; }
        [ForeignKey("Members"),Column(Order =0)]
        public int MembersID { get; set; }
        [ForeignKey("Relatives"),Column(Order =1)]
        public int RelativesID { get; set; }
        [ForeignKey("Relationships"),Column(Order =2)]
        public int ReationshpsID { get; set; }
        public virtual Members Members { get; set; }
        public virtual Members Relatives { get; set; }
        public virtual Relationships Relationships { get; set; }
    }
    //public class Context :FamilyMVCContext
    //{
    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<MembersRelationships>()
    //            .HasRequired(m => m.Members)
    //            .WithMany(t => t.MemberMembersRelationships)
    //            .HasForeignKey(m => m.MembersID)
    //            .WillCascadeOnDelete(false);
    //        modelBuilder.Entity<MembersRelationships>()
    //            .HasRequired(m => m.Relatives)
    //            .WithMany(t => t.RelativeMembersRelationships)
    //            .HasForeignKey(m => m.RelativesID)
    //            .WillCascadeOnDelete(false);        }
    //}
}