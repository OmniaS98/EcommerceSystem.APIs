using EcommerceSystem.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories.Generic;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly EcommerceContext _context;

    public GenericRepository(EcommerceContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>()
                .Add(entity);
    }

    public void Update(TEntity entity)
    {

    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>()
                .Remove(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>()
                       .AsNoTracking();
    }

    public TEntity? GetById(int id)
    {
        return _context.Set<TEntity>()
                       .Find(id);
    }

}
