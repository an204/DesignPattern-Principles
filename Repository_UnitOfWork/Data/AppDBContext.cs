using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository_UnitOfWork.Etities;
using System.Configuration;
using System.Drawing;

namespace Repository_UnitOfWork.Data
{
    public class AppDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("connectionString"));
            base.OnConfiguring(options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Employee> Employee { get; set; }
    }
}
