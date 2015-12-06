using NUnit.Framework;

namespace XeroAutomationFramework
{
    [SetUpFixture]
    public class XeroBaseClass
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialise();

            LoginPage.GoTo();
            LoginPage.LoginAs("sana.mysore@gmail.com", "welcome123");
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
