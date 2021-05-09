using OpenQA.Selenium;

namespace CalculatorSelenium.Specs.Pages.Common
{
    public class LoginPage : PageBase
    {
        public override string Identifier => "#login-page"; //each page should have an identifier like a unique id.

        public LoginPage(IWebDriver driver) : base(driver, "Identity/Account/Login") //path to the login page
        {
            
        }



    }
}