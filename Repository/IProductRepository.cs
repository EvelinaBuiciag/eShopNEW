using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync(string filter = null);
        Task UpdateAsync(Product product);
    }
}