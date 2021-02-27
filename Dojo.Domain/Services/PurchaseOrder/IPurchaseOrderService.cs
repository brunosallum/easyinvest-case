using Dojo.Domain.Entities.PurchaseOrder;
using Dojo.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Domain.Services
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrder> GetByIdAsync(string purchaseOrderId);
        Task<string> CreatePurchaseOrderAsync(PurchaseOrderRequestViewModel purchaseOrder);
    }
}
