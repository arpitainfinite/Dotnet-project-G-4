using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebapiEMS.Models;

namespace WebapiEMS.Controllers
{
    public class DepartmentController : ApiController
    {
        private infiniteEntities db = new infiniteEntities();

        // GET: api/Department
        public IQueryable<DemoCheck> GetDemoChecks()
        {
            return db.DemoChecks;
        }

        // GET: api/Department/5
        [ResponseType(typeof(DemoCheck))]
        public IHttpActionResult GetDemoCheck(int id)
        {
            DemoCheck demoCheck = db.DemoChecks.Find(id);
            if (demoCheck == null)
            {
                return NotFound();
            }

            return Ok(demoCheck);
        }

        // PUT: api/Department/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDemoCheck(int id, DemoCheck demoCheck)
        {

            if (id != demoCheck.DepId)
            {
                return BadRequest();
            }

            db.Entry(demoCheck).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemoCheckExists(id))
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

        // POST: api/Department
        [ResponseType(typeof(DemoCheck))]
        public IHttpActionResult PostDemoCheck(DemoCheck demoCheck)
        {

            db.DemoChecks.Add(demoCheck);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = demoCheck.DepId }, demoCheck);
        }

        // DELETE: api/Department/5
        [ResponseType(typeof(DemoCheck))]
        public IHttpActionResult DeleteDemoCheck(int id)
        {
            DemoCheck demoCheck = db.DemoChecks.Find(id);
            if (demoCheck == null)
            {
                return NotFound();
            }

            db.DemoChecks.Remove(demoCheck);
            db.SaveChanges();

            return Ok(demoCheck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DemoCheckExists(int id)
        {
            return db.DemoChecks.Count(e => e.DepId == id) > 0;
        }
    }
}