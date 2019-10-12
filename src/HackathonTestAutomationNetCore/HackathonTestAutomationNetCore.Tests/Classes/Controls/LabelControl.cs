using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using HackathonTestAutomationNetCore.Tests.Interfaces;
using OpenQA.Selenium;

namespace HackathonTestAutomationNetCore.Tests.Classes.Controls
{
    internal class LabelControl<TFormHelper> : BaseControl<TFormHelper>, IGetter<string, TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        protected LabelControl(By findBy, TFormHelper formHelper) : base(findBy, formHelper)
        {
        }

        public static LabelControl<TFormHelper> CreateByXPath(string xPath, TFormHelper formHelper)
        {
            var labelControl = new LabelControl<TFormHelper>(By.XPath(xPath), formHelper);

            return labelControl;
        }

        public TFormHelper GetValue(out string value)
        {
            var spanText = this.GetSpanText();
            value = this.WebElement.Text;

            if (spanText != null)
            {
                value = value.Replace(spanText, string.Empty);
            }

            return this.FormHelper;
        }

        private string GetSpanText()
        {
            IWebElement span;

            try
            {
                span = this.WebElement.FindElement(By.TagName("span"));
            }
            catch (NoSuchElementException)
            {
                span = null;
            }

            return span?.Text;
        }
    }
}