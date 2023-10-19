using Domain.Entities;

namespace Domain.Interfaces;
public interface IPerson : IGenericRepository<Person>
{
    Task<IEnumerable<Person>> GetVetByEspecialityAsync(string Especiality);   
    Task<IEnumerable<Person>> GetAllOwnersAndPets();
    Task<IEnumerable<Pet>> PetsAttendedByVet(string veterinarian);
    Task<IEnumerable<Person>> GetSuppliersByProduct(string product);
    Task<IEnumerable<Person>> GetAllOwnersAsync();
    Task<IEnumerable<Person>> GetAllVeterinarianAsync();
    Task<IEnumerable<Person>> GetAllSuppliersAsync();
    Task<(int totalRegistros, IEnumerable<Person> registros)> GetAllPeopleAsync(int pageIndex, int pageSize, string search, string person);

}
