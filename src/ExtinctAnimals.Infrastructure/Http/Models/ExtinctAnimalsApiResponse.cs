using System.Text.Json.Serialization;

namespace ExtinctAnimals.Infrastructure.Http.Models
{
    public class ExtinctAnimalsApiResponse
    {
        [JsonPropertyName("binomialName")]
        public string BinomialName { get; set; }
        [JsonPropertyName("commonName")]
        public string CommonName { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("wikiLink")]
        public string WikiLink { get; set; }
        [JsonPropertyName("lastRecord")]
        public string LastRecord { get; set; }
        [JsonPropertyName("imageSrc")]
        public string imageSrc { get; set; }
        [JsonPropertyName("shortDesc")]
        public string ShortDescription { get; set; }
    }
}
