using System.Text.Json.Serialization;

namespace Handler.WebApi.Features.Telemetry.AddPoint;

public class AddPointRequest
{
    [JsonPropertyName("deviceId")]
    public Guid DeviceId { get; set; }

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("measurement")]
    public string Measurement { get; set; }

    [JsonPropertyName("fieldName")]
    public string FieldName { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }
}