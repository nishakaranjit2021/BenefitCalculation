using EmployeeBenefitsApp.Models;
using EmployeeBenefitsApp.Services.Interfaces;
using EmployeeBenefitsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Dictionary<char, decimal> dictOfDiscountEligibleChar = new Dictionary<char, decimal>(){
            { 'a', 10 },
        };

        public Dictionary<int, string> GetRelations()
        {
            try
            {
                string[] enumNames = System.Enum.GetNames(typeof(EmployeeBenefitsApp.Common.Enum.Relation));

                Dictionary<int, String> listRelationPair = new Dictionary<int, String>();
                for (int i = 0; i < enumNames.Length; i++)
                {
                    listRelationPair.Add(i, enumNames[i].ToString());
                }
                return listRelationPair;
            }
            catch (Exception ex)
            {
                //Handling exception in Base controller
                throw ex;
            }
        }


        public void CalculateCostOfBenefit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                string employerFirstName = employeeViewModel.Employee.EmployeeName.FirstName;
                decimal employerDiscountPercentage = GetDiscountPercentageBasedOnName(employerFirstName);

                employeeViewModel.TotalAnnualCostOfBenefits = ((100 - employerDiscountPercentage) / 100) * Employee._AnnualCostOfBenefit;

                //reset Value
                employeeViewModel.EmployeeAnnualTotalBenefitDeductionForDependents = 0;

                //For dependent

                string dependentFirstName = string.Empty;
                decimal currentDependentDiscountPercentage = 0;

                if (employeeViewModel.Employee.Dependents != null)
                {
                    for (int i = 0; i < employeeViewModel.Employee.Dependents.Count; i++)
                    {
                        dependentFirstName = employeeViewModel.Employee.Dependents[i].Dependent.DependentName.FirstName;
                        currentDependentDiscountPercentage = GetDiscountPercentageBasedOnName(dependentFirstName);

                        employeeViewModel.Employee.Dependents[i].Dependent.TotalAnnualCostOfBenefits = ((100 - currentDependentDiscountPercentage) / 100) * (Dependent.AnnualCostOfBenefitForDependentWithOutDiscount);
                        employeeViewModel.EmployeeAnnualTotalBenefitDeductionForDependents += employeeViewModel.Employee.Dependents[i].Dependent.TotalAnnualCostOfBenefits;
                    }
                }

                employeeViewModel.EmployeeTotalBenefitDeductionForDependentsPerPayCheck = employeeViewModel.EmployeeAnnualTotalBenefitDeductionForDependents / Employee._PayCheckPeriod;
                employeeViewModel.EmployeeNetSalaryPerPayCheck = employeeViewModel.Employee.GetPayCheckPeriodSalary() - employeeViewModel.PayCheckPeriodCostOfBenefits - (employeeViewModel.EmployeeTotalBenefitDeductionForDependentsPerPayCheck);
                employeeViewModel.EmployeeAnnualNetSalaryAfterDeduction = employeeViewModel.Employee.AnnualSalary - employeeViewModel.TotalAnnualCostOfBenefits - employeeViewModel.EmployeeAnnualTotalBenefitDeductionForDependents;
            }
            catch (NullReferenceException ex)
            {
                // We should handle the error in more appropriate way like logging it for further use
                throw ex;
            }
            catch (InvalidCastException ex)
            {
                // We should handle the error in more appropriate way like logging it for further use
                throw ex;
            }

        }



        public decimal GetDiscountPercentageBasedOnName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name) == false)
                {
                    char nameFirstChar = Char.ToLower(name[0]);
                    if (dictOfDiscountEligibleChar.ContainsKey(nameFirstChar))
                    {
                        return dictOfDiscountEligibleChar[nameFirstChar];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}