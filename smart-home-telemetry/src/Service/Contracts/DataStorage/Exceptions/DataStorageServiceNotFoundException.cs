namespace Service.Contracts.DataStorage.Exceptions;

public class DataStorageServiceNotFoundException : Exception
{
    public DataStorageServiceNotFoundException(string message)
        : base(message)
    {
    }
}