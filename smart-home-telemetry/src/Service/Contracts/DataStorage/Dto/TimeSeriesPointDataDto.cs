namespace Service.Contracts.DataStorage.Dto;

public class TimeSeriesPointDataDto
{
    public Guid DeviceId { get; set; }

    public DateTime Time { get; set; }

    public string Measurement { get; set; }

    public string FieldName { get; set; }

    public double Value { get; set; }
}