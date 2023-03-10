using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.DTOs
{
    internal class SetMovementDTO
    {
        public string AccountNumber { get; set; }
        public string MovementType { get; set; }
        public decimal InitialBalance { get; set; }
        public bool State { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
    }
}
