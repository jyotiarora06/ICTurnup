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
            homeObj.NavigateToTM();

            //TM page objects
            TMPage tmObj = new TMPage(driver);
            tmObj.CreateTM();
        }

        [Test]
        public void EditTMTest()
        {
            //home page objects
            HomePage homeObj = new HomePage(driver);
            homeObj.NavigateToTM();

            //TM page objects
            TMPage tmObj = new TMPage(driver);
            tmObj.EditTM();
        }

        [Test]
        public void DeleteTMTest()
        {
            //home page objects
            HomePage homeObj = new HomePage(driver);
            homeObj.NavigateToTM();

            //TM page objects
            TMPage tmObj = new TMPage(driver);
            tmObj.DeleteTM();
        }
    }
}