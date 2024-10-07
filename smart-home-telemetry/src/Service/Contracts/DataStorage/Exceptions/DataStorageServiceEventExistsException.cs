namespace Service.Contracts.DataStorage.Exceptions;

public class DataStorageServiceEventExistsException : Exception
{
    public DataStorageServiceEventExistsException(string message)
        : base(message)
    {
    }
}