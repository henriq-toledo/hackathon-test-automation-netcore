using HackathonTestAutomationNetCore.Tests.Classes.Helpers;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using OpenQA.Selenium;

namespace HackathonTestAutomationNetCore.Tests.Classes.Controls
{
    internal abstract class BaseControl<TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        protected By FindBy { get; private set; }

        protected IWebElement WebElement
        {
            get
            {
                IWebElement webElement;

                try
                {
                    webElement = WebDriverHelper.Current.FindElement(FindBy);
                }
                catch (NoSuchElementException)
                {
                    webElement = null;
                }

                return webElement;
            }
        }

        protected TFormHelper FormHelper { get; private set; }

        protected bool IsElementPresent => this.WebElement == null == false;

        public BaseControl(By findBy, TFormHelper formHelper)
        {
            this.FindBy = findBy;
            this.FormHelper = formHelper;
        }
    }
}