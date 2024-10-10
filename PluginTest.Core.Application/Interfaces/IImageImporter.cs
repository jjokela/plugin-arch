namespace PluginTest.Core.Application.Interfaces
{
    public interface IImageImporter : IPlugin
    {
        public void ImportImage(string imagePath);
    }
}
