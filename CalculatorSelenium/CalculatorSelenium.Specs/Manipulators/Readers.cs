using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CalculatorSelenium.Specs.Pages.Components;
using Newtonsoft.Json;
using OpenQA.Selenium;

namespace CalculatorSelenium.Specs.Manipulators
{
    public partial class PageManipulator
    {
        protected T Attr<T>(string attribute, string cssSelector)
        {
            var value = Attr(attribute, cssSelector);

            return (T)Convert.ChangeType(value, typeof(T));
        }
        protected IEnumerable<T> Attrs<T>(string attribute, string cssSelector)
        {
            var values = Attrs(attribute, cssSelector);

            return values.Select(value => (T)Convert.ChangeType(value, typeof(T)));
        }

        protected T Text<T>(string cssSelector)
        {
            var value = Text(cssSelector);

            return (T)Convert.ChangeType(value, typeof(T));
        }

        protected string Attr(string attribute, string cssSelector)
        {
            Exception exception = new Exception();

            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    //report.StartInteraction($"Reading attribute '{attribute}' from '{cssSelector}'");

                    WaitToSee(cssSelector);
                    var elm = Element(cssSelector);
                    var result = elm.GetAttribute(attribute);
                    //report.EndInteraction();
                    return result;
                }
                catch (Exception ex)
                {
                    //report.EndInteraction(ex);
                    exception = ex;
                    if (ex.Message.Contains("no such element"))
                    {
                        Thread.Sleep(2000);
                        continue;
                    }

                    throw;
                }
            }

            throw exception;
        }

        protected string Text(string cssSelector)
        {
            Exception exception = new Exception();

            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    //report.StartInteraction($"Reading text from '{cssSelector}'");

                    WaitToSee(cssSelector);
                    var elm = Element(cssSelector);
                    var result = elm.Text;
                    //report.EndInteraction();
                    return result;
                }
                catch (Exception ex)
                {
                    //report.EndInteraction(ex);
                    exception = ex;
                    if (ex.Message.Contains("no such element"))
                    {
                        Thread.Sleep(2000);
                        continue;
                    }

                    throw;
                }
            }

            throw exception;
        }

        protected IEnumerable<string> Attrs(string attribute, string cssSelector)
        {

            var elms = Elements(cssSelector);
            try
            {
                //report.StartInteraction($"Reading attributes '{attribute}' from '{cssSelector}'");
                var result = elms.Select(e => e.GetAttribute(attribute)).ToList();
                //report.EndInteraction();
                return result;
            }
            catch (Exception e)
            {
                //report.EndInteraction(e);
                throw;
            }
        }

        protected bool IsVisible(string cssSelector)
        {

            try
            {
                if (!Exists(cssSelector))
                    return false;
                var elm = Element(cssSelector);
                //report.StartInteraction($"Check visibility of '{cssSelector}'");
                var result = elm.Displayed;
                //report.EndInteraction();
                return result;
            }
            catch (Exception e)
            {
                //report.EndInteraction(e);
                throw;
            }
        }

        protected bool IsVisible(ComponentBase component)
        {
            return IsVisible(component.Identifier);
        }

        protected string QueryString(string name)
        {
            var uri = new Uri(Driver.Url);
            var value = HttpUtility.ParseQueryString(uri.Query).Get(name);
            return value;
        }

        /*protected bool IsValidLink(string cssSelector)
        {
            try
            {
                var href = Attr("href", cssSelector);
                //report.StartInteraction($"Check validity of link '{href}' '{cssSelector}'");
                //report.EndInteraction();
                //return new HttpService().Head(href);
            }
            catch (Exception e)
            {
                //report.EndInteraction(e);
                throw;
            }
        }*/


        protected IEnumerable<string> Texts(string cssSelector)
        {
            var elms = Elements(cssSelector);
            try
            {
                //report.StartInteraction($"Reading texts of '{cssSelector}'");
                var result = elms.Select(e => e.Text).ToList();
                //report.EndInteraction();
                return result;
            }
            catch (Exception e)
            {
                //report.EndInteraction(e);
                throw;
            }
        }

        protected bool Exists(string cssSelector)
        {
            try
            {
                return Elements(cssSelector).Any();
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public T ExecuteJs<T>(string functionCall)
        {
            var data = (string)(Driver as IJavaScriptExecutor).ExecuteScript($"return JSON.stringify({functionCall})");

            return JsonConvert.DeserializeObject<T>(data);
        }
        protected bool Exists(ComponentBase component)
        {
            return Elements(component.Identifier).Any();
        }
    }
}