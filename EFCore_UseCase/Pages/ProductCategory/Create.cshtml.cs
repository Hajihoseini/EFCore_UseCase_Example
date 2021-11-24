using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class CreateModel : PageModel
    {
        private readonly IproductCategoryApplication _productCategoryApplication;

        public CreateModel(IproductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateProductCategory command)
        {
            _productCategoryApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
