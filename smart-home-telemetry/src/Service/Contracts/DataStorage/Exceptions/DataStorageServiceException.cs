namespace Service.Contracts.DataStorage.Exceptions;

public class DataStorageServiceException : Exception
{
    public DataStorageServiceException(string message, Exception exception)
        : base(message, exception)
    {
    }
}