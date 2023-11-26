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
    public class Employee_DetailsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Employee_Details
        public IQueryable<Employee_Details> GetEmployee_Details()
        {
            return db.Employee_Details;
        }

        // GET: api/Employee_Details/5
        [ResponseType(typeof(Employee_Details))]
        public IHttpActionResult GetEmployee_Details(int id)
        {
            Employee_Details employee_Details = db.Employee_Details.Find(id);
            if (employee_Details == null)
            {
                return NotFound();
            }

            return Ok(employee_Details);
        }

        // PUT: api/Employee_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee_Details(int id, Employee_Details employee_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee_Details.Emp_ID)
            {
                return BadRequest();
            }

            db.Entry(employee_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee_DetailsExists(id))
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

        // POST: api/Employee_Details
        [ResponseType(typeof(Employee_Details))]
        public IHttpActionResult PostEmployee_Details(Employee_Details employee_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee_Details.Add(employee_Details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee_Details.Emp_ID }, employee_Details);
        }

        // DELETE: api/Employee_Details/5
        [ResponseType(typeof(Employee_Details))]
        public IHttpActionResult DeleteEmployee_Details(int id)
        {
            Employee_Details employee_Details = db.Employee_Details.Find(id);
            if (employee_Details == null)
            {
                return NotFound();
            }

            db.Employee_Details.Remove(employee_Details);
            db.SaveChanges();

            return Ok(employee_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee_DetailsExists(int id)
        {
            return db.Employee_Details.Count(e => e.Emp_ID == id) > 0;
        }
    }
}