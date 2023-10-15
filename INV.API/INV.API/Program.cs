using INV.DomainLayer.Data;
using INV.DomainLayer.DTOs.Common;
using INV.DomainLayer.Models;
using INV.RepositoryLayer.Repository;
using INV.ServiceLayer.Implementation;
using INV.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConStringDTO.INVConnectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryService<UserRole>, RepositoryService<UserRole>>();
builder.Services.AddScoped<IRepositoryService<UserModel>, RepositoryService<UserModel>>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();

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
