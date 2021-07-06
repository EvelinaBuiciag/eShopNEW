using Repository.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IWebApiExecuter webApiExecuter;

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await webApiExecuter.InvokeGet<IEnumerable<Product>>("api/products");
        }
        public ProductRepository(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await webApiExecuter.InvokeGet<Product>($"api/products/{id}?api-version=1.0");
            //return products.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            await webApiExecuter.InvokePut($"api/products/{product.ProductId}?api-version=1.0", product);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return await webApiExecuter.InvokeGet<IEnumerable<Product>>("api/products");
            else
            {
                //return await products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
                //await webApiExecuter.InvokePut($"api/products?{Name}?api -version=1.0", product);
                return await webApiExecuter.InvokeGet<IEnumerable<Product>>("api/products");
            }
        }

    }
}