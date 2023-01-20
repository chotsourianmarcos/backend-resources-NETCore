using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<OrderItem> Orders { get; set; }
        public DbSet<PersonItem> Persons { get; set; }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<EmployeeItem> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductItem>()
            .ToTable("Products");

            builder.Entity<OrderItem>()
            .ToTable("Orders")
            .HasOne<ProductItem>()
            .WithMany()
            .HasForeignKey(o => o.ProductId);

            builder.Entity<PersonItem>()
            .ToTable("Persons");

            builder.Entity<UserItem>()
            .ToTable("Users");

            builder.Entity<EmployeeItem>()
            .ToTable("Employees");
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
