using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Relations.Models
{
    
        public class MemberRelationships
        {
            [Key]
            public int MembersRelationshipsID { get; set; }
            [ForeignKey("Members"), Column(Order = 0)]
            public int MembersID { get; set; }
            [ForeignKey("Relatives"), Column(Order = 1)]
            public int RelativesID { get; set; }
            [ForeignKey("Relationships"), Column(Order = 2)]
            public int ReationshpsID { get; set; }
            public virtual Members Members { get; set; }
            public virtual Members Relatives { get; set; }
            public virtual Relationships Relationships { get; set; }
        }
    }