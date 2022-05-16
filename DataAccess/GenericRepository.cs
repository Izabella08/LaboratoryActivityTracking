using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class GenericRepository : IRepository
    {
        private readonly SchoolDbContext _dbContext;
        public GenericRepository(SchoolDbContext dbContext)
        {
            this._dbContext = dbContext;
        } 
        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }
        
        public List<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Update(entity);
        }

        public T GetById<T>(Guid Id) where T : class
        {
            return _dbContext.Set<T>().Find(Id);
        }
    }
}
