using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMSAPI1.Models;
using PagedList;


namespace EMSAPI1.Controllers
{
    public class EMPSearchController : ApiController
    {
        public IHttpActionResult getempdetails(string name)
        {
            DBModel ba = new DBModel();
            var result = ba.Employee_Details.Where(x => x.Emp_First_Name.StartsWith(name) || x.Emp_Designation.StartsWith(name) || name == null).ToList();
            return Ok(result);
        }

        public IHttpActionResult getempid(int id)
        {
            DBModel ida = new DBModel();
            var resultid = ida.Employee_Details.Where(x => x.Emp_ID.Equals(id) || id == null).ToList();
            return Ok(resultid);
        }
    }
}

