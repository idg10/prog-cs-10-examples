namespace Records.PodClass.WithPropertiesAndCtor;

public class Person
{
    public string Name;
    public string FavoriteColor;

    public Person(string name, string favoriteColor)
    {
        this.Name = name;
        this.FavoriteColor = favoriteColor;
    }
}
