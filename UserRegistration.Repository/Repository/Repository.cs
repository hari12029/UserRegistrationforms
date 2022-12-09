using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserRegistration.Repository.Database;

namespace UserRegistration.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly userregistration_Context _userregistration_Context;
        private DbSet<T> entities;

        public Repository(userregistration_Context userregistration_Context)
        {
            _userregistration_Context = userregistration_Context;
            entities = _userregistration_Context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filters)
        {
            return await entities.Where(filters).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            foreach (var item in includeProperties)
                entities.Include(item).Load();

            return await entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filters, params Expression<Func<T, object>>[] includeProperties)
        {
            var data = entities.Where(filters);
            if (includeProperties != null)
            {
                foreach (var item in includeProperties)
                    data.Include(item).Load();
            }

            return await data.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await entities.AddAsync(entity);
            await Save();
        }

        public async Task Update(T entity)
        {
            entities.Attach(entity);
            _userregistration_Context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task Delete(object id)
        {
            T existing = await entities.FindAsync(id);
            entities.Remove(existing);
            await Save();
        }

        public async Task Save()
        {
            await _userregistration_Context.SaveChangesAsync();
        }


    }
}
