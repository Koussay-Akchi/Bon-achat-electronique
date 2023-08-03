using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace bonachatelecronique.data.Data
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetEntity(object id);
        Task<bool> AddEntity(T entity);
        Task<bool> AddListEntity(List<T> list_entity);
        //Task<T> UpdateEntity(T entity);
        Task<bool> UpdateEntity(T entity);
        Task<bool> UpdateListEntity(List<T> list_entity);
        Task<bool> DeleteEntity(object id);
        Task<ICollection<T>> GetAllEntity();
        //IEnumerable<T>  (Expression<Func<T, bool>> predicate);
        Task<bool> DeleteListEntity(List<T> list_entity);
    }
}
