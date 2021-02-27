using Dojo.Domain.Entities.Client;
using Dojo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Domain.Services
{
    public class ClientService : IClientService
    {
        readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Client>> GetAllAsync()
        {
            try
            {
                var clients = await _clientRepository.GetAll();
                return clients;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Nenhum cliente encontrado.");
            }            
        }

        public async Task<Client> GetByIdAsync(string clientId)
        {
            try
            {
                var client = await _clientRepository.GetById(clientId);
                return client;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cliente não encontrado.");
            }
        }
    }
}
