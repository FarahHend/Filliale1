using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FillialeDomain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        #region async Functions
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<T> GetAsync(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        string Update(T entity);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        string Removeobject(T entity);
        IEnumerable<T> GetByID(Guid id);
        T GetById(Guid id);

        IEnumerable<T> ExecuteStoreQueryAsync(String commandText, params object[] parameters);
        IEnumerable<T> ExecuteStoreQueryAsync(String commandText, Func<IQueryable<T>,
            IIncludableQueryable<T, object>> includes = null);

        #endregion

        #region sync Functions

        string Add(T entity);
        T AddId(T entity);
        string AddRange(IEnumerable<T> entities);

        T Get(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        IEnumerable<T> GetList(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        IEnumerable<T> ExecuteStoreQuery(String commandText, params object[] parameters);

        IEnumerable<T> ExecuteStoreQuery(String commandText,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        string Remove(Guid id);
        void RemoveRange(IEnumerable<T> entites);
        #endregion
    }
}
