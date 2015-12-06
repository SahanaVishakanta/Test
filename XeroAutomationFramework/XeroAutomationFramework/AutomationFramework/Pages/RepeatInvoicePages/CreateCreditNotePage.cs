using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    /*
   * This class consists of functions to test creating New Credit Note
   * It is designed to demonstrate that most of the form items required to create a new credit note is the same as those required to create bill or invoice
   */

    public class CreateCreditNotePage
    {
        public static void Create()
        {
            string fileimgId = "ext-gen48";
            string addfromlibraryId = "ext-gen66";
            string filestoaddClassName = "x-grid3-hd-checker";
            int filestoaddIndex = 0;
            string addfilebuttonId = "ext-gen85";

            BillingFormItems.AddRelatedFiles(fileimgId, addfromlibraryId, filestoaddClassName, filestoaddIndex, addfilebuttonId);

            string invoicecalendararrowId = "ext-gen91";
            string invoicecalendarvalueId = "StartDate"; string invoicedateValue = "10 Dec 2015";
            BillingFormItems.SetDate(invoicecalendararrowId, invoicecalendarvalueId, invoicedateValue);
            

            string invoiceId = "PaidToName_"; string invoiceValue = "Sana";
            BillingFormItems.SetToInvoice(invoiceId, invoiceValue);
            

            string refId = "Reference_"; string refValue = "Ref-156";
            BillingFormItems.SetReference(refId, refValue);

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

            Action.WithLinkText.Click("Approve");
        }
    }
}
