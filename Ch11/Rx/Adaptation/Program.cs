using Adaptation;

using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient();
using ServiceProvider sp = services.BuildServiceProvider();

IHttpClientFactory cf = sp.GetRequiredService<IHttpClientFactory>();
IObservable<string> pageContentObservable = Async.FetchOnce.GetWebPageAsObservable(new Uri("https://endjin.com"), cf);

using IDisposable sub = pageContentObservable.Subscribe(Console.WriteLine);

Console.ReadKey();