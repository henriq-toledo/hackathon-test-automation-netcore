using HackathonTestAutomationNetCore.Tests.Classes.Controls;
using HackathonTestAutomationNetCore.Tests.Classes.Entities;
using HackathonTestAutomationNetCore.Tests.Classes.Settings;
using HackathonTestAutomationNetCore.Tests.Enums;

namespace HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms
{
    internal class SearchJobFormHelper : BaseFormHelper
    {
        #region Properties

        public ComboInputControl<ExperienceLevelEnum, SearchJobFormHelper> ExperienceLevel { get; private set; }

        public ComboInputControl<JobCategoryEnum, SearchJobFormHelper> JobCategory { get; private set; }

        public ComboInputControl<JobCountryEnum, SearchJobFormHelper> JobCountry { get; private set; }

        public StringInputControl<SearchJobFormHelper> KeyWordSearch { get; private set; }

        public ButtonControl<SearchJobFormHelper> SearchButton { get; private set; }

        public GridControl<JobResult, SearchJobFormHelper> JobResults { get; private set; }

        public LabelControl<SearchJobFormHelper> NoJobsMessage { get; private set; }

        #endregion Properties

        public SearchJobFormHelper()
        {
            ExperienceLevel = ComboInputControl<ExperienceLevelEnum, SearchJobFormHelper>.CreateById(formHelper: this, id: "Experience-Level");
            JobCategory = ComboInputControl<JobCategoryEnum, SearchJobFormHelper>.CreateById(formHelper: this, id: "Job-Category");
            JobCountry = ComboInputControl<JobCountryEnum, SearchJobFormHelper>.CreateById(formHelper: this, id: "Job-Country");
            KeyWordSearch = StringInputControl<SearchJobFormHelper>.CreateById(formHelper: this, id: "keyword-search");
            SearchButton = ButtonControl<SearchJobFormHelper>.CreateById(formHelper: this, id: "btnSearch");
            JobResults = GridControl<JobResult, SearchJobFormHelper>.CreateByXPath(xPath: "/html/body/div[1]/main/div[2]/table", formHelper: this);
            NoJobsMessage = LabelControl<SearchJobFormHelper>.CreateByXPath(xPath: "/html/body/div[1]/main/p", formHelper: this);
        }

        internal static SearchJobFormHelper Open()
        {
            WebDriverHelper.Current.Navigate().GoToUrl(TestSettings.Current.CareersURL);

            return new SearchJobFormHelper();
        }

    }
}