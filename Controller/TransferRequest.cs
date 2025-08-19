namespace _BankWebAPI.Controller
{
    public class TransferRequest
    {
        public required string SenderAccountId { get; set; }
        public required string RecipientAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
