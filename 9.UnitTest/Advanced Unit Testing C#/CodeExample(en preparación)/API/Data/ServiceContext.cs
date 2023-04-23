using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using API.Models.Entities;

namespace API.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<OrderItem> Orders { get; set; }
        public DbSet<ProductItem> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<OrderItem>(user =>
            {
                user.ToTable("t_orders");
            });

            builder.Entity<ProductItem>(user =>
            {
                user.ToTable("t_products");
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
