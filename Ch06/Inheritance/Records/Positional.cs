namespace Records;

public abstract record Colorful(string Color);

public record LightBulb(string Color, int Lumens) : Colorful(Color);

public record FordModelT() : Colorful("Black");

public record RedDelicious : Colorful
{
    public RedDelicious() : base("Red")
    { }
}

public record LabelledDemographic : OptionallyLabelled
{
    public LabelledDemographic(string label)
    {
        Label = label;
    }
}