using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using Test_NothWind.Pages;
using System.Threading;

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
            Login login = new Login(webDriver);
            HomePage homePage = login.LogSystem();
            homePage.CheckLabel(); //Проверка заголовка
        }
        [Test]
        public void Test_AddProduct()
        {
            Login login = new Login(webDriver);
            HomePage homePage = login.LogSystem();
            AllProducts allProducts =  homePage.ShowAllProducts();
            AddProduct addProduct = allProducts.ShowAddProduct();
            allProducts = addProduct.CreateProduct(name, category, supplier, price);
            allProducts.CheckLabel();
        }
        [Test]
        public void Test_CheckAddProduct()
        {
            Login login = new Login(webDriver);
            HomePage homePage = login.LogSystem();
            AllProducts allProducts = homePage.ShowAllProducts();
            ProductInfo productInfo = allProducts.ShowLastProduct();
            //Thread.Sleep(200);
            productInfo.CheckAddProduct(name, category, supplier, price);
        }
        [Test]
        public void Test_LogOut()
        {
            Login login = new Login(webDriver);
            HomePage homePage = login.LogSystem();
            homePage.CheckLabel();
            login = homePage.LogOut();
            login.CheckLabel();
        }
        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
} 