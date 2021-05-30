using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Pages;

namespace Test_NothWind_SpecFlow.Steps
{
    [Binding]
    public class LoginSteps
    {
        Login login;
        HomePage homePage;
        IWebDriver webDriver;

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string p0)
        {
            webDriver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
            webDriver.Navigate().GoToUrl(p0);
            login = new Login(webDriver);
        }
        
        [When(@"I enter my username ""(.*)""")]
        public void WhenIEnterMyUsername(string p0)
        {
            login.EnterUserName(p0);
        }
        
        [When(@"I enter password ""(.*)""")]
        public void WhenIEnterPassword(string p0)
        {
            login.EnterPass(p0);
        }
        
        [When(@"I click button")]
        public void WhenIClickButton()
        {
            homePage = login.GoToHomePage();
        }
        
        [Then(@"I should be on the page Home page")]
        public void ThenIShouldBeOnThePageHomePage()
        {
            homePage.CheckLabel();
            webDriver.Quit();
        }
    }
}
