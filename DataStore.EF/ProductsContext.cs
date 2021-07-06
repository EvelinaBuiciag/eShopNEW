using Microsoft.EntityFrameworkCore;
using System;
using Core.Models;

namespace DataStore.EF
{
    public class ProductsContext: DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasMany(p => p.Products)
                .WithOne(t => t.Cart)
                .HasForeignKey(t => t.CartId);

            //seeding
            modelBuilder.Entity<Cart>().HasData(
                    new Cart { CartId = 1},
                    new Cart { CartId = 2},
                    new Cart { CartId = 3}
                );

            modelBuilder.Entity<Product>().HasData(
               new Product { ProductId = 1, CartId = 1, Name = "Red dress", Description = "Red dress", Image = "https://i0.wp.com/myenvie.com/wp-content/uploads/2018/08/Gabriella-Red-Dress-Cocktail-Mermaid-Hem-Bright-Bandage.jpg?fit=2047%2C3071&ssl=1", Price = 345, Discount = 0 },
                new Product { ProductId = 2, CartId = 2, Name = "Blue dress", Description = "Blue dress", Image = "https://cf.shopee.ph/file/b05b3d64e9c34210662dde776f32167d", Price = 2345, Discount = 30 },
                new Product { ProductId = 3, CartId = null, Name = "Red pants", Description = "Red pants", Image = "https://www.na-kd.com/globalassets/nakd_wide_leg_tailored_pants_1018-001153-0004_01c.jpg?ref=68D5C97B86", Price = 860, Discount = 10 },
                new Product { ProductId = 4, CartId = null, Name = "Blue pants", Description = "Blue pants", Image = "https://sslimages.shoppersstop.com/sys-master/images/h56/hfc/15521843937310/5544AEIROYALBLU_ROYAL_BLUE.jpg_2000Wx3000H", Price = 123, Discount = 0 },
                new Product { ProductId = 5, CartId = null, Name = "Yellow dress", Description = "Yellow dress", Image = "https://photos.starshiners.com/85960/yellow-dress-elegant-cloche-short-cut-with-button--S049270-1-477592.jpgg", Price = 678, Discount = 5 },
                new Product { ProductId = 6, CartId = null, Name = "Green dress", Description = "Green dress", Image = "https://i.pinimg.com/236x/03/44/a6/0344a6c2f87278f4a9e09671ebcdbc2e--emerald-green-dresses-green-long-dresses.jpg", Price = 900, Discount = 10 },
                new Product { ProductId = 7, CartId = null, Name = "Black dress", Description = "Black dress", Image = "https://www.chiquelle.com/pub_images/large/096-8dec2020.JPG?timestamp=1607448930", Price = 345, Discount = 0 },
                new Product { ProductId = 8, CartId = 3, Name = "White dress", Description = "White dress", Image = "https://i.pinimg.com/736x/6b/7f/2b/6b7f2b737717f29a62cb376f9d6ab35b.jpg", Price = 780, Discount = 10 },
                new Product { ProductId = 9, CartId = 1, Name = "Pink dress", Description = "Pink dress", Image = "https://cdn.shopify.com/s/files/1/2434/7173/products/WhatsAppImage2020-09-09at11.27.44_1125x.jpg?v=1601147395", Price = 650, Discount = 0 },
                new Product { ProductId = 10, CartId = 2, Name = "Purple dress", Description = "Purple dress", Image = "https://i.etsystatic.com/7799304/r/il/8770f2/2330260135/il_570xN.2330260135_9311.jpg", Price = 1100, Discount = 10 }
                );
        }
    }
}
