using HackathonTestAutomationNetCore.Tests.Classes.Helpers;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;

namespace HackathonTestAutomationNetCore.Tests.Classes.Entities
{
    internal class BaseEntity
    {
        protected string Link { get; set; }

        public JobDetailsFormHelper ClickOnLink()
        {
            WebDriverHelper.Current.Navigate().GoToUrl(this.Link);

            return new JobDetailsFormHelper();
        }

        public void SetLink(string link)
        {
            this.Link = link;
        }
    }
}
