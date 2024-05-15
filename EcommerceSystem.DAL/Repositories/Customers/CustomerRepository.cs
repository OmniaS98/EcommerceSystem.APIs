using EcommerceSystem.DAL.Data.Context;
using EcommerceSystem.DAL.Data.Models;
using EcommerceSystem.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories.Customers;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(EcommerceContext context) : base(context)
    {
    }

    public Customer? GetById(string id)
    {
        return _context.Set<Customer>()
            .Find(id);
    }
}
