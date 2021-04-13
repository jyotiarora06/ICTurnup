using System;
using icTurnup.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace icTurnup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //launch turnup portal
            IWebDriver driver = new ChromeDriver();
          
            //login page objects 
            LoginPage loginObj = new LoginPage();
            loginObj.loginSteps(driver);

            //home page objects
            HomePage homeObj = new HomePage();
            homeObj.navigateToTM(driver);

            //TM page objects
            TMPage tmObj = new TMPage();
            tmObj.createTM(driver);
            tmObj.editTM(driver);
            tmObj.deleteTM(driver);

            // close the driver
            driver.Close();
        }
    }
}
