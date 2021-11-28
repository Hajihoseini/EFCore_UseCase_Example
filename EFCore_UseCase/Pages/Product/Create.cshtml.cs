using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EFCore_UseCase.Pages.Product
{
    public class CreateModel : PageModel
    {
        public SelectList ProductCategories;

        private readonly IProductApplication _productApplication;
        private readonly IproductCategoryApplication _categoryApplication;

        public CreateModel(IProductApplication productApplication, IproductCategoryApplication ProductategoryApplication)
        {
            this._productApplication = productApplication;
            this._categoryApplication = ProductategoryApplication;
        }


        public void OnGet()
        {
            ProductCategories = new SelectList(_categoryApplication.GetAll(), "Id","Name");
        }

        public RedirectToPageResult OnPost(CreateProduct command)
        {
            _productApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}