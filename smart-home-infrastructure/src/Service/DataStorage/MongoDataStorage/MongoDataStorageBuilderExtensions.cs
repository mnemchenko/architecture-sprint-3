using Microsoft.Extensions.DependencyInjection;
using Service.Contracts.DataStorage;

namespace Service.DataStorage.MongoDataStorage;

public static class MongoDataStorageBuilderExtensions
{
    public static void AddMongoDataStorage(this IServiceCollection services)
    {
        services.AddSingleton<IDataStorage, MongoDataStorage>();
    }
}