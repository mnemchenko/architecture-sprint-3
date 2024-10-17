using System.Text.Json.Serialization;
using Domain.Enums;

namespace Handler.WebApi.Features.Devices.ChangeDeviceStatus;

public class ChangeDeviceStatusRequest
{
    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DeviceStatus Status { get; set; }
}