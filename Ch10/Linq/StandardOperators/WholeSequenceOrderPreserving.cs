namespace StandardOperators;

public static class WholeSequenceOrderPreserving
{
    public static void CombiningWithZip()
    {
        string[] firstNames = { "Elisenda", "Jessica", "Liam" };
        string[] lastNames = { "Gascon", "Hill", "Mooney" };
        IEnumerable<string> fullNames = firstNames.Zip(lastNames,
            (first, last) => first + " " + last);
        foreach (string name in fullNames)
        {
            Console.WriteLine(name);
        }
    }
}