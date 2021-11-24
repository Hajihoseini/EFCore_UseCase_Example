using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IproductCategoryApplication _productCategoryApplication;
        public List<ProductCategoryViewModel> productCategories;

        public IndexModel(IproductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(string name)
        {
            productCategories = _productCategoryApplication.Searsh(name);
        }
    }
}
