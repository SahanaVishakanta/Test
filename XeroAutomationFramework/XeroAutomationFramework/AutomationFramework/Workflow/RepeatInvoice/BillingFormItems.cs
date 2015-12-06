using System;
using OpenQA.Selenium;
using System.Linq;

namespace XeroAutomationFramework
{
    /*
    * This class contains list of commonly used Items/functions in the following scenarios
    * Creating New Invoice
    * Creating New Repeating Invoice
    * Creating New Credit Note
    * This class can be extended to include all the common actions/functions across the whole webpage
    */
    public class BillingFormItems
    {
        public static void SetToInvoice(string id, string value)
        {
            Action.WithXPath.SetTextValueWhichStartsWith(id, value);
        }

        public static void AddRelatedFiles(string fileImgId, string addFromLibraryId, string filesToAddClassName, int filesToAddIndex, string addFileButtonId)
        {
            Action.WithId.Click(fileImgId);
            Action.WithId.Click(addFromLibraryId);
            Action.WithClassName.ClickCheckBox(filesToAddClassName, filesToAddIndex);
            Action.WithId.Click(addFileButtonId);
        }

        public static void SelectAllItemsFromTableWithId(string checkboxId)
        {
            Action.WithId.Click(checkboxId);
        }

        public static bool DoesElementWithClassNameExist(string msgClassName)
        {
            return Driver.Instance.FindElements(By.ClassName(msgClassName)).Any();
        }

        public static void SetTransactionFrequency(string timeUnitId, string timeUnitValue, string timeUnitDropDownArrowId, string timeUnitDropDownValuesId, string timeUnitDropDownTagName, int timeUnitDropDownIndex)
        {
            Action.WithId.SetTextValue(timeUnitId, timeUnitValue);
            Action.WithId.SetDropDownValue(timeUnitDropDownArrowId, timeUnitDropDownValuesId, timeUnitDropDownTagName, timeUnitDropDownIndex);
        }

        public static void SetDueDateOption(string duedateId, string duedateValue, string duedatedropdownarrowId, string duedatedropdownvaluesId, string duedatedropdownTagName, int duedatedropdownIndex)
        {
            Action.WithId.SetTextValue(duedateId, duedateValue);
            Action.WithId.SetDropDownValue(duedatedropdownarrowId, duedatedropdownvaluesId, duedatedropdownTagName, duedatedropdownIndex);
        }

        internal static void SetDate(string calendararrowId, string calendardatevalueId, string calendarValue)
        {
            Action.WithId.Click(calendararrowId);
            Action.WithId.SetTextValue(calendardatevalueId, calendarValue);
        }

        public static void SetInvoiceStatus(string draftoptionId)
        {
            Action.WithId.Click(draftoptionId);
        }

        public static void SetReference(string refId, string refValue)
        {
            Action.WithXPath.SetTextValueWhichStartsWith(refId, refValue);
        }

        public static void SetTaxOption(string taxdropdownarrowId, string taxdropdownoptionsId, string taxdropdownTagName, int taxdropdownIndex)
        {
            Action.WithId.SetDropDownValue(taxdropdownarrowId, taxdropdownoptionsId, taxdropdownTagName, taxdropdownIndex);
        }

        public static void AddNewLineToList(string newlineId)
        {
            Action.WithId.Click(newlineId);
        }

        public static void AddNotes(string addnoteId, string notetextId, string notetextValue, string savenoteId)
        {
            Action.WithId.Click(addnoteId);
            Action.WithId.SetTextValue(notetextId, notetextValue);
            Action.WithId.Click(savenoteId);
        }

        public static bool DoesElementWithIdExist(string id)
        {
            return Driver.Instance.FindElements(By.Id(id)).Any();
        }
    }
}