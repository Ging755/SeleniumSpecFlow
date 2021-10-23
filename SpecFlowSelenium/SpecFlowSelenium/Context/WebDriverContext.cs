using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowSelenium.Context
{
    public class WebDriverContext
    {
        public WebDriverContext()
        {
            this.driver = new ChromeDriver();
        }

        public ChromeDriver driver;
    }
}
