using System;
using CalculatorSelenium.Specs.Pages.Common;
using OpenQA.Selenium;

namespace CalculatorSelenium.Specs.Pages
{
    public class PageFactory : IDisposable
    {
        private readonly IWebDriver _driver;

        public IWebDriver Driver => _driver;

        public PageFactory(IWebDriver driver)
        {
            _driver = driver;
            if (Config.Environment == Config.Environments.Development)
                driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(Config.BasePath);
            //SetDefaultCookies(); // if you want to set cookies before running tests
        }
        /*private void SetDefaultCookies()
        {
            DateTime time = DateTime.Now.AddYears(1);
            var host = new Uri(Config.BasePath).Host;
            _driver.Manage().Cookies.AddCookie(new Cookie("sample cookie", "true", host, "/", time)); 
        }*/

        
        public LoginPage LoginPage => new LoginPage(_driver);
        public RegisterPage RegisterPage => new RegisterPage(_driver);
        public CalculatorPage CalculatorPage => new CalculatorPage(_driver);
        

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}