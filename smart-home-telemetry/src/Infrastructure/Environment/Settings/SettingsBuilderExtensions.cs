using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Environment.Settings;

public static class SettingsBuilderExtensions
{
    /// <summary>
    /// Adds solution shared settings (appsettings.Shared.json) to an assembly.
    /// </summary>
    /// <param name="builder">>The target builder for adding the settings.</param>
    /// <param name="hostEnvironment">Contains current environment data for settings import.</param>
    public static void AddSharedSettings(this IConfigurationBuilder builder, IHostEnvironment hostEnvironment)
    {
        builder
            .SetBasePath(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) ?? string.Empty)
            .AddJsonFile("appsettings.Shared.json")
            .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.Shared.json", true);
    }
}