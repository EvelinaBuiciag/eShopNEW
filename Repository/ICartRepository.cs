using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICartRepository
    {
        Task<int> CreateCartAsync(Cart cart);
        Task<IEnumerable<Cart>> GetAsync();
        Task<Cart> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetCartProductsAsync(int cartId, string filter = null);
        Task UpdateCartAsync(Cart cart);
    }
}