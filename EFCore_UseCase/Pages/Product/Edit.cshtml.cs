using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_UseCase.Pages.Product
{
    public class EditModel : PageModel
    {
        public EditProduct command;
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IproductCategoryApplication _productCategoryApplication;


        public EditModel(IproductCategoryApplication productCategoryApplication,  IProductApplication productApplication)
        {
            _productCategoryApplication = productCategoryApplication;   
            _productApplication = productApplication;
        }

        public void OnGet(int id)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetAll(), "Id", "Name");
            command = _productApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditProduct command)
        {
            _productApplication.Edit(command);
            return RedirectToPage("./index");
        }
    }
}
