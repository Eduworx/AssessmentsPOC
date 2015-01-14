using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AssessmentsPOC.Models;

namespace AssessmentsPOC.Controllers
{
    public class AssessmentsController : ApiController
    {
        private AssessmentsContext db = new AssessmentsContext();// GET: api/contexts/1/Assessments/5
        
        
        public IQueryable<Assessment> GetAssessments()
        {
            return db.Assessments;
        }

        // GET: api/Assessments/5
        [ResponseType(typeof(Assessment))]
        public async Task<IHttpActionResult> GetAssessment(int id)
        {
            Assessment assessment = await db.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }

            return Ok(assessment);
        }

        // GET: api/contexts/1/Assessments/5
        [ResponseType(typeof(Assessment))]
        [ActionName("GetAssessment")]
        public IQueryable<Assessment> GetAssessmentForContext(int contextId)
        {
            var assessment = db.Assessments.Where(x => x.ContextId == contextId);
            return assessment;
        }


        // GET: api/Assessments/5
        [ResponseType(typeof(Assessment))]
        public async Task<IHttpActionResult> GetAssessment(int contextId, int id)
        {
            Assessment assessment = await db.Assessments.Where(x => x.ContextId == contextId && x.Id == id).FirstOrDefaultAsync();
            if (assessment == null)
            {
                return NotFound();
            }

            return Ok(assessment);
        }

        // PUT: api/Assessments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssessment(int id, Assessment assessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assessment.Id)
            {
                return BadRequest();
            }

            db.Entry(assessment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Assessments
        [ResponseType(typeof(Assessment))]
        public async Task<IHttpActionResult> PostAssessment(Assessment assessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assessments.Add(assessment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = assessment.Id }, assessment);
        }

        // DELETE: api/Assessments/5
        [ResponseType(typeof(Assessment))]
        public async Task<IHttpActionResult> DeleteAssessment(int id)
        {
            Assessment assessment = await db.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }

            db.Assessments.Remove(assessment);
            await db.SaveChangesAsync();

            return Ok(assessment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssessmentExists(int id)
        {
            return db.Assessments.Count(e => e.Id == id) > 0;
        }
    }
}