namespace Records;

public abstract record OptionallyLabelled
{
    public string? Label { get; init; }
}

public record OptionallyLabelledItem : OptionallyLabelled;

public record Product(string Name) : OptionallyLabelled;