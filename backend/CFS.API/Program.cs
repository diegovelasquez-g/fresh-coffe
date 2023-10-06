using CFS.API.OptionsSetup;
using CFS.BAL.Extensions;
using CFS.DAL.Data;
using CFS.DAL.Extensions;
using CFS.DTO.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("FCConnectionString");
builder.Services.AddDbContext<FreshCoffeeContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddInjectionDal(); 
builder.Services.AddInjectionDto();
builder.Services.AddInjectionBal();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

var app = builder.Build();

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
