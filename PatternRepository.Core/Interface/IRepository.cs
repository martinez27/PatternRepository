using System.Linq.Expressions;

namespace PatternRepository.Core.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllAsync(
            Expression<Func<T,bool>> expression,
            string navigationProps = "");
        Task<T> GetByIdAsync(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
