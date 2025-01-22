using Microsoft.Playwright;
namespace SauceDemoTest.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        public CheckoutOverviewPage(IPage page) : base(page) { }

        private string Title => ".title";
        private string ProductName => ".inventory_item_name";
        private string FinishButton => "text=Finish";

        public async Task<bool> IsLoaded() => await GetTextAsync(Title) == "Checkout: Overview";

        public async Task<bool> HasProduct(string productName) => await GetTextAsync(ProductName) == productName;

        public async Task FinishOrder() => await ClickAsync(FinishButton);
    }
}