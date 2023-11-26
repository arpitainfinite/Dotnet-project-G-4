using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Management_System.Extensions;

namespace Employee_Management_System.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            IEnumerable<mvcDepartmentModel> deplist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Department_Details").Result;
            deplist = response.Content.ReadAsAsync<IEnumerable<mvcDepartmentModel>>().Result;
            return View(deplist);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcDepartmentModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Department_Details/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcDepartmentModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(mvcDepartmentModel Depv)
        {
            if (Depv.User_Id == 0 && Depv.User_Name != null && Depv.User_Password != null && Depv.Department_Name != null)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Department_Details", Depv).Result;
                return RedirectToAction("getempname", "MainPage");
            }
            //else
            //{
            //    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Department_Details/" + Depv.User_Id, Depv).Result;
            //    return RedirectToAction("getempname", "MainPage");
            //}
            else if (Depv.User_Name == null || Depv.User_Password == null || Depv.Department_Name == null)
            {
                this.AddNotification("All the fields are Mandatory", NotificationType.ERROR);
            }

            return RedirectToAction("AddorEdit", "Department");

        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Department_Details/" + id.ToString()).Result;
            return RedirectToAction("getempname", "MainPage");
        }
    }
}