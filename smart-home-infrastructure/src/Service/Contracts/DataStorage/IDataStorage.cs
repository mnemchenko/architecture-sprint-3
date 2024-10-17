using Domain.Enums;
using Service.Contracts.DataStorage.Dto;

namespace Service.Contracts.DataStorage;

public interface IDataStorage
{
    public Task<DeviceDataStorageDto> GetDeviceAsync(Guid deviceId, CancellationToken cancellationToken = default);

    public Task ChangeDeviceStatusAsync(Guid deviceId, DeviceStatus status, CancellationToken cancellationToken = default);
}