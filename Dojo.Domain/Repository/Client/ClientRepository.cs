using Dojo.Domain.Entities.Client;
using Dojo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dojo.Domain.Repository
{
    public class ClientRepository : IClientRepository
    {
        readonly MockContext _mockContext;

        public ClientRepository(MockContext mockContext)
        {
            _mockContext = mockContext;
        }

        public async Task<Client> GetById(string id)
        {
            Client client = _mockContext.Clients.Find(x => x.Id.Equals(id));
            return await Task.FromResult(client).ConfigureAwait(false);
        }

        public async Task<List<Client>> GetAll()
        {
            return await Task.FromResult(_mockContext.Clients).ConfigureAwait(false);
        }
    }
}
