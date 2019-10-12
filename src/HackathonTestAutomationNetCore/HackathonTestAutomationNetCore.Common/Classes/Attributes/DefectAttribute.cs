using HackathonTestAutomationNetCore.Common.Enums;
using System;

namespace HackathonTestAutomationNetCore.Common.Classes.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DefectAttribute : Attribute
    {
        public PriorityEnum Priority { get; private set; }
        public SeverityEnum Severity { get; private set; }
        public string Description { get; private set; }
        public string[] Steps { get; private set; }

        public DefectAttribute (PriorityEnum priority, SeverityEnum severity, string description = "", params string [] steps)
        {
            this.Priority = priority;
            this.Severity = severity;
            this.Description = description;
            this.Steps = steps;
        }
    }
}
