var numbers = new List<int> { 1, 2, 1, 4 };
numbers[2] += numbers[1];
Console.WriteLine(numbers[0]);

NullConditionalIndex(null);
EquivalentOfNullConditionalIndex(null);

static void NullConditionalIndex(List<string>? objectWithIndexer)
{
    string? s = objectWithIndexer?[2];

    Console.WriteLine(s ?? "Null");
}

static void EquivalentOfNullConditionalIndex(List<string>? objectWithIndexer)
{
    string? s = objectWithIndexer == null ? null : objectWithIndexer[2];

    Console.WriteLine(s ?? "Null");
}
