using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace emma_patterson.specflow.PageObjects
{
    public class NavigationLinks
    {
        [FindsBy(How = How.CssSelector, Using = "ul.menu > li.current > a")]
        protected IWebElement _selectedMenuLink;

        [FindsBy(How = How.CssSelector, Using = "ul.menu > li > a")]
        protected IList<IWebElement> _menuLinks;

        private IWebDriver _driver;

        public NavigationLinks(IWebDriver driver)
        {
            if (driver == null)
                throw new ArgumentNullException("driver");

            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public IWebElement Selected
        {
            get { return _selectedMenuLink; }
        }

        public void Click(string linkText)
        {
            var link = _menuLinks.First(x => x.Text == linkText);

            if (link == null)
                throw new NotFoundException(string.Format("Could not find a navigation link with text '{0}'", linkText));
            else
                link.Click();
        }
    }
}
