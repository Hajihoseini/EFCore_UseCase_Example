using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application.Contracts.ProductCategory
{
    public interface IproductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);
        EditProductCategory GetDetails(int id);
        List<ProductCategoryViewModel> Searsh(string name);
    }
}