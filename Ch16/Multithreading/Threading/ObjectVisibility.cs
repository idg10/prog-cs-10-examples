using System.Text;

namespace Threading;

internal class ObjectVisibility
{
    public static string FormatDictionary<TKey, TValue>(
        IDictionary<TKey, TValue> input)
    {
        var sb = new StringBuilder();
        foreach (var item in input)
        {
            sb.AppendFormat("{0}: {1}", item.Key, item.Value);
            sb.AppendLine();
        }

        return sb.ToString();
    }
}
