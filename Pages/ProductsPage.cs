using Microsoft.Playwright;
namespace SauceDemoTest.Pages
{
    public class ProductsPage : BasePage
    {
        public ProductsPage(IPage page) : base(page) { }

        private string ProductTitle => ".title";
        private string ProductItem(string productName) => $"text={productName}";

        public async Task<bool> IsLoaded() => await GetTextAsync(ProductTitle) == "Products";

        public async Task OpenProductAsync(string productName) => await ClickAsync(ProductItem(productName));
    }
}