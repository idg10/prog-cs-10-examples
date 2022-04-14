namespace CreatingThreads;

internal static class Program
{
    private static readonly HttpClient http = new();

    private static void Main(string[] args)
    {
        Thread t1 = new(MyThreadEntryPoint);
        Thread t2 = new(MyThreadEntryPoint);
        Thread t3 = new(MyThreadEntryPoint);

        t1.Start("https://endjin.com/");
        t2.Start("https://oreilly.com/");
        t3.Start("https://dotnet.microsoft.com/");
    }

    private static void MyThreadEntryPoint(object? arg)
    {
        string url = (string)arg!;

        Console.WriteLine($"Downloading {url}");
        var response = http.Send(new HttpRequestMessage(HttpMethod.Get, url));
        using StreamReader r = new(response.Content.ReadAsStream());
        string page = r.ReadToEnd();
        Console.WriteLine($"Downloaded {url}, length {page.Length}");
    }
}
