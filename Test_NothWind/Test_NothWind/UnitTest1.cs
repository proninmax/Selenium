using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Test_NothWind
{
    public class Tests
    {
        IWebDriver webDriver; 
        private string name;
        private string category;
        private string supplier;
        private string price;
        WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
            webDriver.Navigate().GoToUrl("http://localhost:5000");
            name = "TestProduct";
            category = "Produce";
            supplier = "Exotic Liquids";
            price = "200";
        }
        public void Login()
        {
            IWebElement name = webDriver.FindElement(By.XPath("//*[@id='Name']"));
            name.SendKeys("user");
            IWebElement password = webDriver.FindElement(By.XPath("//*[@id='Password']"));
            password.SendKeys("user");
            IWebElement button = webDriver.FindElement(By.XPath("//input[@class = 'btn btn-default']"));
            button.Click();
        }
        [Test]
        public void Test_Login()
        {
            this.Login();
            IWebElement label = webDriver.FindElement(By.XPath("//h2"));
            Assert.AreEqual("Home page", label.Text.ToString());
        }
        [Test]
        public void Test_AddProduct()
        {
            this.Login();
            IWebElement aProduct = webDriver.FindElement(By.XPath("//div[2]/div[1]/a"));
            aProduct.Click();
            IWebElement buttonAddProduct = webDriver.FindElement(By.XPath("//div[2]/a"));
            buttonAddProduct.Click();
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement addProductName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ProductName']")));
            addProductName.SendKeys(name);
            IWebElement addCategory = webDriver.FindElement(By.XPath("//*[@id='CategoryId']"));
            addCategory.SendKeys(category);
            IWebElement addSupplier = webDriver.FindElement(By.XPath("//*[@id='SupplierId']"));
            addSupplier.SendKeys(supplier);
            IWebElement addPrice = webDriver.FindElement(By.XPath("//*[@id='UnitPrice']"));
            addPrice.SendKeys(price);
            IWebElement addProduct = webDriver.FindElement(By.XPath("//form/input[1]"));
            addProduct.Click();
            IWebElement label = webDriver.FindElement(By.XPath("//h2"));
            Assert.AreEqual("All Products", label.Text.ToString());
        }
        [Test]
        public void Test_CheckAddProduct()
        {
            this.Login();
            IWebElement aProduct = webDriver.FindElement(By.XPath("//div[2]/div[1]/a"));
            aProduct.Click();
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException)); 
            IWebElement buttonGoProduct = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[last()]/td[2]/a")));
            buttonGoProduct.Click();
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement tProductName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ProductName']")));
            Assert.AreEqual(name, tProductName.GetAttribute("value").ToString());
            IWebElement tCategory = webDriver.FindElement(By.XPath("//*[@id='CategoryId']/option[@selected]"));
            Assert.AreEqual(category, tCategory.Text.ToString());
            IWebElement tSupplier = webDriver.FindElement(By.XPath("//*[@id='SupplierId']/option[@selected]"));
            Assert.AreEqual(supplier, tSupplier.Text.ToString());
            IWebElement tPrice = webDriver.FindElement(By.XPath("//*[@id='UnitPrice']"));
            Assert.AreEqual(price+",0000", tPrice.GetAttribute("value").ToString()); 
        }
        [Test]
        public void Test_LogOut()
        {
            this.Login();
            IWebElement label = webDriver.FindElement(By.XPath("//h2"));
            Assert.AreEqual("Home page", label.Text.ToString());
            IWebElement logOut = webDriver.FindElement(By.XPath("//a[@href='/Account/Logout']"));
            logOut.Click();
            IWebElement labelHome = webDriver.FindElement(By.XPath("//h2"));
            Assert.AreEqual("Login", labelHome.Text.ToString());
        }
        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
}