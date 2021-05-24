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
    public class ProductInfo: AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        private IWebElement productName;
        [FindsBy(How = How.XPath, Using = "//*[@id='CategoryId']/option[@selected]")]
        private IWebElement productCategory;
        [FindsBy(How = How.XPath, Using = "//*[@id='SupplierId']/option[@selected]")]
        private IWebElement productSupplier;
        [FindsBy(How = How.XPath, Using = "//*[@id='UnitPrice']")]
        private IWebElement productPrice;

        public ProductInfo(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void CheckAddProduct(string name, string category, string supplier,string price)
        {
            Assert.AreEqual(name, productName.GetAttribute("value").ToString());
            Assert.AreEqual(category, productCategory.Text.ToString());
            Assert.AreEqual(supplier, productSupplier.Text.ToString());
            Assert.AreEqual(price + ",0000", productPrice.GetAttribute("value").ToString());
        }
    }
}
