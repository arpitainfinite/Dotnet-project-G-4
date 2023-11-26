using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class mvcEmployeeModel
    {
        public int Emp_ID { get; set; }
        public string Emp_First_Name { get; set; }
        public string Emp_Last_Name { get; set; }
        public Nullable<System.DateTime> Emp_Date_of_Birth { get; set; }
        public Nullable<System.DateTime> Emp_Date_of_Joining { get; set; }
        public string Emp_Designation { get; set; }
        public string Emp_Grade { get; set; }
        public string Emp_Basic { get; set; }
        public string Emp_Dept_Name { get; set; }
        public string Emp_Gender { get; set; }
        public string Emp_Marital_Status { get; set; }
        public string Emp_Home_Address { get; set; }
        public Nullable<int> Emp_Contact_Num { get; set; }
    }
}