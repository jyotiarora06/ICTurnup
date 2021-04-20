using System;
using icTurnup.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace icTurnup.Utilities
{
    public class CommonDriver
    {
        // init driver
        public IWebDriver driver;

        [OneTimeSetUp]
        public void LoginTurnup()
        {
            //Console.WriteLine("Hello World!");

            //launch turnup portal
            driver = new ChromeDriver();

            //login page objects 
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);
        }

        [OneTimeTearDown]
        public void FinalSteps()
        {
            // close the driver
            driver.Close();
            driver.Quit();
        }
    }
}
