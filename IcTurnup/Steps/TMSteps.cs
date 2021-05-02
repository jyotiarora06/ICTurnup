using System;
using icTurnup.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace icTurnup.Steps
{
    [Binding]
    public class TMSteps
    {
        //Intialize WebDriver
        private readonly IWebDriver driver;
        private TMPage tmPageObj;
        private LoginPage loginPageObj;
        private HomePage homePageObj;


        //Create a Constructor
        public TMSteps()
        {
            driver = new ChromeDriver();
            tmPageObj = new TMPage(driver);
            loginPageObj = new LoginPage(driver);
            homePageObj = new HomePage(driver);

        }

        [Given("I am logged into the site")]
        public void GivenIAmLoggedInToTheSite()
        {

            loginPageObj.login(null, null);
            Console.WriteLine("I am logged into the site");
        }

        [Given("I am at the TM page")]
        public void GivenIAmAtTMPage()
        {
            homePageObj.ClickAdministrationDropdown();
            homePageObj.NavigateToTM();
            bool isAtTMPage = tmPageObj.ValidateAtTMPage();
            Assert.IsTrue(isAtTMPage);
            Console.WriteLine("I am at the TM page");
        }

        [When("I click the create new")]
        public void WhenIClickCreateNew()
        {
            tmPageObj.ClickCreateNew();
            Console.WriteLine("I click the create new");
        }

        [When("I enter the details for the new TM")]
        public void WhenIEnterDetailsFotTheNewTM()
        {
            tmPageObj.SelectTimeTypeCode();
            tmPageObj.EnterCode(null);
            tmPageObj.EnterDescription(null);
            tmPageObj.EnterPrice();
            Console.WriteLine("I enter the details for the new TM");
        }

        [When("I click the save")]
        public void WhenIClickSave()
        {
            tmPageObj.ClickSave();
            Console.WriteLine("I click the save");
        }

        [When("I click the last page")]
        public void WhenIClickLastPage()
        {
            tmPageObj.ClickLastPage();
            Console.WriteLine("I click the last page");
        }

        [Then("Validate the TM is created")]
        public void ThenValidateTheTMIsCreated()
        {
            bool isTMCreated = tmPageObj.ValidateTMIsCreated();
            Console.WriteLine("Validate the TM is created");
            Assert.IsTrue(isTMCreated);
        }


        [When("I click the edit")]
        public void WhenIClickEdit()
        {
            tmPageObj.ClickEdit();
            Console.WriteLine("I click the edit");
        }

        [When("I edit the details for the TM")]
        public void WhenIEditTheDetailsForTheTM()
        {
            tmPageObj.EditDescription(null);
            Console.WriteLine("I edit the details for the TM");
        }

        [Then("Validate that TM I edited was saved")]
        public void ThenValidateTheTMIsEdited()
        {
            bool isTMEdited = tmPageObj.ValidateTMIsEdited();
            Console.WriteLine("Validate that TM I edited was saved");
            Assert.IsTrue(isTMEdited);
        }

        [When("I click the delete")]
        public void WhenIClickDelete()
        {
            tmPageObj.ClickDelete();
            Console.WriteLine("I click the delete");
        }

        [When("I click the ok button")]
        public void WhenIClickOkButton()
        {
            tmPageObj.ClickOkButton();
            Console.WriteLine("I click the ok button");
        }

        [Then("Validate the TM is deleted")]
        public void ThenValidateTheTMIsDeleted()
        {
            bool isTMDeleted = tmPageObj.ValidateTMIsDeleted();
            Console.WriteLine("Validate the TM is deleted");
            Assert.IsTrue(isTMDeleted);
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
