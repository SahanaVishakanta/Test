using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace XeroAutomationFramework
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.XeroURL);
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "email");
        }

        public static void LoginAs(string username, string password)
        {
            Driver.Instance.FindElement(By.Id("email")).SendKeys(username);
            Driver.Instance.FindElement(By.Id("password")).SendKeys(password);

            Driver.Instance.FindElement(By.Id("submitButton")).Submit();
        }
    }
}