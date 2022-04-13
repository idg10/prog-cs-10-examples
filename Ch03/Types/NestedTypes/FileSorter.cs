namespace NestedTypes;

internal static class FileSorter
{
    public static string[] GetByNameLength(string path)
    {
        string[] files = Directory.GetFiles(path);
        var comparer = new LengthComparer();
        Array.Sort(files, comparer);
        return files;
    }

    private class LengthComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            int diff = (x?.Length ?? 0) - (y?.Length ?? 0);
            return diff == 0
                ? StringComparer.OrdinalIgnoreCase.Compare(x, y)
                : diff;
        }
    }
}
