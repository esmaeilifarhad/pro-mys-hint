using Pro.MYS.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Application.IRepository
{
    public interface IRepositoryGeneric<T> where T : BaseEntity<long>
    {
        IQueryable<T> TableNoTracking { get; }

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includes = "", int skip = -1, int take = -1);
        Task<int> CountRecords(Expression<Func<T, bool>> where = null);
        Task<T> GetById(long id);
        Task<T> FindSingleOrDefault(Expression<Func<T, bool>> where = null);
        Task<T> Insert(T entity);
        T Add(T entity);
        Task<int> SaveAsync();
        Task<IEnumerable<T>> InsertRange(IEnumerable<T> entity);
        Task<int> Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task DeleteRange(IEnumerable<T> entities);
        Task<int> Delete(T entity);
        Task<int> DeleteById(long id);
        IQueryable<T> queryable();
    }
}
