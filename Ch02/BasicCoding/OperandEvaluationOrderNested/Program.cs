static int X(string label, int i)
{
    Console.Write(label);
    return i;
}

Console.WriteLine(
    X("a", 1) +
    X("b", (X("c", 1) + X("d", 1) + X("e", 1))) +
    X("f", 1));
