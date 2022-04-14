using System.Reactive.Linq;

namespace DelegateBasedPubSub;

public static class AsyncSource
{
    public static IObservable<string> GetFilePusher(string path)
    {
        return Observable.Create<string>(async (observer, cancel) =>
        {
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream && !cancel.IsCancellationRequested)
                {
                    string? line = await sr.ReadLineAsync();
                    if (line is not null)
                    {
                        observer.OnNext(line);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            observer.OnCompleted();
        });
    }
}