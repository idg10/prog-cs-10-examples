using DelegateBasedPubSub;

using System.Reactive.Linq;

DelegateBasedHotSource.Run();

var source = new KeyWatcher();
source.Subscribe(value => Console.WriteLine("Received: " + value));
source.Run();