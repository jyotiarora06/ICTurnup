using System;
using icTurnup.Pages;
using icTurnup.Utilities;
using NUnit.Framework;

namespace icTurnup.Tests
{
    [TestFixture]
    [Parallelizable]
    class TMTest : CommonDriver
    {
       // static void Main(string[] args)
       //{}

        [Test]
        public void CreateTMTest()
        {
            //home page objects
            HomePage homeObj = new HomePage(driver);
            homeObj.ClickAdministrationDropdown();
            homeObj.NavigateToTM();

            //TM page objects
            TMPage tmObj = new TMPage(driver);
            tmObj.ClickCreateNew();
            tmObj.SelectTimeTypeCode();
            tmObj.EnterCode(null);
            tmObj.EnterDescription(null);
            tmObj.EnterPrice();
            tmObj.ClickSave();
            tmObj.ClickLastPage();
            bool isTMCreated = tmObj.ValidateTMIsCreated();
            Assert.IsTrue(isTMCreated);
        }

        [Test]
        public void EditTMTest()
        {
            //home page objects
            HomePage homeObj = new HomePage(driver);
            homeObj.ClickAdministrationDropdown();
            homeObj.NavigateToTM();

            //TM page objects
            TMPage tmObj = new TMPage(driver);
            tmObj.ClickLastPage();
            tmObj.ClickEdit();
            tmObj.EditDescription(null);
            tmObj.ClickSave();
            tmObj.ClickLastPage();
            bool isTMEdited = tmObj.ValidateTMIsEdited();
            Assert.IsTrue(isTMEdited);
        }

        [Test]
        public void DeleteTMTest()
        {
            //home page objects
            HomePage homeObj = new HomePage(driver);
            homeObj.ClickAdministrationDropdown();
            homeObj.NavigateToTM();

            //TM page objects
            TMPage tmObj = new TMPage(driver);
            tmObj.ClickDelete();
            tmObj.ClickOkButton();
            bool isTMDeleted = tmObj.ValidateTMIsDeleted();
            Assert.IsTrue(isTMDeleted);
        }
    }
}