namespace DelegateConversion
{
    class Program
    {
        public static bool IsLongString(object o)
        {
            return o is string s && s.Length > 20;
        }

        static void Main(string[] args)
        {
            Predicate<object> po = IsLongString;
            Predicate<string> ps = po;
            Console.WriteLine(ps("Too short"));
        }

        // This example shows an approach that will not work. Change the
        // #if false to #if true to see the compiler error.
#if false
        public static void IllegalConversion()
        {
            Predicate<string> pred = IsLongString;
            Func<string, bool> f = pred;  // Will fail with compiler error
        }
#endif
    }
}
