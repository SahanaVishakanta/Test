using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    /*
    * This class consists of functions to test bulk actions available on Repeating Invoice Page. The different bulk actions are
    * Save as Draft
    * Approve 
    * Approve for sending
    * Delete
    * This class can be extended to include various other bulk action options available 
    * All, Draft, Awaiting Approval & Payment, Paid Invoice filters.
    */

    public class BulkActionPage
    {
        public static int invoiceCount;
        public static string bulkactionType;

        public static void GoTo()
        {
            NavigationMenu.Accounts.Sales.Select();
            Action.WithLinkText.Click("Repeating");
        }

        public static bool IsBulkActionSuccessful
        {
            get
            {
                string msgClassName = "message";
                bool statusFlag = false;
                if (BillingFormItems.DoesElementWithClassNameExist(msgClassName))
                {
                    string confirmationMsg = Driver.Instance.FindElement(By.ClassName(msgClassName)).Text;
                    switch(bulkactionType)
                    {
                        case "Draft":
                            if ((confirmationMsg.Contains(invoiceCount+" repeating transaction saved as draft")) || (confirmationMsg.Contains(invoiceCount + " repeating transactions saved as draft")))
                                statusFlag = true;
                            break;

                        case "Approved":
                            if((confirmationMsg.Contains(invoiceCount + " repeating transaction approved")) || (confirmationMsg.Contains(invoiceCount + " repeating transactions approved")))
                                statusFlag = true;
                        break;

                        case "ApprovedToSend":
                       if ((confirmationMsg.Contains(invoiceCount + " invoice have been approved for sending")) || (confirmationMsg.Contains(invoiceCount + " invoices have been approved for sending")))
                                    statusFlag = true;
                        break;

                        case "Delete":
                            if((confirmationMsg.Contains(invoiceCount + " repeating transaction deleted")) || (confirmationMsg.Contains(invoiceCount + " repeating transactions deleted")))
                                statusFlag = true;
                            break;

                        default:
                            statusFlag = false;
                        break;
                    }
                }
                return statusFlag;
            }
        }

        public static void SaveInvoiceAsDraft()
        {
            bulkactionType = "Draft";

            var topCls = Driver.Instance.FindElement(By.Id("ext-gen47"));
            topCls.FindElement(By.XPath(".//*[starts-with(@id,'ext-gen')]")).Click();   //Check all the invoice(s) listed from above search

            Action.WithXPath.Click("//*[@id='ext-gen37']/a/span");                      //Click on SaveAsDraft option 

            Action.WithXPath.Click(".//*[@id='__popupSpin']/div[2]/div/div/div/div/div/div[2]/div[2]/a/span");
        }

        public static void ApproveInvoice()
        {
            bulkactionType = "Approved";

            var topCls = Driver.Instance.FindElement(By.Id("ext-gen47"));
            topCls.FindElement(By.XPath(".//*[starts-with(@id,'ext-gen')]")).Click();   //Check all the invoice(s) listed from above search

            Action.WithXPath.Click("//*[@id='ext-gen40']/a/span");                      //Click on Save as Draft option 

            Action.WithXPath.Click(".//*[@id='__popupSpin']/div[2]/div/div/div/div/div/div[2]/div[2]/a/span");
        }

        public static void ApproveInvoiceToSend()
        {
            bulkactionType = "ApprovedToSend";

            var topCls = Driver.Instance.FindElement(By.Id("ext-gen47"));
            topCls.FindElement(By.XPath(".//*[starts-with(@id,'ext-gen')]")).Click();   //Check all the invoice(s) listed from above search

            Action.WithXPath.Click("//*[@id='ext-gen42']/span");                        //Click on Approved For Sending option 

            Action.WithId.SetTextValue("MessageSubject", "Test invoice mail, subject");
            Action.WithId.SetTextValue("MessageTextBody", "Test invoice mail, body");
            Action.WithId.Click("popupSend");
            Action.WithId.Click("popupSend");
        }

        public static void DeleteInvoice()
        {
            bulkactionType = "Delete";

            var topCls = Driver.Instance.FindElement(By.Id("ext-gen47"));
            topCls.FindElement(By.XPath(".//*[starts-with(@id,'ext-gen')]")).Click();   //Check all the invoice(s) listed from above search

            Action.WithXPath.Click("//*[@id='ext-gen44']/a/span");                      //Click on Delete option 

            Action.WithXPath.Click(".//*[@id='__popupSpin']/div[2]/div/div/div/div/div/div[2]/div[2]/a/span");
        }
        
    }
}
