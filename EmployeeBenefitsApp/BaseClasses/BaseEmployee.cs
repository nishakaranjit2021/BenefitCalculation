using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.BaseClasses
{
    public abstract class BaseEmployee
    {
        public Name EmployeeName { get; set; }
        public Address Address { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public abstract decimal GetPayCheckPeriodSalary();
    }
}