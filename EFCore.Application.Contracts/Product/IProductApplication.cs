using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application.Contracts.Product
{
    internal interface IProductApplication
    {
        void Create(CreateProduct command);
        void Edit(EditProduct command);
        void Remove(int Id);
        void Restore(int Id);
        EditProduct GetDetails(int Id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
