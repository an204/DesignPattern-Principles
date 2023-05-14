using IoC_DIP_DI_Demo.BusinessLayer;
using IoC_DIP_DI_Demo.DataAcessLayer;
using IoC_DIP_DI_Demo.Entities;
using Microsoft.Practices.Unity;

namespace IoC_DIP_DI_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IEmployeeDataAccess, EmployeeDataAccess>();

            EmployeeBusinessLogic BL = new EmployeeBusinessLogic(unityContainer.Resolve<EmployeeDataAccess>());
            Employee employeeDetails = BL.GetEmployeeDetails(1);
            Console.WriteLine();
            Console.WriteLine("Employee Details:");
            Console.WriteLine("ID : {0}, Name : {1}, Department : {2}, Salary : {3}",
                                employeeDetails.ID, employeeDetails.Name, employeeDetails.Department,
                                employeeDetails.Salary);
            Console.WriteLine("Press any key to exist.");
            Console.ReadKey();
        }
    }
    

    

}