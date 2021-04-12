using EmployeeBenefitsApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.Repositories.Interfaces
{
    public interface ICommonRepository
    {
        IList<US_State> GetStates();
    }
}