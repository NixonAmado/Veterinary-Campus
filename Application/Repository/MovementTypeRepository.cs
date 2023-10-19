using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class MovementTypeRepository : GenericRepository<MovementType>, IMovementType
    {
        private readonly DbAppContext _context;

        public MovementTypeRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<MovementType> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
        var query = _context.MovementDetails as IQueryable<MovementType>;
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
