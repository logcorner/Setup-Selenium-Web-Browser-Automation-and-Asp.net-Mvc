using OpenQA.Selenium;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Components
{
    public class BlogListComponent
    {
        private readonly IWebDriver _webDriver;

        private IWebElement Root => _webDriver.FindElement(By.Id("listBlogTable"));

        public BlogListComponent(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickOnCreateBlogLink()
        {
            Root.FindElement(By.Id("CreateNewBlogLink")).Click();

            // _webDriver.FindElement(By.("MyTagName"));
        }

        internal string IsAt()
        {
            if (Root != null)
            {
                return _webDriver.Url;
            }
            return string.Empty;
        }
    }
}