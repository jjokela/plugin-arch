using PluginTest.Core.Application.Interfaces;

namespace PluginTest.Core.Application.Services;

// NEEDS to be IEnumerable, if using a List<>, then plugins would have to be instantiated and registered like so:
/*
var plugins = new List<IPlugin>
{
    // You need to instantiate your plugins here
    // new SomePlugin(),
    // new AnotherPlugin(),
};

// Register the list of plugins as a singleton service
builder.Services.AddSingleton(plugins);
 */
public class PluginService(IEnumerable<IPlugin> plugins) : IPluginService
{
    public List<T> GetPluginsOfType<T>() where T : IPlugin
    {
        var typedPlugins = new List<T>();

        foreach (var plugin in plugins)
        {
            if (plugin is T typedPlugin)
            {
                typedPlugins.Add(typedPlugin);
            }
        }

        return typedPlugins;
    }
}