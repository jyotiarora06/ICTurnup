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
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCompanies(driver);

            //Companies page objects
            CompaniesPage companyObj = new CompaniesPage();
            companyObj.CreateCompany(driver);
        }

        [Test]
        public void EditCompanyTest()
        {
            //home page objects
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCompanies(driver);

            //TM page objects
            CompaniesPage companyObj = new CompaniesPage();
            companyObj.EditCompany(driver);
        }
    }
}
