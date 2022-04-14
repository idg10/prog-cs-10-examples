using Newtonsoft.Json.Linq;

namespace PlugInInterface;

public interface IPlugIn
{
    string Foo(JObject o);
}