using CFS.API.OptionsSetup;
using CFS.BAL.Contracts;
using CFS.BAL.Services;
using CFS.DAL.Contracts;
using CFS.DAL.Data;
using CFS.DAL.Repositories;
using CFS.DTO.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Database
var connectionString = builder.Configuration.GetConnectionString("FCConnectionString");
builder.Services.AddDbContext<FreshCoffeeContext>(options => options.UseNpgsql(connectionString));

//DAL
builder.Services.AddScoped<IUserRepository, UserRepository>();

//DTO   
builder.Services.AddAutoMapper(typeof(UserMappingsProfile));

//BAL
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

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
