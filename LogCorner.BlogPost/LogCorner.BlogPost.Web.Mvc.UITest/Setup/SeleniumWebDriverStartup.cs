using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Setup
{
    public class SeleniumWebDriverStartup : IisRexpressServerStartup
    {
        private IWebDriver _remoteWebDriver;

        public IWebDriver WebDriver => _remoteWebDriver;

        public SeleniumWebDriverStartup(string applicationName) : base(applicationName)
        {
        }

        public override void Initialize()
        {
            TestInitialize();
            _remoteWebDriver = new ChromeDriver(@"C:\Selenium\drivers");
            _remoteWebDriver.Manage().Window.Maximize();
        }

        private IWebDriver IEDriver()
        {
            InternetExplorerOptions options =
                new InternetExplorerOptions { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
            _remoteWebDriver = new InternetExplorerDriver(options);
            return _remoteWebDriver;
        }

        public override void Cleanup()
        {
            _remoteWebDriver.Dispose();
            TestCleanup();
        }
    }
}