using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;
    public class SpeciesRepository : GenericRepository<Species>, ISpecies
    {
        private readonly DbAppContext _context;

        public SpeciesRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

            //Listar todas las mascotas agrupadas por especie.
        public async Task<IEnumerable<Species>> GetPetBySpecies()
        {
            return await _context.Species
                        .Include(p => p.Pets)
                        .ToListAsync();
        //     await _context.Pets
        //             .Select(group => new Species
        //             {
        //                 Name = group.FirstOrDefault().Species.Name,
        //                 Pets = group.ToList(),
        //             })
        //             .ToListAsync();
        }

    }
