using System.Reflection;
using Application.Features.Devices.ChangeDeviceStatus;
using Application.Features.Devices.GetDevice;
using Infrastructure.Environment.Settings;
using Infrastructure.MongoDb;
using Microsoft.OpenApi.Models;
using Service.DataStorage.MongoDataStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSharedSettings(builder.Environment);

builder.Configuration.AddEnvironmentVariables();

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMongoDbInfrastructure(builder.Configuration);

builder.Services.AddMongoDataStorage();

builder.Services.AddGetDeviceApplication();

builder.Services.AddChangeDeviceStatusApplication();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();