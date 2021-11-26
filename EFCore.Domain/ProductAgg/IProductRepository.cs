using EFCore.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product Get(int id);
        EditProduct GetDetails(int id); 
        void Create(Product product);
        void SaveChanges();
    }
}
