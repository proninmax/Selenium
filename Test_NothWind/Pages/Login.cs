using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Login: AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='Name']")]
        private IWebElement nameText;
        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        private IWebElement passwordText;
        [FindsBy(How = How.XPath, Using = "//input[@class = 'btn btn-default']")]
        private IWebElement button;
        public Login(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(webDriver, this);
        }
        public HomePage LogSystem()
        {
            nameText.SendKeys("user");
            passwordText.SendKeys("user");
            button.Click();
            return new HomePage(webDriver);
        }

    }
}
