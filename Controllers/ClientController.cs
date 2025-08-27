using _BankWebAPI.Data.Entities;
using _BankWebAPI.Models.DTOs;
using _BankWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace _BankWebAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetClients([FromQuery] long fromId = 1, [FromQuery] int count = 20)
        {
            fromId = Math.Max(fromId, 1);
            count = Math.Clamp(count, 1, 100);

            IList<Client> clients = _clientService.GetClients(fromId, count);

            return Ok(clients);
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Client createdClient = _clientService.CreateClient(clientDto);

            return Ok(createdClient);
        }

        [HttpGet("{clientId:long}")]
        public IActionResult GetClientById([FromRoute] long clientId)
        {
            Client? client = _clientService.GetClientById(clientId);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpDelete("{clientId:long}")]
        public IActionResult DeleteClientById([FromRoute] long clientId)
        {
            return _clientService.DeleteClientById(clientId) ? Ok() : NotFound();
        }

        [HttpGet]
        [Route("/test")]
        public IActionResult RandomEndpoint()
        {
            throw new Exception();
            return Content("Привет!");
        }
    }
}
