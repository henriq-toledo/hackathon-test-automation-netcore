using System.ComponentModel;

namespace HackathonTestAutomationNetCore.Tests.Enums
{
    internal enum JobCategoryEnum
    {
        [Description("Job Category")]
        None,

        [Description("Architect")]
        Architect,

        [Description("Consultant")]
        Consultant,

        [Description("Data Science")]
        DataScience,

        [Description("Enterprise Operations")]
        EnterpriseOperations,

        [Description("Finance")]
        Finance,

        [Description("Hardware Development & Support")]
        HardwareDevelopment,

        [Description("Human Resources")]
        HumanResources,
        [Description("Information Technology & Services")]
        InformationTechnology,

        [Description("Legal")]
        Legal,

        [Description("Manufacturing")]
        Manufacturing,

        [Description("Marketing & Communications")]
        MarketingCommunications,

        [Description("Product Services")]
        ProductServices,

        [Description("Project Executive")]
        ProjectExecutive,

        [Description("Project Management")]
        ProjectManagement,

        [Description("Research")]
        LegalResearch,

        [Description("Sales")]
        Sales,

        [Description("Service Solutions Management")]
        ServiceSolutionsManagement,

        [Description("Software Development & Support")]
        SoftwareDevelopment,

        [Description("Supplay Chain")]
        SupplyChain,

        [Description("Technical Specialist")]
        TechnicalSpecialist,

        [Description("Other")]
        Other
    }
}
