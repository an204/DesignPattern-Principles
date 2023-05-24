using Microsoft.AspNetCore.Mvc;
using Repository_UnitOfWork.Etities;
using Repository_UnitOfWork.Repo;
using Repository_UnitOfWork.UOW;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Repository_UnitOfWork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();
        public EmployeeController()
        {
        }
        [HttpGet(Name = "GetEmployee")] 
        public IEnumerable<Employee> Get()
        {
            return UnitOfWork.EmployeeRepo.Get();
        }
    }
}
