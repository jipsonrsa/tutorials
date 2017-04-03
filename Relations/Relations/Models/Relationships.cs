using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Relations.Models
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