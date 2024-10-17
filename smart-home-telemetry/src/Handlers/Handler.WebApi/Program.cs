using System.Reflection;
using Application.Features.Telemetry.AddPoint;
using Infrastructure.Environment.Settings;
using Service.DataStorage.InfluxTimeSeriesDataStorage;

var builder = WebApplication.CreateBuilder(args);

// Add configuration to the container

builder.Configuration.AddSharedSettings(builder.Environment);

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddInfluxTimeSeriesDataStorage(builder.Configuration);

builder.Services.AddAddPointApplication();

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