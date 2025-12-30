using ExtinctAnimals.Application.Interfaces;
using ExtinctAnimals.Domain.Models;
using ExtinctAnimals.Infrastructure.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctAnimals.Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ExtinctAnimalsApiClient _apiClient;

        public AnimalRepository(ExtinctAnimalsApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Animal> GetRandomAsync(CancellationToken ct)
        {
            var r = await _apiClient.GetRandomAsync(ct);

            return new Animal
            {
              BinomialName = r.BinomialName,
              CommonName = r.CommonName,
              Location = r.Location,
              WikiLink = r.WikiLink,
              LastRecord = r.LastRecord,
              ImageSrc = r.imageSrc,
              ShortDescription = r.ShortDescription

            };
        }

        public async Task<IEnumerable<Animal>> GetManyAsync(int count, CancellationToken ct)
        {
            var response = await _apiClient.GetManyAsync(count, ct);

            return response.Select(r => new Animal
            {
                BinomialName = r.BinomialName,
                CommonName = r.CommonName,
                Location = r.Location,
                WikiLink = r.WikiLink,
                LastRecord = r.LastRecord,
                ImageSrc = r.imageSrc,
                ShortDescription = r.ShortDescription
            });
        }
    }
}
