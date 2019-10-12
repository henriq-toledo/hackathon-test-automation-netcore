using System.ComponentModel;

namespace HackathonTestAutomationNetCore.Tests.Classes.Entities
{
    internal class JobResult : BaseEntity
    {
        [Description("Job Title")]
        public string JobTitle { get; set; }

        [Description("Job Category")]
        public string JobCategory { get; set; }

        [Description("State / Province / County")]
        public string StateProvinceCounty { get; set; }
        
        [Description("City")]
        public string City { get; set; }

        [Description("Job ID")]
        public string JobId { get; set; }

        [Description("Language")]
        public string Language { get; set; }
    }
}
