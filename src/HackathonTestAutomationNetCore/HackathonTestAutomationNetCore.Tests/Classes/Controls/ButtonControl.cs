using HackathonTestAutomationNetCore.Tests.Classes.Helpers;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using OpenQA.Selenium;
using System.Linq;

namespace HackathonTestAutomationNetCore.Tests.Classes.Controls
{
    internal class ButtonControl<TFormHelper> : BaseControl<TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        protected ButtonControl(By findBy, TFormHelper formHelper) : base(findBy, formHelper)
        {
        }

        public static ButtonControl<TFormHelper> CreateById(string id, TFormHelper formHelper)
        {
            var buttonControl = new ButtonControl<TFormHelper>(By.Id(id), formHelper);

            return buttonControl;
        }

        public TFormHelper Click(bool switchToLastOpenedWindow = false)
        {
            RetryHelper.Retry(() => 
            {
                try
                {
                    this.WebElement.Click(); return true;
                }
                catch
                {
                    return false;
                }
            });

            if (switchToLastOpenedWindow)
            {
                var windowHandles = WebDriverHelper.Current.WindowHandles;
                var lastWindow = windowHandles.LastOrDefault();
                WebDriverHelper.Current.SwitchTo().Window(lastWindow);
            }

            return this.FormHelper;
        }

        public static ButtonControl<TFormHelper> CreateByXPath(string xPath, TFormHelper formHelper)
        {
            var buttonControl = new ButtonControl<TFormHelper>(By.XPath(xPath), formHelper);

            return buttonControl;
        }

        public TFormHelper GetValue(out string value)
        {
            value = this.WebElement.Text;

            return this.FormHelper;
        }
    }
}