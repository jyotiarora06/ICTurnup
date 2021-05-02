using System;
using icTurnup.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
namespace icTurnup.Steps
{
    [Binding]
    public class CompaniesSteps
    {
        //Intialize WebDriver
        private readonly IWebDriver driver;
        private CompaniesPage companiesPage;
        private LoginPage loginObj;
        private HomePage homePage;
        

        //Create a Constructor
        public CompaniesSteps()
        {
            driver = new ChromeDriver();
            companiesPage = new CompaniesPage(driver);
            loginObj = new LoginPage(driver);
            homePage = new HomePage(driver);
       
        }

        [Given("I am logged in")]
        public void GivenIAmLoggedIn()
        {
          
            loginObj.login(null, null);
            Console.WriteLine("I am logged in");
        }

        [Given("I am at the company page")]
        public void GivenIAmAtCompanyPage()
        {
            homePage.ClickAdministrationDropdown();
            homePage.NavigateToCompanies();
            bool isAtCompaniesPage = companiesPage.ValidateAtCompaniesPage();
            Assert.IsTrue(isAtCompaniesPage);
            Console.WriteLine("I am at the company page");
        }
        
        [When("I click the create new button")]
        public void WhenIClickCreateNewButton()
        {
            companiesPage.ClickCreateNewButton();
            Console.WriteLine("I click the create new button");
        }

        [When("I enter the details for the new company")]
        public void WhenIEnterDetailsFotTheNewCompany()
        {
            companiesPage.EnterName(null);
            companiesPage.ClickEditContactButton();
            companiesPage.EnterFirstName(null);
            companiesPage.EnterLastName(null);
            companiesPage.EnterPhone();
            companiesPage.ClickSaveContactButton();
            Console.WriteLine("I enter the details for the new company");
        }

        [When("I click the save company button")]
        public void WhenIClickSaveCompanyButton()
        {
            companiesPage.ClickSaveCompanyButton();
            Console.WriteLine("I click the save company button");
        }

        [When("I click the last page icon")]
        public void WhenIClickLastPageIcon()
        {
            companiesPage.ClickLastPage();
            Console.WriteLine("I click the last page icon");
        }
        
        [Then("Validate the company is created")]
        public void ThenValidateTheCompanyIsCreated()
        {
            bool isCompanyCreated = companiesPage.ValidateTheCompanyIsCreated();
            Console.WriteLine("Validate the company is created");
            Assert.IsTrue(isCompanyCreated);
        }
        

        [When("I click the edit button")]
        public void WhenIClickEditButton()
        { 
            companiesPage.ClickEditButton();
            Console.WriteLine("I click the edit button");
        }

        [When("I edit the details")]
        public void WhenIEditTheDetails()
        {
            companiesPage.EditName(null);
            Console.WriteLine("I edit the details");
        }

        [Then("Validate that company I edited was saved")]
        public void ThenValidateTheCompanyIsEdited()
        {
            bool isCompanyEdited = companiesPage.ValidateTheCompanyIsEdited();
            Console.WriteLine("Validate that company I edited was saved");
            Assert.IsTrue(isCompanyEdited);
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