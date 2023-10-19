using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class PersonTypeRepository : GenericRepository<PersonType>, IPersonType
    {
        private readonly DbAppContext _context;

        public PersonTypeRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<PersonType> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.PersonTypes as IQueryable<PersonType>;

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Description.ToUpper() == search.ToUpper());
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
