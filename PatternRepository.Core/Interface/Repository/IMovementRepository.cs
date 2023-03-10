using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;

namespace PatternRepository.Core.Interface.Repository
{
    public interface IMovementRepository : IRepository<Movement>
    {
        IEnumerable<Movement> GetAllMovementByUser(DateTime dateTime, int customerId);
    }
}
