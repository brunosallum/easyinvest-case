using Bogus;
using Dojo.Domain.Entities.Client;
using Dojo.Domain.Entities.Product;
using Dojo.Domain.Entities.PurchaseOrder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Domain.Repository
{
    public class MockContext
    {
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

        public MockContext()
        {
            LoadFakeData();
        }

        private void LoadFakeData()
        {
            var id = 0;
            Clients = new Faker<Client>()
                .RuleFor(s => s.Id, f => (id++).ToString())
                .RuleFor(s => s.Name, f => f.Name.FullName())
                .RuleFor(s => s.Address, f => f.Address.FullAddress())
                .RuleFor(s => s.Balance, f => f.Finance.Amount(10000, 100000))
                .Generate(10)
                .ToList();
            id = 0;
            Products = new Faker<Product>()
                .RuleFor(s => s.Id, f => (id++).ToString())
                .RuleFor(s => s.Description, f => f.Commerce.ProductName())
                .RuleFor(s => s.Inventory, 1000)
                .RuleFor(s => s.MinPurchaseValue, 50)
                .RuleFor(s => s.UnityPrice, f => f.Commerce.Price(1, 100, 2))
                .Generate(5)
                .ToList();

            PurchaseOrders = new Faker<PurchaseOrder>()
                .RuleFor(s => s.Id, s => "00d3e59c-ab7c-4689-9c86-dbb3e35d2e55")
                .RuleFor(s => s.ClientID, s => "2")
                .RuleFor(s => s.OperationDate, s => DateTime.Now)
                .RuleFor(s => s.ProductID, s => "3")
                .RuleFor(s => s.OperationValue, s => 200)
                .RuleFor(s => s.RequestedAmount, s => 4)
                .RuleFor(s => s.Status, s => PurchaseOrderStatusEnum.Requested)
                .RuleFor(s => s.UnityPrice, s => 2)
                .Generate(1)
                .ToList();
        }
    }
}
