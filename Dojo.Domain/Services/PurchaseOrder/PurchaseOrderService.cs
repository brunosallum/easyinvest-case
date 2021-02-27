using Dojo.Domain.Entities.PurchaseOrder;
using Dojo.Domain.Interfaces;
using Dojo.Domain.ViewModels;
using System;
using System.Threading.Tasks;

namespace Dojo.Domain.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        readonly IClientRepository _clientRepository;
        readonly IProductRepository _productRepository;
        readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IClientRepository clientRepository,
            IProductRepository productRepository, IPurchaseOrderRepository purchaseOrderRepository)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        private async Task<string> CreatePurchaseOrder(PurchaseOrder order)
        {
            var client = await _clientRepository.GetById(order.ClientID).ConfigureAwait(false);
            var product = await _productRepository.GetById(order.ProductID).ConfigureAwait(false);

            if (order.RequestedAmount <= 0)
                throw new InvalidOperationException("Quantidade solicitada não suficiente para compra.");

            if (product.Inventory <= 0)
                throw new InvalidOperationException("Quantidade em estoque não suficiente para compra.");

            var operationValue = Math.Round(decimal.Parse(product.UnityPrice) * order.RequestedAmount, 2);
            if (operationValue > client.Balance)
                throw new InvalidOperationException("Cliente não possui saldo suficiente para compra.");

            if (Math.Round(order.RequestedAmount * decimal.Parse(product.UnityPrice), 2) < product.MinPurchaseValue)
                throw new InvalidOperationException("Quantidade mínima não atendida para compra.");

            if (operationValue > product.Inventory)
                throw new InvalidOperationException("Quantidade em estoque não suficiente para compra.");

            var newOrder = new PurchaseOrder
            {
                ClientID = client.Id,
                ProductID = product.Id,
                OperationDate = DateTime.Now,
                UnityPrice = decimal.Parse(product.UnityPrice),
                OperationValue = operationValue,
                RequestedAmount = order.RequestedAmount
            };

            return await _purchaseOrderRepository.PersistPurchaseOrder(newOrder).ConfigureAwait(false);
        }

        public async Task<string> CreatePurchaseOrderAsync(PurchaseOrderRequestViewModel purchaseOrder)
        {
            var order = new PurchaseOrder
            {
                Id = Guid.NewGuid().ToString(),
                ClientID = purchaseOrder.ClientId,
                ProductID = purchaseOrder.ProductId,
                RequestedAmount = purchaseOrder.RequestedAmount
            };

            return await CreatePurchaseOrder(order);
        }

        public async Task<PurchaseOrder> GetByIdAsync(string purchaseOrderId)
        {
            try
            {
                var order = await _purchaseOrderRepository.GetById(purchaseOrderId);
                return order;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Ordem não encontrada.");
            }
        }
    }
}
