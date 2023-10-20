using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class ProductMovementRepository : GenericRepository<ProductMovement>, IProductMovement
    {
        private readonly DbAppContext _context;

        public ProductMovementRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        //Listar todos los movimientos de medicamentos y el valor total de cada movimiento. --Ok
        public async Task<IEnumerable<ProductMovement>> GetProductMovement()
        {
            return await _context.ProductMovements
                                .Include(p => p.Product)
                                .Select(p => new ProductMovement
                                {
                                    Product = p.Product,
                                    Quantity = p.Quantity,
                                    Date = p.Date,
                                    TotalPrice = p.Product.Price * p.Quantity
                                })
                                .ToListAsync();
        }
        public override async Task<ProductMovement> GetByIdAsync(int id)
        {
            return await _context.ProductMovements
                                .Include(p => p.Product)
                                .FirstAsync(p => id == p.Id);
        }
        public override async Task<IEnumerable<ProductMovement>> GetAllAsync()
        {
            return await _context.ProductMovements
                                .Include(p => p.Product)
                                .ToListAsync();
        }
        public override async Task<(int totalRegistros, IEnumerable<ProductMovement> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.ProductMovements as IQueryable<ProductMovement>;
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
