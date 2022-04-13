namespace Records.Nested;

internal class UsingNestedRecords
{
    public static void Use()
    {
        var ian = new Person("Ian", "Blue");
        var gina = new Person("Gina", "Green");
        var ian2 = new Person("Ian", "Blue");
        var gina2 = new Person("Gina", "Green");
        var r1 = new Relation(ian, gina, "Sister");
        var r2 = new Relation(gina, ian, "Brother");
        var r3 = new Relation(ian2, gina2, "Sister");

        Console.WriteLine(r1);
        Console.WriteLine(r2);
        Console.WriteLine(r3);
        Console.WriteLine(r1 == r2);
        Console.WriteLine(r1 == r3);
        Console.WriteLine(r2 == r3);
    }
}
