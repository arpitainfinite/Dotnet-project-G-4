using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class mvcGradeModel
    {
        public int Grade_Id { get; set; }
        public string Grade { get; set; }
        public Nullable<int> Min_Salary { get; set; }
        public Nullable<int> Max_Salary { get; set; }
        public string Description { get; set; }
    }
}