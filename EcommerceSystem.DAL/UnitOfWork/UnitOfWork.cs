using EcommerceSystem.DAL.Data.Context;
using EcommerceSystem.DAL.Repositories.Carts;
using EcommerceSystem.DAL.Repositories.Customers;
using EcommerceSystem.DAL.Repositories.Orders;
using EcommerceSystem.DAL.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public ICustomerRepository CustomerRepository { get; }
    public ICartRepository CartRepository { get; }
    public IOrderRepository OrderRepository { get; }
    private readonly EcommerceContext _context;


    public UnitOfWork(IProductRepository productRepository,
        ICustomerRepository cutomerRepository,
        ICartRepository cartRepository,
        IOrderRepository orderRepository,
        EcommerceContext context)
    {
        ProductRepository = productRepository;
        CustomerRepository = cutomerRepository;
        CartRepository= cartRepository;
        OrderRepository = orderRepository;
        _context = context;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
