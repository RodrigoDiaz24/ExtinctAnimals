using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExtinctAnimals.Infrastructure.Http.Models
{
    public class ExtinctAnimalsApiResponseWrapper
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("data")]
        public List<ExtinctAnimalsApiResponse> Data { get; set; } = new();
    }
}
