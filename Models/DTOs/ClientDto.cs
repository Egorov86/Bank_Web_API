using System.ComponentModel.DataAnnotations;

namespace _BankWebAPI.Models.DTOs
{
    public class ClientDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string? FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string? LastName { get; set; }

        [MinLength(2)]
        [MaxLength(150)]
        public string? MiddleName { get; set; }

    }
}
