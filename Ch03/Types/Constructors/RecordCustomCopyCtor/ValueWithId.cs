namespace Constructors.RecordCustomCopyCtor;

public record ValueWithId(int Value, int Id)
{
    public ValueWithId(ValueWithId source)
    {
        Value = source.Value;
        Id = source.Id + 1;
    }
}
