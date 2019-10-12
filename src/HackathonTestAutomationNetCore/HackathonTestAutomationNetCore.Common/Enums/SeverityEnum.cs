using HackathonTestAutomationNetCore.Common.Classes.Helpers;
using System.ComponentModel;

namespace HackathonTestAutomationNetCore.Common.Enums
{
    public enum SeverityEnum
    {
        /// <summary>
        /// 1 - Critical
        /// </summary>
        [Description("1 - Critical")]
        Critical = 1,

        /// <summary>
        /// 2 - Major
        /// </summary>
        [Description("2 - Major")]
        Major = 2,

        /// <summary>
        /// 3 - Moderate
        /// </summary>
        [Description("3 - Moderate")]
        Moderate = 3,

        /// <summary>
        /// 4 - Minor
        /// </summary>
        [Description("4 - Minor")]
        Minor = 4
    }

    public static class SeverityEnumExtension
    {
        public static string GetDescription(this SeverityEnum severity)
        {
            return EnumHelper.GetDescriptionAttributeValue(severity);
        }
    }
}
