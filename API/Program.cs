using API.Contracts;
using API.Data;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using API.Utilities.SampleData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HumanResourcesDbContext>(options => options.UseSqlServer(connectionString));

// Add repositories to container
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobHistoryRepository, JobHistoryRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// JWT Services
builder.Services.AddScoped<IJWTokenHandler, JWTokenHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Staff", policy =>
        policy.RequireRole("Staff"));
    options.AddPolicy("Manager", policy =>
        policy.RequireRole("Manager"));
    options.AddPolicy("Admin", policy =>
        policy.RequireRole("Admin"));

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
