using Domain.Enums;

namespace Service.Contracts.DataStorage.Dto;

public class DeviceDataStorageDto
{
    public Guid Id { get; set; }

    public string SerialNumber { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DeviceStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}