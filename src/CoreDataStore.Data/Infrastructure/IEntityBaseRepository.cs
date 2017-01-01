using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Domain.Entities.Base;

namespace CoreDataStore.Data.Infrastructure
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T GetSingle(long id);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetSingleAsync(long id);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetPage(int startRow, int pageLength, IEnumerable<SortModel> sortingList);

        IQueryable<T> GetPage(Expression<Func<T, bool>> predicate, int startRow, int pageLength, IEnumerable<SortModel> sortingList);

        void Add(T entity);

        void Delete(T entity);

        void Edit(T entity);

        void Commit();
    
    }
}
