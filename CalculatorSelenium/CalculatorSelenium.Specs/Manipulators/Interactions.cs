using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.Manipulators
{
    public partial class PageManipulator
    {
        private int maxAttempts = 5;


        #region Click

        protected void ClickOn(string cssSelector, string what = null)
        {
            Exception exception = new Exception();

            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    WaitToSee(cssSelector);
                    var elm = Element(cssSelector);
                    var message = $"Click on '{what ?? cssSelector}'.";
                    if (i > 0)
                        message += $"(attempt:{i + 1})";
                    //report.StartInteraction(message);
                    elm.Click();
                    //report.EndInteraction();
                    return;
                }
                catch (Exception ex)
                {
                    //report.EndInteraction(ex);
                    exception = ex;
                    if (ex.Message.Contains("not clickable") || ex.Message.Contains("not interactable") || ex.Message.Contains("intercepted") ||
                        ex.Message.Contains("stale element reference"))
                    {
                        HideInPageLog();
                        Thread.Sleep(2000);
                        continue;
                    }

                    throw;
                }
            }

            throw exception;
        }

        private void HideInPageLog()
        {
           // new InPageLogService(Driver).Hide();
        }

        #endregion

        protected void Enter(string value, string cssSelector, string what = null, bool clear = true, bool enterOnEnd = false)
        {
            var elm = Element(cssSelector);
            var exception = new Exception();
            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    var message = $"'{value}' entered in the '{what ?? cssSelector}' field.";
                    if (i > 0)
                        message += $"(attempt:{i + 1})";
                    //report.StartInteraction(message);

                    if (clear)
                        elm.Clear();
                    elm.SendKeys(value);
                    if (enterOnEnd)
                        elm.SendKeys(Keys.Enter);

                    //report.EndInteraction();
                    return;
                }
                catch (Exception e)
                {
                    //report.EndInteraction(e);
                    exception = e;

                    if (e.Message.Contains("cannot focus element") || e.Message.Contains("not interactable"))
                    {
                        HideInPageLog();
                        Thread.Sleep(2000);
                        continue;
                    }

                    throw;
                }
            }

            throw exception;
        }

        protected void ChooseItem(string itemText, string cssSelector, string what = null)
        {
            var elm = Element(cssSelector);
            var exception = new Exception();
            for (int i = 0; i < maxAttempts; i++)
            {
                //report.StartInteraction($"Choose item '{itemText}' from '{what ?? cssSelector}'");
                try
                {
                    var select = new SelectElement(elm);
                    select.SelectByText(itemText);
                    //report.EndInteraction();
                    return;
                }
                catch (Exception ex)
                {
                    //report.EndInteraction(ex);
                    exception = ex;
                    if (ex.Message.Contains("not interactable"))
                    {
                        HideInPageLog();
                        Thread.Sleep(2000);
                        continue;
                    }

                    throw;
                }
            }

            throw exception;

        }

        protected void ChooseMultiple(IEnumerable<string> items, string cssSelector, string what = null)
        {
            var elm = Element($"{cssSelector}+.chosen-container input");
            //report.StartInteraction($"Choose multiple items [{string.Join(",", items)}] from '{what ?? cssSelector}'");

            try
            {
                elm.Clear();

                foreach (var item in items)
                {
                    elm.Click();
                    elm.SendKeys(item);
                    elm.SendKeys(Keys.Enter);
                    //report.EndInteraction();
                }
            }
            catch (Exception e)
            {
                //report.EndInteraction(e);
                throw;
            }
        }

        protected void Upload(string path, string what = null, string cssSelector = "#fileupload_general")
        {
            var elm = Element(cssSelector);
            //report.StartInteraction($"'{path}' file selected for '{what ?? cssSelector}'");
            try
            {
                elm.SendKeys(path);
                //report.EndInteraction();
            }
            catch (Exception e)
            {
                //report.EndInteraction(e);
                throw;
            }
        }

        protected void RespondToAlert(bool accept)
        {
            Exception exception = new Exception();

            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    var alert = Driver.SwitchTo().Alert();
                    //report.StartInteraction($"Respond '{accept}' to alert '{alert.Text}'");

                    if (accept)
                        alert.Accept();
                    else
                        alert.Dismiss();
                    //report.EndInteraction();
                    return;
                }
                catch (Exception ex)
                {
                    //report.EndInteraction(ex);
                    exception = ex;
                    if (ex.Message.Contains("no such alert"))
                    {
                        HideInPageLog();
                        Thread.Sleep(2000);
                        continue;
                    }

                    throw;
                }
            }

            throw exception;
        }

        protected void Each(string cssSelector, Action<int> action)
        {
            var elements = Elements(cssSelector);
            for (int i = 0; i < elements.Count; i++)
            {
                action.Invoke(i);
            }
        }

        protected void Hover(string cssSelector, string what = null)
        {
            var exception = new Exception();

            for (var i = 0; i < maxAttempts; i++)
            {
                try
                {
                    WaitToSee(cssSelector);
                    var elm = Element(cssSelector);
                    var message = $"Hover on '{what ?? cssSelector}'.";
                    if (i > 0)
                        message += $"(attempt:{i + 1})";
                    //report.StartInteraction(message);
                    //hover starts here
                    var action = new Actions(Driver);
                    action.MoveToElement(elm).Perform();
                    //hover ends here
                    //report.EndInteraction();
                    return;
                }
                catch (Exception ex)
                {
                    //report.EndInteraction(ex);
                    exception = ex;
                    if (ex.Message.Contains("not clickable") || ex.Message.Contains("not interactable") || ex.Message.Contains("intercepted") ||
                        ex.Message.Contains("stale element reference"))
                    {
                        HideInPageLog();
                        Thread.Sleep(2000);
                        continue;
                    }

                    throw;
                }
            }

            throw exception;
        }
        protected void HoverAndCloseNotify(string notifyCssSelector = ".noty_message", string closeButtonCssSelector = ".noty_close", string what = null)
        {
            if (!IsVisible(notifyCssSelector)) return;
            Hover(notifyCssSelector, what);
            if (IsVisible(closeButtonCssSelector))
            {
                ClickOn(closeButtonCssSelector, what);
            }

        }
    }
}