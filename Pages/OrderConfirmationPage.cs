using Microsoft.Playwright;
namespace SauceDemoTest.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(IPage page) : base(page) { }

        private string ConfirmationMessage => ".complete-header";

        public async Task<bool> IsOrderSuccessful() =>
            await GetTextAsync(ConfirmationMessage) == "Thank you for your order!";
    }
}