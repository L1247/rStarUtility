#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class VectorHelper
    {
    #region Public Variables

        /// <summary>
        ///     判斷兩點接不接近，可調整magnitude數值去判斷兩者距離多近才算
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="magnitude">向量長度</param>
        /// <returns></returns>
        public static bool CloseThePointV2(Vector2 point1 , Vector2 point2 , float magnitude)
        {
            var distance = (point1 - point2).sqrMagnitude;
            return distance <= magnitude;
        }

        /// <summary>
        ///     判斷兩點接不接近，可調整magnitude數值去判斷兩者距離多近才算
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="magnitude">向量長度</param>
        /// <returns></returns>
        public static bool CloseThePointV3(Vector3 point1 , Vector3 point2 , float magnitude)
        {
            return CloseThePointV2(point1 , point2 , magnitude);
        }

    #endregion
    }
}