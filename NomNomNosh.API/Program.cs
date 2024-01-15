using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

using NomNomNosh.API.Config.Auth;
using NomNomNosh.API.Config.Authentication;
using NomNomNosh.API.Config.ErrorHandler;

using NomNomNosh.Application.Interfaces;
using NomNomNosh.Application.Services;

using NomNomNosh.Infrastructure.Data;
using NomNomNosh.Infrastructure.Repositories;
using NomNomNosh.Infrastructure.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NomNomNosh.API"))
);

// Services & Repo
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddScoped<IRecipeStepRepository, RecipeStepRepository>();
builder.Services.AddScoped<IRecipeStepService, RecipeStepService>();

builder.Services.AddScoped<IRecipeCommentRepository, RecipeCommentRepository>();
builder.Services.AddScoped<IRecipeCommentService, RecipeCommentService>();

// Utils DI
builder.Services.AddSingleton<IErrorHandler, ErrorHandler>();
builder.Services.AddScoped<IUtils, Utils>();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
