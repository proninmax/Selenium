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
    public class ProductInfo: AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        public IWebElement productName;
        [FindsBy(How = How.XPath, Using = "//*[@id='CategoryId']/option[@selected]")]
        public IWebElement productCategory;
        [FindsBy(How = How.XPath, Using = "//*[@id='SupplierId']/option[@selected]")]
        public IWebElement productSupplier;
        [FindsBy(How = How.XPath, Using = "//*[@id='UnitPrice']")]
        public IWebElement productPrice;

        public ProductInfo(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
