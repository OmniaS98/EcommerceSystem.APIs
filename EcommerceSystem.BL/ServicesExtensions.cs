using EcommerceSystem.BL.Managers.Carts;
using EcommerceSystem.BL.Managers.Orders;
using EcommerceSystem.BL.Managers.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL;

public static class ServicesExtensions
{
    public static void AddBLServices(this IServiceCollection  services)
    {
        services.AddScoped<IProductManager, ProductManager>();
        services.AddScoped<ICartManager, CartManager>();
        services.AddScoped<IOrderManager, OrderManager>();
    }
}
