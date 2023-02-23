using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using API.Models.Entities;

namespace API.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<EmployeeItem> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<EmployeeItem>(employee =>
            {
                employee.ToTable("t_employees");
            });
        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }
    }
}
