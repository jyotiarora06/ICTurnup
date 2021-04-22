using System;
using System.Threading;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class LoginPage
    {
        IWebDriver driver;
        IWebElement Username => driver.FindElement(By.Id("UserName"));
        IWebElement Password => driver.FindElement(By.Id("Password"));
        IWebElement LoginButton => driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
        IWebElement HelloHari => driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

        public LoginPage(IWebDriver driver)
        {
           this.driver = driver;
        }

        public void LoginSteps()
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            //maximize browser
            driver.Manage().Window.Maximize();

            wait.ElementExists(driver, "Id", "UserName", 5);

            try
            {
                //Enter username
                
                Username.SendKeys("hari");

                //Enter password
                
                Password.SendKeys("123123");

                //Click login button
                
                LoginButton.Click();
            }
            catch(Exception msg)
            {
                Assert.Fail("Test failed at login page",msg.Message);
            }

            wait.ElementExists(driver, "XPath", "//*[@id='logoutForm']/ul/li/a", 2);

            //validate if the user is logged in successfully
            
            Assert.That(HelloHari.Text,Is.EqualTo("Hello hari!"),"Test failed");

            //if (helloHari.Text == "Hello hari!")
            //{
            //    Console.WriteLine("Logged in successfully, test passed");
            //}
            //else
            //{
            //    Console.WriteLine("Login failed, test failed");
            //}
        }
    }
}
