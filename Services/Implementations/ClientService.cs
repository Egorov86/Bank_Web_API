using _BankWebAPI.Data;
using _BankWebAPI.Data.Entities;
using _BankWebAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace _BankWebAPI.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _database;

        public ClientService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IList<Client> GetClients(long fromClientId, int count)
        {
            return _database.Clients.Where(c => c.Id >= fromClientId)
                                    .OrderBy(c => c.Id)
                                    .Take(count)
                                    .ToList();
        }

        public Client? GetClientById(long clientId)
        {
            return _database.Clients.Find(clientId);
        }

        public Client CreateClient(ClientDto clientDto)
        {
            if (string.IsNullOrWhiteSpace(clientDto.FirstName))
                throw new MissingFieldException("Client first name is required");

            if (string.IsNullOrWhiteSpace(clientDto.LastName))
                throw new MissingFieldException("Client last name is required");

            Client client = new Client()
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                MiddleName = clientDto.MiddleName
            };

            _database.Clients.Add(client);
            _database.SaveChanges();

            return client;
        }

        public bool DeleteClientById(long clientId)
        {
            //Client? findedClient = _database.Clients.Find(clientId);

            //if (findedClient == null)
            //    return false;

            //_database.Clients.Remove(findedClient);
            //_database.SaveChanges();

            //return true;

            int affectedRows = _database.Clients.Where(c => c.Id == clientId)
                                                .ExecuteDelete();

            return affectedRows > 0;
        }
    }
}
