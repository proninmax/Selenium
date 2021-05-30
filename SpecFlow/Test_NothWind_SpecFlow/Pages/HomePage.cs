using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class HomePage : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement labelWelcome;
        [FindsBy(How = How.XPath, Using = "//div[2]/div[1]/a")]
        private IWebElement allProduct;
        [FindsBy(How = How.XPath, Using = "//a[@href='/Account/Logout']")]
        private IWebElement buttonLogout;

        public HomePage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(webDriver, this);
        }
        public void CheckLabel()
        {
            Assert.AreEqual("Home page", labelWelcome.Text);
        }
        public AllProducts ShowAllProducts()
        {
            allProduct.Click();
            return new AllProducts(webDriver);
        } 
        public Login LogOut()
        {
            buttonLogout.Click();
            return new Login(webDriver);
        }
    }
}
