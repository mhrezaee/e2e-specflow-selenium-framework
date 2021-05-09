using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        
        private readonly PageFactory _pageFactory;
        

        public CalculatorStepDefinitions(BrowserDriver browserDriver)
        {
            _pageFactory = new PageFactory(browserDriver.Current);
        }

        [Given(@"I am on calculator page")]
        public void GivenIAmOnCalculatorPage()
        {
            _pageFactory.CalculatorPage.Navigate();
        }


        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _pageFactory.CalculatorPage.SetFirstNumber(number.ToString());
            
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _pageFactory.CalculatorPage.SetSecondNumber(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _pageFactory.CalculatorPage.ClickAdd();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            var actualResult = _pageFactory.CalculatorPage.ReadResult();

            actualResult.Should().Be(expectedResult);
        }
    }
}
