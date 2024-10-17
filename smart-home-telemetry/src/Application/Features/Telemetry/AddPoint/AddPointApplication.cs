using Application.Contracts.Dto;
using Application.Contracts.Exceptions;
using Service.Contracts.DataStorage;
using Service.Contracts.DataStorage.Dto;

namespace Application.Features.Telemetry.AddPoint;

public class AddPointApplication(
    ITimeSeriesDataStorage timeSeriesDataStorage)
{
    public async Task AddPointAsync(
        TelemetryPointDto telemetryPoint,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await timeSeriesDataStorage.AddTimeSeriesDataAsync(
                new TimeSeriesPointDataDto
                {
                    DeviceId = telemetryPoint.DeviceId,
                    Time = telemetryPoint.Time,
                    Measurement = telemetryPoint.Measurement,
                    FieldName = telemetryPoint.FieldName,
                    Value = telemetryPoint.Value,
                },
                cancellationToken);
        }
        catch (Exception exception)
        {
            throw new TelemetryApplicationException("Failed to add telemetry point", exception);
        }
    }
}