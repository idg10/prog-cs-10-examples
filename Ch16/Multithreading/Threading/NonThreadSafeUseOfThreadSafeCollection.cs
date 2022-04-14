using System.Collections.Concurrent;

namespace Threading;

internal class NonThreadSafeUseOfThreadSafeCollection
{
    internal static string UseDictionary(ConcurrentDictionary<int, string> cd)
    {
        cd[1] = "One";
        return cd[1];
    }
}
