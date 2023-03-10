using PatternRepository.Core.Entities.Enumeration;

namespace PatternRepository.Core.Entities
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public AccountType AccounType { get; set; }
        public decimal Balance { get; set; }
        public bool State { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Movement> Movements { get; set; }    
    }
}
