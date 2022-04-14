using System.Reflection;

namespace ReflectionTypes;

class Program
{
    static void Main()
    {
        Assembly me = typeof(Program).Assembly;
        Console.WriteLine(me.FullName);
    }
}
