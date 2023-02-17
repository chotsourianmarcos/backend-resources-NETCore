using API.IServices;
using API.Services;
using Data;
using Logic.ILogic;
using Logic.Logic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Security.IServices;
using Security.Services;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserSecurityService, UserSecurityService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserSecurityLogic, UserSecurityLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();

builder.Services.AddDbContext<ServiceContext>(
        options => options.UseSqlServer("name=ConnectionStrings:ServiceContext"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) => {
    //también habría que validar url, captcha, que no haya muchos reintentos, locación segura, etcs.
    //esto no va así acá pero bue
    //esto no sé si va así pero bue
    var controller = context.GetRouteData().Values["controller"].ToString();
    var action = context.GetRouteData().Values["action"].ToString();
    if (!(controller == "User" && action == "Login"))
    {
        var serviceScope = app.Services.CreateScope();
        var userSecurityService = serviceScope.ServiceProvider.GetRequiredService<IUserSecurityService>();
        userSecurityService.ValidateUserToken(context.Request.Headers.Authorization.ToString(),
                                          controller,
                                          action,
                                          context.Request.Method.ToString());
    }
    await next();
    //after request. logging etcs.
});

app.UseHttpsRedirection();

//lo de arriba no iría acá? verlo...
app.UseAuthorization();

app.MapControllers();

app.Run();