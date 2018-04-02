using OpenQA.Selenium;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Components
{
    public class LoginComponent
    {
        private readonly IWebDriver _webDriver;

        private string _userName;

        private string _password;

        private IWebElement Root => _webDriver.FindElement(By.Id("loginForm"));

        public LoginComponent(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string IsAt()
        {
            if (Root != null)
            {
                return _webDriver.Url;
            }
            return string.Empty;
        }

        public LoginComponent LoginAs(string userName)
        {
            _userName = userName;
            return this;
        }

        internal LoginComponent WithPassword(string password)
        {
            _password = password;
            return this;
        }

        internal void Login()
        {
            var loginInput = Root.FindElement(By.Id("Email"));
            loginInput.SendKeys(_userName);

            var passwordInput = Root.FindElement(By.Id("Password"));
            passwordInput.SendKeys(_password);

            var loginButton = Root.FindElement(By.XPath("//*[@type='submit']"));
            loginButton.Click();
        }
    }
}