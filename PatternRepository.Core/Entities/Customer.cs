using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Entities
{
    public class Customer : People
    {
        public int CustomereId { get; set; }
        public string Password { get; set; }
        public string State { get; set; }
    }
}
