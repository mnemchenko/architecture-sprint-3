namespace Service.Contracts.DataStorage.Exceptions;

public class DataStorageServiceConnectionException : Exception
{
    public DataStorageServiceConnectionException(string message, Exception exception)
        : base(message, exception)
    {
    }
}