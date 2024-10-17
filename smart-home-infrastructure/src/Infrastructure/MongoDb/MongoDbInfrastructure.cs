using MongoDB.Driver;

namespace Infrastructure.MongoDb;

public class MongoDbInfrastructure
{
    public required IMongoDatabase Database { get; init; }
}
