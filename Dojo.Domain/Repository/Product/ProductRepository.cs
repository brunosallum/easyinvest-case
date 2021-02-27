using Dojo.Domain.Entities.Product;
using Dojo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly MockContext _mockContext;

        public ProductRepository(MockContext mockContext)
        {
            _mockContext = mockContext;
        }

        public async Task<List<Product>> GetAll()
        {
            return await Task.FromResult(_mockContext.Products).ConfigureAwait(false);
        }

        public async Task<Product> GetById(string id)
        {
            return await Task.FromResult(_mockContext.Products.Find(x => x.Id.Equals(id))).ConfigureAwait(false);
        }
    }
}
