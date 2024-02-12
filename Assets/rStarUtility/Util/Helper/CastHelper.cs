#region

using System.Collections.Generic;
using System.Linq;
using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace rStarUtility.Util.Helper
{
    public class CastHelper
    {
    #region Public Methods

        /// <summary>
        ///     return results by BoxCastAll with type of T
        /// </summary>
        /// <param name="position">Center position</param>
        /// <param name="size">cast size</param>
        /// <returns></returns>
        public static IEnumerable<T> BoxCastAll<T>(Vector2 position , Vector2 size)
        {
            var collider2Ds =
                    Physics2D.BoxCastAll(position , size , 0 ,
                                         Vector2.zero , 0)
                             .Select(hit2D => hit2D.collider.GetComponent<T>())
                             .Where(damageable => damageable.IsNotNull());
            return collider2Ds;
        }

        /// <summary>
        ///     return results by overlap box  with type of T
        /// </summary>
        /// <param name="position">Center position</param>
        /// <param name="size">cast size</param>
        /// <returns></returns>
        public static IEnumerable<T> OverlapBoxAll<T>(Vector2 position , Vector2 size)
        {
            var collider2Ds =
                    Physics2D.OverlapBoxAll(position , size , 0)
                             .Select(collider2D => collider2D.GetComponent<T>())
                             .Where(damageable => damageable.IsNotNull());
            return collider2Ds;
        }

    #endregion
    }
}