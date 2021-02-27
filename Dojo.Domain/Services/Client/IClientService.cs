using Dojo.Domain.Entities.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dojo.Domain.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(string clientId);
    }
}
