using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HackathonTestAutomationNetCore.Tests.Classes.Extensions
{
    internal static class TypeExtension
    {
        internal static Dictionary<string, string> GetPropertiesDescriptionValues(this Type type)
        {
            var columns = new Dictionary<string, string>();

            foreach (var property in type.GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)attributes[0]).Description;

                columns.Add(property.Name, description);
            }

            return columns;
        }
    }
}
