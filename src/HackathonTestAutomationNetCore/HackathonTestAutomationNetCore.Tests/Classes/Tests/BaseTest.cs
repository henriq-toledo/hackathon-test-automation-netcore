using HackathonTestAutomationNetCore.Tests.Classes.Helpers;
using NUnit.Framework;

namespace HackathonTestAutomationNetCore.Tests.Classes.Tests
{
    public class BaseTest
    {
        [TearDown]
        public void TearDown()
        {
            WebDriverHelper.Dispose();
        }
    }
}
