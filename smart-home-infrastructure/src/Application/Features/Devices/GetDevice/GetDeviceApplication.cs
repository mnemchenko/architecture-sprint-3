using Application.Common.Mappers;
using Application.Contracts.Dto;
using Application.Contracts.Exceptions;
using Service.Contracts.DataStorage;

namespace Application.Features.Devices.GetDevice;

public class GetDeviceApplication(
    IDataStorage dataStorage)
{
    public async Task<DeviceApplicationDto> GetDeviceAsync(Guid deviceId, CancellationToken cancellationToken)
    {
        try
        {
            return ApplicationDeviceToDataStorageDeviceMapper.ApplyReverse(
                await dataStorage.GetDeviceAsync(deviceId, cancellationToken));
        }
        catch (Exception exception)
        {
            throw new InfrastructureServiceApplicationException("Failed to get device", exception);
        }
    }
}