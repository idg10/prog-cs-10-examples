using GenericTypes;

void Show<T>(NamedContainer<T> c)
{
    Console.WriteLine($"{c.Name}: {c.Item}");
}

void ShowMany<T>(IEnumerable<NamedContainer<T>> cs)
{
    foreach (NamedContainer<T> c in cs)
    {
        Show(c);
    }
}

var a = new NamedContainer<int>(42, "The answer");
var b = new NamedContainer<int>(99, "Number of red balloons");
var c = new NamedContainer<string>("Programming C#", "Book title");

// ...where a, and b come from Example 4-3
var namedInts = new List<NamedContainer<int>>() { a, b };
var namedNamedItem = new NamedContainer<NamedContainer<int>>(a, "Wrapped");

Show(a);
Show(b);
Show(c);

ShowMany(namedInts);
Show(namedNamedItem);
