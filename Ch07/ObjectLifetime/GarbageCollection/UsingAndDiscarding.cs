using System.Net;

namespace GarbageCollection;

internal class UsingAndDiscarding
{
    public static string WriteUrl(string relativeUri)
    {
        var baseUri = new Uri("https://endjin.com/");
        var fullUri = new Uri(baseUri, relativeUri);
        var w = new WebClient();
        return w.DownloadString(fullUri);
    }
}
