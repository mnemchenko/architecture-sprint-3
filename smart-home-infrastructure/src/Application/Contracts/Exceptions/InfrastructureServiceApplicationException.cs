namespace Application.Contracts.Exceptions;

public class InfrastructureServiceApplicationException : Exception
{
    public InfrastructureServiceApplicationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}