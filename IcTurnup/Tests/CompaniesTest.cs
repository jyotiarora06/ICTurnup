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
            homeObj.NavigateToCompanies();

            //Companies page objects
            CompaniesPage companyObj = new CompaniesPage(driver);
            companyObj.CreateCompany();
        }

        [Test]
        public void EditCompanyTest()
        {
            //home page objects
            HomePage homeObj = new HomePage(driver);
            homeObj.NavigateToCompanies();

            //TM page objects
            CompaniesPage companyObj = new CompaniesPage(driver);
            companyObj.EditCompany();
        }
    }
}
