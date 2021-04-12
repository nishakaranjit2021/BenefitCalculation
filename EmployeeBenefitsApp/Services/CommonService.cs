using EmployeeBenefitsApp.Common;
using EmployeeBenefitsApp.Repositories.Interfaces;
using EmployeeBenefitsApp.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.Services
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        public CommonService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }
        public IList<US_State> GetStates()
        {
            return _commonRepository.GetStates();
        }
    }
}