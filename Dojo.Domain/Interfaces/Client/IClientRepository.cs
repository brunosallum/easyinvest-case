using Dojo.Domain.Entities.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dojo.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll();
        Task<Client> GetById(string id);
    }
}
