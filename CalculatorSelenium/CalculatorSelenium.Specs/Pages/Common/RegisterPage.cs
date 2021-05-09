using OpenQA.Selenium;

namespace CalculatorSelenium.Specs.Pages.Common
{
    public class RegisterPage : PageBase
    {
        public RegisterPage(IWebDriver driver) : base(driver, "Identity/Account/Register")
        {
        }

        public override string Identifier => "#register-page";

    }
}