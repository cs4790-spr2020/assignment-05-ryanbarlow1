using BlabberApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;

namespace BlabberApp.DataStore
{
    public class MySqlRepository<T> : IRepository<T> where T : EntityBase
    {
        private IContext _context;
        private DbSet<T> _entities;

        public MySqlRepository(IContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            _entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            if (id < 1)
                return null;
            
            return _entities.Find(id);
        }

        public IEnumerable GetAll()
        {
            return _entities.AsEnumerable();
        }
    }
}