using EFCore.Application;
using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EFCore_UseCase.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> products;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            products = _productApplication.Search(searchModel);
        }
    }
}
