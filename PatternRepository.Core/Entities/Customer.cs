using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Entities
{
    public class Customer : People
    {
        public string Password { get; set; }
        public bool State { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
