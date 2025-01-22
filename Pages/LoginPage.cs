using Microsoft.Playwright;
namespace SauceDemoTest.Pages
{
    public class LoginPage : BasePage
    {
        private readonly string _url = "https://www.saucedemo.com/";

        public LoginPage(IPage page) : base(page) { }

        public async Task GoToAsync() => await _page.GotoAsync(_url);

        public async Task LoginAsync(string username, string password)
        {
            await FillAsync("#user-name", username);
            await FillAsync("#password", password);
            await ClickAsync("#login-button");
        }
    }
}