using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace emma_patterson.specflow.PageObjects
{
    public class SitePage
    {
        [FindsBy(How = How.CssSelector, Using = "h2.page-title")]
        protected IWebElement _pageTitle;

        private static IWebDriver _driver;

        public SitePage(IWebDriver driver)
        {
            if (driver == null)
                throw new ArgumentNullException("driver");

            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string WindowTitle
        {
            get { return _driver.Title; }
        }

        public string PageTitle
        {
            get { return _pageTitle.Text; }
        }

        private NavigationLinks _links;
        public NavigationLinks Links
        {
            get
            {
                return _links ?? (_links = new NavigationLinks(_driver));
            }
        }

        public static SitePage NavigateTo(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            var sitepage = new SitePage(driver);
            return sitepage;
        }
    }
}
