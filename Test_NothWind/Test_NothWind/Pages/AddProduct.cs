using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_NothWind.Pages
{
    public class AddProduct:AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        private IWebElement addName;
        [FindsBy(How = How.XPath, Using = "//*[@id='CategoryId']")]
        private IWebElement addCategory;
        [FindsBy(How = How.XPath, Using = "//*[@id='SupplierId']")]
        private IWebElement addSupplier;
        [FindsBy(How = How.XPath, Using = "//*[@id='UnitPrice']")]
        private IWebElement addPrice;
        [FindsBy(How = How.XPath, Using = "//form/input[1]")]
        private IWebElement buttonAdd;
        public AddProduct(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
        public AllProducts CreateProduct(string name, string category, string supplier, string price)
        {
            addName.SendKeys(name);
            addCategory.SendKeys(category);
            addSupplier.SendKeys(supplier);
            addPrice.SendKeys(price);
            buttonAdd.Click();
            return new AllProducts(webDriver);
        }
    }
}
