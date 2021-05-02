using System;
using System.Threading;
using icTurnup.Utilities;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class HomePage
    {
        IWebDriver driver;
        IWebElement AdministrationDropdown => driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        IWebElement TimeMaterialsMenuitem => driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        IWebElement CompaniesMenuitem => driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[6]/a"));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAdministrationDropdown()
        {
            //Click Administration dropdown
            AdministrationDropdown.Click();
            wait.ElementExists(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 5);

        }

        public void NavigateToTM()
        {
            //Click Time & Materials menuitem
            TimeMaterialsMenuitem.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='container']/p/a", 5);
        }

        public void NavigateToCompanies()
        {
            //Click Companies menuitem
            CompaniesMenuitem.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='container']/p/a", 5);
        }
    }
}