namespace Bases.InheritanceChain;

public class Conversions
{
    public static void UseAsDerived(Base baseArg)
    {
        var d = (Derived)baseArg;

        // ... go on to do something with d
    }

    public static void MightUseAsDerived(Base b)
    {
        var d = b as Derived;

        if (d != null)
        {
            // ... go on to do something with d
        }
    }
}
