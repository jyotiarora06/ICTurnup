using System;
using System.Threading;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class TMPage
    {
        IWebDriver driver;
        IWebElement CreateNewButton => driver.FindElement(By.XPath("//*[@id='container']/p/a"));
        IWebElement MaterialTypeCode => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
        IWebElement TimeTypeCode => driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
        IWebElement Code => driver.FindElement(By.Id("Code"));
        IWebElement Description => driver.FindElement(By.Id("Description"));
        IWebElement SelectPricetextbox => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
        IWebElement Price => driver.FindElement(By.XPath("//*[@id='Price']"));
        IWebElement SaveButton => driver.FindElement(By.Id("SaveButton"));
        IWebElement GotoLastpage => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
        IWebElement actualCode => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        IWebElement actualTypeCode => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
        IWebElement actualDesc => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
        IWebElement actualPrice => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
        IWebElement EditButton => driver.FindElement(By.XPath(" //*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        IWebElement DeleteButton => driver.FindElement(By.XPath(" //*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));


        public TMPage(IWebDriver driver)
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

        public void CreateTM()
        {
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 30);

            //Total items before creating TM
            int totalItems = ItemsCount();

            //Click Create New button
            CreateNewButton.Click();
            wait.ElementExists(driver, "Id", "Code", 2);

            //Select time type code
            MaterialTypeCode.Click();
            TimeTypeCode.Click();

            //Enter Code
            Code.SendKeys("TimeItemJA");

            //Enter Description
            Description.SendKeys("CreatingTimeItem");

            //Enter Price per unit
            SelectPricetextbox.Click();
            Price.SendKeys("232");

            //Click Save button
            SaveButton.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 30);


            //Total items after creating TM
            int actualTotalItems = ItemsCount();


            //Click on Go to Last Page
            GotoLastpage.Click();
            wait.ElementExists(driver,"XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);

            //validate if the user is able to create TM successfully
            if (actualTotalItems == totalItems + 1)
            {
               Assert.Pass("user is able to create TM successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to create TM, test failed");
            }

            if (actualCode.Text == "TimeItemJA" && actualTypeCode.Text == "T" && actualDesc.Text == "CreatingTimeItem" && actualPrice.Text == "$232.00")
            {
                Assert.Pass("user is able to create TM successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to create TM, test failed");
            }
        }

        public void EditTM()
        {
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);

            //Click on Go to Last Page
            GotoLastpage.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 5);

            //Click Edit button
            EditButton.Click();
            wait.ElementExists(driver, "Id", "Description", 2);

            //Edit description
            Description.Clear();
            Description.SendKeys("EditingTimeItem");

            //Click Save button
            SaveButton.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 20);

            //click on Go to Last Page
            GotoLastpage.Click();
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 40);

            //validate if the user is able to edit TM successfully
            if (actualDesc.Text == "EditingTimeItem")
            {
                Assert.Pass("user is able to edit TM successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to edit TM, test failed");
            }
        }

        public void DeleteTM()
        {
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);

            //total items before deleting 
            int totalItems = ItemsCount();


            // Click Delete button
            DeleteButton.Click();


            //Accept the Alert message 
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);

            //total items after delete
            int actualTotalItems = ItemsCount();

            //validate if the user is able to delete TM successfully
            if (actualTotalItems == totalItems - 1)
            {
                 Assert.Pass("user is able to delete TM successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to delete TM, test failed");
            }
        }

    }
}
