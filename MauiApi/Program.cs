using Core.Interfaces;
using Infrastructure.Config.IoC;
using Infrastructure.Data;
using Infrastructure.Repositorys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharedComponents.Model;
using Stashbox;
using System.ComponentModel;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlServer();

builder.Services.Configure<ConfigurationModel>(
    builder.Configuration.GetSection("Jwt")
);

//Register the self hosting API
//var config = new HttpSelfHostConfiguration("http://localhost:8080"); //TODO: take this from appsettings.js
//config.Routes.MapHttpRoute(
//    "API Default", "api/{controller}/{id}", 
//    new { id = RouteParameter.Optional });

//using (HttpSelfHostServer server = new HttpSelfHostServer(config))
//{
//    server.OpenAsync().Wait();
//}
builder.Host.UseStashbox();
builder.Host.ConfigureContainer<IStashboxContainer>((context, container) =>
{
    container.AddDependencies(context.Configuration);
});

builder.Host.ConfigureServices((hostContext, services) =>
{
    services.AddDbContextPool<MauiContext>(option =>
        option.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.CommandTimeout(120)).EnableSensitiveDataLogging());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
