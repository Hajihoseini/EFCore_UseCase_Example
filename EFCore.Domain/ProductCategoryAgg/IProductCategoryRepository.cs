using EFCore.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory productCategory);
        void SaveChanges();
        bool Exist(string name);
        EditProductCategory GetDetails(int id);
        ProductCategory Get(int id);
        List<ProductCategoryViewModel> Search(string name);
        List<ProductCategoryViewModel> GetAll();
    }
}
