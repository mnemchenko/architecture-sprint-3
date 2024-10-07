namespace Application.Contracts.Dto;

public class TelemetryPointDto
{
    public Guid DeviceId { get; set; }

    public DateTime Time { get; set; }

    public string Measurement { get; set; }

    public string FieldName { get; set; }

    public double Value { get; set; }
}