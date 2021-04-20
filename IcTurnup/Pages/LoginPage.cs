using System;
using System.Threading;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            //maximize browser
            driver.Manage().Window.Maximize();

            wait.ElementExists(driver, "Id", "UserName", 5);

            try
            {
                //identify and enter username
                IWebElement username = driver.FindElement(By.Id("UserName"));
                username.SendKeys("hari");

                //identify and enter password
                IWebElement password = driver.FindElement(By.Id("Password"));
                password.SendKeys("123123");

                //identify and click login button
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();
            }
            catch(Exception msg)
            {
                Assert.Fail("Test failed at login page",msg.Message);
            }

            wait.ElementExists(driver, "XPath", "//*[@id='logoutForm']/ul/li/a", 2);

            //validate if the user is logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            Assert.That(helloHari.Text,Is.EqualTo("Hello hari!"),"Test failed");

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
