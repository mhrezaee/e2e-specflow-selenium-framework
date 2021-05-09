using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.Manipulators
{
    public abstract partial class PageManipulator
    {
        //protected TestReportService report;
        protected IWebDriver Driver;
        protected WebDriverWait ShortWait;
        protected WebDriverWait Wait;
        protected WebDriverWait LongWait;

        protected PageManipulator(IWebDriver driver)
        {
            Driver = driver;
            ShortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ShortWait));
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ShortWait));
            LongWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.LongWait));
            //report = new TestReportServiceFactory().Create();
        }


    }
}