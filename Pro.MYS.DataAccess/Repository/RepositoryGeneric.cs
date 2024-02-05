using Microsoft.EntityFrameworkCore;
using Pro.MYS.Application.IRepository;
using Pro.MYS.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.DataAccess.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : BaseEntity<long>

    {

        private readonly DatabaseContext context;
        private readonly DbSet<T> _entities;

        public virtual IQueryable<T> Table => _entities;
        public virtual IQueryable<T> TableNoTracking => _entities.AsNoTracking();

       

        public RepositoryGeneric(DatabaseContext context)
        {
            this.context = context;
            _entities = context.Set<T>();
        }
        public async Task<int> Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
           var res=  await context.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            var res = await _entities.SingleOrDefaultAsync(s => s.Id == id);
            return res;


        }

        public async Task<T> Insert(T entity)
        {
            try
            {

                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _entities.Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)

            {

                throw ex;
            }

        }
        public T Add(T entity)
        {
            try
            {

                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _entities.Add(entity);
                // await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)

            {

                throw;
            }

        }
        public async Task<int> SaveAsync()
        {
            return (await context.SaveChangesAsync());
        }
        public async Task<IEnumerable<T>> InsertRange(IEnumerable<T> entity)
        {
            try
            {

                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                await _entities.AddRangeAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                return null;

            }

        }

        public async Task<int> Update(T entity)
        {
            try
            {

                if (entity == null)
                {
                   
                    throw new ArgumentNullException("entity");
                   
                }

                _entities.Attach(entity);
                //added by esmaeili
               context.Entry(entity).State = EntityState.Modified;
              return  await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());

            }
        }

        public async Task UpdateRange(IEnumerable<T> entities)
        {
            try
            {

                if (entities == null)
                {
                    throw new ArgumentNullException("entity");
                }

                _entities.AttachRange(entities);
                //added by esmaeili
                // context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task DeleteRange(IEnumerable<T> entities)
        {
            try
            {

                if (entities == null)
                {
                    throw new ArgumentNullException("entity");
                }

                _entities.RemoveRange(entities);
                //added by esmaeili
                // context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> DeleteById(long id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
          var res=  await Delete(entity);
            return res;
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderby, string includes, int skip = -1, int take = -1)
        {
            IQueryable<T> query = _entities;

            if (where != null)
            {

                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            if (take != -1 && skip == -1)
            {
                query = query.Take(take);
            }
            if (take != -1 && skip != -1)
            {
                query = query.Skip((skip * take)).Take(take);
            }
            return await query.ToListAsync();
        }


        public async Task<int> CountRecords(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> query = _entities;

            if (where != null)
            {
                query = query.Where(where);
            }
            return await query.CountAsync();

        }
        public IQueryable<T> queryable()
        {
            IQueryable<T> query = _entities;

            return query;

        }

        public async Task<T> FindSingleOrDefault(Expression<Func<T, bool>> where = null)
        {
            return await _entities.SingleOrDefaultAsync(where);
            // throw new NotImplementedException();
        }
    }
}
