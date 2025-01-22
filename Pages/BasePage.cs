using Microsoft.Playwright;
namespace SauceDemoTest.Pages
{
    public abstract class BasePage
    {
        protected readonly IPage _page;

        protected BasePage(IPage page) => _page = page;

        public async Task ClickAsync(string selector) => await _page.ClickAsync(selector);

        public async Task FillAsync(string selector, string text) => await _page.FillAsync(selector, text);

        public async Task<string> GetTextAsync(string selector) => await _page.InnerTextAsync(selector);

        public async Task<bool> IsVisibleAsync(string selector) => await _page.IsVisibleAsync(selector);

        public async Task WaitForPageLoadAsync() => await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }
}