#region

using System.Collections;
using System.Linq;
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
        public static IEnumerable BoxCastAll<T>(Vector2 position , Vector2 size)
        {
            var collider2Ds =
                    Physics2D.BoxCastAll(position , size , 0 ,
                                         Vector2.zero , 0)
                             .Where(hit2D => hit2D.collider.TryGetComponent<T>(out _));
            return collider2Ds;
        }

        /// <summary>
        ///     return results by overlap box  with type of T
        /// </summary>
        /// <param name="position">Center position</param>
        /// <param name="size">cast size</param>
        /// <returns></returns>
        public static IEnumerable OverlapBoxAll<T>(Vector2 position , Vector2 size)
        {
            var collider2Ds =
                    Physics2D.OverlapBoxAll(position , size , 0)
                             .Where(collider2D => collider2D.TryGetComponent<T>(out _));
            return collider2Ds;
        }

    #endregion
    }
}