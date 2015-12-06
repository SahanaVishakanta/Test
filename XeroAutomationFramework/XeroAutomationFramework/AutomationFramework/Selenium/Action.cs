using System;
using OpenQA.Selenium;

namespace XeroAutomationFramework
{
    /*
    * This class consists of functions to perform driver level activities such as find elements on 
    * various widget available.
    * The nested class are organized based on the web element information available on the webpage. 
    * example, Individual class for elements which has Id, ClassName, XPath
    * And also to provide readymade functions to set values for dropdown list, table list, calendar etc
    */

    public class Action
    {
        public class WithId
        {
            public static void Click(string id)
            {
                Driver.Instance.FindElement(By.Id(id)).Click();
            }

            public static void SetTextValue(string id, string value)
            {
                var textValueCls = Driver.Instance.FindElement(By.Id(id));
                textValueCls.Clear();
                textValueCls.SendKeys(value);
            }

            public static void SetDropDownValue(string dropDownArrowId, string dropDownValueId, string tagName, int tagIndex)
            {
                Driver.Instance.FindElement(By.Id(dropDownArrowId)).Click();
                var dropdownValueCls = Driver.Instance.FindElement(By.Id(dropDownValueId));
                dropdownValueCls.FindElements(By.TagName(tagName))[tagIndex].Click();
            }
        }

        public class WithClassName
        {
            public static void ClickCheckBox(string className, int index)
            {
                Driver.Instance.FindElements(By.ClassName(className))[index].Click();
            }
        }

        public class WithLinkText
        {
            public static void Click(string linkText)
            {
                Driver.Instance.FindElement(By.LinkText(linkText)).Click();
            }
        }

        public class WithXPath
        {
            public static void SetTextValueWhichStartsWith(string id, string value)
            {
                var textValueCls = Driver.Instance.FindElements(By.XPath("//*[starts-with(@name,'" + id + "')]"))[0];
                textValueCls.Clear();
                textValueCls.SendKeys(value);
            }

            public static void Click(string path)
            {
                Driver.Instance.FindElement(By.XPath(path)).Click();
            }
        }
    }
}