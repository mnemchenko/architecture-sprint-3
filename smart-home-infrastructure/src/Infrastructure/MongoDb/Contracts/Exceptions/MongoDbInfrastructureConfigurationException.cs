namespace Infrastructure.MongoDb.Contracts.Exceptions;

public class MongoDbInfrastructureConfigurationException : Exception
{
    public MongoDbInfrastructureConfigurationException(string message, Exception exception)
        : base(message, exception)
    {
    }
}