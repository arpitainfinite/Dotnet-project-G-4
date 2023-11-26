using System;
using Employee_Management_System.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Management_System.Extensions;


namespace Employee_Management_System.Controllers
{
    public class MainPageController : Controller
    {
        //GET: MainPage
        public ActionResult getempname()
        {
            IEnumerable<mvcEmployeeModel> mainlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee_Details").Result;
            mainlist = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(mainlist);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee_Details/" + id.ToString()).Result;
            this.AddNotification("Deleted Succesfully", NotificationType.SUCCESS);
            return RedirectToAction("getempname", "MainPage");
        }

        //public ActionResult getempname(string name)
        //{
        //    IEnumerable<mvcEmployeeModel> obj = null;
        //    HttpClient hc = new HttpClient();
        //    hc.BaseAddress = new Uri("https://localhost:44330/api/");

        //    var consumeapi = hc.GetAsync("EMPSearch?name=" + name);
        //    consumeapi.Wait();

        //    var readdata = consumeapi.Result;
        //    if (readdata.IsSuccessStatusCode)
        //    {
        //        var displaydata = readdata.Content.ReadAsAsync<IList<mvcEmployeeModel>>();
        //        displaydata.Wait();
        //        obj = displaydata.Result;
        //    }
        //    return View(obj);
        //}

    }
}