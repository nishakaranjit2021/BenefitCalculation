using EmployeeBenefitsApp.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.Models
{
    public class Dependent
    {
        public Name DependentName { get; set; }

        [Display(Name = "Dependent Annual Cost Of Benefits")]
        public decimal TotalAnnualCostOfBenefits { get; set; }

        public const decimal AnnualCostOfBenefitForDependentWithOutDiscount = 500;

        public Common.Enum.Relation Relation { get; set; }
    }
}