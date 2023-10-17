using Domain.Entities;

namespace Domain.Interfaces;
public interface IProduct : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProdByLabAsync( string name);
    Task<IEnumerable<Product>> GetGreaterThan( double price);
}
