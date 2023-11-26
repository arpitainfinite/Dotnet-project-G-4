using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMSAPI1.Models;

namespace EMSAPI1.Controllers
{
    public class SearchController : ApiController
    {
        public IHttpActionResult getempdetails(string name)
        {
            DBModel co = new DBModel();
            var result = co.Employee_Details.Where(x => x.Emp_First_Name.StartsWith(name) || name == null).ToList();
            return Ok(result);
        }
        

    }
}
