namespace Records.Nested;

public record Person(string Name, string FavoriteColor);
public record Relation(Person Subject, Person Other, string RelationshipType);
