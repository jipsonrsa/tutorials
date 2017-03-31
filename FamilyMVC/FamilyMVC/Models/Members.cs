using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FamilyMVC.Models
{
    public class Members
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        //public virtual ICollection<Members> Relatives { get; set; }
        public virtual ICollection<MembersRelationships> MemberMembersRelationships { get; set; }
        public virtual ICollection<MembersRelationships> RelativeMembersRelationships { get; set; }
        //public Members()
        //{
        //    Relatives = new HashSet<Members>();
        //}

    }
}