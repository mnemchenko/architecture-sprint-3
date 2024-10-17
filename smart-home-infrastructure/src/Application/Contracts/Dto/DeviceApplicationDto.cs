using Domain.Enums;

namespace Application.Contracts.Dto;

public class DeviceApplicationDto
{
    public Guid Id { get; set; }

    public string SerialNumber { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DeviceStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}