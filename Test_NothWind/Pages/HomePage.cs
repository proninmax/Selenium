using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class HomePage : AbstractPage
    {
        public HomePage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(webDriver, this);
        }
    }
}
