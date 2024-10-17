using Service.Contracts.DataStorage.Dto;
using Service.DataStorage.MongoDataStorage.Documents;

namespace Service.Common.Mappers;

public static class DataStorageDeviceToDocumentDeviceMapper
{
    public static DeviceDataStorageDto ApplyReverse(DeviceDocument documentDevice)
    {
        return new DeviceDataStorageDto
        {
            Id = Guid.Parse(documentDevice.Id),
            SerialNumber = documentDevice.SerialNumber,
            Name = documentDevice.Name,
            Description = documentDevice.Description,
            Status = documentDevice.Status,
            CreatedAt = documentDevice.CreatedAt
        };
    }
}