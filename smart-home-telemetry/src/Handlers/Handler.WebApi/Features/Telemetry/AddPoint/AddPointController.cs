using Application.Contracts.Dto;
using Application.Features.Telemetry.AddPoint;
using Microsoft.AspNetCore.Mvc;

namespace Handler.WebApi.Features.Telemetry.AddPoint;

[ApiController]
[Tags("Telemetry")]
public class AddPointController(
    AddPointApplication application) : ControllerBase
{
    [HttpPost("/telemetry")]
    public async Task<IActionResult> AddPointAsync(
        CancellationToken cancellationToken,
        [FromBody] AddPointRequest request)
    {
        try
        {
            await application.AddPointAsync(
                new TelemetryPointDto
                {
                    DeviceId = request.DeviceId,
                    Time = request.Time,
                    Measurement = request.Measurement,
                    FieldName = request.FieldName,
                    Value = request.Value,
                },
                cancellationToken);

            return Created();
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}