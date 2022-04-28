#region

using System.Collections.Generic;

#endregion

namespace AutoBot.Utilities.Extensions
{
    public static class ListExtension
    {
    #region Public Variables

        public static void AddIfNotContains<T>(this List<T> list , T t)
        {
            if (list.Contains(t) == false) list.Add(t);
        }

    #endregion
    }
}