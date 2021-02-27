using Dojo.Domain.Entities.PurchaseOrder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Domain.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<PurchaseOrder> GetById(string id);
        Task<string> PersistPurchaseOrder(PurchaseOrder purchaseOrder);
    }
}
