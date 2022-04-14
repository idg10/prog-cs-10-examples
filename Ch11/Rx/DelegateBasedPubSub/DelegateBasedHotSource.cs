using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DelegateBasedPubSub;

public class DelegateBasedHotSource
{
    public static void Run()
    {
        IObservable<char> singularHotSource = Observable.Create(
            (Func<IObserver<char>, IDisposable>)(obs =>
            {
                while (true)
                {
                    obs.OnNext(Console.ReadKey(true).KeyChar);
                }
            }));

        IConnectableObservable<char> keySource = singularHotSource.Publish();

        keySource.Subscribe(new MySubscriber<char>());
        keySource.Subscribe(new MySubscriber<char>());

        keySource.Connect();
    }
}