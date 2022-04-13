#nullable disable

namespace Nullability;

internal class LegacyComponent
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "CA1822:Mark members as static",
        Justification = "Not real code - this is here to illustrate something in a different file, and we need this to be an instance member")]
    public string GetReferenceWeKnowWontBeNull() => "Definitely not null";
}
