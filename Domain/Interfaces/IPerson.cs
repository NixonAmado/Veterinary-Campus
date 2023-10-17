using Domain.Entities;

namespace Domain.Interfaces;
public interface IPerson : IGenericRepository<Person>
{
    Task<IEnumerable<Person>> GetVetByEspecialityAsync(string Especiality);   
    Task<IEnumerable<Person>> GetAllOwnersAndPets();
    Task<IEnumerable<Pet>> PetsAttendedByVet(string veterinarian);
    Task<IEnumerable<Person>> GetSuppliersByProduct(string product);
}
