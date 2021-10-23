using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SpecFlowSelenium.Context;
using SpecFlowSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class ProductFeatureSteps : IDisposable
    {
        private LoginPage _loginPage;
        private ProductPage _productPage;
        private ChromeDriver _driver;

        public ProductFeatureSteps(WebDriverContext webDriverContext)
        {
            _driver = webDriverContext.driver;
        }

        [Given(@"I have logged in successfully with (.*) username and (.*) password")]
        public void GivenIHaveLoggedInSuccessfullyWithStandard_UserUsernameAndSecret_SaucePassword(string username, string password)
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
            _loginPage.UserName.SendKeys(username);
            _loginPage.Password.SendKeys(password);
            _loginPage.LoginButton.Submit();
            Assert.IsTrue(true);
        }
        
        [When(@"I press add to cart or remove from cart button")]
        public void WhenIPressAddToCartOrRemoveFromCartButton()
        {
            _productPage.AddToCartOrRemoveFromCartButton.Click();
        }
        
        [When(@"I select ""(.*)""")]
        public void WhenISelect(string dropdownText)
        {
            _productPage.FillterDropDown.SelectByText(dropdownText);
        }
        
        [Then(@"any number of product items should be displayed")]
        public void ThenAnyNumberOfProductItemsShouldBeDisplayed()
        {
            Assert.IsTrue(_productPage.ProductItems.Count > 0);
        }
        
        [Then(@"product item should be added the cart and (.*) button should be displayed")]
        public void ThenProductItemShouldBeAddedTheCartAndRemoveFromCartButtonShouldBeDisplayed(string buttonText)
        {
            Assert.IsTrue(_productPage.AddToCartOrRemoveFromCartButton.Text.Equals(buttonText));
            Assert.IsTrue(Int32.Parse(_productPage.CartCount().Text) > 0);
        }
        
        [Then(@"product item should be removed from the cart and (.*) button should be displayed")]
        public void ThenProductItemShouldBeRemovedFromTheCartAndAddToCartButtonShouldBeDisplayed(string buttonText)
        {
            Assert.IsTrue(_productPage.AddToCartOrRemoveFromCartButton.Text.Equals(buttonText));
            Assert.IsTrue(_productPage.CartCount() == null);
        }     

        [Then(@"first item should be priced (.*)")]
        public void ThenFirstItemShouldBePriced(string itemPrice)
        {
            Assert.IsTrue(_productPage.FirstProductItemPrice.Text.Equals(itemPrice));
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
