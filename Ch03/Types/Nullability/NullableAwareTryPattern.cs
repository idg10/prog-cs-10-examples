using System.Diagnostics.CodeAnalysis;

namespace Nullability;

public class NullableAwareTryPattern<TKey, TValue>
{
    public static string Get(IDictionary<int, string> d)
    {
        if (d.TryGetValue(42, out string? s))
        {
            return s;
        }

        return "Not found";
    }

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        value = default!;
        return false;
    }
}
