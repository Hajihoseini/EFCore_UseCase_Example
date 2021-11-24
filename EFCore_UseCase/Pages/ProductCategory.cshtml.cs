using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EFCore_UseCase.Pages
{
    public class ProductCategoryModel : PageModel
    {

        private readonly IproductCategoryApplication _productCategoryApplication;
        public List<ProductCategoryViewModel> productCategories;


        public ProductCategoryModel(IproductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(string name)
        {
            productCategories = _productCategoryApplication.Searsh(name);
        }
    }
}
