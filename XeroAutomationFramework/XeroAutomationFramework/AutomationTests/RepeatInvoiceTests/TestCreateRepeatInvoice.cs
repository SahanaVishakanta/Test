using NUnit.Framework;
using System;

namespace XeroAutomationFramework
{
    [TestFixture]
    public class TestCreateRepeatInvoice
    {
        [Test]
        public static void Test_Create_RepeatInvoice_AsDraft()
        {
            CreateRepeatInvoicePage.GoTo();

            CreateRepeatInvoicePage.Create();
            Assert.IsTrue(CreateRepeatInvoicePage.IsRepeatInvoiceCreated, "Repeat Invoice creation unsuccessful, check if the invoice already exists");
        }
    }
}
