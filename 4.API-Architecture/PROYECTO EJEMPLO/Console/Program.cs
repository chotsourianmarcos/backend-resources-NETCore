// See https://aka.ms/new-console-template for more information
using Data;
using Entities.Entities;
using Logic.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, Console!");

var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
var config = builder.Build();
var connectionString = config.GetConnectionString("ServiceContext");

var services = new ServiceCollection();
services = ServiceContext.AddDbContextServiceFromConnString(services, connectionString);
var serviceProvider = services.BuildServiceProvider();

try
{
    Console.WriteLine("Insertando Producto...");
    var newProduct = new ProductItem();
    var curriculumLogic = new ProductLogic(serviceProvider);
    newProduct.Id = 0;
    newProduct.IdWeb = Guid.NewGuid();
    newProduct.InsertDate = DateTime.Now;
    newProduct.UpdateDate = null;
    curriculumLogic.InsertProductItem(newProduct);
    Console.WriteLine("Producto insertado...");
}
catch (Exception e)
{
    Console.WriteLine("Ups...");
}
