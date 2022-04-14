using System.Reflection;

using ReflectionContexts;

var ctx = new MyReflectionContext();
TypeInfo mappedType = ctx.MapType(typeof(NotVeryInteresting).GetTypeInfo());

foreach (PropertyInfo prop in mappedType.DeclaredProperties)
{
    Console.WriteLine($"{prop.Name} ({prop.PropertyType.Name})");
}