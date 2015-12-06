using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace XeroAutomationFramework
{
    /*
    * This class consists of functions to perform driver level actions and kernel level actions.
    */
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string XeroURL
        {
            get { return "https://login.xero.com/"; }
        }

        public static void Initialise()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(int millisecTimeout)
        {
            Thread.Sleep(millisecTimeout);
        }
    }
}