using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Pages;
using DAO;
using System;
using TechTalk.SpecFlow;
using PageObject;

namespace Test_NothWind_SpecFlow.Steps
{
    [Binding]
    public class AddAndCheckProductSteps
    {
        Login login;
        HomePage homePage;
        IWebDriver webDriver;
        AllProducts allProducts;
        ProductDAO productDAO;
        Product product;
        ProductInfo productInfo;

        [When(@"I log in to the app")]
        public void WhenILogInToTheApp()
        {
            webDriver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
            webDriver.Navigate().GoToUrl("http://localhost:5000");
            login = new Login(webDriver);
            homePage = login.LogSystem();
        }
        
        [When(@"I go to the page All Product")]
        public void WhenIGoToThePageAllProduct()
        {
            allProducts = homePage.ShowAllProducts();
        }
        
        [When(@"I go to the page Create New")]
        public void WhenIGoToThePageCreateNew()
        {
            productDAO = new ProductDAO(allProducts.ShowAddProduct());
        }
        
        [When(@"I add new product")]
        public void WhenIAddNewProduct()
        {
            product = new Product();
            allProducts = productDAO.AddNewProduct(product);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
        }
        
        [When(@"I go to the added product page")]
        public void WhenIGoToTheAddedProductPage()
        {
            productInfo = allProducts.ShowLastProduct();
        }
        
        [Then(@"I check info about new product")]
        public void ThenICheckInfoAboutNewProduct()
        {
            productDAO = new ProductDAO(productInfo);
            productDAO.CheckAddProduct(product);
            webDriver.Quit();
        }
    }
}
