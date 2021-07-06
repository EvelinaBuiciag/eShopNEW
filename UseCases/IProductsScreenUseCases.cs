using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UseCases
{
    public interface IProductsScreenUseCases
    {
        Task<IEnumerable<Product>> Execute(string filter = null);
        Task UpdateProduct(Product product);
        Task<IEnumerable<Product>> ViewCartsProducts(int cartId);
        Task<Product> ViewProductById(int productId);
        Task<IEnumerable<Product>> ViewProductsAsync();
    }
}