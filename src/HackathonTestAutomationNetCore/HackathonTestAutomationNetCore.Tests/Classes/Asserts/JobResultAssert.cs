using HackathonTestAutomationNetCore.Tests.Classes.Entities;
using NUnit.Framework;

namespace HackathonTestAutomationNetCore.Tests.Classes.Asserts
{
    internal static class JobResultAssert
    {
        public static void AssertJobResult(JobResult[] expectedJobs, JobResult[] actualJobs)
        {
            Assert.AreEqual(expected: expectedJobs.Length, actual: actualJobs.Length,
                message: $"The returned jobs should be {expectedJobs.Length} but returned {actualJobs.Length}.");

            for (int i = 0; i < expectedJobs.Length; i++)
            {
                var expectedJob = expectedJobs[i];
                var actualJob = actualJobs[i];

                AssertJobResult(expected: expectedJob, actual: actualJob);
            }
        }

        public static void AssertJobResult(JobResult expected, JobResult actual)
        {
            AssertJobResultProperty(propertyName: nameof(expected.JobTitle), expected: expected.JobTitle, actual: actual.JobTitle);
            AssertJobResultProperty(propertyName: nameof(expected.JobCategory), expected: expected.JobCategory, actual: actual.JobCategory);
            AssertJobResultProperty(propertyName: nameof(expected.StateProvinceCounty), expected: expected.StateProvinceCounty, actual: actual.StateProvinceCounty);
            AssertJobResultProperty(propertyName: nameof(expected.City), expected: expected.City, actual: actual.City);
            AssertJobResultProperty(propertyName: nameof(expected.JobId), expected: expected.JobId, actual: actual.JobId);
            AssertJobResultProperty(propertyName: nameof(expected.Language), expected: expected.Language, actual: actual.Language);
        }

        private static void AssertJobResultProperty(string propertyName, string expected, string actual)
        {
            Assert.AreEqual(expected, actual, $"The '{propertyName}' should be '{expected}' and not '{actual}'.");
        }
    }
}
