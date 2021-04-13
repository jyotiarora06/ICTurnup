using System;
using System.Threading;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class HomePage
    {
        public void navigateToTM(IWebDriver driver)
        {
            //identify and click Administration dropdown
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();

            Thread.Sleep(500);

            //identify and click Time & Materials menuitem
            IWebElement timematerialsMenuitem = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timematerialsMenuitem.Click();  
        }
    }
}