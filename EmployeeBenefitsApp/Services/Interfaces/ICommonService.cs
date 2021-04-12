using EmployeeBenefitsApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.Services.Interfaces
{
    public interface ICommonService
    {
        IList<US_State> GetStates();
    }
}