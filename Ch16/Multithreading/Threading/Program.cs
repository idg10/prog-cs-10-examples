using System.Collections.Concurrent;

using Threading;

ObjectVisibility.FormatDictionary(new Dictionary<string, string> { { "One", "one" }, { "Two", "two" } });

// Demonstrate non-thread-safety of example misusing ConcurrentDictionary
ConcurrentDictionary<int, string> cd = new();
Thread[] threads = new Thread[Environment.ProcessorCount];
for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() =>
    {
        try
        {
            while (true)
            {
                NonThreadSafeUseOfThreadSafeCollection.UseDictionary(cd);
                cd.TryRemove(1, out _);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    });
    threads[i].Start();
}

Console.ReadLine();