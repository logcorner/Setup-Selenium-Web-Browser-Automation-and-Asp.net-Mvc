using OpenQA.Selenium;
using System.Configuration;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Setup
{
    public class Browser
    {
        protected string WebSiteUrl => $"{ConfigurationManager.AppSettings["webSiteHost"]}:{ConfigurationManager.AppSettings["webSitePort"]}";

        public string Title => WebDriver.Title;

        protected IWebDriver WebDriver => StartUp.WebDriver;

        protected void Goto(string url)
        {
            WebDriver.Url = url;
        }
    }
}