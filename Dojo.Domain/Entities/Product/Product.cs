using System;
using System.Collections.Generic;
using System.Text;

namespace Dojo.Domain.Entities.Product
{
    public class Product : IBaseEntity
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal Inventory { get; set; }
        public string UnityPrice { get; set; }
        public int MinPurchaseValue { get; set; }
    }
}
