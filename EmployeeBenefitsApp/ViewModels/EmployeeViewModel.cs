using EmployeeBenefitsApp.Common;
using EmployeeBenefitsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeBenefitsApp.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Employee = new Employee()
            {
                Address = new BaseClasses.Address()
            };
        }
        public Employee Employee { get; set; }

        public IList<US_State> States { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Employee Total Benefit Deduction For Dependents")]
        public decimal EmployeeAnnualTotalBenefitDeductionForDependents { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Employee Benefit Deduction For Dependents")]
        public decimal EmployeeTotalBenefitDeductionForDependentsPerPayCheck { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal EmployeeNetSalaryPerPayCheck { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Net Annual Salary After Deduction")]
        public decimal EmployeeAnnualNetSalaryAfterDeduction { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Employee Annual Cost Of Benefits")]
        public decimal TotalAnnualCostOfBenefits { get; set; }


        [Display(Name = "No. Of Dependents")]
        public int NumberOfDependents
        {
            get
            {
                return (Employee.Dependents == null ? 0 : Employee.Dependents.Count());
            }
        }

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                if (Employee.Address != null)
                {
                    return string.Format("{0}{1} {2}{3} {4}", Employee.Address.AddressLine1, (Employee.Address.AddressLine2 == null ? "" : " "
                        + Employee.Address.AddressLine2), Employee.Address.City, (Employee.Address.State == null ? "" : ", " + Employee.Address.State),
                          Employee.Address.ZipCode);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public IList<SelectListItem> StateSelectListItems
        {
            get
            {
                if (States == null)
                {
                    return null;
                }

                var items = States.Select(
                    x => new SelectListItem
                    {
                        Value = x.Abbreviation,
                        Text = x.Name
                    }).ToList();

                items.Insert(0,
                    new SelectListItem
                    {
                        Text = string.Empty,
                        Value = string.Empty
                    });

                return items;
            }
        }
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Employee Biweekly Cost Of Benefits")]
        public decimal PayCheckPeriodCostOfBenefits
        {
            get
            {
                return TotalAnnualCostOfBenefits / Employee._PayCheckPeriod;
            }
        }
    }
}