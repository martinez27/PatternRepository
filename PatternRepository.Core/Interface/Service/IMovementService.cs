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
       IEnumerable<GetMovementDTO> GetAllMovementByUser(DateTime from, DateTime to, string customerId);
    }
}
