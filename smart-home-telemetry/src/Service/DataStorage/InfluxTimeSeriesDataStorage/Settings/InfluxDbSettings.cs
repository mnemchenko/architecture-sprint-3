namespace Service.DataStorage.InfluxTimeSeriesDataStorage.Settings;

public class InfluxDbSettings
{
    public required string Url { get; set; }

    public required string Token { get; set; }

    public required string Organization { get; set; }

    public required string Bucket { get; set; }
}