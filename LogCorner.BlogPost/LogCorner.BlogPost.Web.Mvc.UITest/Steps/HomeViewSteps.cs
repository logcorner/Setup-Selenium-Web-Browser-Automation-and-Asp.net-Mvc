using LogCorner.BlogPost.Web.Mvc.UITest.Views;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LogCorner.BlogPost.Web.Mvc.UITest.Steps
{
    [Binding]
    public class HomeViewSteps
    {
        private readonly HomeView _homeView;
        private BlogListView _blogListView;

        public HomeViewSteps(HomeView homeView, BlogListView blogListView)
        {
            _homeView = homeView;
            _blogListView = blogListView;
        }

        [Given(@"I am on the BlogPost application home page")]
        public void GivenIAmOnTheBlogPostApplicationHomePage()
        {
            _homeView.Goto();
        }

        [Then(@"Verify that the page title is (.*)")]
        public void ThenVerifyThePageTitle(string title)
        {
            Assert.True(title == _homeView.Title, "The page title is not correct");
        }
    }
}