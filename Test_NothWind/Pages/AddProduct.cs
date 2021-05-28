
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
   
    public class AddProduct:AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        public IWebElement addName;
        [FindsBy(How = How.XPath, Using = "//*[@id='CategoryId']")]
        public IWebElement addCategory;
        [FindsBy(How = How.XPath, Using = "//*[@id='SupplierId']")]
        public IWebElement addSupplier;
        [FindsBy(How = How.XPath, Using = "//*[@id='UnitPrice']")]
        public IWebElement addPrice;
        [FindsBy(How = How.XPath, Using = "//form/input[1]")]
        public IWebElement buttonAdd;
        public AddProduct(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
