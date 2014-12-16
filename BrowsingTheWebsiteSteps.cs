using emma_patterson.specflow.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using Xunit;

namespace emma_patterson.specflow
{
    [Binding]
    public class BrowsingTheWebsiteSteps
    {
        private SitePage _page;
        private IWebDriver _driver;

        [BeforeScenario()]
        public void Setup()
        {
            _driver = new FirefoxDriver();
        }

        [AfterScenario()]
        public void Teardown()
        {
            _driver.Quit();
        }

        [Given(@"I have browsed to the site '(.*)'")]
        public void GivenIHaveBrowsedToTheSite(string p0)
        {
            _page = SitePage.NavigateTo(_driver, p0);
        }

        [Then(@"I should see the site homepage")]
        public void ThenIShouldSeeTheSiteHomepage()
        {
            Assert.True(_page.WindowTitle.Contains("Home"));
        }

        [When(@"I click the '(.*)' Navigation Link")]
        public void WhenIClickTheNavigationLink(string p0)
        {
            _page.Links.Click(p0);
        }

        [Then(@"the text '(.*)' should be displayed in the page title")]
        public void ThenTheTextShouldBeDisplayedInThePageTitle(string p0)
        {
            Assert.Equal(p0, _page.PageTitle);
        }
    }
}   
