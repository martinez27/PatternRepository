using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Services
{
    public class MovementService : IMovementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateMovement(MovementDTO movementDTO)
        {
            try
            {
                //Mapeo de DTO a Entidad
                var movement = new Movement
                {
                    Date = movementDTO.Date,
                    //AccountNumber = movementDTO.AccountNumber,
                    //TypeAccount = movementDTO.TypeAccount,
                    TypeMotion= movementDTO.TypeMotion,
                    //InitialBalance = movementDTO.InitialBalance,
                    //State = movementDTO.State,
                    Value = movementDTO.Value,
                    Balance = movementDTO.Balance
                };


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task DeleteMovement(int movementId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovement(MovementDTO movementDTO)
        {
            throw new NotImplementedException();
        }
    }
}
