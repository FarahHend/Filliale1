using FillialeData.Context;
using FillialeDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FillialeData.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FillialeContext Context;

        public Repository(FillialeContext context)
        {
            Context = context;
        }

        #region Async Functions

        public virtual async Task AddAsync(T entity)
        {
            try
            {
                await Context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await Context.Set<T>().AddRangeAsync(entities);
            }
            catch (Exception e)
            {
                var s = e.ToString();
                throw;
            }

        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();
                if (includes != null)
                {
                    query = includes(query);
                }

                if (condition != null)
                {
                    return await query.FirstOrDefaultAsync(condition);
                }

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                query = includes(query);
            }

            if (condition != null)
            {
                return await query.Where(condition).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public virtual IEnumerable<T> ExecuteStoreQueryAsync(string commandText, params object[] parameters)
        {
            throw new NotImplementedException();

        }

        public virtual IEnumerable<T> ExecuteStoreQueryAsync(string commandText, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {

            throw new NotImplementedException();
        }

        #endregion


        #region Sync Functions

        public string Add(T entity)
        {
            string response = "";
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();

                response = "Added done";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response = "Add Not done , with Exeption \n" + e;
            }
            return response;
        }

        public T AddId(T entity)
        {



            Context.Set<T>().Add(entity);

            Context.SaveChanges();

            return entity;


        }

        public string AddRange(IEnumerable<T> entities)
        {
            string response = "";
            try
            {
                Context.Set<T>().AddRange(entities);
                Context.SaveChanges();
                return response = "Added done";
            }
            catch (Exception e)
            {
                var s = e.ToString();
                return response = "Add Not done , with Exeption \n" + e;
            }
        }


        public IEnumerable<T> ExecuteStoreQuery(string commandText, params object[] parameters)
        {


            throw new NotImplementedException();
        }

        public IEnumerable<T> ExecuteStoreQuery(string commandText, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {


            throw new NotImplementedException();
        }



        public T Get(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();

                if (includes != null)
                {
                    query = includes(query);
                }

                if (condition != null)
                {
                    return query.FirstOrDefault(condition);
                }

                return query.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public IEnumerable<T> GetList(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = Context.Set<T>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (condition != null)
            {
                return query.Where(condition).ToList();
            }

            return query.ToList();
        }


        public string Remove(Guid id)
        {

            //    T table = Context.Set<T>().Find(id);
            //    Context.Set<T>().Remove(table);
            //    Context.SaveChanges();

            //    return "Delete Done";



            if (id == null)
            {
                return "Id null";
            }

            try
            {
                T table = Context.Set<T>().Find(id);
                Context.Set<T>().Remove(table);
                Context.SaveChanges();

                JsonConvert.SerializeObject(table, Formatting.Indented,
                   new JsonSerializerSettings
                   {
                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                       //ContractResolver = new CamelCasePropertyNamesContractResolver()
                   });
                return "Done";
            }
            catch (Exception ex)
            {
                return "Delete error";
                // return "could not be updated: {ex.Message}";
            }
        }



        public void RemoveRange(IEnumerable<T> entites)
        {
            try
            {
                Context.Set<T>().RemoveRange(entites);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #endregion

        #region Generic Controller Test

        public T GetById(Guid id)
        {
            IQueryable<T> query = Context.Set<T>();
            return Context.Set<T>().FirstOrDefault();
        }

        public IEnumerable<T> GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Update(T entity)
        {
            Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return "Update Done";
        }

        public string Removeobject(T entity)
        {

            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
            return "delete done";




        }



        #endregion
    }
}
