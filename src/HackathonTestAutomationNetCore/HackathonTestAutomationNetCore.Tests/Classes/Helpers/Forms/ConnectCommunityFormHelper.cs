using HackathonTestAutomationNetCore.Tests.Classes.Controls;
using HackathonTestAutomationNetCore.Tests.Classes.Entities;
using HackathonTestAutomationNetCore.Tests.Enums;

namespace HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms
{
    internal class ConnectCommunityFormHelper : BaseFormHelper
    {
        #region Properties

        public StringInputControl<ConnectCommunityFormHelper> FirstName { get; set; }
        public StringInputControl<ConnectCommunityFormHelper> LastName { get; set; }
        public StringInputControl<ConnectCommunityFormHelper> PrimaryEmail { get; set; }
        public ButtonControl<ConnectCommunityFormHelper> ConnectAndApply { get; set; }

        #endregion Properties

        public ConnectCommunityFormHelper()
        {
            this.FirstName = StringInputControl<ConnectCommunityFormHelper>.CreateByXPath(xPath: "/html/body/form/div[5]/div/div/table/tbody/tr[2]/td[2]/div/div[3]/div/div/div[1]/table/tbody/tr[1]/td[2]/input", formHelper: this);
            this.LastName = StringInputControl<ConnectCommunityFormHelper>.CreateByXPath(xPath: "/html/body/form/div[5]/div/div/table/tbody/tr[2]/td[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[2]/input", formHelper: this);
            this.PrimaryEmail = StringInputControl<ConnectCommunityFormHelper>.CreateByXPath(xPath: "/html/body/form/div[5]/div/div/table/tbody/tr[2]/td[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[2]/input", formHelper: this);
            this.ConnectAndApply = ButtonControl<ConnectCommunityFormHelper>.CreateById(id: "formCtrl_cmd0", formHelper: this);
        }

        public static ConnectCommunityFormHelper Open(string jobId)
        {
            var jobs = new JobResult[] { };

            SearchJobFormHelper
              .Open()
              .ExperienceLevel.SetValue(ExperienceLevelEnum.None)
              .JobCategory.SetValue(JobCategoryEnum.None)
              .JobCountry.SetValue(JobCountryEnum.None)
              .KeyWordSearch.SetValue(jobId)
              .SearchButton.Click()
              .JobResults.GetValue(out jobs);

            var job = jobs[0];
            var jobDetailsFormHelper = job.ClickOnLink();

            var connectComunnityFormHelper = jobDetailsFormHelper.ApplyNowButton.Click(switchToLastOpenedWindow: true);

            return connectComunnityFormHelper;
        }
    }
}
