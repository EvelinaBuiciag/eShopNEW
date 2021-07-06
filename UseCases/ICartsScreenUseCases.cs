using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UseCases
{
    public interface ICartsScreenUseCases
    {
        Task<int> AddCart(Cart cart);
        Task UpddateCart(Cart cart);
        Task<Cart> ViewCartById(int cartId);
        Task<IEnumerable<Cart>> ViewCartsAsync();
    }
}