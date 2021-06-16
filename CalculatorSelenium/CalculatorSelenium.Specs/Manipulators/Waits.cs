using System;
using System.Diagnostics;
using System.Threading;
using CalculatorSelenium.Specs.Exceptions;
using CalculatorSelenium.Specs.Pages.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.Manipulators
{
    public partial class PageManipulator 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverWait"></param>
        /// <param name="cssSelector"></param>
        /// <param name="see"></param>
        /// <param name="what"></param>
        /// <exception cref="WaitTimeoutException"></exception>
        private void _waitTo(WebDriverWait driverWait, string cssSelector, bool see, string what = null)
        {
            var action = see ? "See" : "Hide";
            Exception exception = new Exception();
            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {

                    //report.StartInteraction($"Wait to {action} {what ?? cssSelector}");
                    if (see)
                        driverWait.Until(d => d.FindElement(By.CssSelector(cssSelector)).Displayed);
                    else
                        driverWait.Until(d => !d.FindElement(By.CssSelector(cssSelector)).Displayed);
                    //report.EndInteraction();
                    return;
                }
                catch (WebDriverTimeoutException e)
                {
                    var message = $"{action} '{what ?? cssSelector}' failed";
                    var ex = new WaitTimeoutException(message, e);
                    //report.EndInteraction(ex);
                    throw ex;
                }
                catch (StaleElementReferenceException ex)
                {
                    Thread.Sleep(1000);
                    exception = ex;
                }
            }
            //report.EndInteraction(exception);

            throw exception;

        }

        /// <exception cref="T:nativy_E2E_Tests.Exceptions.WaitTimeoutException">Condition.</exception>
        protected void WaitToSee(string cssSelector, string what = null)
        {
            _waitTo(LongWait, cssSelector, true, what);
        }
        protected void WaitToHide(string cssSelector, string what = null)
        {
            _waitTo(LongWait, cssSelector, false, what);
        }

        /// <exception cref="T:nativy_E2E_Tests.Exceptions.WaitTimeoutException">Condition.</exception>
        protected void ShortWaitToSee(string cssSelector, string what = null)
        {
            _waitTo(ShortWait, cssSelector, true, what);
        }


        protected void WaitToSeeAndHide(string cssSelector, string what = null)
        {
            WaitToSee(cssSelector, what);
            WaitToHide(cssSelector, what);
        }
        protected void WaitToHideAndSee(string cssSelector, string what = null)
        {
            WaitToHide(cssSelector, what);
            WaitToSee(cssSelector, what);
        }

        protected void WaitForAllAjax()
        {
            WaitToSee("[data-app-ajax]", "All Ajax Requests");
            Thread.Sleep(2000);
            WaitToSee("[data-app-ajax]", "All Ajax Requests");
        }
        protected void WaitToSee(ComponentBase page)
        {
            if (Debugger.IsAttached)
                Thread.Sleep(3000);
            WaitToSee(page.Identifier);
        }

        protected void WaitToSeeText(string cssSelector, string value)
        {
            LongWait.Until(ExpectedConditions.TextToBePresentInElementValue(By.CssSelector(cssSelector),value));
        }
        
    }
}