using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeManagement(string username, string password)
        {
            if (IsValidUser(username, password))
            {
                // Authentication successful, redirect to the admin page
                return RedirectToAction("getempname", "MainPage");
            }
            else
            {
                // Authentication failed
                ViewBag.ErrorMessage = "Invalid username or password";
                return View("Index");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EMS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Department_Details WHERE User_Name = @username AND User_Password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

    }
}