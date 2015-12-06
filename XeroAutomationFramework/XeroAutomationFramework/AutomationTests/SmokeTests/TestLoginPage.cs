using NUnit.Framework;

namespace XeroAutomationFramework
{
    [TestFixture]
    public class TestLoginPage
    {
        [Test]
        public void Test_Login_To_Xero()
        {
            Assert.IsTrue(MyXeroPage.IsAt, "Failed to Login");
        }
    }
}
