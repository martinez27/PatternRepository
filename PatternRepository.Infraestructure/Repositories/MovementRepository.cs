using PatternRepository.Core.Entities;
using PatternRepository.Core.Interface.Repository;
using PatternRepository.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Infraestructure.Repositories
{
    public class MovementRepository : Repository<Movement>, IMovementRepository
    {
        public MovementRepository(AppEntitiesContext context) : base(context) { }
    }
}
