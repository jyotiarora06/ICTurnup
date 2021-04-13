using System;
using System.Threading;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class LoginPage
    {
        public void loginSteps(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            //maximize browser
            driver.Manage().Window.Maximize();

            //identify and enter username
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            //identify and enter password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");
             
            //identify and click login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            Thread.Sleep(500);

            //validate if the user is logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in successfully, test passed");
            }
            else
            {
                Console.WriteLine("Login failed, test failed");
            }
        }
    }
}
