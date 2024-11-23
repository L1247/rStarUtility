#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace rStarUtility.Util.Extensions.CSharp
{
    public static class EnumExtension
    {
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