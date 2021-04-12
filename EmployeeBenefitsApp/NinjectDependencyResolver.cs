using EmployeeBenefitsApp.Repositories;
using EmployeeBenefitsApp.Repositories.Interfaces;
using EmployeeBenefitsApp.Services;
using EmployeeBenefitsApp.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeBenefitsApp
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICommonService>().To<CommonService>();
            kernel.Bind<ICommonRepository>().To<CommonRepository>();

            kernel.Bind<IEmployeeService>().To<EmployeeService>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
        }
    }
}