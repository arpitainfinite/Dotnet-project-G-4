using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Employee_Management_System.Models;

namespace Employee_Management_System.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult getempname(string name)
        {
            IEnumerable<mvcEmployeeModel> obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44330/api/");

            var consumeapi = hc.GetAsync("EMPSearch?name=" + name);
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<mvcEmployeeModel>>();
                displaydata.Wait();
                obj = displaydata.Result;
            }
            return View();
        }
    }
}