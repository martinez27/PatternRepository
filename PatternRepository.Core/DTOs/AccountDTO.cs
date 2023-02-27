using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.DTOs
{
    public class AccountDTO
    {
        public string AccountNumber { get; set; }
        public string TypeAccount { get; set; }
        public decimal InitialBalance { get; set; }
        public string State { get; set; }
        public int CustomerId { get; set; }
    }
}
