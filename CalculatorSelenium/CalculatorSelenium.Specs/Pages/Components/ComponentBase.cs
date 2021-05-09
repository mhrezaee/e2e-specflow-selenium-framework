using CalculatorSelenium.Specs.Manipulators;
using OpenQA.Selenium;

namespace CalculatorSelenium.Specs.Pages.Components
{
    public abstract class ComponentBase : PageManipulator
    {
        public abstract string Identifier { get; }

        protected ComponentBase(IWebDriver driver) : base(driver)
        {
        }
    }
}