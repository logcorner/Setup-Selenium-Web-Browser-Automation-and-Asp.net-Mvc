using LogCorner.BlogPost.Web.Mvc.UITest.Components;
using LogCorner.BlogPost.Web.Mvc.UITest.Setup;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Views
{
    public class LoginView : Browser
    {
        private readonly LoginComponent _loginComponent;
        private readonly MenuComponent _menuComponent;

        public LoginView()
        {
            _loginComponent = new LoginComponent(WebDriver);
            _menuComponent = new MenuComponent(WebDriver);
        }

        public bool IsAt()
        {
            return _loginComponent.IsAt() == $"{WebSiteUrl}/Account/Login?ReturnUrl=%2FBlog%2FCreate";
        }

        internal void Login(string email, string password)
        {
            _loginComponent.LoginAs(email).WithPassword(password).Login();
        }

        internal bool AuthenticatedUser(string email, string password)
        {
            _menuComponent.ClickOnLoginLink();
            _loginComponent.LoginAs(email).WithPassword(password).Login();
            return !_menuComponent.IsAuthenticatedUser(email);
        }
    }
}