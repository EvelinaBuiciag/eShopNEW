using Core.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class CartsScreenUseCases : ICartsScreenUseCases
    {
        private readonly ICartRepository cartRepository;

        public CartsScreenUseCases(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public async Task<Cart> ViewCartById(int cartId)
        {
            return await cartRepository.GetByIdAsync(cartId);
        }
        public async Task UpddateCart(Cart cart)
        {
            await cartRepository.UpdateCartAsync(cart);
        }

        public async Task<int> AddCart(Cart cart)
        {
            return await this.cartRepository.CreateCartAsync(cart);
        }
        public async Task<IEnumerable<Cart>> ViewCartsAsync()
        {
            return await cartRepository.GetAsync();
        }
    }
}