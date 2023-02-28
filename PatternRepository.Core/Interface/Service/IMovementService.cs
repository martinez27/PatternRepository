using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Interface.Service
{
    public interface IMovementService
    {
        void CreateMovement(MovementDTO movement);
        void UpdateMovement(MovementDTO movement);
        Task DeleteMovement(int movementId);
        void RetirarMovement(MovementDTO movement);
        void DepositarMovement(MovementDTO movement);

    }
}
