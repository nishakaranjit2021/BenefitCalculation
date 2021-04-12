using EmployeeBenefitsApp.BaseClasses;
using EmployeeBenefitsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.Models
{
    public class Employee : BaseEmployee
    {
        public Employee()
        {

        }
        // In the question, we are assuming that Bi-weekly salary for all employees is going to be 2000, cost of Benefit without discount is 1000.
        public const decimal _AnnualSalary = 52000;
        public const decimal _AnnualCostOfBenefit = 1000;
        public const int _PayCheckPeriod = 26;

        public List<DependentViewModel> Dependents { get; set; }

        [Display(Name = "Annual Salary")]
        public decimal AnnualSalary
        {
            get
            {
                return _AnnualSalary;
            }
        }

        public override decimal GetPayCheckPeriodSalary()
        {
            return _AnnualSalary / _PayCheckPeriod;
        }


    }
}