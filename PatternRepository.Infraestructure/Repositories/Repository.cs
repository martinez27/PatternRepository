using Microsoft.EntityFrameworkCore;
using PatternRepository.Core.Interface;
using PatternRepository.Infraestructure.Data;
using System.Linq.Expressions;

namespace PatternRepository.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppEntitiesContext _context;
        private readonly DbSet<T> _entity;

        public Repository(AppEntitiesContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public void Add(T entity)
        {
            _entity.Add(entity);

        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public IEnumerable<T> GetAllAsync(Expression<Func<T, bool>> expression, string navigationProps = "")
        {
            IQueryable<T> query = _entity.AsQueryable().Where(expression);

            if (!string.IsNullOrEmpty(navigationProps))
            {
                foreach (var property  in navigationProps.Split(","))
                {
                    query = query.Include(property);
                }
            }

            return query.AsEnumerable();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _entity.FindAsync(id);
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }
    }
}
