using Repository;
using Repository.ApiClient;
using Core.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

HttpClient httpClient = new();
IWebApiExecuter apiExectuer = new WebApiExecuter("https://localhost:44363", httpClient);

await TestCarts();

await TestProducts();

#region Test Carts

async Task TestCarts()
{
    Console.WriteLine("////////////////////");
    Console.WriteLine("Reading carts...");
    await GetCarts();

    Console.WriteLine("////////////////////");
    Console.WriteLine("Reading cart's products...");
    await GetCartProducts(1);
}

async Task GetCarts()
{
    CartRepository repository = new(apiExectuer);
    var carts = await repository.GetAsync();
    foreach (var cart in carts)
    {
        Console.WriteLine($"Cart: {cart.CartId}");
    }
}

async Task<Cart> GetCart(int id)
{
    CartRepository repository = new(apiExectuer);
    return await repository.GetByIdAsync(id);
}

async Task GetCartProducts(int id)
{
    var Cart = await GetCart(id);
    Console.WriteLine($"Cart: {Cart.CartId}");

    CartRepository repository = new(apiExectuer);
    var products = await repository.GetCartProductsAsync(id);
    foreach (var product in products)
    {
        Console.WriteLine($"    Product: {product.Name}");
    }
}
#endregion

#region Test Products
async Task TestProducts()
{
    Console.WriteLine("////////////////////");
    Console.WriteLine("Reading all products...");
    await GetProducts();

    Console.WriteLine("////////////////////");
    Console.WriteLine("Reading product id 1...");
    var tId = await GetProductById(1);
    await GetProducts();

    Console.WriteLine("////////////////////");
    Console.WriteLine("Update product id 1");
    var product = await GetProductById(1);
    await UpdateProduct(product);
    await GetProducts();
}

async Task GetProducts()
{
    ProductRepository productRepository = new(apiExectuer);
    var products = await productRepository.GetAsync();
    foreach (var product in products)
    {
        Console.WriteLine($"Product: {product.Name}");
    }
}

async Task<Product> GetProductById(int id)
{
    ProductRepository productRepository = new(apiExectuer);
    var product = await productRepository.GetByIdAsync(id);
    return product;
}

async Task UpdateProduct(Product product)
{
    ProductRepository productRepository = new(apiExectuer);
    product.Name += " Updated";
    await productRepository.UpdateAsync(product);
}

#endregion
