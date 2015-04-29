using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DAL_abstract;
using System.Data.Entity;

namespace Backend.DAL_implementation
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private DbSet<T> _db;
        public Repository(DbSet<T> dbParam)
        {
            _db = dbParam;
        }
                 
        public T Get(Guid id)
        {
            return _db.Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _db;
        }

        public T Create(T entity)
        {
            var createdEntity = _db.Add(entity);
            return createdEntity;
        }

        public void Update(Guid id, T newEntity, DbContext context)
        {
            var existingEntity = _db.Find(id);
            context.Entry(existingEntity).CurrentValues.SetValues(newEntity);
        }

        public void Delete(Guid id)
        {
            var entityToRemove = _db.Find(id);
            _db.Remove(entityToRemove);
        }
    }
}
