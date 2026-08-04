using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProductApp.Application.Common.Behaviors;
using MyProductApp.Application.Interfaces.Identity;
using MyProductApp.Application.Interfaces.Repositories;
using MyProductApp.Infrastructure.Identity;
using MyProductApp.Infrastructure.Persistence;
using MyProductApp.Infrastructure.Repositories;
using MyProductApp.Infrastructure.Services.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Config DbContext SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")?? "Data Source=products.db"));

//Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMatriculaRoleRepository, MatriculaRoleRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

//MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("MyProductApp.Application")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(IProductRepository).Assembly);

//Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    //Regras de senha
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase =true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    //Regra de Usuário
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


//Validation Behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

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
