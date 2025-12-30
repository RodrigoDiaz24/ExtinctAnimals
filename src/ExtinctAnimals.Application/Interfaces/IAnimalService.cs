using ExtinctAnimals.Application.DTOs;

namespace ExtinctAnimals.Application.Interfaces
{
    public interface IAnimalService
    {
        Task<AnimalDto> GetRandomAsync(CancellationToken ct = default);
        Task<IEnumerable<AnimalDto>> GetManyAsync(int count, CancellationToken ct = default);
    }
}
