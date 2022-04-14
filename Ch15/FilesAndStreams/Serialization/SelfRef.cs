namespace Serialization;

public class SelfRef
{
    public string? Name { get; set; }
    public SelfRef? Next { get; set; }
}