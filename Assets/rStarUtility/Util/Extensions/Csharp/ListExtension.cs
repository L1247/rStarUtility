#region

using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

#endregion

namespace rStarUtility.Util.Extensions.Csharp
{
    public static class ListExtension
    {
    #region Public Methods

        public static void AddIfNotContains<T>(this List<T> list , T t)
        {
            if (list.Contains(t) == false) list.Add(t);
        }

        /// <summary>
        ///     https://stackoverflow.com/questions/222598/how-do-i-clone-a-generic-list-in-c
        /// </summary>
        /// <param name="listToClone"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

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

        public static T PickRandomValue<T>(this IList<T> ts)
        {
            var maxIndex    = ts.Count == 0 ? 0 : ts.Count - 1;
            var randomIndex = RandomUtilities.GetRandomValue(0 , maxIndex);
            return ts[randomIndex];
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