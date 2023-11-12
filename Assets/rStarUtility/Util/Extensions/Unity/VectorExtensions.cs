#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Extensions.Unity
{
    public static class VectorExtensions
    {
    #region Public Methods

        public static Vector2 MultiplyX(this Vector2 vector2 , float value)
        {
            vector2.x *= value;
            return vector2;
        }

        public static Vector2 MultiplyY(this Vector2 vector2 , float value)
        {
            vector2.y *= value;
            return vector2;
        }

    #endregion
    }
}