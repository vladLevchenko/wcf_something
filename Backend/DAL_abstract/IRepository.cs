using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backend.DAL_abstract
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IEnumerable<T> Get();
        T Create(T entity);
        void Update(Guid id, T newEntity, DbContext context);
        void Delete(Guid id);
    }
}
