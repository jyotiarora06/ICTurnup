using System;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace icTurnup.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        //page factory design pattern
        IWebElement UserName => driver.FindElement(By.Id("UserName"));
        IWebElement Password => driver.FindElement(By.Id("Password"));
        IWebElement LoginButton => driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
        IWebElement HelloHari => driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
        IWebElement LoginErrorMessage => driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[1]/ul/li"));

        //Create a Constructor
        public LoginPage(IWebDriver driver)
        {
           this.driver = driver;
        }

        public void navigateToLoginPage()
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            //maximize browser
            driver.Manage().Window.Maximize();

            
        }

        public void login(string usernameValue, string passwordValue)
        {
            navigateToLoginPage();
            EnterGivenUserNameAndPassword(null, null);
            ClickLoginButton();
            ValidateLoggedInSuccessfully();
        }

        public void EnterGivenUserNameAndPassword(string usernameValue,string passwordValue)
        {

            try
            {
                wait.ElementExists(driver, "Id", "UserName", 10);
                Console.WriteLine("enterUsername" + usernameValue);

                if(usernameValue != null)
                {
                    //Enter username
                    UserName.SendKeys(usernameValue);
                }
                else
                {
                    //Enter default username
                    UserName.SendKeys("hari");
                }

                Console.WriteLine("enterPassword" + passwordValue);

                if(passwordValue != null)
                {
                    //Enter password
                    Password.SendKeys(passwordValue);
                }
                else
                {
                    //Enter default password
                    Password.SendKeys("123123");
                }
                   
            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed at login page", msg.Message);
            }

        }

        public void ClickLoginButton()
        {
            //Click login button

            LoginButton.Click();
           
        }

        public bool ValidateYouAreAtLoginPage()
        {
            return LoginButton.Displayed;
        }

        public bool ValidateLoggedInSuccessfully()
        {
            wait.ElementExists(driver, "XPath", "//*[@id='logoutForm']/ul/li/a", 10);

            //validate if the user is logged in successfully

            //Assert.That(HelloHari.Text, Is.EqualTo("Hello hari!"), "Test failed");

            if (HelloHari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in successfully, test passed");
                return true;
            }
            else
            {
                Console.WriteLine("Login failed, test failed");
                return false;
            }
        }

        public bool ValidateNotLoggedIn()
        {
            wait.ElementExists(driver, "XPath", "//*[@id='loginForm']/form/div[1]/ul/li", 10);
            return LoginErrorMessage.Displayed;
        }

        
    }
}
