using Api.Foundation.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Data.Repository
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperies);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        IQueryable<T> TableNoTracking { get; }
        T GetSingle(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(Expression<Func<T, bool>> predicate);
        void Edit(T entity);
       
    }
}
