using System.Reactive.Linq;

namespace DelegateBasedPubSub;

public static class DelegateBasedSource
{
    public static IObservable<string> GetFilePusher(string path)
    {
        return Observable.Create<string>(observer =>
        {
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();
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
            return () => { };
        });
    }
}