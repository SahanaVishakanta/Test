using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    /*
    * This NUnit test class checks the following bulk actions on invoices
    * Save Invoice As Draft
    * Approve Invoice
    * Approve Invoice to Send
    * Delete Invoice
    *
    * In order to perform any bulk action, it is necessary to filter(search) invoice. Invoice can be search based on
    * Contact name or Reference
    * Next Invoice Date
    * End Date
    * Or Any Date
    *
    * Testcase are designed for each bulk action with every search option available
    */


    [TestFixture]
    public class TestBulkActionOnInvoice
    {
        [TestCase("Sana")]
        public static void Test_SaveAsDraft_InvoiceFilteredOnContactOrReference(string searchValue)
        {
            SearchRepeatInvoicePage.GoTo();
            SearchRepeatInvoicePage.SearchWithContactOrReference(searchValue);
            
            if(SearchRepeatInvoicePage.IsSearchSuccessful)
            {
                BulkActionPage.SaveInvoiceAsDraft();
                Assert.IsTrue(BulkActionPage.IsBulkActionSuccessful, "Save invoice as draft was not succcessful");
            }
            else
                Assert.Fail("No invoice found");
        }

        [TestCase("23 Nov 2014", "10 Dec 2015")]
        public static void Test_Approve_InvoiceFilteredOnNextInvoiceDate(string startDate, string endDate)
        {
            SearchRepeatInvoicePage.GoTo();
            SearchRepeatInvoicePage.SearchWithNextInvoiceDate(startDate, endDate);
            if (SearchRepeatInvoicePage.IsSearchSuccessful)
            {
                BulkActionPage.ApproveInvoice();
                Assert.IsTrue(BulkActionPage.IsBulkActionSuccessful, "Approve invoice was not successful");
            }
            else
                Assert.Fail("No invoice found");
        }


        [TestCase("23 Nov 2016", "10 Dec 2018")]
        public static void Test_ApproveToSend_InvoiceFilteredOnAnyDate(string startDate, string endDate)
        {
            SearchRepeatInvoicePage.GoTo();
            SearchRepeatInvoicePage.SearchWithAnyDate(startDate, endDate);
            if (SearchRepeatInvoicePage.IsSearchSuccessful)
            {
                BulkActionPage.ApproveInvoiceToSend();
                Assert.IsTrue(BulkActionPage.IsBulkActionSuccessful, "Approve for sending invoice was not successful");
            }
            else
                Assert.Fail("No invoice found");
        }

        [TestCase("23 Nov 2014", "10 Dec 2018")]
        public static void Test_Delete_InvoiceFilteredOnEndDate(string startDate, string endDate)
        {
            SearchRepeatInvoicePage.GoTo();
            SearchRepeatInvoicePage.SearchWithEndDate(startDate, endDate);
            if (SearchRepeatInvoicePage.IsSearchSuccessful)
            {
                BulkActionPage.DeleteInvoice();
                Assert.IsTrue(BulkActionPage.IsBulkActionSuccessful, "Delete invoice was not successful");
            }
            else
                Assert.Fail("No invoice found");
        }

    }
}
