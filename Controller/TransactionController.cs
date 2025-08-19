namespace _BankWebAPI.Controller;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    [HttpPost("transfer")]
    public IActionResult Transfer([FromBody] TransferRequest request)
    {
        if (request == null)
        {
            return BadRequest("Transfer request cannot be null.");
        }

        if (string.IsNullOrEmpty(request.SenderAccountId) ||
            string.IsNullOrEmpty(request.RecipientAccountId) ||
            request.Amount <= 0)
        {
            return BadRequest("Invalid transfer request.");
        }

        decimal commission = CalculateCommission(request.Amount);

        bool transferSuccess = ExecuteTransfer(request.SenderAccountId, request.RecipientAccountId, request.Amount, commission);

        if (transferSuccess)
        {
            return Ok("Transfer completed successfully.");
        }
        else
        {
            return BadRequest("Transfer failed.");
        }
    }

    private decimal CalculateCommission(decimal amount)
    {
        if (amount <= 10000)
        {
            return amount * 0.005m; 
        }
        else
        {
            return amount * 0.01m; 
        }
    }

    private bool ExecuteTransfer(string senderAccountId, string recipientAccountId, decimal amount, decimal commission)
    {
        return true;
    }
}
