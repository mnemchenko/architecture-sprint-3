namespace Application.Contracts.Exceptions;

public class TelemetryApplicationException : Exception
{
    public TelemetryApplicationException(string message)
        : base(message)
    {
    }

    public TelemetryApplicationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}