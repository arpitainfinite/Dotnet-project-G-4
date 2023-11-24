using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            IEnumerable<mvcDepartmentModel> deplist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Department").Result;
            deplist = response.Content.ReadAsAsync<IEnumerable<mvcDepartmentModel>>().Result;
            return View(deplist);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if(id == 0)
               return View(new mvcDepartmentModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Department/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcDepartmentModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(mvcDepartmentModel Depv)
        {
            if (Depv.DepId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Department", Depv).Result;
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Department/"+Depv.DepId, Depv).Result;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Department/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}