static void Greet(string greetingRecipient)
{
    ArgumentNullException.ThrowIfNull(greetingRecipient);
    Console.WriteLine($"Hello, {greetingRecipient}");
}

Greet("world");
Greet(null!);

#if false
// Illustration of how this method declaration looks.
// For the real thing, see:
// https://github.com/dotnet/runtime/blob/1486f66725f16b8026f2cca331266765cffd1c6b/src/libraries/System.Private.CoreLib/src/System/ArgumentNullException.cs#L59

public class ArgumentNullException
{
    public static void ThrowIfNull(
        [NotNull] object? argument,
        [CallerArgumentExpression("argument")] string? paramName =  null)
    {
#endif