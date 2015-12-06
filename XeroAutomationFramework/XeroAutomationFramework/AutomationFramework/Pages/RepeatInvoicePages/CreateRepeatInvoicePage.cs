using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    /*
    * This class of functions to create a repeating invoice.
    * Includes functions to navigate to create repeating invoice page, 
    * and to check if a repeating invoice is created successfully.
    */

    public class CreateRepeatInvoicePage
    {
        public static bool IsRepeatInvoiceCreated {
            get
            {
                if (Driver.Instance.FindElements(By.Id("ext-gen129")).Any())
                {
                    string confirmationMsg = Driver.Instance.FindElement(By.Id("ext-gen129")).Text;
                    if (confirmationMsg.Contains("Repeating Template Saved."))
                        return true;
                }
                return false;
            }
        }

        public static void GoTo()
        {
            NavigationMenu.Accounts.Sales.Select();
            Action.WithLinkText.Click("Repeating");
            Action.WithLinkText.Click("New Repeating Invoice");
        }

        
        public static void Create()
        {          
            string fileimgId = "ext-gen96";
            string addfromlibraryId = "ext-gen115";
            string filestoaddClassName = "x-grid3-row-checker";
            int filestoaddIndex = 0;
            string addfilebuttonId = "ext-gen134";

            BillingFormItems.AddRelatedFiles(fileimgId, addfromlibraryId, filestoaddClassName, filestoaddIndex, addfilebuttonId);
                
            string timeunitId = "PeriodUnit";  string timeunitValue = "1";
            string timeunitdropdownarrowId = "TimeUnit_toggle";
            string timeunitdropdownoptionsId = "TimeUnit_suggestions";
            string timeunitdropdownTagName = "div";
            int timeunitdropdownIndex = 1;
            BillingFormItems.SetTransactionFrequency(timeunitId, timeunitValue, timeunitdropdownarrowId, timeunitdropdownoptionsId, timeunitdropdownTagName, timeunitdropdownIndex);

            // Set Invoice Date 
            string invoicecalendararrowId = "ext-gen91";
            string invoicecalendarvalueId = "StartDate"; string invoicedateValue = "10 Dec 2015";
            BillingFormItems.SetDate(invoicecalendararrowId, invoicecalendarvalueId, invoicedateValue);
            SearchRepeatInvoice.startDate = invoicedateValue;

            string duedateId = "DueDateDay"; string duedateValue = "1";
            string duedatedropdownarrowId = "DueDateType_toggle";
            string duedatedropdownoptionsId = "DueDateType_suggestions";
            string duedatedropdownTagName = "div";
            int duedatedropdownIndex = 2;
            BillingFormItems.SetDueDateOption(duedateId, duedateValue, duedatedropdownarrowId, duedatedropdownoptionsId, duedatedropdownTagName, duedatedropdownIndex);

            // Set End Date 
            string endcalendararrowId = "ext-gen94";
            string endcalendarvalueId = "EndDate"; string enddateValue = "10 Dec 2015";
            BillingFormItems.SetDate(endcalendararrowId, endcalendarvalueId, enddateValue);
            SearchRepeatInvoice.endDate = enddateValue;

            string draftoptionId = "saveAsDraft";
            BillingFormItems.SetInvoiceStatus(draftoptionId);

            string invoiceId = "PaidToName_";  string invoiceValue = "Garry";
            BillingFormItems.SetToInvoice(invoiceId, invoiceValue);
            SearchRepeatInvoice.contactOrReference = invoiceValue;

            string refId = "Reference_"; string refValue = "Ref-166";
            BillingFormItems.SetReference(refId,refValue);

            string existinginvoicemsgId = "existingBillMessage";
            if (BillingFormItems.DoesElementWithIdExist(existinginvoicemsgId))
                return;

            //To be implemented
            //BillingFormItems.SetCurrencyOption();

            string taxdropdownarrowId = "ext-gen9";
            string taxdropdownoptionsId = "ext-gen103";
            string taxdropdownTagName = "div";
            int taxdropdownIndex = 1;
            BillingFormItems.SetTaxOption(taxdropdownarrowId, taxdropdownoptionsId, taxdropdownTagName, taxdropdownIndex);

            //To be implemented
            //BillingFormItems.AddItemToList();

            string newlineId = "addNewLineItemButton";
            BillingFormItems.AddNewLineToList(newlineId);

            string addnoteId = "historyright";
            string notetextId = "HistoryNote"; string notetextValue = "Test notes";
            string savenoteId = "HistorySaveLink";
            BillingFormItems.AddNotes(addnoteId, notetextId, notetextValue, savenoteId);

            Action.WithXPath.Click(".//*[@id='bodyContainer']/div[2]/div/div[2]/div/span[1]/button");
       }
    }
}
