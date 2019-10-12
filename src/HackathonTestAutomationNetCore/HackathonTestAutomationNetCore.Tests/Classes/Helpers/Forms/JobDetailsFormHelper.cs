using HackathonTestAutomationNetCore.Tests.Classes.Controls;
using HackathonTestAutomationNetCore.Tests.Classes.Entities;
using HackathonTestAutomationNetCore.Tests.Enums;

namespace HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms
{
    internal class JobDetailsFormHelper : BaseFormHelper
    {
        #region Properties

        public LabelControl<JobDetailsFormHelper> JobTitle { get; private set; }
        public LabelControl<JobDetailsFormHelper> Country { get; private set; }
        public LabelControl<JobDetailsFormHelper> State { get; private set; }
        public LabelControl<JobDetailsFormHelper> City { get; private set; }
        public LabelControl<JobDetailsFormHelper> Category { get; private set; }
        public LabelControl<JobDetailsFormHelper> RequiredEducation { get; private set; }
        public LabelControl<JobDetailsFormHelper> PositionType { get; private set; }
        public LabelControl<JobDetailsFormHelper> EmploymentType { get; private set; }
        public LabelControl<JobDetailsFormHelper> ContractType { get; private set; }
        public LabelControl<JobDetailsFormHelper> ReqId { get; private set; }
        public ButtonControl<ConnectCommunityFormHelper> ApplyNowButton { get; private set; }

        #endregion Properties
        public JobDetailsFormHelper()
        {
            JobTitle = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/div/div[3]/div[1]/h1");
            Country = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[1]");
            State = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[2]");
            City = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[3]");
            Category = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[4]");
            RequiredEducation = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[5]");
            PositionType = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[6]");
            EmploymentType = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[7]");
            ContractType = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[8]");
            ReqId = LabelControl<JobDetailsFormHelper>.CreateByXPath(formHelper: this, xPath: "/html/body/div[1]/main/div[2]/aside/section/ul/li[9]");
            ApplyNowButton = ButtonControl<ConnectCommunityFormHelper>.CreateByXPath(formHelper: new ConnectCommunityFormHelper(), xPath: "/html/body/div[1]/main/div[2]/aside/div[2]");
        }

        public static JobDetailsFormHelper Open(string jobId)
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

            return jobDetailsFormHelper;
        }
    }
}
