using Repository.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly IWebApiExecuter webApiExecuter;

        public CartRepository(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }
        public async Task UpdateCartAsync(Cart cart)
        {
            await webApiExecuter.InvokePut($"api/carts/{cart.CartId}?api-version=1.0", cart);
        }
        public async Task<IEnumerable<Cart>> GetAsync()
        {
            return await webApiExecuter.InvokeGet<IEnumerable<Cart>>("api/carts");
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await webApiExecuter.InvokeGet<Cart>($"api/carts/{id}");
        }

        public async Task<IEnumerable<Product>> GetCartProductsAsync(int cartId, string filter = null)
        {
            string uri = $"api/carts/{cartId}/products";
            if (!string.IsNullOrWhiteSpace(filter))
                uri += $"?cart={filter}&api-version=2.0";

            return await webApiExecuter.InvokeGet<IEnumerable<Product>>(uri);
        }
        public async Task<int> CreateCartAsync(Cart cart)
        {
            cart = await webApiExecuter.InvokePost("api/cards", cart);
            return cart.CartId;
        }
    }
}

