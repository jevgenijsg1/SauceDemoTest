using Microsoft.Playwright;
namespace SauceDemoTest.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IPage page) : base(page) { }

        private string CartTitle => ".title";
        private string CartItem(string productName) => $".cart_item .inventory_item_name:has-text('{productName}')";
        private string CheckoutButton => "text=Checkout";

        public async Task<bool> IsLoaded() => await GetTextAsync(CartTitle) == "Your Cart";

        public async Task<bool> HasItem(string productName) => await IsVisibleAsync(CartItem(productName));

        public async Task Checkout() => await ClickAsync(CheckoutButton);
    }
}