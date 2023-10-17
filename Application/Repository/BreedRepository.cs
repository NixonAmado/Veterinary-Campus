using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class BreedRepository : GenericRepository<Breed>, IBreed
    {
        private readonly DbAppContext _context;

        public BreedRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

        //Listar la cantidad de mascotas que pertenecen a una raza a una raza. Nota: Se debe mostrar una lista de las razas y la cantidad de mascotas que pertenecen a la raza.        
        public async Task<IEnumerable<CountBreed>> GetPetCountInBreed()
        {            
            List<CountBreed> breeds = new();
                                
            var BreedIteration =  await _context.Breeds
                                        .Select(p => new CountBreed
                                        {
                                            Name = p.Name,
                                            Pets = p.Pets.Count()  
                                        })
                                .ToListAsync();
                breeds.AddRange(BreedIteration);

                return breeds;
        
        }    
    }