using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Contracts.DataStorage;
using Service.DataStorage.InfluxTimeSeriesDataStorage.Settings;

namespace Service.DataStorage.InfluxTimeSeriesDataStorage;

public static class InfluxTimeSeriesDataStorageBuilderExtensions
{
    public static void AddInfluxTimeSeriesDataStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<InfluxDbSettings>(configuration.GetSection("InfluxDb"));

        services.AddSingleton<ITimeSeriesDataStorage, InfluxTimeSeriesDataStorage>();
    }
}