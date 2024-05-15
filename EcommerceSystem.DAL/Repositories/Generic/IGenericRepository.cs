using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories.Generic;

public interface IGenericRepository<TEntity> where TEntity: class
{
    IEnumerable<TEntity> GetAll();
    void Add(TEntity entity);
    TEntity? GetById(int id);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
