using Microsoft.EntityFrameworkCore;

namespace _BankWebAPI.Data.Entities
{
    public class Card
    {
        public long Id { get; set; }

        public required long AccountId { get; set; }

        public required Account Account { get; set; }

        [Precision(16, 0)]
        public long Number { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
