using CFS.BAL.Contracts;
using CFS.BAL.Services;
using CFS.DAL.Contracts;
using CFS.DAL.Data;
using CFS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Database
var connectionString = builder.Configuration.GetConnectionString("FCConnectionString");
builder.Services.AddDbContext<FreshCoffeeContext>(options => options.UseNpgsql(connectionString));

//DAL
builder.Services.AddScoped<IUserRepository, UserRepository>();  

//BAL
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

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
