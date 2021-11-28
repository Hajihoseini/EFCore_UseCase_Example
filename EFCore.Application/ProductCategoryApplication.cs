using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace EFCore.Application
{
    public class ProductCategoryApplication : IproductCategoryApplication
    {

        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }



        public void Create(CreateProductCategory command)
        {
            if (_productCategoryRepository.Exist(command.Name)) return;
            var productCategory = new ProductCategory(command.Name);
            _productCategoryRepository.Create(productCategory); 
            _productCategoryRepository.SaveChanges();   
        }

        public void Edit(EditProductCategory command)
        {
           var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null) return;
            productCategory.Edit(command.Name);
            _productCategoryRepository.SaveChanges();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _productCategoryRepository.GetDetails(id);   
        }

        public List<ProductCategoryViewModel> Searsh(string name)
        {
            return _productCategoryRepository.Search(name);
        }
    }
}
