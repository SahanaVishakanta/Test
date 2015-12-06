using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    public class MenuSelector
    {
        public static void Select(string topMenuItem, string subMenuItem)
        {
            Driver.Instance.FindElement(By.Id(topMenuItem)).Click();
            Driver.Instance.FindElement(By.LinkText(subMenuItem)).Click();
            Driver.Wait(10000);
        }
    }
}
