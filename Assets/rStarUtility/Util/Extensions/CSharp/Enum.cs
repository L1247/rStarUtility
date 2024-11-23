#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

#endregion

namespace rStarUtility.Util.Extensions.CSharp
{
    /// <summary>
    ///     https://stackoverflow.com/questions/15388072/how-to-add-extension-methods-to-enums
    /// </summary>
    public static class EnumExtension
    {
    #region Public Methods

        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return string.Empty;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }

    #endregion

    #region Nested Types

        public class Enum<T> where T : struct , IConvertible
        {
        #region Public Variables

            public static int Count
            {
                get
                {
                    if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
                    return Enum.GetNames(typeof(T)).Length;
                }
            }

        #endregion

        #region Public Methods

            public static List<T> GetValues()
            {
                if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
                return Enum.GetValues(typeof(T)).Cast<T>().ToList();
            }

        #endregion
        }

    #endregion
    }
}