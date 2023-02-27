namespace PatternRepository.Core.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
