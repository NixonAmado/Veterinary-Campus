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
    //Mostrar las mascotas que se encuentren registradas cuya especie sea felina.
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
                            .ToListAsync();
    }
    //Listar las mascotas y sus propietarios cuya raza sea Golden Retriver
    public async Task<IEnumerable<Pet>> GetOwnerPetByBreed (string breed)
    {
        return await _context.Pets
                            .Where(p => p.Breed.Name.ToUpper() == breed.ToUpper())
                            .Include(p => p.Breed)
                            .Include(p => p.Species)
                            .Include(p => p.Owner)
                            .ToListAsync();
    }
    

        
}