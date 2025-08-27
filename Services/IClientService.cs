using _BankWebAPI.Data.Entities;
using _BankWebAPI.Models.DTOs;

namespace _BankWebAPI.Services
{
    public interface IClientService
    {
        IList<Client> GetClients(long fromClientId, int count);
        Client? GetClientById(long clientId);
        Client CreateClient(ClientDto clientDto);
        bool DeleteClientById(long clientId);
    }
}
