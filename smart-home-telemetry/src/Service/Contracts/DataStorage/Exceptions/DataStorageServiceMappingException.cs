namespace Service.Contracts.DataStorage.Exceptions;

public class DataStorageServiceMappingException : Exception
{
    public DataStorageServiceMappingException(string message, Exception exception)
        : base(message, exception)
    {
    }
}