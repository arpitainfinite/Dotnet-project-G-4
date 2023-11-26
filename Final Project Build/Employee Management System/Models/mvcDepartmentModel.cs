using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Models
{
    public class mvcDepartmentModel
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public string Department_Name { get; set; }
    }

    
}

