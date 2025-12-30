using ExtinctAnimals.Domain.Models;

namespace ExtinctAnimals.Application.Interfaces
{
    public interface IAnimalRepository
    {
        Task<Animal> GetRandomAsync(CancellationToken ct = default);
        Task<IEnumerable<Animal>> GetManyAsync(int count, CancellationToken ct = default);
    }
}
