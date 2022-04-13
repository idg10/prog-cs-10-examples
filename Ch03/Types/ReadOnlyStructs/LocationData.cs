namespace ReadOnlyStructs;

public class LocationData
{
    public LocationData(string label, Point location)
    {
        Label = label;
        Location = location;
    }

    public string Label { get; }
    public Point Location { get; }
}
