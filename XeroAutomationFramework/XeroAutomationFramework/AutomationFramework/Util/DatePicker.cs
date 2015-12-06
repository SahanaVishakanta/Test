using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace XeroAutomationFramework
{
    /*
    * This class consists of functions to pick a date from calendar widget.
    */
    public class DatePicker
    {
        public static void SelectDateFromCalendar(string calenderId)
        {
            Random r = new Random();
            int randomDate = r.Next(1, 28);
            Console.WriteLine("Random date : " + randomDate);

            var dateWidget = Driver.Instance.FindElement(By.Id(calenderId));
            var tblCls = dateWidget.FindElement(By.ClassName("x-date-inner"));
            IList<IWebElement> rows = tblCls.FindElements(By.TagName("tr"));

            foreach (IWebElement row in rows)
            {
                IList<IWebElement> columns = row.FindElements(By.TagName("td"));
                foreach (IWebElement cell in columns)
                {
                    int cellValue = int.Parse(cell.Text);
                    if (cellValue.Equals(randomDate))
                    {
                        cell.Click();
                        break;
                    }
                }
            }
        }
    }
}