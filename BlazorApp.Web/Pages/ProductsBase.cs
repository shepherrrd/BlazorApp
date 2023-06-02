using Microsoft.AspNetCore.Components;
using BlazorApp.Models.Dtos;
using BlazorApp.Web.Services.Contracts;

namespace BlazorApp.Web.Pages
{
    public class ProductsBase:ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }


        public IEnumerable<ProductDto> Products { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();

            //try
            //{
            //    await ClearLocalStorage();

            //    Products =  await ManageProductsLocalStorageService.GetCollection();

            //    var shoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();

            //    var totalQty = shoppingCartItems.Sum(i => i.Qty);

            //    ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);

            //}
            //catch (Exception ex)
            //{
            //    ErrorMessage = ex.Message;

            //}

        }

        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        { 
            return (from product in Products
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup);
        }
        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDtos)
        {
            return groupedProductDtos.FirstOrDefault(pg => pg.CategoryId == groupedProductDtos.Key).CategoryName;
        }

        private async Task ClearLocalStorage()
        {
        //    await ManageProductsLocalStorageService.RemoveCollection();
        //    await ManageCartItemsLocalStorageService.RemoveCollection();
        }

    }
}
