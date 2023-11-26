using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Management_System.Models;
using System.Net.Http;

namespace Employee_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcEmployeeModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee_Details/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(mvcEmployeeModel Depv)
        {
            if (Depv.Emp_ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee_Details", Depv).Result;
                return RedirectToAction("getempname", "MainPage");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employee_Details/" + Depv.Emp_ID, Depv).Result;
                return RedirectToAction("getempname", "MainPage");
            }
            return RedirectToAction("getempname", "MainPage");
        }

        public ActionResult Delete(int Emp_ID)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee_Details/" + Emp_ID.ToString()).Result;
            return RedirectToAction("getempname", "MainPage");
        }

    }
}