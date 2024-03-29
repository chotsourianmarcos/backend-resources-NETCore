﻿using Entities.Entities;
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
        public DbSet<PersonItem> Persons { get; set; }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<EmployeeItem> Employees { get; set; }
        public DbSet<UserRolItem> UserRols { get; set; }
        public DbSet<ContractItem> Contracts { get; set; }
        public DbSet<JobItem> Jobs { get; set; }
        public DbSet<AreaItem> Areas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonItem>()
            .ToTable("Persons");

            builder.Entity<UserItem>(user =>
            {
                user.ToTable("Users");
                user.HasOne<PersonItem>().WithMany().HasForeignKey(u => u.IdPerson);
                user.HasOne<UserRolItem>().WithMany().HasForeignKey(u => u.IdRol);
            });

            builder.Entity<UserRolItem>()
            .ToTable("UserRols");

            builder.Entity<EmployeeItem>(employee =>
            {
                employee.ToTable("Employees");

                //esto me obliga a poner a la clase empleado como atributo de la clase Persona
                //por eso no lo hago así
                //employee.HasOne<PersonItem>().WithOne().HasForeignKey(e => e.IdPerson);
                employee.HasOne<PersonItem>().WithMany().HasForeignKey(e => e.IdPerson);
                employee.HasIndex(c => c.IdPerson).IsUnique();

                employee.HasOne<JobItem>().WithMany().HasForeignKey(e => e.IdJob);

                employee.HasOne<ContractItem>().WithMany().HasForeignKey(e => e.IdContract);
            });

            builder.Entity<ContractItem>()
            .ToTable("Contracts");

            builder.Entity<JobItem>()
            .ToTable("Jobs")
            .HasOne<AreaItem>().WithMany().HasForeignKey(e => e.IdArea);

            builder.Entity<AreaItem>()
            .ToTable("Areas");
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
