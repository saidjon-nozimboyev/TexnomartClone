using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TexnomartClone.Application.Common.Validators;
using TexnomartClone.Application.Interfaces;
using TexnomartClone.Application.Services;
using TexnomartClone.Configurations;
using TexnomartClone.Data.DbContexts;
using TexnomartClone.Data.Interfaces;
using TexnomartClone.Data.Repositories;
using TexnomartClone.Domain.Entities;
using TexnomartClone.Domain.Enums;
using TexnomartClone.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
//Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Unit Of Work
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAuthManager, AuthManager>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IEmailService, EmailService>();

// Configure
builder.Services.ConfigureJwtAuthorize(builder.Configuration);
builder.Services.ConfigureSwaggerAuthorize(builder.Configuration);

//Validator
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<Order>,OrderValidator>();



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

app.UseMiddleware<ExceptionsHadle>();

app.MapControllers();

app.Run();
