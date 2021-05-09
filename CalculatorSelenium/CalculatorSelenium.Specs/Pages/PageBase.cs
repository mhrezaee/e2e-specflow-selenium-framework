using System;
using System.ComponentModel;
using CalculatorSelenium.Specs.Pages.Components;
using OpenQA.Selenium;

namespace CalculatorSelenium.Specs.Pages
{
    public abstract class PageBase : ComponentBase
    {
        private string _path;

        public string Path
        {
            get => _path;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.StartsWith("/"))
                    throw new InvalidEnumArgumentException("Path can not start with /");
                _path = value;
            }
        }

        protected PageBase(IWebDriver driver, string path) : base(driver)
        {
            Path = path;
        }


        public void Navigate()
        {
            if (string.IsNullOrEmpty(Path))
                throw new ApplicationException("Path is not defined. Please set path property first.");

            Driver.Url = Config.BasePath + this.Path;
        }

        public bool IsOnPage()
        {
            return Exists(Identifier);
        }

        public static TPageType CreatePage<TPageType>(IWebDriver driver)
            where TPageType : ComponentBase
        {
            return (TPageType)Activator.CreateInstance(typeof(TPageType), driver);
        }
        public void Reload()
        {
            Driver.Navigate().Refresh();
            WaitToSee(this);
        }
    }
}