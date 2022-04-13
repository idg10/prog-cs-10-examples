using System.Reflection;

namespace Arrays;

public class ConvolutedArrayAccess
{
    public static string GetCopyrightForType(object o)
    {
        Assembly asm = o.GetType().Assembly;
        var copyrightAttribute = (AssemblyCopyrightAttribute)
            asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true)[0];
        return copyrightAttribute.Copyright;
    }
}
