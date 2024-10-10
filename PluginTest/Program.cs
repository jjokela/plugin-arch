using Microsoft.Extensions.DependencyInjection;
using PluginTest.Core.Application.Interfaces;

namespace PluginTest.Core.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = DependencyInjectionConfig.ConfigureServices();

        var pluginService = serviceProvider.GetService<IPluginService>();

        if (pluginService is null)
        {
            throw new Exception("Cannot get pluginService");
        }

        while (true)
        {
            Console.WriteLine("Select Plugin Type:");
            Console.WriteLine("1. Text Transformer");
            Console.WriteLine("2. Image Importer");
            Console.WriteLine("0. Exit");

            Console.Write("\nEnter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleTextTransformers(pluginService);
                    break;
                case "2":
                    HandleImageImporters(pluginService);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice.\n");
                    break;
            }
        }
    }

    static void HandleTextTransformers(IPluginService pluginService)
    {
        var textTransformers = pluginService.GetPluginsOfType<ITextTransformer>();

        if (!textTransformers.Any())
        {
            Console.WriteLine("No Text Transformer plugins available.\n");
            return;
        }

        Console.WriteLine("\nText Transformer Plugins:");
        var index = 1;
        var transformerList = new List<ITextTransformer>(textTransformers);
        foreach (var plugin in transformerList)
        {
            Console.WriteLine($"{index}. {plugin.Name} - {plugin.Description}");
            index++;
        }

        Console.Write("\nSelect a plugin by number: ");
        if (!int.TryParse(Console.ReadLine(), out int selectedIndex) || selectedIndex < 1 || selectedIndex > transformerList.Count)
        {
            Console.WriteLine("Invalid selection.\n");
            return;
        }

        var selectedPlugin = transformerList[selectedIndex - 1];

        Console.Write("\nEnter text to process: ");
        string inputText = Console.ReadLine();

        string result = selectedPlugin.Transform(inputText);

        Console.WriteLine($"\nResult:\n{result}\n");
    }

    static void HandleImageImporters(IPluginService pluginService)
    {
        var imageImporters = pluginService.GetPluginsOfType<IImageImporter>();

        if (imageImporters == null)
        {
            Console.WriteLine("No Image Importer plugins available.\n");
            return;
        }

        Console.WriteLine("\nImage Importer Plugins:");
        int index = 1;
        var importerList = new List<IImageImporter>(imageImporters);
        foreach (var plugin in importerList)
        {
            Console.WriteLine($"{index}. {plugin.Name} - {plugin.Description}");
            index++;
        }

        Console.Write("\nSelect a plugin by number: ");
        if (!int.TryParse(Console.ReadLine(), out int selectedIndex) || selectedIndex < 1 || selectedIndex > importerList.Count)
        {
            Console.WriteLine("Invalid selection.\n");
            return;
        }

        var selectedPlugin = importerList[selectedIndex - 1];

        Console.Write("\nEnter image path to import: ");
        string imagePath = Console.ReadLine();

        selectedPlugin.ImportImage(imagePath);

        Console.WriteLine("\nImage imported successfully.\n");
    }
}