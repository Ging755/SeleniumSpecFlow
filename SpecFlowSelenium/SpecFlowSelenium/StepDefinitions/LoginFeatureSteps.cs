using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowSelenium.Context;
using SpecFlowSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class LoginFeatureSteps : IDisposable
    {
        private LoginPage _loginPage;
        private ChromeDriver _driver;

        public LoginFeatureSteps(WebDriverContext webDriverContext)
        {
            _driver = webDriverContext.driver;
        }

        [Given(@"I have navigated to login page")]
        public void GivenIHaveNavigatedToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage = new LoginPage(_driver);
            Assert.IsTrue(true);
        }


        [Given(@"I have entered (.*) as username and (.*) as password")]
        public void GivenIHaveEnteredusernameAsUsernameAndpasswordAsPassword(string username, string password)
        {
            _loginPage.UserName.SendKeys(username);
            _loginPage.Password.SendKeys(password);
        }

        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            _loginPage.LoginButton.Submit();
        }

        [Then(@"I should be redirected to products page")]
        public void ThenIShouldBeNavigateToProductsPage()
        {
            Assert.IsTrue(_driver.FindElement(By.Id("inventory_container")).Displayed);
        }

        [Then(@"Login Page should be displayed")]
        public void ThenLoginPageShouldBeDisplayed()
        {
            Assert.IsTrue(_loginPage.UserName.Displayed && 
                _loginPage.UserName.Text.Equals(String.Empty) && 
                _loginPage.Password.Displayed && 
                _loginPage.Password.Text.Equals(String.Empty) &&
                _loginPage.LoginButton.Displayed);
        }

        [Then(@"Username and password input should be displayed and empty and login button should be displayed")]
        public void ThenUsernameAndPasswordInputShouldBeDisplayedAndEmptyAndLoginButtonShouldBeDisplayed()
        {
            Assert.IsTrue(_loginPage.UserName.Displayed &&
                _loginPage.UserName.Text.Equals(String.Empty) &&
                _loginPage.Password.Displayed &&
                _loginPage.Password.Text.Equals(String.Empty) &&
                _loginPage.LoginButton.Displayed);
        }

        [Then(@"""(.*)"" error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string errorMessage)
        {
            Assert.IsTrue(
                _loginPage.ErrorMessage
                .Text.Equals(errorMessage));
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
