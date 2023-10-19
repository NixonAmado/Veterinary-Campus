using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratory
    {
        private readonly DbAppContext _context;

        public LaboratoryRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    
    public override async Task<(int totalRegistros, IEnumerable<Laboratory> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Laboratories as IQueryable<Laboratory>;
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