using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyMVC.Models
{
    public class Relationships
    {
        
        public int Id { get; set; }
        public string Kind { get; set; }
        public Boolean InCrown { get; set; }
        public int? ReverseRelationshipId { get; set; }
        [ForeignKey("ReverseRelationshipId")]
        public Relationships ReverseRelationship { get; set; }


    }
}