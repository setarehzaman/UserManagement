using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.AppService;
using UserManagement.Domain.Core.Contracts.AppService;
using UserManagement.Domain.Core.Contracts.Repository;
using UserManagement.Domain.Core.Contracts.Service;
using UserManagement.Domain.Service;
using UserManagement.Infrastructure.EF;
using UserManagement.Infrastructure.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string? connectionString = builder.Configuration.GetConnectionString("UserManagement");
builder.Services.AddDbContext<UserManagementDbContext>(o => o
    .UseSqlServer(connectionString));

builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
