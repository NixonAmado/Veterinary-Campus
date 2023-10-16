using Domain.Entities;

namespace Domain.Interfaces;
public interface IPerson : IGenericRepository<Person>
{
    Task<IEnumerable<Person>> GetVetByEspecialityAsync(string Especiality);   
}
