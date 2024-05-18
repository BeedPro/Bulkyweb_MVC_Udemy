using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
    // Implement Repository Interface
    internal interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
