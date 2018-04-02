using LogCorner.BlogPost.Web.Mvc.UITest.Extensions;
using OpenQA.Selenium;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Components
{
    internal class MenuComponent
    {
        private IWebDriver webDriver;

        private IWebElement _rootMenu
        {
            get
            {
                return webDriver.FindElement(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']"));
            }
        }

        public MenuComponent(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        internal bool IsNotAuthenticatedUser(string email)
        {
            bool isLoggedIn = webDriver.ElementIsPresent(By.Id("registerLink"));
            if (isLoggedIn)
            {
                var registerLink = _rootMenu.FindElement(By.Id("registerLink"));
                var loginLink = _rootMenu.FindElement(By.Id("loginLink"));

                return loginLink != null && registerLink != null && loginLink.Text == "Log in" && registerLink.Text == "Register";
            }
            return false;
        }

        internal void ClickOnLoginLink()
        {
            ClickOnLogOffLink();
            var loginLink = _rootMenu.FindElement(By.Id("loginLink"));
            loginLink.Click();
        }

        internal void ClickOnLogOffLink()
        {
            bool isLoggedIn = webDriver.ElementIsPresent(By.Id("Log off"));
            if (isLoggedIn)
            {
                var loginLink = _rootMenu.FindElement(By.LinkText("Log off"));
                loginLink.Click();
            }
        }

        internal bool IsAuthenticatedUser(string email)
        {
            return true;
        }
    }
}