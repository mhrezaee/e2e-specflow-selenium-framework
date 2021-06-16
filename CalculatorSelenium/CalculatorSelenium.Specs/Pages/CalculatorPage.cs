using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.Pages
{
    public class CalculatorPage : PageBase
    {
        public CalculatorPage(IWebDriver driver) : base(driver, "Calculator-Demo/Calculator.html")
        {
        }

        public override string Identifier => ".container";


        public void SetFirstNumber(string number)
        {
            Enter(number, "#first-number");
        }

        public void SetSecondNumber(string number)
        {
            Enter(number, "#second-number");
        }

        public int ReadResult(string expectedResult)
        {
            //Thread.Sleep(3000);
            WaitToSeeText("#result", expectedResult);
            var result = Attr<int>("value", "#result");
            return result;
        }

        public void ClickAdd()
        {
            ClickOn("#add-button");
        }
    }
}