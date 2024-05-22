using EcommerceSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Data.Context;

public class EcommerceContext : IdentityDbContext<Customer>
{

    public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        //User has one to one relation with cart 
        modelBuilder.Entity<Customer>()
             .HasOne(c => c.Cart)
             .WithOne(cart => cart.Cutomer)
             .HasForeignKey<Cart>(cart => cart.CustomerId);

   

        #region Data Seed
        List<Category> categories =
            [
                new() { Id = 1, Name = "Electronics" },
                new() { Id = 2, Name = "Clothing" },
                new() { Id = 3, Name = "Sports & Outdoors" },
                new() { Id = 4, Name = "Books & Audible" }
            ];

        List<Product> products =
            [
                new() { Id = 1, Name = "Dell XPS 13", Description = "Premium ultrabook with Intel Core i7 processor, 16GB RAM, 512GB SSD, and 13.3-inch InfinityEdge display.", Price = 1499.99, CategoryId = 1, Quantity = 10 },
                new() { Id = 2, Name = "Lenovo ThinkPad X1 Carbon", Description = "Business-class laptop with Intel Core i5 processor, 8GB RAM, 256GB SSD, and 14-inch FHD display.", Price = 1299.99, CategoryId = 1, Quantity = 15 },
                new() { Id = 3, Name = "Samsung Galaxy S21 Ultra", Description = "Flagship smartphone with 6.8-inch AMOLED display, Snapdragon 888 processor, 12GB RAM, 128GB storage, and quad rear cameras.", Price = 1199.99, CategoryId = 1, Quantity = 20 },
                new() { Id = 4, Name = "Sony WH-1000XM4 Wireless Headphones", Description = "Premium wireless headphones with industry-leading noise cancellation, 30-hour battery life, and touch sensor controls.", Price = 349.99, CategoryId = 1, Quantity = 25 },
                new() { Id = 5, Name = "Apple Watch Series 7", Description = "Advanced smartwatch with always-on Retina display, blood oxygen sensor, ECG app, and built-in GPS.", Price = 399.99, CategoryId = 1, Quantity = 30 },

                new() { Id = 6, Name = "Nike Men's Dri-FIT Polo Shirt", Description = "Nike Dri-FIT moisture-wicking polo shirt with ribbed collar and three-button placket. Available in various colors and sizes.", Price = 39.99, CategoryId = 2, Quantity = 40 },
                new() { Id = 7, Name = "Adidas Women's Ultraboost Running Shoes", Description = "Adidas Ultraboost running shoes with Primeknit upper and responsive Boost midsole. Designed specifically for women's fit.", Price = 169.99, CategoryId = 2, Quantity = 45 },
                new() { Id = 8, Name = "The North Face Men's Resolve 2 Jacket", Description = "Waterproof and breathable jacket with seam-sealed DryVent 2L shell. Features adjustable hood, hem cinch-cord, and zippered hand pockets.", Price = 89.99, CategoryId = 2, Quantity = 50 },
                new() { Id = 9, Name = "Levi's Women's High Rise Skinny Jeans", Description = "Levi's high rise skinny jeans with stretch denim construction and slim fit through hips and thighs. Available in various washes.", Price = 59.99, CategoryId = 2, Quantity = 55 },
                new() { Id = 10, Name = "Under Armour Men's Tech 2.0 Short Sleeve T-Shirt", Description = "Under Armour Tech 2.0 short sleeve t-shirt with UA Tech fabric for quick-drying and ultra-soft comfort. Available in assorted colors.", Price = 24.99, CategoryId = 2, Quantity = 60 },

                new() { Id = 11, Name = "Yeti Tundra 45 Cooler", Description = "Premium cooler with rotomolded construction for durability and superior ice retention. Features PermaFrost insulation and FatWall design.", Price = 299.99, CategoryId = 3, Quantity = 20 },
                new() { Id = 12, Name = "Osprey Packs Atmos AG 65 Backpack", Description = "Osprey Atmos AG 65 backpack with Anti-Gravity suspension system for comfort and ventilation. Features adjustable harness and fit-on-the-fly hipbelt.", Price = 289.95, CategoryId = 3, Quantity = 25 },
                new() { Id = 13, Name = "Yeti Rambler 30 oz Tumbler", Description = "Double-wall vacuum insulated tumbler with stainless steel construction. Keeps drinks hot or cold for hours. Includes MagSlider lid.", Price = 34.99, CategoryId = 3, Quantity = 30 },
                new() { Id = 14, Name = "ENO DoubleNest Hammock", Description = "Double hammock for two people with 70D high-tenacity nylon taffeta construction. Features aluminum wiregate carabiners and triple interlocking stitching.", Price = 69.95, CategoryId = 3, Quantity = 35 },
                new() { Id = 15, Name = "Coleman RoadTrip 285 Portable Stand-Up Propane Grill", Description = "Portable propane grill with 20,000 BTUs of cooking power. Features 285 square inches of grilling area, InstaStart ignition, and collapsible design.", Price = 249.99, CategoryId = 3, Quantity = 40 },

                new() { Id = 16, Name = "Becoming by Michelle Obama", Description = "Memoir by former First Lady Michelle Obama. Chronicles her life from childhood to her years in the White House.", Price = 14.99, CategoryId = 4, Quantity = 100 },
                new() { Id = 17, Name = "The Silent Patient by Alex Michaelides", Description = "Bestselling psychological thriller novel by Alex Michaelides. Gripping storyline with unexpected twists.", Price = 14.99, CategoryId = 4, Quantity = 105 },
                new() { Id = 18, Name = "Educated by Tara Westover", Description = "Memoir by Tara Westover. Chronicles her journey from a survivalist family in Idaho to earning a PhD from Cambridge University.", Price = 11.99, CategoryId = 4, Quantity = 110 },
                new() { Id = 19, Name = "Where the Crawdads Sing by Delia Owens", Description = "Bestselling novel by Delia Owens. A mystery and coming-of-age story set in the marshes of North Carolina.", Price = 9.99, CategoryId = 4, Quantity = 115 },
                new() { Id = 20, Name = "A Promised Land by Barack Obama", Description = "Memoir by former President Barack Obama. Reflects on his early political career, presidency, and legacy.", Price = 22.99, CategoryId = 4, Quantity = 120 }

            ];



        modelBuilder.Entity<Category>()
            .HasData(categories);

        modelBuilder.Entity<Product>()
            .HasData(products);



        #endregion

    }



}
