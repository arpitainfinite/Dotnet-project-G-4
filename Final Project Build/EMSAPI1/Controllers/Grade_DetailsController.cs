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
using EMSAPI1.Models;

namespace EMSAPI1.Controllers
{
    public class Grade_DetailsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Grade_Details
        public IQueryable<Grade_Details> GetGrade_Details()
        {
            return db.Grade_Details;
        }

        // GET: api/Grade_Details/5
        [ResponseType(typeof(Grade_Details))]
        public IHttpActionResult GetGrade_Details(int id)
        {
            Grade_Details grade_Details = db.Grade_Details.Find(id);
            if (grade_Details == null)
            {
                return NotFound();
            }

            return Ok(grade_Details);
        }

        // PUT: api/Grade_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrade_Details(int id, Grade_Details grade_Details)
        {

            if (id != grade_Details.Grade_Id)
            {
                return BadRequest();
            }

            db.Entry(grade_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Grade_DetailsExists(id))
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

        // POST: api/Grade_Details
        [ResponseType(typeof(Grade_Details))]
        public IHttpActionResult PostGrade_Details(Grade_Details grade_Details)
        {

            db.Grade_Details.Add(grade_Details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grade_Details.Grade_Id }, grade_Details);
        }

        // DELETE: api/Grade_Details/5
        [ResponseType(typeof(Grade_Details))]
        public IHttpActionResult DeleteGrade_Details(int id)
        {
            Grade_Details grade_Details = db.Grade_Details.Find(id);
            if (grade_Details == null)
            {
                return NotFound();
            }

            db.Grade_Details.Remove(grade_Details);
            db.SaveChanges();

            return Ok(grade_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Grade_DetailsExists(int id)
        {
            return db.Grade_Details.Count(e => e.Grade_Id == id) > 0;
        }
    }
}