using HackathonTestAutomationNetCore.Common.Classes.Helpers;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using OpenQA.Selenium;
using System.Linq;

namespace HackathonTestAutomationNetCore.Tests.Classes.Controls
{
    internal class ComboInputControl<TEnum, TFormHelper> : BaseInputControl<TEnum, TFormHelper>
        where TEnum : struct
        where TFormHelper : BaseFormHelper
    {
        protected ComboInputControl(By findBy, TFormHelper formHelper) : base(findBy, formHelper)
        {
        }

        protected override TEnum Value
        {
            get
            {
                var description = this.WebElement.Text;
                return EnumHelper.GetValues<TEnum>().FirstOrDefault(e => e.Value == description).Key;
            }
            set
            {
                var description = EnumHelper.GetDescriptionAttributeValue<TEnum>(value);
                var option = this.WebElement.FindElements(By.TagName("option")).FirstOrDefault(e => e.Text == description);
                option.Click();
            }
        }

        public static ComboInputControl<TEnum, TFormHelper> CreateById(string id, TFormHelper formHelper)
        {
            var stringInputControl = new ComboInputControl<TEnum, TFormHelper>(By.Id(id), formHelper);

            return stringInputControl;
        }
    }
}