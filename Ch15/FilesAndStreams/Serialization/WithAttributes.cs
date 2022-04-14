using System.Text.Json.Serialization;

namespace Serialization;

public class WithAttributes
{
    public class NestedData
    {
        [JsonPropertyName("locationName")]
        public string? LocationName { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
