using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductCategoryAgg;

namespace EFCore.infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EFContext _context;
        public ProductCategoryRepository(EFContext context)
        {
            _context = context;
        }


        public void Create(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            SaveChanges();
        }


        public bool Exist(string name)
        {
            return _context.ProductCategories.Any(c => c.Name == name);
        }


        public ProductCategory Get(int id)
        {
            return _context.ProductCategories.FirstOrDefault(c => c.Id == id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,

            }).ToList();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _context.ProductCategories.Select(x=>new EditProductCategory {
                Id = x.Id ,
                Name = x.Name
            }).FirstOrDefault(x=>x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public List<ProductCategoryViewModel> Search(string name)
        {
            var query = _context.ProductCategories
                .Select(c => new ProductCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    CreationDate = c.CreationDate.Date.ToString(),
                });

            if(!string.IsNullOrWhiteSpace(name)) 
                query = query.Where(x=>x.Name.Contains(name));

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
