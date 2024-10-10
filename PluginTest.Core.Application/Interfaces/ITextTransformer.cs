namespace PluginTest.Core.Application.Interfaces
{
    public interface ITextTransformer : IPlugin
    {
        public string Transform(string input);
    }
}
