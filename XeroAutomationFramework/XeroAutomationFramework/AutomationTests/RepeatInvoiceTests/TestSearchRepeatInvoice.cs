using NUnit.Framework;

namespace XeroAutomationFramework.AutomationTests
{
    [TestFixture]
    public class TestSearchRepeatInvoice
    {
        [TestCase("Sana")]
        [TestCase("Sana1")]
        [TestCase("Ref-123")]
        [TestCase("No Ref")]
        public static void Test_Search_RepeatInvoice_By_ContactOrReference(string searchValue)
        {
            SearchRepeatInvoicePage.GoTo();

            SearchRepeatInvoicePage.SearchWithContactOrReference(searchValue);

            Assert.IsTrue(SearchRepeatInvoicePage.IsSearchSuccessful, "No Invoices found for the above user");
        }

        [TestCase("23 Nov 2015", "10 Dec 2016")]
        [TestCase("12 Dec 2012", "3 Feb 2013")]
        public static void Test_Search_RepeatInvoice_By_AnyDate(string startDate, string endDate)
        {
            SearchRepeatInvoicePage.GoTo();

            SearchRepeatInvoicePage.SearchWithAnyDate(startDate, endDate);

            Assert.IsTrue(SearchRepeatInvoicePage.IsSearchSuccessful, "No Invoice found in the above date range");
        }

        [TestCase("23 Nov 2015", "10 Dec 2016")]
        [TestCase("12 Dec 2012", "3 Feb 2013")]
        public static void Test_Search_RepeatInvoice_By_NextInvoiceDate(string startDate, string endDate)
        {
            SearchRepeatInvoicePage.GoTo();

            SearchRepeatInvoicePage.SearchWithNextInvoiceDate(startDate, endDate);

            Assert.IsTrue(SearchRepeatInvoicePage.IsSearchSuccessful, "No Invoice found in the above date range");
        }

        [TestCase("23 Nov 2015", "10 Dec 2016")]
        [TestCase("12 Dec 2012", "3 Feb 2013")]
        public static void Test_Search_RepeatInvoice_By_EndDate(string startDate, string endDate)
        {
            SearchRepeatInvoicePage.GoTo();

            SearchRepeatInvoicePage.SearchWithEndDate(startDate, endDate);

            Assert.IsTrue(SearchRepeatInvoicePage.IsSearchSuccessful, "No Invoice found in the above date range");
        }
    }
}
