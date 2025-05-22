using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        Task SaveChangesAsync();
        void DeleteRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);

        

    }
}
