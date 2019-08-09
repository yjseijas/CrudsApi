using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Employee
    {
        public int idEmployee { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string city { get; set; }
        public int gender { get; set; }
        public int department { get; set; }
        public DateTime hireDate { get; set; }
        public bool isPermanent { get; set; }
    }
}