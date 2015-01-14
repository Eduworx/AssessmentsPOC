using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssessmentsPOC.Models
{
    public class AssessmentsDBInitializer : DropCreateDatabaseIfModelChanges<AssessmentsContext> //CreateDatabaseIfNotExists<AssessmentsContext>
    {
        protected override void Seed(AssessmentsContext context)
        {
            base.Seed(context);


            var Contexts = new Context()
            {
                Assessments = new Assessment[]
                    {
                        new Assessment(){ Title = "Assessment 1", Type = AssessmentTypes.TakeOnce},
                        new Assessment(){ Title = "Assessment 2", Type = AssessmentTypes.Practice},
                        new Assessment(){ Title = "Assessment 3", Type = AssessmentTypes.Practice}
                    }.ToList()
            };

            context.Contexts.Add(Contexts);

            Contexts = new Context()
            {
                Assessments = new Assessment[]
                    {
                        new Assessment(){ Title = "Assessment 4", Type = AssessmentTypes.TakeOnce},
                        new Assessment(){ Title = "Assessment 5", Type = AssessmentTypes.Practice},
                        new Assessment(){ Title = "Assessment 6", Type = AssessmentTypes.Practice}
                    }.ToList()
            };
            context.Contexts.Add(Contexts);
            context.SaveChanges();
        }
    }
}