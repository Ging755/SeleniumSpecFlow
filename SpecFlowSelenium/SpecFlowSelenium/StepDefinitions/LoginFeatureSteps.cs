using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowSelenium.Context;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class LoginFeatureSteps : IDisposable
    {
        private ChromeDriver _driver;

        private readonly WebDriverContext _webDriverContext;

        public LoginFeatureSteps(WebDriverContext webDriverContext)
        {
            _webDriverContext = webDriverContext;
            _driver = _webDriverContext.driver;
        }

        [Given(@"I have navigated to login page")]
        public void GivenIHaveNavigatedToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Assert.IsTrue(true);
        }

        [Given(@"I have entered (.*) as username and (.*) as password")]
        public void GivenIHaveEnteredusernameAsUsernameAndpasswordAsPassword(string username, string password)
        {
            IWebElement UserName = _driver.FindElement(By.Id("user-name"));
            IWebElement Password = _driver.FindElement(By.Id("password"));

            UserName.SendKeys(username);
            Password.SendKeys(password);

        }

        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            IWebElement LoginButton = _driver.FindElement(By.Id("login-button"));
            LoginButton.Submit();
        }

        [Then(@"I should be redirected to products page")]
        public void ThenIShouldBeNavigateToProductsPage()
        {
            Assert.IsTrue(_driver.FindElement(By.Id("inventory_container")).Displayed);
        }

        [Then(@"Login Page should be displayed")]
        public void ThenLoginPageShouldBeDisplayed()
        {
            IWebElement UserName = _driver.FindElement(By.Id("user-name"));
            IWebElement Password = _driver.FindElement(By.Id("password"));
            IWebElement LoginButton = _driver.FindElement(By.Id("login-button"));

            Assert.IsTrue(UserName.Displayed && UserName.Text.Equals(String.Empty) && Password.Displayed && Password.Text.Equals(String.Empty) && LoginButton.Displayed);
        }

        [Then(@"Username and password input should be displayed and empty and login button should be displayed")]
        public void ThenUsernameAndPasswordInputShouldBeDisplayedAndEmptyAndLoginButtonShouldBeDisplayed()
        {
            IWebElement UserName = _driver.FindElement(By.Id("user-name"));
            IWebElement Password = _driver.FindElement(By.Id("password"));
            IWebElement LoginButton = _driver.FindElement(By.Id("login-button"));

            Assert.IsTrue(UserName.Displayed && UserName.Text.Equals(String.Empty) && Password.Displayed && Password.Text.Equals(String.Empty) && LoginButton.Displayed);
        }

        [Then(@"""(.*)"" error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string errorMessage)
        {
            Assert.IsTrue(_driver.FindElement(By.XPath("//div[@class='error-message-container error']/h3")).Text.Equals(errorMessage));
        }


        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
