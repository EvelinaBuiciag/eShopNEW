using Core.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UseCases
{
    public class ProductsScreenUseCases : IProductsScreenUseCases
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;

        public ProductsScreenUseCases(ICartRepository cartRepository,
            IProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
        }


        public async Task<IEnumerable<Product>> ViewProductsAsync()
        {
            return await productRepository.GetAsync();
        }
        public async Task<IEnumerable<Product>> ViewCartsProducts(int cartId)
        {
            return await cartRepository.GetCartProductsAsync(cartId);
        }
        public async Task<Product> ViewProductById(int productId)
        {
            return await productRepository.GetByIdAsync(productId);
        }

        public async Task UpdateProduct(Product product)
        {
            await productRepository.UpdateAsync(product);
        }


        public async Task<IEnumerable<Product>> Execute(string filter = null)
        {
            return await productRepository.GetProductsAsync(filter);
        }
    }
}