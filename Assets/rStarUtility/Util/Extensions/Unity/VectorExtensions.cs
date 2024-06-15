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

        public static Vector3 MultiplyY(this Vector3 vector3 , float value)
        {
            vector3.z *= value;
            return vector3;
        }

        public static Vector2 SetX(this Vector2 vector2 , float x)
        {
            vector2.x = x;
            return vector2;
        }

        public static Vector3 SetX(this Vector3 vector3 , float x)
        {
            vector3.x = x;
            return vector3;
        }

        public static Vector2 SetY(this Vector2 vector2 , float y)
        {
            vector2.y = y;
            return vector2;
        }

        public static Vector3 SetY(this Vector3 vector3 , float y)
        {
            vector3.y = y;
            return vector3;
        }

        public static Vector3 SetZ(this Vector3 vector3 , float z)
        {
            vector3.z = z;
            return vector3;
        }

    #endregion
    }
}