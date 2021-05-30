using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
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
        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement label;

        public Login(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
        public HomePage LogSystem()
        {
            nameText.SendKeys("user");
            passwordText.SendKeys("user");
            button.Click();
            return new HomePage(webDriver);
        }
        public void EnterUserName(string userName)
        {
            nameText.SendKeys(userName);
        }
        public void EnterPass(string pass)
        {
            passwordText.SendKeys(pass);
        }
        public HomePage GoToHomePage()
        {
            button.Click();
            return new HomePage(webDriver);
        }
        public void CheckLabel()
        {
            Assert.AreEqual("Login", label.Text.ToString());
        }

    }
}
