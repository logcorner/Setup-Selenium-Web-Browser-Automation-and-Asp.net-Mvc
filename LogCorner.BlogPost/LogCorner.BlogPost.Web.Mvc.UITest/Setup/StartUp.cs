using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Setup
{
    [Binding]
    public static class StartUp
    {
        private static readonly SeleniumWebDriverStartup SeleniumTest =
             new SeleniumWebDriverStartup(ConfigurationManager.AppSettings["webSiteName"]);

        public static IWebDriver WebDriver => SeleniumTest.WebDriver;

        [BeforeTestRun]
        public static void Start()
        {
            SeleniumTest.Initialize();
        }

        [AfterTestRun]
        public static void Down()
        {
            SeleniumTest.Cleanup();
        }
    }
}