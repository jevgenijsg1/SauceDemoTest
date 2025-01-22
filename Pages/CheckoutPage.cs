using Microsoft.Playwright;
namespace SauceDemoTest.Pages
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IPage page) : base(page) { }

        private string Title => ".title";
        private string FirstName => "#first-name";
        private string LastName => "#last-name";
        private string PostalCode => "#postal-code";
        private string ContinueButton => "text=Continue";

        public async Task<bool> IsLoaded() => await GetTextAsync(Title) == "Checkout: Your Information";

        public async Task FillCheckoutInfo(string firstName, string lastName, string postalCode)
        {
            await FillAsync(FirstName, firstName);
            await FillAsync(LastName, lastName);
            await FillAsync(PostalCode, postalCode);
        }

        public async Task Continue() => await ClickAsync(ContinueButton);
    }
}