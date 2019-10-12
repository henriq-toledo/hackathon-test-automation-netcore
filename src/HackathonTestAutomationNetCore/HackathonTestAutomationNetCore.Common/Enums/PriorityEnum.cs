using HackathonTestAutomationNetCore.Common.Classes.Helpers;
using System.ComponentModel;

namespace HackathonTestAutomationNetCore.Common.Enums
{
    /// <summary>
    /// The <c>PriorityEnum</c> enum represents the priority of a defect
    /// </summary>
    public enum PriorityEnum
    {
        /// <summary>
        /// 1 - High
        /// </summary>
        [Description("1 - High")]
        High = 1,

        /// <summary>
        /// 2 - Medium
        /// </summary>
        [Description("2 - Medium")]
        Medium = 2,

        /// <summary>
        /// 3 - Low
        /// </summary>
        [Description("3 - Low")]
        Low = 3
    }

    /// <summary>
    /// The <c>PriorityEnumExtension</c> class is the extension class from the <c>PriorityEnum</c> enum
    /// </summary>
    public static class PriorityEnumExtension
    {
        /// <summary>
        /// Gets the enum value description
        /// </summary>
        /// <param name="priority">The priority</param>
        /// <returns>The enum value description</returns>
        public static string GetDescription(this PriorityEnum priority)
        {
            return EnumHelper.GetDescriptionAttributeValue(priority);
        }
    }
}
