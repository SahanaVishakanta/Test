using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    /*
    * This class contains functions to search a Repeat Invoice by providing following invoice details 
    * Customer name or Reference
    * Next Invoice date 
    * End date of Invoice
    * Any one of the above dates
    *
    * This class can be further extended to perform a search on all invoice(s) i.e., On invoices listed under
    * Draft, Awaiting Approval, Awaiting Payment, Paid filters.
    */
    public class SearchRepeatInvoicePage
    {
        public static void GoTo()
        {
            NavigationMenu.Accounts.Sales.Select();
            Action.WithLinkText.Click("Repeating");

            string searchbuttonPath = "//*[@id='ext-gen46']/span";
            Action.WithXPath.Click(searchbuttonPath);
        }

        public static bool IsSearchSuccessful {
            get
            {
                if (SearchRepeatInvoice.IsSearchConfirmed())
                    return true;
                else
                    return false;
            }
        }

        public static void SearchWithContactOrReference(string searchValue)
        {
            SearchRepeatInvoice.SetContactOrReferenceWithValue(searchValue);
            SearchRepeatInvoice.ExecuteSearch();
        }
        
        public static void SearchWithAnyDate(string startDate, string endDate)
        {
            SearchRepeatInvoice.SetDateOptionFromDropDownWithIndex(1);

            SearchRepeatInvoice.SetDates(startDate, endDate);

            SearchRepeatInvoice.ExecuteSearch();
        }

        public static void SearchWithNextInvoiceDate(string startDate, string endDate)
        {
            SearchRepeatInvoice.SetDateOptionFromDropDownWithIndex(2);

            SearchRepeatInvoice.SetDates(startDate, endDate);

            SearchRepeatInvoice.ExecuteSearch();
        }
        
        public static void SearchWithEndDate(string startDate, string endDate)
        {
            SearchRepeatInvoice.SetDateOptionFromDropDownWithIndex(3);

            SearchRepeatInvoice.SetDates(startDate, endDate);

            SearchRepeatInvoice.ExecuteSearch();
        }

        public static void SearchWithContactOrReferenceAndAnyDate(string name, string stDate, string edDate)
        {
            SearchRepeatInvoice.SetContactOrReferenceWithValue(name);
            SearchRepeatInvoice.SetDateOptionFromDropDownWithIndex(1);
            SearchRepeatInvoice.SetDates(stDate, edDate);
            SearchRepeatInvoice.ExecuteSearch();
        }

        public static void SearchWithContactOrReferenceAndNextInvoiceDate(string name, string stDate, string edDate)
        {
            SearchRepeatInvoice.SetContactOrReferenceWithValue(name);
            SearchRepeatInvoice.SetDateOptionFromDropDownWithIndex(2);
            SearchRepeatInvoice.SetDates(stDate, edDate);
            SearchRepeatInvoice.ExecuteSearch();
        }

        public static void SearchWithContactOrReferenceAndEndDate(string name, string stDate, string edDate)
        {
            SearchRepeatInvoice.SetContactOrReferenceWithValue(name);
            SearchRepeatInvoice.SetDateOptionFromDropDownWithIndex(3);
            SearchRepeatInvoice.SetDates(stDate, edDate);
            SearchRepeatInvoice.ExecuteSearch();
        }
    }
}
