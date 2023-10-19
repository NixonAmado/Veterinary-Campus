using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        private readonly DbAppContext _context;

        public ProductRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        //Listar los medicamentos que pertenezcan a el laboratorio X --OK
        public async Task<IEnumerable<Product>> GetProdByLabAsync( string name)
        {
            return await _context.Products
                                .Where( p => p.Laboratory.Name == name)
                                .ToListAsync();
        }
        //Listar los medicamentos que tenga un precio de venta mayor a X
        public async Task<IEnumerable<Product>> GetGreaterThan( double price)
        {
            return await _context.Products
                                .Where( p => p.Price > price)
                                .ToListAsync();
        }


        public override async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
                            .Include(p => p.Laboratory)
                            .ToListAsync();
    }
    public override async Task<(int totalRegistros, IEnumerable<Product> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Products as IQueryable<Product>;
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.ToUpper() == search.ToUpper());
        }
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.Laboratory)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
    
    }
