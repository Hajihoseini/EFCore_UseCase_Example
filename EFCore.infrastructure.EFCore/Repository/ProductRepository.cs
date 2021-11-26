using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.infrastructure.EFCore.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly EFContext _context;

        public ProductRepository(EFContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public EditProduct GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
