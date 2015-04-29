using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backend.DAL_implementation
{
    public class RepositoryFactory
    {
        private DbContext _dbContext;
        public RepositoryFactory()
        {
            _dbContext = new parking_stubEntities();
        }
        public Repository<T> GetRepository<T>() where T:class
        {            
            var repository = new Repository<T>(_dbContext.Set<T>());
            return repository;
        }
    }
}
