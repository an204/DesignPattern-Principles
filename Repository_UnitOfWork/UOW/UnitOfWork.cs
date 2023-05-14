using Repository_UnitOfWork.Repo;
using Repository_UnitOfWork.Data;
using Repository_UnitOfWork.Etities;

namespace Repository_UnitOfWork.UOW
{
    //Generic UnitOfWork Class. 
    //While Creating an Instance of the UnitOfWork object, we need to specify the actual type for the TContext Generic Type
    //In our example, TContext is going to be EmployeeDBContext
    //new() constraint will make sure that this type is going to be a non-abstract type with a parameterless constructor
    public class UnitOfWork : IDisposable
    {
        public AppDBContext _context { get; set; }

        private GenericRepository<Employee> employeeRepo;
        public UnitOfWork()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            string conn = configuration.GetConnectionString("connectionString");

            this._context = new AppDBContext(configuration);
        }

        public GenericRepository<Employee> EmployeeRepo
        {
            get
            {

                if (this.employeeRepo == null)
                {
                    this.employeeRepo = new GenericRepository<Employee>(_context);
                }
                return employeeRepo;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
