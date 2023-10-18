using INV.DomainLayer.Data;
using INV.DomainLayer.DTOs.Common;
using INV.DomainLayer.Models;
using INV.RepositoryLayer.Repository;
using INV.ServiceLayer.Implementation;
using INV.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConStringDTO.INVConnectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("INV", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    JwtCredentialsDTO jwtCredentialsDTO = new JwtCredentialsDTO();
    var Issuer = builder.Configuration.GetSection(jwtCredentialsDTO.Issuer).ToString();
    var Key = builder.Configuration.GetSection(jwtCredentialsDTO.Key).Get<string>();
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Issuer,
        ValidAudience = Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
    };
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
