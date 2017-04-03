using Relations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Relations.DAL
{
    public class FamilyTreeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FamilyTreeContext>
    {
        protected override void Seed(FamilyTreeContext context)
        {
            base.Seed(context);
            var members = new List<Members>
            {
                new Members {LastName="Mathew",FirstMidName="Thomas"},
                new Members {LastName="Thomas",FirstMidName="Leelamma"},
                new Members {LastName="Thomas",FirstMidName="Aidan Jipson"},
                new Members {LastName="Thomas",FirstMidName="Jipson Thomas"},
                new Members {LastName="Thomas",FirstMidName="Gisha Jipson"},
                new Members {LastName="Thomas",FirstMidName="Jaison"},
                new Members {LastName="Jaison",FirstMidName="Bigi"},
                new Members {LastName="Jaison",FirstMidName="Austle"},
                new Members {LastName="Jaison",FirstMidName="Angel Maria"},
                new Members {LastName="Jaison",FirstMidName="Alistar"}

            };
            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
        }
    }
}