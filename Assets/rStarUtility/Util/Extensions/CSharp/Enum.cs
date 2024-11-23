#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace rStarUtility.Util.Extensions.CSharp
{
    public static class EnumExtension
    {
    #region Public Methods

        public static List<T> GetValues<T>(this T obj) where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

    #endregion
    }
}