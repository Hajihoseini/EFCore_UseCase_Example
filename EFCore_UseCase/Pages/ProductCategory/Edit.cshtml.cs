using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        public EditProductCategory command;
        private readonly IproductCategoryApplication _productCategoryApplication;

        public EditModel(IproductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(int id)
        {
            command = _productCategoryApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditProductCategory command)
        {
            _productCategoryApplication.Edit(command);
            return RedirectToPage("./index");
        }
    }
}
