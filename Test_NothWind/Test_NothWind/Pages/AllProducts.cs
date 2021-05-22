using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_NothWind.Pages
{
    public class AllProducts: AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//div[2]/a")]
        private IWebElement buttonCreate;
        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement label;
        [FindsBy(How = How.XPath, Using = "//tr[last()]/td[2]/a")]
        private IWebElement testProduct;

        public AllProducts(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
        public AddProduct ShowAddProduct()
        {
            buttonCreate.Click();
            return new AddProduct(webDriver);
        }
        public void CheckLabel()
        {
            Assert.AreEqual("All Products", label.Text.ToString());
        }
        public ProductInfo ShowLastProduct()
        {
            testProduct.Click();
            return new ProductInfo(webDriver);
        }
    }
}
