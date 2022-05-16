using System;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository
    {
        List<T> GetAll<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void SaveChanges();
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        T GetById<T>(Guid Id) where T : class;
    }
}
