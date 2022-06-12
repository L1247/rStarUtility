#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class VectorHelper
    {
    #region Public Variables

        public static bool CloseThePointV2(Vector2 point1 , Vector2 point2 , float threshold)
        {
            var distance = (point1 - point2).sqrMagnitude;
            return distance <= threshold;
        }

        public static bool CloseThePointV3(Vector3 point1 , Vector3 point2 , float threshold)
        {
            return CloseThePointV2(point1 , point2 , threshold);
        }

    #endregion
    }
}