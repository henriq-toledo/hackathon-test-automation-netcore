using HackathonTestAutomationNetCore.Tests.Classes.Helpers;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using OpenQA.Selenium;

namespace HackathonTestAutomationNetCore.Tests.Classes.Controls
{
    internal class StringInputControl<TFormHelper> : BaseInputControl<string, TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        protected StringInputControl(By findBy, TFormHelper formHelper) : base(findBy, formHelper)
        {
        }

        protected override string Value
        {
            get
            {
                return this.WebElement.Text;
            }
            set
            {
                this.WebElement.SendKeys(value);
            }
        }

        public TFormHelper GetError(out string error)
        {
            IWebElement errorElement;

            var webElementId = this.WebElement.GetAttribute("id");

            try
            {
                errorElement = WebDriverHelper.Current.FindElement(By.Id(webElementId + "-error"));
            }
            catch
            {
                errorElement = null;
            }
                        
            error = errorElement?.Text;

            return this.FormHelper;
        }

        public static StringInputControl<TFormHelper> CreateById(string id, TFormHelper formHelper)
        {
            var stringInputControl = new StringInputControl<TFormHelper>(By.Id(id), formHelper);

            return stringInputControl;
        }

        public static StringInputControl<TFormHelper> CreateByXPath(string xPath, TFormHelper formHelper) => new StringInputControl<TFormHelper>(By.XPath(xPath), formHelper);
    }
}