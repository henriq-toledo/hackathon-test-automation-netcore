using OpenQA.Selenium;

namespace HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms
{
    internal abstract class BaseFormHelper
    {
        protected IWebDriver webDriver;

        public BaseFormHelper()
        {
            this.webDriver = WebDriverHelper.Current;
        }
    }
}
