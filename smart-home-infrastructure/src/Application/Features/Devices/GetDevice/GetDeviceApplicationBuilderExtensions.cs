using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Devices.GetDevice;

public static class GetDeviceApplicationBuilderExtensions
{
    public static void AddGetDeviceApplication(this IServiceCollection services)
    {
        services.AddSingleton<GetDeviceApplication>();
    }
}