using Dojo.Domain.Entities.PurchaseOrder;
using Dojo.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Dojo.Domain.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        readonly MockContext _mockContext;
        public PurchaseOrderRepository(MockContext mockContext)
        {
            _mockContext = mockContext;
        }

        public async Task<PurchaseOrder> GetById(string id)
        {
            PurchaseOrder purchaseOrder = await Task.FromResult(_mockContext.PurchaseOrders.Find(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase))).ConfigureAwait(false);
            return purchaseOrder;
        }

        public async Task<string> PersistPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            await Task.Run(() => _mockContext.PurchaseOrders.Add(purchaseOrder)).ConfigureAwait(false);
            return purchaseOrder.Id;
        }
    }
}
