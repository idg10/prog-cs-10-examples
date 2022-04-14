namespace FundamentalInterfaces;

public static class AttachingAnObserver
{
    public static void SubscribeToKeyWatcher()
    {
        var source = new KeyWatcher();
        var sub = new MySubscriber<char>();
        source.Subscribe(sub);
        source.Run();
    }
}