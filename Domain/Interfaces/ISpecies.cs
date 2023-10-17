using Domain.Entities;

namespace Domain.Interfaces;
public interface ISpecies : IGenericRepository<Species>
{
    Task<IEnumerable<Species>> GetPetBySpecies ();
}
