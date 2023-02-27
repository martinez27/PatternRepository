using PatternRepository.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Interface
{
    public interface IMovementService
    { 
        void CreateMovement(MovementDTO movement);
        void UpdateMovement(MovementDTO movement);
        Task DeleteMovement(int movementId);
    }
}
