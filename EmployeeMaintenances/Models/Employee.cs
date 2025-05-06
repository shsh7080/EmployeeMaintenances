using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeMaintenances.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public decimal Earnings { get; set; }
        public decimal Deduction { get; set; }
        public string Qualification { get; set; }

    }
}