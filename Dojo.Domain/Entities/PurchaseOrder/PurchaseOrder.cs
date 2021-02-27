using System;
using System.Collections.Generic;
using System.Text;

namespace Dojo.Domain.Entities.PurchaseOrder
{
    public class PurchaseOrder : IBaseEntity
    {
        public PurchaseOrder()
        {
            Status = PurchaseOrderStatusEnum.Requested;
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime OperationDate { get; set; }
        public string ProductID { get; set; }
        public string ClientID { get; set; }
        public int RequestedAmount { get; set; }
        public decimal OperationValue { get; set; }
        public decimal UnityPrice { get; set; }
        public PurchaseOrderStatusEnum Status { get; set; }

    }
}
