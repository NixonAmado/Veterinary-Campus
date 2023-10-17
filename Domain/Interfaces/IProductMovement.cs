using Domain.Entities;

namespace Domain.Interfaces;
public interface IProductMovement : IGenericRepository<ProductMovement>
{
    Task<IEnumerable<ProductMovement>> GetProductMovement();
}
