using FundamentalInterfaces;

var source = new SimpleColdSource();
var sub = new MySubscriber<string>();
source.Subscribe(sub);

// This example illustrates how the fundamental Rx interfaces look. Since these are defined
// by .NET we don't need to define them ourselves, hence the #if false.
#if false
    public interface IObservable<out T>
    {
        IDisposable Subscribe(IObserver<T> observer);
    }

    public interface IObserver<in T>
    {
        void OnCompleted();
        void OnError(Exception error);
        void OnNext(T value);
    }
#endif
