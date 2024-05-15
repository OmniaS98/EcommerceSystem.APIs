using EcommerceSystem.DAL.Data.Context;
using EcommerceSystem.DAL.Repositories.Carts;
using EcommerceSystem.DAL.Repositories.Customers;
using EcommerceSystem.DAL.Repositories.Orders;
using EcommerceSystem.DAL.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL;

public static class ServicesExtensions
{
    public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EcommerceDB");
        services.AddDbContext<EcommerceContext>(options =>
        options.UseSqlServer(connectionString));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
