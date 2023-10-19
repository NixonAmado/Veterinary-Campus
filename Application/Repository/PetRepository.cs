using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class PetRepository : GenericRepository<Pet>, IPet
    {
        private readonly DbAppContext _context;

        public PetRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
    //Mostrar las mascotas que se encuentren registradas cuya especie sea X.
    public async Task<IEnumerable<Pet>> GetAllBySpecies (string species)
    {
        return await _context.Pets
                            .Where(p => p.Species.Name.ToUpper() == species.ToUpper())
                            .Include(p => p.Breed)
                            .Include(p => p.Species)
                            .ToListAsync();
    }

    //Listar las mascotas que fueron atendidas por motivo de vacunacion en el X trimestre del X --OK
    public async Task<IEnumerable<Pet>> GetAttendedByReasonInTrimesterYear( int trim, int year, string reason)
    {
        int firstMonthTrim = (trim - 1) * 3 + 1 ;
        return await _context.Pets
                            .Where( p => p.Appointments.Any(a =>
                                    a.Reason.ToUpper() == reason.ToUpper() &&
                                    a.Date.Year == year &&
                                    a.Date.Month >= firstMonthTrim &&
                                    a.Date.Month <= firstMonthTrim + 2)
                                )
                            .Include(p => p.Breed)
                            .Include(p => p.Species)
                            .ToListAsync();
    }
    //Listar las mascotas y sus propietarios cuya raza sea Golden Retriver --OK
    public async Task<IEnumerable<Pet>> GetOwnerPetByBreed (string breed)
    {
        return await _context.Pets
                            .Where(p => p.Breed.Name.ToUpper() == breed.ToUpper())
                            .Include(p => p.Breed)
                            .Include(p => p.Species)
                            .Include(p => p.Owner)
                            .ToListAsync();
    }
    public override async Task<Pet> GetByIdAsync(int id)
    {
        return await _context.Pets
                            .Include(p => p.Owner)
                            .Include(p => p.Species)
                            .Include(p => p.Breed)
                            .FirstOrDefaultAsync();
    }
    public override async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await _context.Pets
                            .Include(p => p.Owner)
                            .Include(p => p.Species)
                            .Include(p => p.Breed)
                            .ToListAsync();
    }
    public override async Task<(int totalRegistros, IEnumerable<Pet> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Pets as IQueryable<Pet>;
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.ToUpper() == search.ToUpper());
        }
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.Owner)
            .Include(p => p.Species)
            .Include(p => p.Breed)                
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

        
}