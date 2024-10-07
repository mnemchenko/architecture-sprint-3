using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Telemetry.AddPoint;

public static class AddPointApplicationBuilderExtensions
{
    public static void AddAddPointApplication(this IServiceCollection services)
    {
        services.AddSingleton<AddPointApplication>();
    }
}