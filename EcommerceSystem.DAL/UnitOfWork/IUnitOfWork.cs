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

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public ICustomerRepository CustomerRepository { get; }
    public ICartRepository  CartRepository { get; }
    public IOrderRepository OrderRepository { get; }

    public void SaveChanges();
}
