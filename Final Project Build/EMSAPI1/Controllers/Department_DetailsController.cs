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
    public class Department_DetailsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Department_Details
        public IQueryable<Department_Details> GetDepartment_Details()
        {
            return db.Department_Details;
        }

        // GET: api/Department_Details/5
        [ResponseType(typeof(Department_Details))]
        public IHttpActionResult GetDepartment_Details(int id)
        {
            Department_Details department_Details = db.Department_Details.Find(id);
            if (department_Details == null)
            {
                return NotFound();
            }

            return Ok(department_Details);
        }

        // PUT: api/Department_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment_Details(int id, Department_Details department_Details)
        {

            if (id != department_Details.User_Id)
            {
                return BadRequest();
            }

            db.Entry(department_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Department_DetailsExists(id))
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

        // POST: api/Department_Details
        [ResponseType(typeof(Department_Details))]
        public IHttpActionResult PostDepartment_Details(Department_Details department_Details)
        {

            db.Department_Details.Add(department_Details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = department_Details.User_Id }, department_Details);
        }

        // DELETE: api/Department_Details/5
        [ResponseType(typeof(Department_Details))]
        public IHttpActionResult DeleteDepartment_Details(int id)
        {
            Department_Details department_Details = db.Department_Details.Find(id);
            if (department_Details == null)
            {
                return NotFound();
            }

            db.Department_Details.Remove(department_Details);
            db.SaveChanges();

            return Ok(department_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Department_DetailsExists(int id)
        {
            return db.Department_Details.Count(e => e.User_Id == id) > 0;
        }
    }
}