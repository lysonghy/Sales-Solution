using Sales.DataAccess.Core;
using Sales.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Repository
{
    public class EFRepository<TEntity,TKey>:Core.IRepository<TEntity,TKey> where TEntity:class
    {
        private DbContext _context;
        public EFRepository()
        {
            this._context = ContextManager.CreateContext;
        }

        public TEntity Get(TKey value)
        {
            return _context.Set<TEntity>().Find(value);
        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Get(string orderField)
        {
            return OrderBy(Get(), orderField);
        }

        public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> filters)
        {
            return Get().Where(filters);
        }

        public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> filters, string orderField)
        {
            return Get(orderField).Where(filters);
        }

        public IQueryable<BusinessObject> Query<BusinessObject>(string query, System.Data.CommandType commandType, params object[] parameters) where BusinessObject : class
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("Query", "Query is empty");
            }
            return _context.Database.SqlQuery<BusinessObject>(query, parameters).AsQueryable();
        }
        
        public int Excute(string query, params object[] parameters)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("Query", "Query is empty");
            }
            return _context.Database.ExecuteSqlCommand(query, parameters);
        }

        public int Insert(TEntity entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException("Entity", "Entity is not avaliable");
            }
            if (getPrimaryKeyValue(entity)!=null)
            {
                return 0;
            }
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            if (getPrimaryKeyValue(entity)==null)
            {
                return 0;
            }
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public TKey getPrimaryKeyValue(TEntity entity) {
            var objectStateEntry = ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
            return (TKey)objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
        public int Delete(TKey key)
        {
            if (key==null)
            {
                return 0;
            }
            var entity = Get(key);
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        public int InsertCollection(ICollection<TEntity> lstEntity)
        {
            throw new NotImplementedException();
        }

        public int UpdateCollection(ICollection<TEntity> lstEntity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TKey[] keys)
        {
            throw new NotImplementedException();
        }

        private IOrderedQueryable<TEntity> OrderingHelper(IQueryable<TEntity> source, string propertyName, bool descending, bool anotherLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(TEntity), string.Empty); // I don't care about some naming
            MemberExpression property = Expression.PropertyOrField(param, propertyName);

            LambdaExpression sort = Expression.Lambda(property, param);

            MethodCallExpression call = Expression.Call(
                                        typeof(Queryable),
                                        (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                                        new[] 
                                            { 
                                                typeof(TEntity), 
                                                property.Type 
                                                
                                            },
                                        source.Expression,
                                        Expression.Quote(sort)
                        );
            return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(call);
        }
        /// <summary>
        /// Order by property name 
        /// </summary>
        /// <param name="source">Data</param>
        /// <param name="propertyName">attribute of object</param>
        /// <returns></returns>
        public IOrderedQueryable<TEntity> OrderBy(IQueryable<TEntity> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, false);
        }
    }
}
