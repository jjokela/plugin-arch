using PluginTest.Core.Application.Interfaces;

namespace PluginTest.Plugin.ImageImporter;

public class ImageImporterPlugin : IImageImporter
{
    public string Name => "Image importer plugin";
    public string Description => "Imports an image";
    public void ImportImage(string imagePath)
    {
        Console.WriteLine($"Image imported from {imagePath}");
    }
}