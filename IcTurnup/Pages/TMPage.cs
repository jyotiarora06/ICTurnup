using System;
using System.Threading;
using icTurnup.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 30);
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

            wait.ElementExists(driver, "Id", "Code", 2);

            //identify and select time type code
            IWebElement material = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            material.Click();
            IWebElement time = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            time.Click();

            //identify and enter Code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("TimeItemJA");

            //identify and enter Description
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("CreatingTimeItem");


            //identify and enter Price per unit
            IWebElement Price_unit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            Price_unit.Click();

            IWebElement Price = driver.FindElement(By.XPath("//*[@id='Price']"));
            Price.SendKeys("232");

            //identify and click Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 30);


            //identify total items after creating new TM
            String totalCount = driver.FindElement(By.XPath("//*[@data-role='pager']/span[2]")).Text;
            //remove before characters
            totalCount = totalCount.Remove(0, 10);
            //remove after characters
            int pos = totalCount.IndexOf(" ");
            totalCount = totalCount.Substring(0, pos);
            int actualTotalItems = Convert.ToInt32(totalCount);


            //identify and click on Go to Last Page
            IWebElement gotoLastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            gotoLastpage.Click();

            
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

            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement actualTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement actualDesc = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            if (actualCode.Text == "TimeItemJA" && actualTypeCode.Text == "T" && actualDesc.Text == "CreatingTimeItem" && actualPrice.Text == "$232.00")
            {
                Assert.Pass("user is able to create TM successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to create TM, test failed");
            }
        }

        public void EditTM(IWebDriver driver)
        {
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);

            //identify and click on Go to Last Page
            IWebElement gotoLastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            gotoLastpage.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 5);

            //identify and click Edit button
            IWebElement edit = driver.FindElement(By.XPath(" //*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            edit.Click();
            wait.ElementExists(driver, "Id", "Description", 2);

            //edit description
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.Clear();
            description.SendKeys("EditingTimeItem");

            //identify and click Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 20);
            
            //click on Go to Last Page
            IWebElement goto_Lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goto_Lastpage.Click();

            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 40);

            //validate if the user is able to edit TM successfully

            IWebElement editedDesc = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            if (editedDesc.Text == "EditingTimeItem")
            {
                Assert.Pass("user is able to edit TM successfully, test passed");
            }
            else
            {
                Assert.Fail("user is not able to edit TM, test failed");
            }
        }

        public void DeleteTM(IWebDriver driver)
        {
            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);

            //identify total items
            String recordCount = driver.FindElement(By.XPath("//*[@data-role='pager']/span[2]")).Text;
            //remove before characters
            recordCount = recordCount.Remove(0, 10);
            //remove after characters
            int charPos = recordCount.IndexOf(" ");
            recordCount = recordCount.Substring(0,charPos);
            int totalItems = Convert.ToInt32(recordCount);
           

            // identify and click Delete button
            IWebElement delete = driver.FindElement(By.XPath(" //*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            delete.Click();


            //Accept the Alert message 
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();

            wait.ElementExists(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);

            //identify total items after delete
            String totalCount = driver.FindElement(By.XPath("//*[@data-role='pager']/span[2]")).Text;
            //remove before characters
            totalCount = totalCount.Remove(0, 10);
            //remove after characters
            int pos = totalCount.IndexOf(" ");
            totalCount = totalCount.Substring(0,pos);
            int actualTotalItems = Convert.ToInt32(totalCount);


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
