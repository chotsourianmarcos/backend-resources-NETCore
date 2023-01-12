using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

try
{
    var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
    var config = builder.Build();
    var connectionString = config.GetConnectionString("ServiceContext");

    var services = new ServiceCollection();
    services = ServiceContext.AddDbContextServiceFromConnString(services, connectionString);
    var serviceProvider = services.BuildServiceProvider();

    var newProduct = new Product();
    newProduct.Name = "Producto de Prueba";

    var serviceContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ServiceContext>();

    serviceContext.Set<Product>().Add(newProduct);
    serviceContext.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Upsi...");
}
