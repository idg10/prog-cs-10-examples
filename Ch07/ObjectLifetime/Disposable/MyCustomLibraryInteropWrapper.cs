namespace Disposable;

// Exists only to enable Example 17 to compile
internal static class MyCustomLibraryInteropWrapper
{
    internal static void Close(IntPtr myCustomLibraryHandle)
    {
        throw new NotImplementedException();
    }
}
