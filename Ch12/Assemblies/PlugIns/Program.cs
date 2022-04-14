using System.Reflection;

using HostApp;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using PlugInInterface;

string plugInDllPath = Path.Combine(
    Path.GetDirectoryName(typeof(Program).Assembly.Location)!,
    "MyPlugIn.dll");

Assembly[] plugInApiAssemblies =
{
    typeof(IPlugIn).Assembly,
    typeof(JsonReader).Assembly
};
var plugInAssemblyNames = new HashSet<string>(
    plugInApiAssemblies.Select(a => a.GetName().Name!));

var ctx = new PlugInLoadContext(plugInDllPath, plugInAssemblyNames);
Assembly plugInAssembly = ctx.LoadFromAssemblyPath(plugInDllPath);

var pi = (IPlugIn)plugInAssembly.CreateInstance("MyPlugIn.MyPlugInType")!;

pi.Foo(new JObject());