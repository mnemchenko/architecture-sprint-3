using Application.Contracts.Exceptions;
using Domain.Enums;
using Service.Contracts.DataStorage;

namespace Application.Features.Devices.ChangeDeviceStatus;

public class ChangeDeviceStatusApplication(
    IDataStorage dataStorage)
{
    public async Task ChangeDeviceStatusAsync(Guid deviceId, DeviceStatus status, CancellationToken cancellationToken)
    {
        try
        {
            await dataStorage.ChangeDeviceStatusAsync(deviceId, status, cancellationToken);
        }
        catch (Exception exception)
        {
            throw new InfrastructureServiceApplicationException("Failed to change device status", exception);
        }
    }
}