﻿using IoC_DIP_DI_Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_DIP_DI_Demo.DataAcessLayer
{
    internal class EmployeeDataAccess : IEmployeeDataAccess
    {
        public Employee GetEmployeeDetails(int id)
        {
            // In real-time get the employee details from db
            //but here we are hard coded the employee details
            Employee emp = new Employee()
            {
                ID = id,
                Name = "Pranaya",
                Department = "IT",
                Salary = 10000
            };
            return emp;
        }
    }
}
