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

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Dependent Annual Cost Of Benefits")]
        public decimal TotalAnnualCostOfBenefits { get; set; }

        //This normally goes to respository as it is supposed to come from database. We should add these in Setup Information screen.
        public const decimal AnnualCostOfBenefitForDependentWithOutDiscount = 500;

        public Common.Enum.Relation Relation { get; set; }
    }
}