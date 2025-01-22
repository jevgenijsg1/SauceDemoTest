using Microsoft.Playwright;

namespace SauceDemoTest.Pages
{
    public class LogoutPage : BasePage
    {
        public LogoutPage(IPage page) : base(page) { }

        private string MenuButton => "#react-burger-menu-btn";
        private string LogoutButton => "#logout_sidebar_link";
        private string LoginButton => "#login-button";

        public async Task LogoutAsync()
        {
            await ClickAsync(MenuButton);
            await ClickAsync(LogoutButton);
        }

        public async Task<bool> IsLoggedOutAsync() => await IsVisibleAsync(LoginButton);
    }
}