using Microsoft.Playwright;
using SauceDemoTest.Pages;


namespace SauceDemoTest.Tests
{
    [TestClass]
    public class BuyTShirtTest
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;
        private IBrowserContext _context;

        private LoginPage _loginPage;
        private ProductsPage _productsPage;
        private ProductDetailsPage _productDetailsPage;
        private CartPage _cartPage;
        private CheckoutPage _checkoutPage;
        private CheckoutOverviewPage _checkoutOverviewPage;
        private OrderConfirmationPage _orderConfirmationPage;
        private LogoutPage _logoutPage;

        private string Username;
        private string Password;
        private const string ProductName = "Sauce Labs Bolt T-Shirt";

        [TestInitialize]
        public async Task Setup()
        {
            Username = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
            Password = Environment.GetEnvironmentVariable("SAUCE_PASSWORD");

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Assert.Fail("Missing credentials! Please set SAUCE_USERNAME and SAUCE_PASSWORD.");
            }

            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            _loginPage = new LoginPage(_page);
            _productsPage = new ProductsPage(_page);
            _productDetailsPage = new ProductDetailsPage(_page);
            _cartPage = new CartPage(_page);
            _checkoutPage = new CheckoutPage(_page);
            _checkoutOverviewPage = new CheckoutOverviewPage(_page);
            _orderConfirmationPage = new OrderConfirmationPage(_page);
            _logoutPage = new LogoutPage(_page);
        }

        [TestMethod]
        public async Task BuyTShirt()
        {
            await _loginPage!.GoToAsync();
            await _loginPage.LoginAsync(Username!, Password!);
            Assert.IsTrue(await _productsPage!.IsLoaded(), "Products page did not load.");

            await _productsPage.OpenProductAsync(ProductName);
            Assert.IsTrue(await _productDetailsPage!.IsLoaded(ProductName), "Product details page did not load.");

            await _productDetailsPage.AddToCart();
            await _page!.ClickAsync(".shopping_cart_link");
            Assert.IsTrue(await _cartPage!.IsLoaded(), "Cart page did not load.");
            Assert.IsTrue(await _cartPage.HasItem(ProductName), "Item was not found in cart.");

            await _cartPage.Checkout();
            Assert.IsTrue(await _checkoutPage!.IsLoaded(), "Checkout page did not load.");

            await _checkoutPage.FillCheckoutInfo("Sheldon", "Plankton", "12345");
            await _checkoutPage.Continue();

            Assert.IsTrue(await _checkoutOverviewPage!.IsLoaded(), "Checkout overview page did not load.");
            Assert.IsTrue(await _checkoutOverviewPage.HasProduct(ProductName), "Incorrect product in checkout overview.");

            await _checkoutOverviewPage.FinishOrder();
            Assert.IsTrue(await _orderConfirmationPage!.IsOrderSuccessful(), "Order confirmation was not displayed.");

            await _logoutPage!.LogoutAsync();
            Assert.IsTrue(await _logoutPage.IsLoggedOutAsync(), "Logout failed; login page not displayed.");
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _page?.CloseAsync();
            await _browser?.CloseAsync();
            _playwright?.Dispose();
        }
    }
}