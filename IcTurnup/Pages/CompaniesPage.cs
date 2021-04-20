using System;
using System.Threading;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class CompaniesPage
    {
        public void CreateCompany(IWebDriver driver)
        {
            wait.ElementExists(driver, "XPath", "//*[@data-role='pager']/span[2]", 10);
            //identify total items
            String recordCount = driver.FindElement(By.XPath("//*[@data-role='pager']/span[2]")).Text;

            //remove before characters
            recordCount = recordCount.Remove(0, 10);
            //remove after characters
            int charPos = recordCount.IndexOf(" ");
            recordCount = recordCount.Substring(0, charPos);
            int totalItems = Convert.ToInt32(recordCount);

            //identify and click Create New button
            IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnewButton.Click();

            wait.ElementExists(driver, "Id", "Name", 2);

            //identify and enter Name
            IWebElement name = driver.FindElement(By.Id("Name"));
            name.SendKeys("CompanyItemJA");

            //identify and click Edit Contact button
            IWebElement editContact = driver.FindElement(By.Id("EditContactButton"));
            editContact.Click();

            driver.SwitchTo().Frame(0);

            //identify and enter First Name
            IWebElement firstName = driver.FindElement(By.Id("FirstName"));
            firstName.SendKeys("Tester");

            //identify and enter Last Name
            IWebElement lastName = driver.FindElement(By.Id("LastName"));
            lastName.SendKeys("Tester");

            //identify and enter Phone
            IWebElement phone = driver.FindElement(By.Id("Phone"));
            phone.SendKeys("0203040506");

            //identify and click Save Contact button
            IWebElement saveContact = driver.FindElement(By.Id("submitButton"));
            saveContact.Click();

            driver.SwitchTo().DefaultContent();

            //identify and click Save Company button
            IWebElement saveCompany = driver.FindElement(By.Id("SaveButton"));
            saveCompany.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[4]/ul/li[1]/span", 10);

            //identify total items after creating new company
            String totalCount = driver.FindElement(By.XPath("//*[@data-role='pager']/span[2]")).Text;

            //remove before characters
            totalCount = totalCount.Remove(0, 10);
            //remove after characters
            int pos = totalCount.IndexOf(" ");
            totalCount = totalCount.Substring(0, pos);
            int actualTotalItems = Convert.ToInt32(totalCount);

            //identify and click on Go to Last Page
            IWebElement gotoLastpage = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]/span"));          
            gotoLastpage.Click();
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

            IWebElement actualName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (actualName.Text == "CompanyItemJA")
            {
                Assert.Pass("user is able to create Company successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to create Company, test failed");
            }
        }

        public void EditCompany(IWebDriver driver)
        {
            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[4]/a[4]/span", 10);
            //identify and click on Go to Last Page
            IWebElement gotoLastpage = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]/span"));
            gotoLastpage.Click();

            //identify and click Edit button
            IWebElement edit = driver.FindElement(By.XPath(" //*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            edit.Click();

            wait.ElementExists(driver, "Id", "Name", 2);
            //edit name
            IWebElement name = driver.FindElement(By.Id("Name"));
            name.Clear();
            name.SendKeys("EditingCompanyItem");

            //identify and click Save Company button
            IWebElement saveCompany = driver.FindElement(By.Id("SaveButton"));
            saveCompany.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[4]/ul/li[1]/span", 2);

            //click on Go to Last Page
            IWebElement goto_Lastpage = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]/span"));
            goto_Lastpage.Click();

            //validate if the user is able to edit TM successfully

            IWebElement editedName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if (editedName.Text == "EditingCompanyItem")
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
