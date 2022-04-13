namespace Exceptions;

class Program
{
    static void Main(string[] args)
    {
        using (var r = new StreamReader(@"C:\Temp\File.txt"))
        {
            while (!r.EndOfStream)
            {
                Console.WriteLine(r.ReadLine());
            }
        }
    }

    static int Divide(int x, int y)
    {
        return x / y;
    }

    static void HandlingExceptions()
    {
        try
        {
            using (var r = new StreamReader(@"C:\Temp\File.txt"))
            {
                while (!r.EndOfStream)
                {
                    Console.WriteLine(r.ReadLine());
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Couldn't find the file");
        }
    }

    static void ExceptionObjects()
    {
        try
        {
            // ... same code as Example 8-3 ...
            using (var r = new StreamReader(@"C:\Temp\File.txt"))
            {
                while (!r.EndOfStream)
                {
                    Console.WriteLine(r.ReadLine());
                }
            }
        }
        catch (FileNotFoundException x)
        {
            Console.WriteLine($"File '{x.FileName}' is missing");
        }
    }

    static void MultipleCatchBlocks()
    {
        try
        {
            using (var r = new StreamReader(@"C:\Temp\File.txt"))
            {
                while (!r.EndOfStream)
                {
                    Console.WriteLine(r.ReadLine());
                }
            }
        }
        catch (FileNotFoundException x)
        {
            Console.WriteLine($"File '{x.FileName}' is missing");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"The containing directory does not exist.");
        }
        catch (IOException x)
        {
            Console.WriteLine($"IO error: '{x.Message}'");
        }
    }

    public static bool InsertIfDoesNotExist(MyEntity item, TableClient table)
    {
        try
        {
            table.AddEntity(item);
            return true;
        }
        catch (RequestFailedException x)
        when (x.Status == 409)
        {
            return false;
        }
    }

    public static string GetCommaSeparatedEntry(string text, int position)
    {
        string[] parts = text.Split(',');
        if (position < 0 || position >= parts.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }
        return parts[position];
    }

    public static int CountCommas(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return text.Count(ch => ch == ',');
    }
}
