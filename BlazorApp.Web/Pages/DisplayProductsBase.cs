using Microsoft.AspNetCore.Components;
using BlazorApp.Models.Dtos;

namespace BlazorApp.Web.Pages
{
    public class DisplayProductsBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    
    }
}
