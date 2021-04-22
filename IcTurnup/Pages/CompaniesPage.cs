using System;
using System.Threading;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class CompaniesPage
    {
        IWebDriver driver;
        IWebElement CreatenewButton => driver.FindElement(By.XPath("//*[@id='container']/p/a"));
        IWebElement Name => driver.FindElement(By.Id("Name"));
        IWebElement EditContact => driver.FindElement(By.Id("EditContactButton"));
        IWebElement SaveCompany => driver.FindElement(By.Id("SaveButton"));
        IWebElement GotoLastpage => driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]/span"));
        IWebElement ActualName => driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        IWebElement EditButton => driver.FindElement(By.XPath(" //*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
        IWebElement FirstName => driver.FindElement(By.Id("FirstName"));
        IWebElement LastName => driver.FindElement(By.Id("LastName"));
        IWebElement Phone => driver.FindElement(By.Id("Phone"));
        IWebElement SaveContact => driver.FindElement(By.Id("submitButton"));

        public CompaniesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int ItemsCount()
        {
            //identify total items
            String recordCount = driver.FindElement(By.XPath("//*[@data-role='pager']/span[2]")).Text;
            //remove before characters
            recordCount = recordCount.Remove(0, 10);
            //remove after characters
            int charPos = recordCount.IndexOf(" ");
            recordCount = recordCount.Substring(0, charPos);
            int totalItems = Convert.ToInt32(recordCount);
            return totalItems;
        }

        public void CreateCompany()
        {
            wait.ElementExists(driver, "XPath", "//*[@data-role='pager']/span[2]", 10);

            //identify total items before creating company
            int totalItems = ItemsCount();

            //Click Create New button
            CreatenewButton.Click();

            wait.ElementExists(driver, "Id", "Name", 2);

            //Enter Name
            Name.SendKeys("CompanyItemJA");

            //Click Edit Contact button
            EditContact.Click();

            driver.SwitchTo().Frame(0);

            //Enter First Name
            FirstName.SendKeys("Tester");

            //Enter Last Name
            LastName.SendKeys("Tester");

            //identify and enter Phone
            Phone.SendKeys("0203040506");

            //identify and click Save Contact button
            SaveContact.Click();

            driver.SwitchTo().DefaultContent();

            //Click Save Company button
            SaveCompany.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[4]/ul/li[1]/span", 10);

            //identify total items after creating company
            int actualTotalItems = ItemsCount();

            //Click on Go to Last Page
            GotoLastpage.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 10);

            //validate if the user is able to create Company successfully
            if (actualTotalItems == totalItems + 1)
            {
                Assert.Pass("user is able to create company successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to create company, test failed");
            }

            if (ActualName.Text == "CompanyItemJA")
            {
                Assert.Pass("user is able to create Company successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to create Company, test failed");
            }
        }

        public void EditCompany()
        {
            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[4]/a[4]/span", 10);

            //Click on Go to Last Page
            GotoLastpage.Click();

            //Click Edit button
            EditButton.Click();
            wait.ElementExists(driver, "Id", "Name", 2);

            //Edit name
            Name.Clear();
            Name.SendKeys("EditingCompanyItem");

            //Click Save Company button
            SaveCompany.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[4]/ul/li[1]/span", 2);

            //click on Go to Last Page
            GotoLastpage.Click();

            //validate if the user is able to edit Company successfully
            
            if (ActualName.Text == "EditingCompanyItem")
            {
                Assert.Pass("user is able to edit company successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to edit company, test failed");
            }
        }
    }
}
