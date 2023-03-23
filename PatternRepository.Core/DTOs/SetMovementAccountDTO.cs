using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.DTOs
{
    public class SetMovementAccountDTO
    {
        public string AccountNumber { get; set; }
        public string TypeAccount { get; set; }
        public decimal Value { get; set; }
        //public bool State { get; set; }
        public string CustomerId { get; set; }
        public string UserPassword { get; set; }
    }
}
