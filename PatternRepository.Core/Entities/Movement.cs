using PatternRepository.Core.Entities.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Entities
{
    public class Movement
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public MovementType Type { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
    }
}
