using Application.Features.Devices.ChangeDeviceStatus;
using Microsoft.AspNetCore.Mvc;

namespace Handler.WebApi.Features.Devices.ChangeDeviceStatus;

public class ChangeDeviceStatusController(
    ChangeDeviceStatusApplication application) : ControllerBase
{
    [HttpPut("/devices/{deviceId}/status")]
    public async Task<IActionResult> ChangeStatusAsync(
        CancellationToken cancellationToken,
        [FromRoute] Guid deviceId,
        [FromBody] ChangeDeviceStatusRequest request)
    {
        try
        {
            await application.ChangeDeviceStatusAsync(deviceId, request.Status, cancellationToken);

            return Ok();
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}