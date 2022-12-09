using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.Repository.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filters);
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filters, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetById(object id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(object id);
        Task Save();
        //Task<Register> GetByCredentials(Usermodel um);
    }

}
