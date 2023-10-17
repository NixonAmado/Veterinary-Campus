using Domain.Entities;

namespace Domain.Interfaces;
public interface IPet : IGenericRepository<Pet>
{
    Task<IEnumerable<Pet>> GetAllBySpecies (string species);
    Task<IEnumerable<Pet>> GetAttendedByReasonInTrimesterYear( int trim, int year, string reason);
    Task<IEnumerable<Pet>> GetOwnerPetByBreed (string breed);


}
