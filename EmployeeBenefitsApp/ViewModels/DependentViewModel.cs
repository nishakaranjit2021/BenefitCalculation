using EmployeeBenefitsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeBenefitsApp.ViewModels
{
    public class DependentViewModel
    {
        public int Index { get; set; }
        public Dependent Dependent { get; set; }
        public Dictionary<int, string> Relations { get; set; }

        public decimal PayCheckPeriodCostOfBenefitsDeduction
        {
            get
            {
                return Dependent.TotalAnnualCostOfBenefits / Employee._PayCheckPeriod;
            }
        }
        public IList<SelectListItem> RelationSelectListItems
        {
            get
            {
                if (Relations == null)
                {
                    return null;
                }

                var items = Relations.Select(
                    x => new SelectListItem
                    {
                        Value = x.Key.ToString(),
                        Text = x.Value.ToString()
                    }).ToList();

                return items;
            }
        }
    }
}