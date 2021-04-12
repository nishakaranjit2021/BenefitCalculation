using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefitsApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        Dictionary<int, string> GetRelations();
        void CalculateCostOfBenefit(ViewModels.EmployeeViewModel employeViewModel);
    }
}
