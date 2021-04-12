using EmployeeBenefitsApp.Common;
using EmployeeBenefitsApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        public CommonRepository()
        { 
        
        }

        public IList<US_State> GetStates()
        {
            return USState.States();
        }
    }
}