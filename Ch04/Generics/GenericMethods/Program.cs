using Moq;

namespace GenericMethods;

class Program
{
    static void Main()
    {
        int[] values = { 1, 2, 3 };
        int last = GetLast<int>(values);

        Console.WriteLine(last);
        UseInference();
    }

    public static T GetLast<T>(T[] items) => items[^1];

    public static T MakeFake<T>()
        where T : class
    {
        return new Mock<T>().Object;
    }

    private static void UseInference()
    {
        int[] values = { 1, 2, 3 };
        int last = GetLast(values);

        Console.WriteLine(last);
    }

    // This example illustrates a technique that doesn't work in C#,
    // which is why it's in this #if false block
#if false
    public static T Add<T>(T x, T y)
    {
        return x + y;  // Will not compile
    }
#endif
}
