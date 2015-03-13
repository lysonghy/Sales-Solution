using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Core
{
    public interface IRepository<TEntity,TKey>
    {
        TEntity Get(TKey value);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(string orderField);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filters);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filters, string orderField);
        IQueryable<BusinessObject> Query<BusinessObject>(string query, CommandType commandType, params object[] parameters) where BusinessObject : class;
        int Excute(string query, params object[] parameters);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TKey key);
        int InsertCollection(ICollection<TEntity> lstEntity);
        int UpdateCollection(ICollection<TEntity> lstEntity);
        int Delete(TKey[] keys);
        TKey getPrimaryKeyValue(TEntity entity);
    }
}
