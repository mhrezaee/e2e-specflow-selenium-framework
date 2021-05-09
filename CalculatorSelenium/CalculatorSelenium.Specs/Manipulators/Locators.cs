using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace CalculatorSelenium.Specs.Manipulators
{
    public partial class PageManipulator
    {
        private IWebElement Element(string cssSelector)
        {
            //report.StartInteraction($"Looking for element '{cssSelector}'");
            try
            {
                var result = Driver.FindElement(By.CssSelector(cssSelector), Config.ShortWait);
                //report.EndInteraction();
                return result;
            }
            catch (Exception e)
            {
                //report.EndInteraction(e);
                throw;
            }
        }


        private ReadOnlyCollection<IWebElement> Elements(string cssSelector)
        {
            //report.StartInteraction("Looking for " + cssSelector);
            try
            {
                var result = Driver.FindElements(By.CssSelector(cssSelector), Config.ShortWait);
                //report.EndInteraction();
                return result;
            }
            catch (Exception e)
            {
                //report.EndInteraction(e);
                throw;
            }
        }

    }
}