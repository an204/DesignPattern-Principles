using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository_UnitOfWork.Data;
using Repository_UnitOfWork.Middleware;
using Repository_UnitOfWork.Repo;
using System.Configuration;

namespace Repository_UnitOfWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("connectionString")));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSession();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMvc();

            var app = builder.Build();
            app.UseSession();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // authenticate login to swagger
                app.UseSwaggerAuthorized();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllerRoute(
            name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}