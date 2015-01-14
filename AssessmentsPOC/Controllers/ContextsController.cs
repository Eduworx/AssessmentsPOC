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
    public class ContextsController : ApiController
    {
        private AssessmentsContext db = new AssessmentsContext();

        // GET: api/Contexts
        public IQueryable<Context> GetContexts()
        {
            return db.Contexts;
        }

        // GET: api/Contexts/5
        [ResponseType(typeof(Context))]
        public async Task<IHttpActionResult> GetContext(int id)
        {
            Context context = await db.Contexts.FindAsync(id);
            if (context == null)
            {
                return NotFound();
            }

            return Ok(context);
        }

        // PUT: api/Contexts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContext(int id, Context context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != context.Id)
            {
                return BadRequest();
            }

            db.Entry(context).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContextExists(id))
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

        // POST: api/Contexts
        [ResponseType(typeof(Context))]
        public async Task<IHttpActionResult> PostContext(Context context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contexts.Add(context);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = context.Id }, context);
        }

        // DELETE: api/Contexts/5
        [ResponseType(typeof(Context))]
        public async Task<IHttpActionResult> DeleteContext(int id)
        {
            Context context = await db.Contexts.FindAsync(id);
            if (context == null)
            {
                return NotFound();
            }

            db.Contexts.Remove(context);
            await db.SaveChangesAsync();

            return Ok(context);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContextExists(int id)
        {
            return db.Contexts.Count(e => e.Id == id) > 0;
        }
    }
}