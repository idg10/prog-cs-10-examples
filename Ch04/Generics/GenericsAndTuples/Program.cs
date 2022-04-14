using GenericsAndTuples;

(int, int) p = (42, 99);

ValueTuple<int, int> p2 = (42, 99);

Console.WriteLine(p);
Console.WriteLine(p2);
Console.WriteLine(ReturnTuple.Pos());
