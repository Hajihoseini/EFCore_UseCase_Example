using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.infrastructure.EFCore.Repository
{
    public class ProductRepository : IProductRepository
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

        public bool Exists(string name, int categoryId)
        {
           return _context.Products.Any(x=>x.Name == name && x.CategoryId == categoryId);
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public EditProduct GetDetails(int id)
        {
          return _context.Products.Select(x=> new EditProduct
          {
              Id = x.Id,
              Name = x.Name,
              UnitPrice = x.UnitPrice,
              CategoryId = x.CategoryId,
          }).FirstOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    IsRemoved = x.IsRemoved,
                    CreationDate = x.CreationDate.ToString(),
                    Category = x.Category.Name
                });

            if(searchModel.IsRemoved == true) query = query.Where(x => x.IsRemoved == true);    
            if(!string.IsNullOrWhiteSpace(searchModel.Name)) query = query.Where(x=>x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
        }
    }
}
