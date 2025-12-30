using ExtinctAnimals.Infrastructure.Http.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctAnimals.Infrastructure.Http
{
    public class ExtinctAnimalsApiClient
    {
        private readonly HttpClient _httpClient;

        public ExtinctAnimalsApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExtinctAnimalsApiResponse> GetRandomAsync(
    CancellationToken ct = default)
        {
            var wrapper = await _httpClient.GetFromJsonAsync<ExtinctAnimalsApiResponseWrapper>(
                "animal/",
                ct);

            var animal = wrapper?.Data.FirstOrDefault();

            if (animal is null)
                throw new InvalidOperationException("No animal returned from API");

            return animal;
        }
        public async Task<IEnumerable<ExtinctAnimalsApiResponse>> GetManyAsync(
            int count,
            CancellationToken ct = default)
        {
            var wrapper = await _httpClient.GetFromJsonAsync<ExtinctAnimalsApiResponseWrapper>(
                $"animal/{count}",
                ct);

            return wrapper?.Data ?? Enumerable.Empty<ExtinctAnimalsApiResponse>();
        }
    }
}
