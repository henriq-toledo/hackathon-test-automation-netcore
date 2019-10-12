using HackathonTestAutomationNetCore.Tests.Classes.Entities;

namespace HackathonTestAutomationNetCore.Tests.Classes.Defaults
{
    internal static class JobResultDefault
    {
        public static JobResult InternPortuguese => new JobResult()
        {
            JobTitle = "Estágio em TI: Programa Build to Plan - BTP 2019",
            JobCategory = "Other",
            StateProvinceCounty = "ANY",
            City = "Multiple Cities",
            JobId = "248472BR-PT",
            Language = "Portuguese"
        };

        public static JobResult InternEnglish => new JobResult()
        {
            JobTitle = "Estágio em TI: Programa Build to Plan - BTP 2019",
            JobCategory = "Other",
            StateProvinceCounty = "ANY",
            City = "Multiple Cities",
            JobId = "248472BR",
            Language = "English"
        };

        public static JobResult InternInclusivePortuguese => new JobResult()
        {
            JobTitle = "Estágio inclusivo em TI: Programa Build to Plan - BTP 2019",
            JobCategory = "Other",
            StateProvinceCounty = "ANY",
            City = "Multiple Cities",
            JobId = "233687BR-PT",
            Language = "Portuguese"
        };

        public static JobResult InternInclusiveEnglish => new JobResult()
        {
            JobTitle = "Estágio inclusivo em TI: Programa Build to Plan - BTP 2019",
            JobCategory = "Other",
            StateProvinceCounty = "ANY",
            City = "Multiple Cities",
            JobId = "233687BR",
            Language = "English"
        };
    }
}
