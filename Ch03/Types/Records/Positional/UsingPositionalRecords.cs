namespace Records.Positional;

internal static class UsingPositionalRecords
{
    public static void Use()
    {
        void ShowPerson(Person p)
        {
            Console.WriteLine($"{p.Name}'s favorite color is {p.FavoriteColor}");
        }

        var ian = new Person("Ian", "Blue");
        var deborah = new Person("Deborah", "Green");
        ShowPerson(ian);
        ShowPerson(deborah);

        var startingRecord = new Person("Ian", "Blue");
        var modified = startingRecord with
        {
            FavoriteColor = "Green"
        };

        Console.WriteLine(modified);

        var p1 = new Person("Ian", "Blue");
        var p2 = new Person("Ian", "Blue");
        if (p1 == p2)
        {
            Console.WriteLine("Equal");
        }
    }
}
