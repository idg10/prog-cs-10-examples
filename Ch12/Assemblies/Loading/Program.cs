using LibraryContainingCustomComparer;

static IComparer<string> GetComparer(bool useStandardOrdering)
{
    if (useStandardOrdering)
    {
        return StringComparer.CurrentCulture;
    }
    else
    {
        return new MyCustomComparer();
    }
}

IComparer<string> c = GetComparer(useStandardOrdering: true);

// The LibraryContainingCustomComparer will be loaded by now even through we're not
// using the custom comparer it defines.

Console.WriteLine(c.Compare("apples", "oranges"));