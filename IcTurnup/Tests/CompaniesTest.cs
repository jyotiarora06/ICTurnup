using System;
using icTurnup.Pages;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace icTurnup.Tests
{
    [TestFixture]
    [Parallelizable]
    class CompaniesTest: CommonDriver
    {
        // static void Main(string[] args)
        //{}

        [Test]
        public void CreateCompanyTest()
        {
            //home page objects
            HomePage homeObj = new HomePage(driver);
            homeObj.ClickAdministrationDropdown();
            homeObj.NavigateToCompanies();

            //Companies page objects
            CompaniesPage companyObj = new CompaniesPage(driver);
            companyObj.ClickCreateNewButton();
            companyObj.EnterName(null);
            companyObj.ClickEditContactButton();
            companyObj.EnterFirstName(null);
            companyObj.EnterLastName(null);
            companyObj.EnterPhone();
            companyObj.ClickSaveContactButton();
            companyObj.ClickSaveCompanyButton();
            companyObj.ClickLastPage();
            bool isCompanyCreated = companyObj.ValidateTheCompanyIsCreated();
            Assert.IsTrue(isCompanyCreated);
        }

        [Test]
        public void EditCompanyTest()
        {
            //home page objects
            HomePage homeObj = new HomePage(driver);
            homeObj.ClickAdministrationDropdown();
            homeObj.NavigateToCompanies();

            //TM page objects
            CompaniesPage companyObj = new CompaniesPage(driver);
            companyObj.ClickLastPage();
            companyObj.ClickEditButton();
            companyObj.EditName(null);
            companyObj.ClickSaveCompanyButton();
            companyObj.ClickLastPage();
            bool isCompanyEdited = companyObj.ValidateTheCompanyIsEdited();
            Assert.IsTrue(isCompanyEdited);
        }
    }
}
