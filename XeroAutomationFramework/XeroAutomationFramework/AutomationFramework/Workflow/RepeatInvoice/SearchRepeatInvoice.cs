using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    public class SearchRepeatInvoice
    {
        public static string contactOrReference;
        public static string startDate;
        public static string endDate;

        public static bool DoesInvoiceExist(string Id)
        {
            return BillingFormItems.DoesElementWithIdExist(Id);
        }

        public static void SetDateOptionFromDropDownWithIndex(int dateoptionIndex)
        {
            string searchdateoptionId = "sb_drpWithin_toggle";
            string searchdatevaluePath = "//*[@id='sb_drpWithin_suggestions']/div/div[" + dateoptionIndex + "]";
            
            Action.WithId.Click(searchdateoptionId);
            Action.WithXPath.Click(searchdatevaluePath);
        }

        public static void SetContactOrReferenceWithValue(string searchValue)
        {
            string searchnameId = "sb_txtReference";
            Action.WithId.SetTextValue(searchnameId, searchValue);
            SearchRepeatInvoice.contactOrReference = searchValue;
        }

        public static bool IsSearchConfirmed()
        {
            int colCount = 0;
            bool successFlag = false;
            string messageId = "ext-gen47";

            if (SearchRepeatInvoice.DoesInvoiceExist(messageId))
            {
                var topCls = Driver.Instance.FindElement(By.Id(messageId));
                IList<IWebElement> rows = topCls.FindElements(By.XPath("//tr[starts-with(@id,'ext-gen')]"));
                BulkActionPage.invoiceCount = rows.Count;

                foreach (IWebElement row in rows)
                {
                    string contact_value = null;

                    IList<IWebElement> columns = row.FindElements(By.TagName("td"));
                    foreach (IWebElement cell in columns)
                    {
                        successFlag = true;
                        colCount++;
                        if (colCount == 2 || colCount == 3 || colCount == 7 || colCount == 8)
                        {
                            switch (colCount)
                            {
                                case 2:
                                    if (SearchRepeatInvoice.contactOrReference != null)
                                        if (!(cell.Text == SearchRepeatInvoice.contactOrReference))
                                            contact_value = cell.Text;
                                    break;

                                case 3:
                                    if (SearchRepeatInvoice.contactOrReference != null)
                                        if (!(cell.Text == SearchRepeatInvoice.contactOrReference))
                                            if (!(cell.Text == contact_value) && contact_value != null)
                                                successFlag = false;
                                    break;

                                case 7:
                                    if (SearchRepeatInvoice.startDate != null)
                                        if (!(DateRangeChecker.IsDateInRange(startDate, endDate, cell.Text)))
                                            successFlag = false;
                                    break;
                                case 8:
                                    if (SearchRepeatInvoice.endDate != null)
                                        if (!(DateRangeChecker.IsDateInRange(startDate, endDate, cell.Text)))
                                            successFlag = false;
                                    break;

                                default:
                                    break;
                            }
                            if (successFlag == false)
                                return successFlag;
                        }
                    }
                    colCount = 0;
                }
            }
            return successFlag;
        }

        public static void ExecuteSearch()
        {
            string submitsearchId = "sbSubmit_";
            string clearsearchPath = ".//*[@id='sbContainer_']/div[5]/label/a";
            string closesearchPath = ".//*[@id='sbContainer_']/a[1]";

            Driver.Wait(1000);
            Action.WithId.Click(submitsearchId);
            Action.WithXPath.Click(clearsearchPath);
            Action.WithXPath.Click(closesearchPath);
        }

        public static void SetDates(string startDate, string endDate)
        {
            /* Set start date */
            string startdatearrowId = "ext-gen16";
            string startdatevalueId = "sb_dteStartDate";

            Action.WithId.Click(startdatearrowId);
            Action.WithId.SetTextValue(startdatevalueId, startDate);

            //DatePicker.SelectDateFromCalendar("ext-gen150");
            SearchRepeatInvoice.startDate = startDate;

            /* Set end date */
            string enddatearrowId = "ext-gen22";
            string enddatevalueId = "sb_dteEndDate";

            Action.WithId.Click(enddatearrowId);
            Action.WithId.SetTextValue(enddatevalueId, endDate);

            //DatePicker.SelectDateFromCalendar("ext-gen162");
            SearchRepeatInvoice.endDate = endDate;
        }
    }
}
