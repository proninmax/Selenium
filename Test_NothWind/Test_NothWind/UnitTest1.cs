using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using Page_obgects;
using Pages;
using DAO;

namespace Test_NothWind
{
    public class Tests
    {
        IWebDriver webDriver;
        private Product product;
        WebDriverWait wait;
        ProductDAO productDAO;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
            webDriver.Navigate().GoToUrl("http://localhost:5000");
            product = new Product();
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
            AllProducts allProducts = homePage.ShowAllProducts();
            productDAO = new ProductDAO(allProducts.ShowAddProduct());
            allProducts = productDAO.AddProduct(product);
            allProducts.CheckLabel();
        }
        [Test]
        public void Test_CheckAddProduct()
        {
            Login login = new Login(webDriver);
            HomePage homePage = login.LogSystem();
            AllProducts allProducts = homePage.ShowAllProducts();
            productDAO = new ProductDAO( allProducts.ShowLastProduct());
            //Thread.Sleep(200);
            productDAO.CheckAddProduct(product);
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