using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Serialization;

public class SystemTextJson
{
    public static void Use()
    {
        var model = new SimpleData
        {
            Id = 42,
            Names = new[] { "Bell", "Stacey", "her", "Jane" },
            Location = new NestedData
            {
                LocationName = "London",
                Latitude = 51.503209,
                Longitude = -0.119145
            },
            Map = new Dictionary<string, int>
            {
                { "Answer", 42 },
                { "FirstPrime", 2 }
            }
        };

        string json = JsonSerializer.Serialize(
            model,
            new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);

        var deserialized = JsonSerializer.Deserialize<SimpleData>(json);
        if (deserialized is not null)
        {
            Console.WriteLine(deserialized?.Id);
        }

        using (JsonDocument document = JsonDocument.Parse(json))
        {
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                Console.WriteLine($"Property: {property.Name} ({property.Value.ValueKind})");
            }
        }

        using (JsonDocument document = JsonDocument.Parse(json))
        {
            JsonElement namesElement = document.RootElement.GetProperty("names");
            foreach (JsonElement name in namesElement.EnumerateArray())
            {
                Console.WriteLine($"Name: {name.GetString()}");
            }

            JsonElement root = document.RootElement;
            if (root.TryGetProperty("location", out JsonElement locationElement))
            {
                JsonElement nameElement = locationElement.GetProperty("locationName");
                JsonElement latitudeElement = locationElement.GetProperty("latitude");
                JsonElement longitudeElement = locationElement.GetProperty("longitude");
                string locationName = nameElement.GetString()!;
                double latitude = latitudeElement.GetDouble();
                double longitude = longitudeElement.GetDouble();
                Console.WriteLine($"Location: {locationName}: {latitude},{longitude}");
            }
        }

        JsonNode rootNode = JsonNode.Parse(json)!;
        JsonNode mapNode = rootNode["map"]!;
        mapNode["iceCream"] = 99;
    }

    public static string AutoCamelCase(SimpleData model)
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(
            model,
            options);

        return json;
    }

    public static string SerializeWithCircularReferences()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve
        };
        var circle = new SelfRef
        {
            Name = "Top",
            Next = new SelfRef
            {
                Name = "Bottom",
            }
        };
        circle.Next.Next = circle;
        string json = JsonSerializer.Serialize(circle, options);

        return json;
    }

    public class SimpleData
    {
        public int Id { get; set; }
        public IList<string>? Names { get; set; }
        public NestedData? Location { get; set; }
        public IDictionary<string, int>? Map { get; set; }
    }

    public class NestedData
    {
        public string? LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
