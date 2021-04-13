using System;
using System.Threading;
using OpenQA.Selenium;

namespace icTurnup.Pages
{
    public class TMPage
    {
        public void createTM(IWebDriver driver)
        {
            //identify and click Create New button
            IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnewButton.Click();

            Thread.Sleep(500);

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

            Thread.Sleep(500);

            //identify and click on Go to Last Page
            IWebElement gotoLastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            Thread.Sleep(500);
            gotoLastpage.Click();

            //validate if the user is able to create TM successfully
            IWebElement itemCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement itemTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement itemDesc = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement itemPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            if (itemCode.Text == "TimeItemJA" && itemTypeCode.Text == "T" && itemDesc.Text == "CreatingTimeItem" && itemPrice.Text == "$232.00")
            {
                Console.WriteLine("user is able to create TM successfully, test passed");
            }
            else
            {
                Console.WriteLine("user is not able to create TM, test failed");
            }
        }

        public void editTM(IWebDriver driver)
        {
            // identify and click Edit button
            IWebElement edit = driver.FindElement(By.XPath(" //*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            edit.Click();

            Thread.Sleep(500);
            IWebElement desc = driver.FindElement(By.Id("Description"));
            desc.Clear();
            desc.SendKeys("EditingTimeItem");

            IWebElement save_Button = driver.FindElement(By.Id("SaveButton"));
            save_Button.Click();
            Thread.Sleep(500);

            //identify and click on Go to Last Page
            IWebElement goto_Lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            Thread.Sleep(500);
            goto_Lastpage.Click();

            //validate if the user is able to edit TM successfully

            IWebElement editDesc = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            if (editDesc.Text == "EditingTimeItem")
            {
                Console.WriteLine("user is able to edit TM successfully, test passed");
            }
            else
            {
                Console.WriteLine("user is not able to edit TM, test failed");
            }

        }

        public void deleteTM(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // identify and click Delete button
            IWebElement delete = driver.FindElement(By.XPath(" //*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            delete.Click();


            //Accept the Alert message 
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();

            Thread.Sleep(2000);

            //validate if the user is able to delete TM successfully

            IWebElement delCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement delDesc = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement delPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));


            if (delCode.Text != "TimeItemJA" && delDesc.Text != "EditingTimeItem" && delPrice.Text != "$232.00")
            {
                Console.WriteLine("user is able to delete TM successfully, test passed");
            }
            else
            {
                Console.WriteLine("user is not able to delete TM, test failed");
            }
            
        }

    }
}
