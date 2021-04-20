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
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            //TM page objects
            TMPage tmObj = new TMPage();
            tmObj.CreateTM(driver);
        }

        [Test]
        public void EditTMTest()
        {
            //home page objects
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            //TM page objects
            TMPage tmObj = new TMPage();
            tmObj.EditTM(driver);
        }

        [Test]
        public void DeleteTMTest()
        {
            //home page objects
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            //TM page objects
            TMPage tmObj = new TMPage();
            tmObj.DeleteTM(driver);
        }
    }
}