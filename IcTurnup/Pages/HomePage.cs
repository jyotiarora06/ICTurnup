using System;
using System.Threading;
using icTurnup.Utilities;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class HomePage
    {
        public void NavigateToTM(IWebDriver driver)
        {
            //identify and click Administration dropdown
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();

            wait.ElementExists(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 5);
            //Thread.Sleep(500);

            //identify and click Time & Materials menuitem
            IWebElement timematerialsMenuitem = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timematerialsMenuitem.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='container']/p/a", 5);
        }

        public void NavigateToCompanies(IWebDriver driver)
        {
            //identify and click Administration dropdown
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();

            wait.ElementExists(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[6]/a", 5);


            //identify and click Companies menuitem
            IWebElement companiesMenuitem = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[6]/a"));
            companiesMenuitem.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='container']/p/a", 5);
        }
    }
}