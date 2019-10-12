using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HackathonTestAutomationNetCore.Common.Classes.Helpers
{ 
    /// <summary>
    /// The <c>EnumHelper</c> class is the helper form the <c>Enum</c>
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the enum values
        /// </summary>
        /// <typeparam name="TEnum">The enum type</typeparam>
        /// <returns>The enum values</returns>
        public static Dictionary<TEnum, string> GetValues<TEnum>() where TEnum : struct
        {
            var dictionary = new Dictionary<TEnum, string>();

            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                var description = EnumHelper.GetDescriptionAttributeValue<TEnum>(value);

                dictionary.Add(value, description);
            }

            return dictionary;
        }

        /// <summary>
        /// Gets the description from the description attribute
        /// </summary>
        /// <typeparam name="TEnum">The enum type</typeparam>
        /// <param name="enumValue">The enum value</param>
        /// <returns>The description from the description attribute</returns>
        public static string GetDescriptionAttributeValue<TEnum>(TEnum enumValue)
            where TEnum : struct
        {
            var descriptionAttribute = GetCustomAttributes<TEnum, DescriptionAttribute>(enumValue).FirstOrDefault();

            if (descriptionAttribute == null)
            {
                throw new Exception($"The {typeof(TEnum).ToString()}.{enumValue.ToString()} enum value does not have the DescriptionAttribute attribute.");
            }

            return descriptionAttribute.Description;
        }

        private static TAttribute[] GetCustomAttributes<TEnum, TAttribute>(TEnum enumValue)
            where TEnum : struct
            where TAttribute : Attribute
        {
            var customAttributes = typeof(TEnum).GetMember(enumValue.ToString())
                    .FirstOrDefault()
                    .GetCustomAttributes(typeof(TAttribute), false);

            return (TAttribute[])customAttributes;
        }
    }
}
