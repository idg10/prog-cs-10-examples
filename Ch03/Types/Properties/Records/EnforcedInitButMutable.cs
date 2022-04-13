namespace Properties.Records;

public record EnforcedInitButMutable(string Name, string FavoriteColor)
{
    public string Name { get; set; } = Name;
    public string FavoriteColor { get; set; } = FavoriteColor;
}
