namespace PluginTest.Core.Application.Interfaces;

public interface IPluginService
{
    public List<T> GetPluginsOfType<T>() where T : IPlugin;
}