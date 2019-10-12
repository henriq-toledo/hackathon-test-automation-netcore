using HackathonTestAutomationNetCore.Common.Classes.Attributes;
using HackathonTestAutomationNetCore.Common.Enums;
using HackathonTestAutomationNetCore.Tests.Classes.Asserts;
using HackathonTestAutomationNetCore.Tests.Classes.Defaults;
using HackathonTestAutomationNetCore.Tests.Classes.Entities;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using HackathonTestAutomationNetCore.Tests.Enums;
using NUnit.Framework;

namespace HackathonTestAutomationNetCore.Tests.Classes.Tests
{
    [TestFixture]
    public class SearchJobTest : BaseTest
    {
        [Test]
        [Defect(PriorityEnum.High, SeverityEnum.Critical, description: "The search should return the 248472BR-PT job id information.")]
        public void JobShouldBeShown()
        {
            // Arrange           
            var expectedJob = JobResultDefault.InternPortuguese;
            
            // Act
            SearchJobFormHelper
                .Open()
                .ExperienceLevel.SetValue(ExperienceLevelEnum.Intern)
                .JobCategory.SetValue(JobCategoryEnum.Other)
                .JobCountry.SetValue(JobCountryEnum.Brazil)
                .KeyWordSearch.SetValue(expectedJob.JobId)
                .SearchButton.Click()
                .JobResults.GetValue(out var jobs);

            var actualJob = jobs[0];

            // Assert
            Assert.AreEqual(expected: 1, actual: jobs.Length,
                message: $"The return job should be one but returned {jobs.Length}.");

            JobResultAssert.AssertJobResult(expected: expectedJob, actual: actualJob);
        }

        [Test]
        [Defect(PriorityEnum.High, SeverityEnum.Critical, description: "The search should return all the BTPs jobs to Brazil.")]
        public void AllSearchedJobsShouldBeFound()
        {
            // Arrange
            var expectedJobs = new JobResult[]
            {
                JobResultDefault.InternInclusivePortuguese,
                JobResultDefault.InternPortuguese,
                JobResultDefault.InternInclusiveEnglish,
                JobResultDefault.InternEnglish                
            };

            // Act
            SearchJobFormHelper
                .Open()
                .ExperienceLevel.SetValue(ExperienceLevelEnum.Intern)
                .JobCategory.SetValue(JobCategoryEnum.Other)
                .JobCountry.SetValue(JobCountryEnum.Brazil)
                .KeyWordSearch.SetValue("btp")
                .SearchButton.Click()
                .JobResults.GetValue(out var actualJobs);

            // Assert
            JobResultAssert.AssertJobResult(expectedJobs, actualJobs);
        }

        [Test]
        [Defect(PriorityEnum.Medium, SeverityEnum.Major, description: "The invalid job id should not be found.")]
        public void JobShouldNotBeFound()
        {
            // Arrange
            var jobs = new JobResult[] { };
            var invalidJobId = "000000BR-PT";
            string actualNoJobMessage;
            var expectedNoJobMessage = "There are no jobs available with this search criteria. Please click here to begin a new search.";

            // Act
            SearchJobFormHelper
                .Open()
                .ExperienceLevel.SetValue(ExperienceLevelEnum.None)
                .JobCategory.SetValue(JobCategoryEnum.None)
                .JobCountry.SetValue(JobCountryEnum.None)
                .KeyWordSearch.SetValue(invalidJobId)
                .SearchButton.Click()
                .JobResults.GetValue(out jobs)
                .NoJobsMessage.GetValue(out actualNoJobMessage);

            // Assert
            Assert.AreEqual(expected: 0, actual: jobs.Length,
                message: $"The return job should be one but returned {jobs.Length}.");

            Assert.AreEqual(expected: expectedNoJobMessage, actual: actualNoJobMessage, 
                message: $"When there is no jobs the message '{expectedNoJobMessage}' should be shown.");
        }
    }
}
