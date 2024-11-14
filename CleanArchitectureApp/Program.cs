using CleanArchitectureApp;
using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Domain.Interfaces;
using CleanArchitectureApp.Infrastructure.Data;
using CleanArchitectureApp.Infrastructure.Repositories;
using CleanArchitectureApp.Infrastructure.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-8CV7N11;Database=CleanArchitectureApp;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IJwtTokenHelper, JwtTokenHelper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

/// Configure authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
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

app.UseStaticFiles();
// Use CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
