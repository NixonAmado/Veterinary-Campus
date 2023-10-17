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



    
    }
