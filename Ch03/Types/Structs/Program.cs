using Structs;

// With the default SDK settings, the code analysis rules detect the problem
// this example illustrates, reporting CA2013 warnings. This particular example
// makes this mistake on purpose, so we disable the warning.
// (Note: VS sometimes spuriously labels this as an unnecessary suprpression.)
#pragma warning disable CA2013

var p1 = new Point(40, 2);
Point p2 = p1;
var p3 = new Point(40, 2);

Console.WriteLine($"{p1.X}, {p1.Y}");
Console.WriteLine($"{p2.X}, {p2.Y}");
Console.WriteLine($"{p3.X}, {p3.Y}");
Console.WriteLine(p1 == p2);
Console.WriteLine(p1 == p3);
Console.WriteLine(p2 == p3);
Console.WriteLine(object.ReferenceEquals(p1, p2));
Console.WriteLine(object.ReferenceEquals(p1, p3));
Console.WriteLine(object.ReferenceEquals(p2, p3));
Console.WriteLine(object.ReferenceEquals(p1, p1));
