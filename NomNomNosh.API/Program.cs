using Microsoft.EntityFrameworkCore;
using NomNomNosh.API.Config;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Application.Services;
using NomNomNosh.Application.Utils;
using NomNomNosh.Application.Utils.Interface;
using NomNomNosh.Infrastructure.Data;
using NomNomNosh.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NomNomNosh.API"))
);

// Services & Repo
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

// Utils DI
builder.Services.AddScoped<IEmailValidator, EmailValidator>();
builder.Services.AddSingleton<IErrorHandler, ErrorHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
