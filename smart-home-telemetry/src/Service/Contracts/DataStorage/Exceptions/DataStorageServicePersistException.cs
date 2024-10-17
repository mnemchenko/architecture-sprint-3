namespace Service.Contracts.DataStorage.Exceptions;

public class DataStorageServicePersistException : Exception
{
    public DataStorageServicePersistException(string message, Exception exception)
        : base(message, exception)
    {
    }
}