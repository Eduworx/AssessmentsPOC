using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;




namespace AssessmentsPOC.Models
{
    public class AssessmentsContext : DbContext
    {

        public AssessmentsContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Context> Contexts { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }
    }
}