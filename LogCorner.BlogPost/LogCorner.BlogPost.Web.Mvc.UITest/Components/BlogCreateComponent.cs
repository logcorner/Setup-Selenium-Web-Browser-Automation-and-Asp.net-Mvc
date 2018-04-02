using OpenQA.Selenium;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Components
{
    internal class BlogCreateComponent
    {
        private IWebDriver _webDriver;
        private string _url;
        private string _description;

        public BlogCreateComponent(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        private IWebElement _root
        {
            get
            {
                return _webDriver.FindElement(By.Id("createBlogSection"));
            }
        }

        internal string IsAt()
        {
            if (_root == null)
            {
                return string.Empty; ;
            }
            return _webDriver.Url;
        }

        internal void Create()
        {
            var urlInput = _root.FindElement(By.Id("Url"));
            urlInput.SendKeys(_url);

            var descriptionInput = _root.FindElement(By.Id("Description"));
            descriptionInput.SendKeys(_description);

            var createButton = _root.FindElement(By.XPath("//*[@type='submit']"));
            createButton.Click();
        }

        internal BlogCreateComponent WithDescription(string description)
        {
            this._description = description;
            return this;
        }

        public BlogCreateComponent WithUrl(string url)
        {
            this._url = url;
            return this;
        }
    }
}