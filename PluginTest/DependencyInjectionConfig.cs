using Microsoft.Extensions.DependencyInjection;
using PluginTest.Core.Application.Interfaces;
using PluginTest.Core.Application.Services;
using PluginTest.Plugin.ImageImporter;
using PluginTest.Plugin.ReverseText;
using PluginTest.Plugin.Uppercase;

namespace PluginTest.Core.Presentation;

public class DependencyInjectionConfig
{
    public static ServiceProvider ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();
        // Register PluginService
        serviceCollection.AddTransient<IPluginService, PluginService>();
        // Register plugins
        serviceCollection.AddSingleton<IPlugin, ImageImporterPlugin>();
        serviceCollection.AddSingleton<IPlugin, ReverseTextPlugin>();
        serviceCollection.AddSingleton<IPlugin, UppercasePlugin>();



        //services.AddTransient<IPatientController, PatientController>();

        // Build and return the service provider
        return serviceCollection.BuildServiceProvider();
    }
}