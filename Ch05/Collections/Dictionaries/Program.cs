var textToNumber =
    new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
{
    { "One", 1 },
    { "Two", 2 },
    { "Three", 3 },
};

Console.WriteLine($"{textToNumber["Three"]} is the magic number");