namespace Service.Contracts.DataStorage.Exceptions;

public class DataStorageServiceConfigurationException : Exception
{
    public DataStorageServiceConfigurationException(string message)
        : base(message)
    {
    }
}