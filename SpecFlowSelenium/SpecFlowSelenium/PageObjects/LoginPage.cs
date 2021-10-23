using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowSelenium.PageObjects
{
    class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UserName => _driver.FindElement(By.Id("user-name"));
        public IWebElement Password => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
        public IWebElement ErrorMessage => _driver.FindElement(By.XPath("//div[@class='error-message-container error']/h3"));

    }
}
