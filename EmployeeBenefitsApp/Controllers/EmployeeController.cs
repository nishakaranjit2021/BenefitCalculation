using EmployeeBenefitsApp.Services.Interfaces;
using EmployeeBenefitsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeBenefitsApp.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICommonService _commonService;
        public EmployeeController(IEmployeeService employeeService, ICommonService commonService)
        {
            _employeeService = employeeService;
            _commonService = commonService;

        }
        public ActionResult Index()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            { 
                States = _commonService.GetStates(),
                Employee = new Models.Employee()
                {
                    Dependents = new List<DependentViewModel>()
                }
            };
            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult Index(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CalculateCostOfBenefit(employeeViewModel);
                return View("Details", employeeViewModel);
            }
            employeeViewModel.States = _commonService.GetStates();
            return View(employeeViewModel);
        }

        public ActionResult AddNewDependentRow(int currentIndex)
        {
            var model = new DependentViewModel() 
            { 
                Index = currentIndex + 1,
                Relations = _employeeService.GetRelations()
            };
            return PartialView("_DependentRow", model);
        }
    }
}