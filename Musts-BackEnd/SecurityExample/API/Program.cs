using API.IServices;
using API.Services;
using Logic.ILogic;
using Logic.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Security.IServices;
using Security.Services;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

IUserSecurityService userSecurityService = (IUserSecurityService)app.Services.GetServices(typeof(IUserSecurityService)).First();

app.Use(async (context, next) => {
    //también habría que validar url, captcha, que no haya muchos reintentos, locación segura, etcs.
    userSecurityService.ValidateUserToken(context.Request.Headers.Authorization.ToString(),
                                          context.GetRouteData().Values["controller"].ToString(),
                                          context.GetRouteData().Values["action"].ToString(),
                                          context.Request.Method);
    await next();
    //after request. logging etcs.
});

app.UseHttpsRedirection();

//lo de arriba no iría acá? verlo...
app.UseAuthorization();

app.MapControllers();

app.Run();