using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Devices.ChangeDeviceStatus;

public static class ChangeDeviceStatusApplicationBuilderExtensions
{
    public static void AddChangeDeviceStatusApplication(this IServiceCollection services)
    {
        services.AddSingleton<ChangeDeviceStatusApplication>();
    }
}