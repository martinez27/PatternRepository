using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;
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
                    TypeMotion= movementDTO.TypeMotion,
                    Value = movementDTO.Value,
                    Balance = movementDTO.Balance
                };
                //Agregar entidad Movement
                _unitOfWork.MovementRepository.Add(movement);

                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteMovement(int movementId)
        {
           Movement movement = await _unitOfWork.MovementRepository.GetByIdAsync(movementId);

            _unitOfWork.MovementRepository.Delete(movement);
            _unitOfWork.SaveChanges(); 
        }

        public void DepositarMovement(MovementDTO movementDTO)
        {

            Movement existMovement = _unitOfWork.MovementRepository.GetByIdAsync(movementDTO.Id).Result;

            existMovement.TypeMotion = movementDTO.TypeMotion;
            existMovement.Value = movementDTO.Value;
            existMovement.Balance = movementDTO.Balance;
        }

        public void RetirarMovement(MovementDTO movementDTO)
        {
            Movement existMovement = _unitOfWork.MovementRepository.GetByIdAsync(movementDTO.Id).Result;

            existMovement.TypeMotion = movementDTO.TypeMotion;
            existMovement.Value = movementDTO.Value;
            existMovement.Balance = movementDTO.Balance;

        }

        public void UpdateMovement(MovementDTO movementDTO)
        {
            Movement existMovement = _unitOfWork.MovementRepository.GetByIdAsync(movementDTO.Id).Result;
            
            existMovement.TypeMotion = movementDTO.TypeMotion;
            existMovement.Value = movementDTO.Value;
            existMovement.Balance = movementDTO.Balance;


        }
    }
}
