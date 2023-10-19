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
        public override async Task<(int totalRegistros, IEnumerable<Breed> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Breeds as IQueryable<Breed>;

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToUpper() == search.ToUpper());
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }
    }