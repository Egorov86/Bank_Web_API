using Microsoft.EntityFrameworkCore;

namespace _BankWebAPI.Data.Entities
{
    public class Account
    {
        public long Id { get; set; }

        public long? ClientId { get; set; }

        public Client? Client { get; set; }

        [Precision(15, 2)]
        public decimal Balance { get; set; } = 0;

        public IList<Card> Cards { get; set; } = new List<Card>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
