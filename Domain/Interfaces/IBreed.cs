using Domain.Entities;

namespace Domain.Interfaces;
public interface IBreed : IGenericRepository<Breed>
{
    Task<IEnumerable<CountBreed>> GetPetCountInBreed();
}
