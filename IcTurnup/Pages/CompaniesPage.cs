using System;
using System.Threading;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class CompaniesPage
    {
        private IWebDriver driver;
        private int totalItemsCount;
        private int actualTotalItemsCount;

        //Page factory design pattern
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
        IWebElement ManageButton => driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[2]/a"));
        IWebElement RecordCount => driver.FindElement(By.XPath("//*[@data-role='pager']/span[2]"));

        //Create a Constructor
        public CompaniesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int IdentifyTheTotalItemsCount()
        {
            wait.ElementExists(driver, "XPath", "//*[@data-role='pager']/span[2]", 30);
            //identify total items count
            string recordCountText = RecordCount.Text;
            //remove before characters
            recordCountText = recordCountText.Remove(0, 10);
            //remove after characters
            int charPos = recordCountText.IndexOf(" ");
            recordCountText = recordCountText.Substring(0, charPos);
            int totalItems = Convert.ToInt32(recordCountText);
            return totalItems;
        }

        public bool ValidateAtCompaniesPage()
        {
            return ManageButton.Displayed;
        }

        public void ClickCreateNewButton()
        {
            totalItemsCount = IdentifyTheTotalItemsCount();

           //Click Create New button
            CreatenewButton.Click();

            wait.ElementExists(driver, "Id", "Name", 2);
        }


        public void EnterName(string name)
        {
            //Enter Name

            if(name == null)
            {
                Name.SendKeys("CompanyItemAddTest");
            }
            else
            {
                Name.SendKeys(name);
            }

        }

        public void ClickEditContactButton()
        {
            //Click Edit Contact button
            EditContact.Click();

            driver.SwitchTo().Frame(0);
        }

        public void EnterFirstName(string firstName)

        { 
            //Enter First Name

            if(firstName == null)
            {
                FirstName.SendKeys("Tester");
            }
            else
            {
                FirstName.SendKeys(firstName);
            }
         }

        public void EnterLastName(string lastName)
        {
            //Enter Last Name
            if (lastName == null)
            {
                LastName.SendKeys("Tester");
            }
            else
            {
                LastName.SendKeys(lastName);
            }
        }

        public void EnterPhone()
        {
            Phone.SendKeys("0203040506");
        }

        public void ClickSaveContactButton()
        { 
            //identify and click Save Contact button
            SaveContact.Click();

            driver.SwitchTo().DefaultContent();
        }

        public void ClickSaveCompanyButton()
        {
            //Click Save Company button
            SaveCompany.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[4]/ul/li[1]/span", 10);

            actualTotalItemsCount = IdentifyTheTotalItemsCount();

        }

        public void ClickLastPage()
        {

            //Click on Go to Last Page
            GotoLastpage.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 10);
        }


        public bool ValidateTheCompanyIsCreated()
        {

            //validate if the user is able to create Company successfully
            if (actualTotalItemsCount == totalItemsCount + 1 && ActualName.Text == "CompanyItemAddTest")
            {
                //Assert.Pass("user is able to create company successfully, test passed");
                return true;
            }
            else
            {
                //Assert.Fail("user is not able to create company, test failed");
                return false;
            }
        }

        public void ClickEditButton()
        {
            //Click Edit button
            EditButton.Click();
            wait.ElementExists(driver, "Id", "Name", 2);

        }

        public void EditName(string name)
        {
            //Edit name
            Name.Clear();

            if(name == null)
            {
                Name.SendKeys("CompanyItemEditTest");
            }
            else
            {
                Name.SendKeys("name");
            }
        }

        public bool ValidateTheCompanyIsEdited()
        {

            //validate if the user is able to edit Company successfully
            
            if (ActualName.Text == "CompanyItemEditTest")
            {
                //Assert.Pass("user is able to edit company successfully, test passed");
                return true;
            }
            else
            {
                //Assert.Fail("user is not able to edit company, test failed");
                return false;
            }
        }
    }
}
