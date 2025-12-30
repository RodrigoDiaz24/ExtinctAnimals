using ExtinctAnimals.Application.DTOs;
using ExtinctAnimals.Application.Interfaces;
using ExtinctAnimals.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctAnimals.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<AnimalDto> GetRandomAsync(CancellationToken ct)
        {
            var animal = await _animalRepository.GetRandomAsync(ct);
            return Map(animal);
        }

        public async Task<IEnumerable<AnimalDto>> GetManyAsync(int count, CancellationToken ct)
        {
            if (count < 1 || count > 804)
                throw new ArgumentOutOfRangeException(nameof(count));

            var animals = await _animalRepository.GetManyAsync(count, ct);
            return animals.Select(Map);
        }

        private static AnimalDto Map(Animal animal)
        {
            return new AnimalDto
            {
                BinomialName = animal.BinomialName,
                CommonName = animal.CommonName,
                Location = animal.Location,
                WikiLink = animal.WikiLink,
                LastRecord = animal.LastRecord,
                ImageSrc = animal.ImageSrc,
                ShortDescription = animal.ShortDescription
            };
        }
    }
}
