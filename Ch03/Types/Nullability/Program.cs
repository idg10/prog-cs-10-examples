using Nullability;

string cannotBeNull = "Text";
string? mayBeNull = null;

Console.WriteLine(cannotBeNull.Length);

if (mayBeNull is not null)
{
    // Allowed because we can only get here if mayBeNull is not null
    Console.WriteLine(mayBeNull.Length);
}

// Allowed because it checks for null and handles it
Console.WriteLine(mayBeNull?.Length ?? 0);

// The compiler will warn about this in an enabled nullable warning context
Console.WriteLine(mayBeNull.Length);

LegacyComponent legacy = new();

string? referenceFromLegacyComponent = legacy.GetReferenceWeKnowWontBeNull();
string nonNullableReferenceFromLegacyComponent = referenceFromLegacyComponent!;

Console.WriteLine(nonNullableReferenceFromLegacyComponent.Length);

var nullableStrings = new string?[10];
var nonNullableStrings = new string[10];
Console.WriteLine(nullableStrings[0] == null);
Console.WriteLine(nonNullableStrings[0] == null);
