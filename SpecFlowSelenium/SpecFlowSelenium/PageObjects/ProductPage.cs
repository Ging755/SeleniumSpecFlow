using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecFlowSelenium.PageObjects
{
    class ProductPage
    {
        private IWebDriver _driver;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public List<IWebElement> ProductItems => _driver.FindElements(By.ClassName("inventory_item")).ToList();
        public IWebElement AddToCartOrRemoveFromCartButton => ProductItems.FirstOrDefault().FindElement(By.XPath(".//button"));
        public IWebElement FirstProductItemPrice => ProductItems.FirstOrDefault().FindElement(By.XPath(".//div[@class='inventory_item_price']"));
        public IWebElement CartElement => _driver.FindElement(By.ClassName("shopping_cart_link"));
        public SelectElement FillterDropDown => new SelectElement(_driver.FindElement(By.ClassName("product_sort_container")));

        public IWebElement CartCount()
        {
            try
            {
                return CartElement.FindElement(By.ClassName("shopping_cart_badge"));
            }
            catch
            {
                return null;
            }
        }
    }
}
