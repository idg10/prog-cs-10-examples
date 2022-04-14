namespace Threading;

public static class TaskThreadPool
{
    private static readonly HttpClient http = new();

    public static void DoWork()
    {
        Task.Run(() => MyThreadEntryPoint("https://oreilly.com/"));
    }

    private static void MyThreadEntryPoint(object arg)
    {
        string url = (string)arg!;

        Console.WriteLine($"Downloading {url}");
        var response = http.Send(new HttpRequestMessage(HttpMethod.Get, url));
        using StreamReader r = new(response.Content.ReadAsStream());
        string page = r.ReadToEnd();
        Console.WriteLine($"Downloaded {url}, length {page.Length}");
    }
}
