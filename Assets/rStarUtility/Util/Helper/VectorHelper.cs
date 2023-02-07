#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class VectorHelper
    {
    #region Public Methods

        public static float Distance(this Vector2 point1 , Vector2 point2)
        {
            var distance = (point1 - point2).sqrMagnitude;
            return distance;
        }

        /// <summary>
        ///     判斷兩點接不接近，可調整magnitude數值去判斷兩者距離多近才算
        /// https://www.cnblogs.com/MrZivChu/p/normalclass.html
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="magnitude">向量長度</param>
        /// <returns></returns>
        public static bool IsCloseThePoint(Vector2 point1 , Vector2 point2 , float magnitude)
        {
            var distance = Distance(point1 , point2);
            Debug.Log($"{distance} , {magnitude}");
            return distance <= magnitude;
        }

    #endregion
    }
}