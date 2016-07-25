using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CoreDataStore.Common.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            string description = value.ToString();

            FieldInfo fieldInfo = value.GetType().GetField(description);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                description = attributes[0].Description;

            return description;
        }

        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use generic type constraints on value types,
            // so have to do check like this

            //if (enumType.BaseType != typeof(Enum))
            //    throw new ArgumentException("T must be of type System.Enum");


            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

        public static IEnumerable<T> GetAttributes<T>(this ICustomAttributeProvider source, bool inherit) where T : Attribute
        {
            var attrs = source.GetCustomAttributes(typeof(T), inherit);

            return (T[])attrs;
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

    }
}
