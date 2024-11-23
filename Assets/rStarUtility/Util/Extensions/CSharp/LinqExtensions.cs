#region

using System;
using System.Collections.Generic;

#endregion

namespace rStarUtility.Util.Extensions.CSharp
{
    public static class LinqExtensions
    {
    #region Public Methods

        /// <summary>Perform an action on each item.</summary>
        /// <param name="source">The source.</param>
        /// <param name="action">The action to perform.</param>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source , Action<T> action)
        {
            foreach (var obj in source) action(obj);
            return source;
        }

    #endregion
    }
}