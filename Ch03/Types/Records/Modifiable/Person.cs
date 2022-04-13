namespace Records.Modifiable;

public record Person
{
    public Person(string name, string favoriteColor)
    {
        this.Name = name;
        this.FavoriteColor = favoriteColor;
    }

    public string Name { get; set; }
    public string FavoriteColor { get; set; }
}
