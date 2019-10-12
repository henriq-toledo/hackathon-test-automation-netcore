using HackathonTestAutomationNetCore.Common.Classes.Attributes;
using HackathonTestAutomationNetCore.Common.Enums;
using HackathonTestAutomationNetCore.Tests.Classes.Defaults;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using NUnit.Framework;

namespace HackathonTestAutomationNetCore.Tests.Classes.Tests
{
    [TestFixture]
    public class JobDetailsTest : BaseTest
    {
        [Test]
        [Defect(PriorityEnum.High, SeverityEnum.Critical, description: "The search should return the 248472BR-PT job id information.")]
        public void JobDetailsShouldBeShown()
        {
            //Arange                  
            var expectedJob = JobResultDefault.InternPortuguese;
            var jobId = expectedJob.JobId;

            // Act
            JobDetailsFormHelper
                .Open(jobId)
                .State.GetValue(out var state)
                .City.GetValue(out var city)
                .JobTitle.GetValue(out var jobTitle)
                .Category.GetValue(out var jobCategory)
                .ReqId.GetValue(out var reqId);

            //Assert
            Assert.AreEqual(expected: expectedJob.StateProvinceCounty, actual: state, 
                message: $"The State '{state}' on the Job Details Form does not match with the value '{expectedJob.StateProvinceCounty}' on Search Job Form.");

            Assert.AreEqual(expected: expectedJob.City, actual: city,
                message: $"The City '{city}' on the Job Details Form does not match with the value '{expectedJob.City}' on Search Job Form.");

            Assert.AreEqual(expected: expectedJob.JobTitle, actual: jobTitle,
                message: $"The Job Title '{jobTitle}' on the Job Details Form does not match with the value '{expectedJob.JobTitle}' on Search Job Form.");

            Assert.AreEqual(expected: expectedJob.JobCategory, actual: jobCategory,
                message: $"The Job Category '{jobCategory}' on the Job Details Form does not match with the value '{expectedJob.JobCategory}' on Search Job Form.");

            Assert.AreEqual(expected: expectedJob.JobId, actual: reqId,
                message: $"The Req ID '{reqId}' on the Job Details Form does not match with the value '{expectedJob.JobId}' on Search Job Form.");
        }
    }
}
