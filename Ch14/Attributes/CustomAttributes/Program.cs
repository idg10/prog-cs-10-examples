using System.Reflection;
using System.Runtime.InteropServices;

using CustomAttributes;

static void ShowPluginInformation(string pluginFolder)
{
    var dir = new DirectoryInfo(pluginFolder);
    foreach (FileInfo file in dir.GetFiles("*.dll"))
    {
        Assembly pluginAssembly = Assembly.LoadFrom(file.FullName);
        var plugins =
             from type in pluginAssembly.ExportedTypes
             let info = type.GetCustomAttribute<PluginInformationAttribute>()
             where info != null
             select new { type, info };

        foreach (var plugin in plugins)
        {
            Console.WriteLine($"Plugin type: {plugin.type.Name}");
            Console.WriteLine(
                $"Name: {plugin.info.Name}, written by {plugin.info.Author}");
            Console.WriteLine($"Description: {plugin.info.Description}");
        }
    }
}

// We're adding two different sorts of things here, so separate steps
// better express what's happening.
static void ShowPluginInformationMetadataLoadContext(FileInfo file)
{
    Type pluginAttributeType = typeof(PluginInformationAttribute);

    // Create the list of assembly paths consisting of runtime assemblies and the inspected assembly.
    string[] runtimeAssemblies = Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll");
    var paths = new List<string>(runtimeAssemblies);
    paths.Add(file.FullName);

    var resolver = new PathAssemblyResolver(paths);
    var mlc = new MetadataLoadContext(resolver);

    Assembly pluginAssembly = mlc.LoadFromAssemblyPath(file.FullName);
    var plugins =
         from type in pluginAssembly.ExportedTypes
         let info = type.GetCustomAttributesData().SingleOrDefault(attrData =>
               attrData.AttributeType.FullName == pluginAttributeType.FullName)
         where info != null
         let description = (CustomAttributeNamedArgument?)info.NamedArguments
                               .SingleOrDefault(a => a.MemberName == "Description")
         select new
         {
             type,
             Name = (string)info.ConstructorArguments[0].Value!,
             Author = (string)info.ConstructorArguments[1].Value!,
             Description = description?.TypedValue.Value
         };

    foreach (var plugin in plugins)
    {
        Console.WriteLine($"Plugin type: {plugin.type.Name}");
        Console.WriteLine($"Name: {plugin.Name}, written by {plugin.Author}");
        Console.WriteLine($"Description: {plugin.Description}");
    }
}

Console.WriteLine("Normal reflection");
ShowPluginInformation(Path.GetDirectoryName(typeof(Program).Assembly.Location)!);

Console.WriteLine();
Console.WriteLine("MetadataLoadContext reflection");
ShowPluginInformationMetadataLoadContext(new FileInfo(typeof(Program).Assembly.Location));

// .NET defines this type. The book shows it only for illustration, hence the
// #if false here.
#if false
public interface ICustomAttributeProvider
{
    object[] GetCustomAttributes(bool inherit);
    object[] GetCustomAttributes(Type attributeType, bool inherit);
    bool IsDefined(Type attributeType, bool inherit);
}
#endif
