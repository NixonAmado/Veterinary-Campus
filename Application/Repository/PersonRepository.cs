using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class PersonRepository : GenericRepository<Person>, IPerson
    {
        private readonly DbAppContext _context;

        public PersonRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        /*======================================== Veterinario ===========================================================*/
        public async Task<IEnumerable<Person>> GetVetByEspecialityAsync(string Especiality)
        {
            return await _context.People
                                .Where( p => p.PersonType.Description == "VETERINARIO" &&
                                p.Especiality.Description == Especiality)
                                .ToListAsync();
        }



    }
