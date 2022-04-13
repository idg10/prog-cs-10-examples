namespace Nullability;

// If you remove or comment out the next pragma, you'll see a warning on the
// line that calls TryGetValue.
#nullable disable warnings

public class NonNullableAwareTryPattern
{
    public static string Get(IDictionary<int, string> d)
    {
        if (d.TryGetValue(42, out string s))
        {
            return s;
        }

        return "Not found";
    }
}
