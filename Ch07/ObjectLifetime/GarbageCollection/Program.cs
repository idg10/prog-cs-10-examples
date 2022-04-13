namespace GarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<string>();
            long total = 0;
            for (int i = 1; i < 100_000; ++i)
            {
                numbers.Add(i.ToString());
                total += i;
            }
            Console.WriteLine("Total: {0}, average: {1}",
                total, total / numbers.Count);
        }
    }
}