using LogCorner.BlogPost.Web.Mvc.UITest.Components;
using LogCorner.BlogPost.Web.Mvc.UITest.Setup;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Views
{
    public class HomeView : Browser
    {
        private static string PageTitle = "Immobilier de luxe | Immobilier de prestige";

        private readonly MenuComponent _menuComponent;

        public HomeView()
        {
            _menuComponent = new MenuComponent(WebDriver);
        }

        public void Goto()
        {
            Goto(WebSiteUrl);
        }

        public bool IsAt()
        {
            return Title == PageTitle;
        }

        internal bool IsNotAuthenticatedUser(string email)
        {
            return _menuComponent.IsNotAuthenticatedUser(email);
        }
    }
}