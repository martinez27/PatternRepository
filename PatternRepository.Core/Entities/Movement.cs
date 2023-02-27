using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Entities
{
    public class Movement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TypeMotion { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
