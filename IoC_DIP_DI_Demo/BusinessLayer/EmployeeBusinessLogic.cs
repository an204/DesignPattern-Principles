using IoC_DIP_DI_Demo.DataAcessLayer;
using IoC_DIP_DI_Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_DIP_DI_Demo.BusinessLayer
{
    internal class EmployeeBusinessLogic
    {
        IEmployeeDataAccess _EmployeeDataAccess;
        public EmployeeBusinessLogic(IEmployeeDataAccess dataAccess)
        {
            _EmployeeDataAccess = dataAccess;
        }
        public Employee GetEmployeeDetails(int id)
        {
            return _EmployeeDataAccess.GetEmployeeDetails(id);
        }
    }
}
