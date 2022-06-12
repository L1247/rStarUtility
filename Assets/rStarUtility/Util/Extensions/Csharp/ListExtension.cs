#region

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace rStarUtility.Util.Extensions.Csharp
{
    public static class ListExtension
    {
    #region Public Variables

        /// <summary>
        ///     https://dotblogs.com.tw/rainmaker/2012/02/02/67456
        /// </summary>
        /// <param name="list"></param>
        /// <param name="list2"></param>
        /// <param name="completelyEqual">True: 順序不一樣則不相同 False: 順序不一樣元素一樣則相同</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool CompareWith<T>(this List<T> list , List<T> list2 , bool completelyEqual = false)
        {
            var isListTheSame = completelyEqual
                                    ? list.SequenceEqual(list2)
                                    : !list.Except(list2).Any();
            return isListTheSame;
        }

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static void AddIfNotContains<T>(this List<T> list , T t)
        {
            if (list.Contains(t) == false) list.Add(t);
        }

        /// <summary>
        ///     Shuffles the element order of the specified list.
        /// </summary>
        public static void Shuffle<T>(this IList<T> ts)
        {
            var count = ts.Count;
            var last  = count - 1;
            for (var i = 0 ; i < last ; ++i)
            {
                var r = Random.Range(i , count);
                (ts[i] , ts[r]) = (ts[r] , ts[i]);
            }
        }

    #endregion
    }
}