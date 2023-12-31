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
                        .ThenInclude(p => p.Breed)
                        .ToListAsync();
        }
        public override async Task<(int totalRegistros, IEnumerable<Species> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Species as IQueryable<Species>;
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToUpper() == search.ToUpper());
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Pets)
                .ThenInclude(p => p.Breed)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
                    

    }
