using System;
using System.Threading;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class TMPage
    {
        private IWebDriver driver;
        private CompaniesPage companiesPageObj;
        private int totalItemsCount;
        private int actualTotalItemsCount;

        IWebElement CreateNewButton => driver.FindElement(By.XPath("//*[@id='container']/p/a"));
        IWebElement MaterialTypeCode => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
        IWebElement TimeTypeCode => driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
        IWebElement Code => driver.FindElement(By.Id("Code"));
        IWebElement Description => driver.FindElement(By.Id("Description"));
        IWebElement SelectPricetextbox => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
        IWebElement Price => driver.FindElement(By.XPath("//*[@id='Price']"));
        IWebElement SaveButton => driver.FindElement(By.Id("SaveButton"));
        IWebElement GotoLastpage => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
        IWebElement ActualCode => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        IWebElement ActualTypeCode => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
        IWebElement ActualDesc => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
        IWebElement ActualPrice => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
        IWebElement EditButton => driver.FindElement(By.XPath(" //*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        IWebElement DeleteButton => driver.FindElement(By.XPath(" //*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        
       
        public TMPage(IWebDriver driver)
        {
            this.driver = driver;
            companiesPageObj = new CompaniesPage(driver);
        }

        public bool ValidateAtTMPage()
        {
            return CreateNewButton.Displayed;
        }

        public void ClickCreateNew()
        {
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 30);

            //identify total items before creating TM

            totalItemsCount = companiesPageObj.IdentifyTheTotalItemsCount();


            //Click Create New button
            CreateNewButton.Click();
            wait.ElementExists(driver, "Id", "Code", 2);
        }

        public void SelectTimeTypeCode()
        {
            //Select time type code
            MaterialTypeCode.Click();
            TimeTypeCode.Click();
        }

        public void EnterCode(string code)
        {
            //Enter Code
            if(code == null)
            { 
                Code.SendKeys("TimeItemJA");
            }
            else
            {
                Code.SendKeys(code);
            }
        }

        public void EnterDescription(string description)
        {
            //Enter Description
           
            if (description == null)
            {
                Description.SendKeys("CreatingTimeItem");
            }
            else
            {
                Description.SendKeys(null);
            }
        }

        public void EnterPrice()
        {
            //Enter Price per unit
            SelectPricetextbox.Click();
            Price.SendKeys("232");

        }

        public void ClickSave()
        {
            // Click Save button
            SaveButton.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 30);


            //Total items after creating TM
            actualTotalItemsCount = companiesPageObj.IdentifyTheTotalItemsCount();
        }

        public void ClickLastPage()
        {

            //Click on Go to Last Page
            GotoLastpage.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);
        }

        public bool ValidateTMIsCreated()
        {

            //validate if the user is able to create TM successfully
            if (actualTotalItemsCount == totalItemsCount + 1 && ActualCode.Text == "TimeItemJA" && ActualTypeCode.Text == "T" && ActualDesc.Text == "CreatingTimeItem" && ActualPrice.Text == "$232.00")
            {
                //Assert.Pass("user is able to create TM successfully, test passed");
                return true;
            }
            else
            {
                //Assert.Fail("user is not able to create TM, test failed");
                return false;
            }
        }

        public void ClickEdit()
        {
            //Click Edit button
            EditButton.Click();
            wait.ElementExists(driver, "Id", "Description", 2);
        }

        public void EditDescription(string description)
        {
            //Edit description
            Description.Clear();
            if(description == null)
            { 
            Description.SendKeys("EditingTimeItem");
            }
            else
            {
                Description.SendKeys(null);
            }
        }

        public bool ValidateTMIsEdited()
        {
            //validate if the user is able to edit TM successfully
            if (ActualDesc.Text == "EditingTimeItem")
            {
                //Assert.Pass("user is able to edit TM successfully, test passed");
                return true;
            }
            else
            {
                //Assert.Fail("user is not able to edit TM, test failed");
                return false;
            }
        }

        public void ClickDelete()
        {
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 30);

            //identify total items before creating TM

            totalItemsCount = companiesPageObj.IdentifyTheTotalItemsCount();

            // Click Delete button
            DeleteButton.Click();

        }

        public void ClickOkButton()
        {
            //Accept the Alert message 
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 30);

            //total items after delete
            actualTotalItemsCount = companiesPageObj.IdentifyTheTotalItemsCount();
        }

        public bool ValidateTMIsDeleted()
        {    //validate if the user is able to delete TM successfully
            if (actualTotalItemsCount == totalItemsCount - 1)
            {
                //Assert.Pass("user is able to delete TM successfully, test passed");
                return true;
            }
            else
            {
                //Assert.Fail("user is not able to delete TM, test failed");
                return false;

            }
        }

    }
}
