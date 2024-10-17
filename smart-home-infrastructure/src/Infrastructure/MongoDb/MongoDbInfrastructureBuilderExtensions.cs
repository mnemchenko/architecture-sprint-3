using Infrastructure.MongoDb.Contracts.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infrastructure.MongoDb;

public static class MongoDbInfrastructureBuilderExtensions
{
    public static void AddMongoDbInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            var mongoDbConnectionString = MongoUrl.Create(configuration.GetConnectionString("MongoDb"));

            var mongoDatabase = new MongoClient(mongoDbConnectionString)
                .GetDatabase(mongoDbConnectionString.DatabaseName);

            services.AddSingleton<MongoDbInfrastructure>(_ => new MongoDbInfrastructure
            {
                Database = mongoDatabase
            });
        }
        catch (Exception exception)
        {
            throw new MongoDbInfrastructureConfigurationException("Cannot configure MongoDb infrastructure", exception);
        }
    }
}