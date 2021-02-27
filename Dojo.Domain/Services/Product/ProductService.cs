using Dojo.Domain.Entities.Product;
using Dojo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Domain.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAll();
                return products;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Nenhum produto encontrado.");
            }
        }

        public async Task<Product> GetByIdAsync(string productId)
        {
            try
            {
                var product = await _productRepository.GetById(productId);
                return product;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Produto não encontrado.");
            }
        }
    }
}
