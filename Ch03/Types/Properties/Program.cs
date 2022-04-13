using Properties.Auto;

var o = new HasProperty();
o.X = 123;
o.X += 432;
Console.WriteLine(o.X);

var x = new WithInit
{
    X = 42
};
Console.WriteLine(x.X);

Point p1 = new(0, 10);
Point p2 = p1 with { X = 20 };
Console.WriteLine(p1);
Console.WriteLine(p2);
