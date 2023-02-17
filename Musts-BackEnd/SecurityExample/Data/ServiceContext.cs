using Entities.Entities;
using Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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
        public DbSet<UserItem> Users { get; set; }
        public DbSet<UserRolItem> UserRols { get; set; }
        public DbSet<AuthorizationItem> UserAuthorizations { get; set; }
        public DbSet<RolAuthorization> RolsAuthorizations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserItem>(user =>
            {
                user.ToTable("Users");
                user.HasOne<UserRolItem>().WithMany().HasForeignKey(u => u.IdRol);
            });

            builder.Entity<UserRolItem>(user =>
            {
                user.ToTable("UserRols");
            });

            builder.Entity<AuthorizationItem>(user =>
            {
                user.ToTable("EndpointAuthorizations");
            });

            builder.Entity<RolAuthorization>(user =>
            {
                user.ToTable("Rols_Authorizations");
                user.HasOne<UserRolItem>().WithMany().HasForeignKey(a => a.IdRol);
                user.HasOne<AuthorizationItem>().WithMany().HasForeignKey(a => a.IdAuthorization);
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
