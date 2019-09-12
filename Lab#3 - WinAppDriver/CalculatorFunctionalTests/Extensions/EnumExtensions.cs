using System;
using System.Linq;
using System.Reflection;
using AccessibilityIdAttribute = System.ComponentModel.DescriptionAttribute;

namespace CalculatorFunctionalTests.Extensions
{
    public static class EnumExtensions
    {
        public static string GetAccessibilityId<TEnum>(this TEnum e) where TEnum:Enum
        {
            var attribute =
                e.GetType()
                    .GetTypeInfo()
                    .GetMember(e.ToString())
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                    .GetCustomAttributes(typeof(AccessibilityIdAttribute), false)
                    .SingleOrDefault()
                    as AccessibilityIdAttribute;

            return attribute?.Description ?? e.ToString();
        }
    }
}
