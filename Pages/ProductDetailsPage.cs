using Microsoft.Playwright;
namespace SauceDemoTest.Pages
{
    public class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IPage page) : base(page) { }

        private string ProductTitle => ".inventory_details_name";
        private string AddToCartButton => "button:has-text('Add to cart')";

        public async Task<bool> IsLoaded(string productName) => await GetTextAsync(ProductTitle) == productName;

        public async Task AddToCart() => await ClickAsync(AddToCartButton);
    }
}
