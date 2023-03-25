using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Interface.Utils
{
    public interface IPasswordHasher
    {
        //Hashear una Password
        string Hash(string password);
        //Check
        bool Check(string hash,string password);
    }
}
