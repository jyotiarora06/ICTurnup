using System;
using icTurnup.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace icTurnup.Steps
{
    [Binding]
    public class LoginSteps
    {
        //Intialize WebDriver
        private readonly IWebDriver driver;
        private LoginPage loginPage;

        //Create a Constructor
        public LoginSteps()
        {  
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
        }

        [Given("I am at the login page")]
        public void GivenIAmAtTheLoginPage()
        {
            
            loginPage.navigateToLoginPage();
            Console.WriteLine("I am at the login page");
        }

        
        [Given(@"I validate that i am at the login page")]
        public void GivenIValidateThatIAmAtTheLoginPage()
        {
            
            bool isAtLoginPage = loginPage.ValidateYouAreAtLoginPage();
            Assert.IsTrue(isAtLoginPage);
        }

        [When(@"I login with (.*) and with (.*)")]
        public void WhenILoginWithUsernameAndPassword(String username, String password)
        {
           
            loginPage.EnterGivenUserNameAndPassword(username,password);
            Console.WriteLine("I login with usename =" + username + " and with password =" + password);
        }

        [When(@"I enter valid creds")]
        public void WhenIEnterValidCreds()
        {
           
            loginPage.EnterGivenUserNameAndPassword(null,null);
            Console.WriteLine("I enter valid creds");
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            
            loginPage.ClickLoginButton();
            Console.WriteLine("I click the login button");
        }

        [Then("I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            
            bool isLoggedIn= loginPage.ValidateLoggedInSuccessfully();
            Console.WriteLine("I should be logged in successfully");
            Assert.IsTrue(isLoggedIn);
        }

        [Then("I should be not logged in")]
        public void ThenIShouldBeNotLoggedIn()
        {
            
            bool isNotLoggedIn = loginPage.ValidateNotLoggedIn();
            Console.WriteLine("I should be not logged in");
            Assert.IsTrue(isNotLoggedIn);
        }

        [AfterScenario]
        public void RunAfterEveryTest()
        {
            // close the driver
            driver.Close();
            driver.Quit();
        }

    }
}
