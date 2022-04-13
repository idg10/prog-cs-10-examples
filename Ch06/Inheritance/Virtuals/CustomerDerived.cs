using Library;

namespace Virtuals;

// To see the warning come and go, change this between #if true and
// #if false
#if false
public class CustomerDerived : LibraryBase
{
    public void Start()
    {
        Console.WriteLine("Derived type's Start method");
    }
}
#else
#pragma warning disable CA1822
public class CustomerDerived : LibraryBase
{
    public new void Start()
    {
        Console.WriteLine("Derived type's Start method");
    }
}
#endif
