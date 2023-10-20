using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class MovementDetailRepository : GenericRepository<MovementDetail>, IMovementDetail
    {
        private readonly DbAppContext _context;

        public MovementDetailRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        public override async Task<MovementDetail> GetByIdAsync(int id)
        {
            return await _context.MovementDetails
                                .Include(p => p.Product)
                                .FirstAsync(p => p.Id == id);

        }
        public override async Task<IEnumerable<MovementDetail>> GetAllAsync()
        {
            return await _context.MovementDetails
                                .Include(p => p.Product)
                                .ToListAsync();
        }
        public override async Task<(int totalRegistros, IEnumerable<MovementDetail> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.MovementDetails as IQueryable<MovementDetail>;

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Id.ToString() == search);
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Product)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }
    }
