using System;
using System.Collections.Generic;
using System.Text;

namespace Dojo.Domain.Entities.PurchaseOrder
{
    public enum PurchaseOrderStatusEnum
    {
        Requested = 1,
        Pending = 2,
        Closed = 3,
        Canceled = 4
    }
}
