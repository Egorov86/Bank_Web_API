using System.ComponentModel.DataAnnotations;

namespace _BankWebAPI.Data.Entities
{
    public class Client
    {
        public long Id { get; set; }

        [MaxLength(150)]
        public required string FirstName { get; set; }

        [MaxLength(150)]
        public required string LastName { get; set; }

        [MaxLength(150)]
        public string? MiddleName { get; set; }

        public IList<Account> Accounts { get; set; } = new List<Account>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
