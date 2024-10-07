using Application.Features.Devices.GetDevice;
using Microsoft.AspNetCore.Mvc;

namespace Handler.WebApi.Features.Devices.GetDeviceDetails;

public class GetDeviceDetailsController(
    GetDeviceApplication application) : ControllerBase
{
    [HttpGet("devices/{deviceId}")]
    public async Task<IActionResult> GetDeviceDetailsAsync(
        CancellationToken cancellationToken,
        [FromRoute] Guid deviceId)
    {
        try
        {
            var device = await application.GetDeviceAsync(deviceId, cancellationToken);

            return Ok(new DeviceResponse
            {
                Id = device.Id,
                Name = device.Name ?? string.Empty,
                Description = device.Description,
                SerialNumber = device.SerialNumber,
                Status = device.Status.ToString(),
                CreatedAt = device.CreatedAt,
            });
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}