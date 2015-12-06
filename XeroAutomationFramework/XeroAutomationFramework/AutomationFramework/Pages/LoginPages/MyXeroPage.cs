using OpenQA.Selenium;

namespace XeroAutomationFramework
{
    public class MyXeroPage
    {
        public static bool IsAt
        {
            get
            {
                //Refractor: create a generic IsAt for all pages 
                var tags = Driver.Instance.FindElements(By.TagName("h2"));
                if (tags.Count > 0)
                    return tags[0].Text == "Awesome Pvt Ltd";
                return false;
            }
        }
    }
}