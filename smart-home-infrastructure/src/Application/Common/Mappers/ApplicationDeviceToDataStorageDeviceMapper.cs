using Application.Contracts.Dto;
using Service.Contracts.DataStorage.Dto;

namespace Application.Common.Mappers;

public static class ApplicationDeviceToDataStorageDeviceMapper
{
    public static DeviceApplicationDto ApplyReverse(DeviceDataStorageDto deviceDataStorageDto)
    {
        return new DeviceApplicationDto
        {
            Id = deviceDataStorageDto.Id,
            SerialNumber = deviceDataStorageDto.SerialNumber,
            Name = deviceDataStorageDto.Name,
            Description = deviceDataStorageDto.Description,
            Status = deviceDataStorageDto.Status,
            CreatedAt = deviceDataStorageDto.CreatedAt
        };
    }
}