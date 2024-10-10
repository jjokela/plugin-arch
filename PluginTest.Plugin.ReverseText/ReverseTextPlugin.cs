using PluginTest.Core.Application.Interfaces;

namespace PluginTest.Plugin.ReverseText;

public class ReverseTextPlugin : ITextTransformer
{
    public string Name => "Reverse text plugin";
    public string Description => "Reverses the text";
    public string Transform(string input)
    {
        var textArr = input.ToCharArray();
        Array.Reverse(textArr);
        return new string(textArr);
    }
}