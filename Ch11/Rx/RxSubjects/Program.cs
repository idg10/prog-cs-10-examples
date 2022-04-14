using RxSubjects;

var kw = new KeyWatcher();
kw.Subscribe(Console.WriteLine);
kw.Run();