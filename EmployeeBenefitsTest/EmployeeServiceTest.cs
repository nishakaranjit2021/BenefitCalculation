using System;
using System.Collections.Generic;
using EmployeeBenefitsApp.Services;
using EmployeeBenefitsApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeBenefitsTest
{
    [TestClass]
    public class EmployeeServiceTest
    {
        EmployeeService employeeService = new EmployeeService();

        [TestMethod]
        public void TestDiscountPercentage_ForNameStartsWithA()
        {
           decimal percentage= employeeService.GetDiscountPercentageBasedOnName("Alpha");

            Assert.AreEqual(10, percentage);
        }


        [TestMethod]
        public void TestDiscountPercentage_ForNameStartsWithB()
        {
            decimal percentage = employeeService.GetDiscountPercentageBasedOnName("Biren");

            Assert.AreEqual(0, percentage);
        }

        [TestMethod]
        public void TestGetRelations()
        {
            Dictionary<int,string> dictRelation = employeeService.GetRelations();

            Assert.AreEqual(2, dictRelation.Count);
        }

        [TestMethod]
        public void TestCalculateCostOfBenefits_ForNetAnnualSalaryCalculationWithOutDependent_CaseWithDiscount()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel() {   
            Employee=new EmployeeBenefitsApp.Models.Employee { 
            EmployeeName=new EmployeeBenefitsApp.BaseClasses.Name { 
            FirstName="Alpha",
            LastName="Doe"
            }
            }            
            };

            employeeService.CalculateCostOfBenefit(employeeViewModel);

            decimal netSalaryAfterDeduction = 52000 - 900;

            Assert.AreEqual(netSalaryAfterDeduction, employeeViewModel.EmployeeAnnualNetSalaryAfterDeduction);
        }

        [TestMethod]
        public void TestCalculateCostOfBenefits_ForNetAnnualSalaryCalculationWithOutDependent_CaseWithOutDiscount()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new EmployeeBenefitsApp.Models.Employee
                {
                    EmployeeName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Bijay",
                        LastName = "Doe"
                    }
                }
            };

            employeeService.CalculateCostOfBenefit(employeeViewModel);

            decimal netSalaryAfterDeduction = 52000 - 1000;

            Assert.AreEqual(netSalaryAfterDeduction, employeeViewModel.EmployeeAnnualNetSalaryAfterDeduction);
        }

        [TestMethod]
        public void TestCalculateCostOfBenefits_ForNetAnnualSalaryCalculationWithDependent()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new EmployeeBenefitsApp.Models.Employee
                {
                    EmployeeName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Alpha",
                        LastName = "Doe"
                    },
                    Dependents = new List<DependentViewModel>()
                }

            };
            employeeViewModel.Employee.Dependents.Add(new DependentViewModel()
            {

                Dependent = new EmployeeBenefitsApp.Models.Dependent
                {
                    DependentName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Bihan",
                        LastName = "Doe"
                    }
                }

            });
            employeeService.CalculateCostOfBenefit(employeeViewModel);

            decimal netSalaryAfterDeduction = 52000 - 900 - 500; // 900 for employee and 500 for Dependent

            Assert.AreEqual(netSalaryAfterDeduction, employeeViewModel.EmployeeAnnualNetSalaryAfterDeduction);
        }

        [TestMethod]
        public void TestCalculateCostOfBenefits_ForTotalAnnualCostOfBenefitsForEmployee_WithOutDependent_CaseWithDiscount()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new EmployeeBenefitsApp.Models.Employee
                {
                    EmployeeName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Alpha",
                        LastName = "Doe"
                    }
                }
            };

            employeeService.CalculateCostOfBenefit(employeeViewModel);


            Assert.AreEqual(900, employeeViewModel.TotalAnnualCostOfBenefits);
        }

        [TestMethod]
        public void TestCalculateCostOfBenefits_ForTotalAnnualCostOfBenefitsForEmployee_WithOutDependent_CaseWithOutDiscount()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new EmployeeBenefitsApp.Models.Employee
                {
                    EmployeeName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Nia",
                        LastName = "Doe"
                    }
                }
            };

            employeeService.CalculateCostOfBenefit(employeeViewModel);


            Assert.AreEqual(1000, employeeViewModel.TotalAnnualCostOfBenefits);
        }


        [TestMethod]
        public void TestCalculateCostOfBenefits_For_PerPayCheckBenefitDeductionForEmployee()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new EmployeeBenefitsApp.Models.Employee
                {
                    EmployeeName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Nia",
                        LastName = "Doe"
                    }
                }
            };

            employeeService.CalculateCostOfBenefit(employeeViewModel);

            decimal perPayCheckCostOfDeduction = (decimal)1000 / 26;

            Assert.AreEqual(perPayCheckCostOfDeduction, employeeViewModel.PayCheckPeriodCostOfBenefits);
        }

        [TestMethod]
        public void TestCalculateCostOfBenefits_ForEmployeeAnnualTotalBenefitDeductionForDependents_CalculationWithOutDependent()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new EmployeeBenefitsApp.Models.Employee
                {
                    EmployeeName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Alpha",
                        LastName = "Doe"
                    }
                }
            };

            employeeService.CalculateCostOfBenefit(employeeViewModel);


            Assert.AreEqual(0, employeeViewModel.EmployeeAnnualTotalBenefitDeductionForDependents);
        }

        [TestMethod]
        public void TestCalculateCostOfBenefits_ForEmployeeAnnualTotalBenefitDeductionForDependents_CalculationWithDependentHavingDiscount()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new EmployeeBenefitsApp.Models.Employee
                {
                    EmployeeName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Alpha",
                        LastName = "Doe"
                    },
                    Dependents=new List<DependentViewModel>()
                }
                
            };
            employeeViewModel.Employee.Dependents.Add(new DependentViewModel()
            {

                Dependent = new EmployeeBenefitsApp.Models.Dependent
                {
                    DependentName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Arya",
                        LastName = "Doe"
                    }
                }

            });
            employeeService.CalculateCostOfBenefit(employeeViewModel);

            decimal perPayCheckDeductionForDependent =(decimal) 450 / 26;
            Assert.AreEqual(450, employeeViewModel.EmployeeAnnualTotalBenefitDeductionForDependents);
            Assert.AreEqual(perPayCheckDeductionForDependent, employeeViewModel.EmployeeTotalBenefitDeductionForDependentsPerPayCheck);
        }


        [TestMethod]
        public void TestCalculateCostOfBenefits_ForEmployeeAnnualTotalBenefitDeductionForDependents_MultipleScenario()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new EmployeeBenefitsApp.Models.Employee
                {
                    EmployeeName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Alpha",
                        LastName = "Doe"
                    },
                    Dependents = new List<DependentViewModel>()
                }

            };
            employeeViewModel.Employee.Dependents.Add(new DependentViewModel()
            {

                Dependent = new EmployeeBenefitsApp.Models.Dependent
                {
                    DependentName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Ajai",
                        LastName = "Doe"
                    }
                }

            });

            employeeViewModel.Employee.Dependents.Add(new DependentViewModel()
            {

                Dependent = new EmployeeBenefitsApp.Models.Dependent
                {
                    DependentName = new EmployeeBenefitsApp.BaseClasses.Name
                    {
                        FirstName = "Rohan",
                        LastName = "Doe"
                    }
                }

            });
            employeeService.CalculateCostOfBenefit(employeeViewModel);

            decimal perPayCheckDeductionForDependent = (decimal)950/ 26; //450 for Arya as name starts with A and 500 for Rohan 
            decimal employeeAnnualSalaryAfterDeduction = 52000 - 900 - 950;
            Assert.AreEqual(950, employeeViewModel.EmployeeAnnualTotalBenefitDeductionForDependents); //Test Total annual deduction for dependents
            Assert.AreEqual(perPayCheckDeductionForDependent, employeeViewModel.EmployeeTotalBenefitDeductionForDependentsPerPayCheck); //Per Paycheck
            Assert.AreEqual(employeeAnnualSalaryAfterDeduction, employeeViewModel.EmployeeAnnualNetSalaryAfterDeduction); //Net Salary after Deduction
        }
      
    }
}
