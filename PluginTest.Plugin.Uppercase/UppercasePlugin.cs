using PluginTest.Core.Application.Interfaces;

namespace PluginTest.Plugin.Uppercase;

public class UppercasePlugin : ITextTransformer
{
    public string Name => "Uppercase Plugin";
    public string Description => "Converts text to uppercase";
    public string Transform(string input)
    {
        return input.ToUpper();
    }
}