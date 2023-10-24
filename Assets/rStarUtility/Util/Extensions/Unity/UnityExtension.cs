#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Extensions.Unity
{
    public static class UnityExtension
    {
    #region Public Methods

        public static bool IsActive(this MonoBehaviour monoBehaviour)
        {
            return monoBehaviour.gameObject.activeSelf;
        }

        public static bool IsActive(this Transform transform)
        {
            return transform.gameObject.activeSelf;
        }

        public static bool IsActive(this GameObject gameObject)
        {
            return gameObject.activeSelf;
        }

        public static Vector2 Position2(this MonoBehaviour monoBehaviour)
        {
            return monoBehaviour.transform.position;
        }

        public static Vector2 Position2(this GameObject gameObject)
        {
            return gameObject.transform.position;
        }

        public static Vector3 Position3(this MonoBehaviour monoBehaviour)
        {
            return monoBehaviour.transform.position;
        }

        public static Vector3 Position3(this GameObject gameObject)
        {
            return gameObject.transform.position;
        }

        public static void SetActive(this MonoBehaviour monoBehaviour , bool value)
        {
            monoBehaviour.gameObject.SetActive(value);
        }

        public static void SetActive(this Behaviour behaviour , bool value)
        {
            behaviour.gameObject.SetActive(value);
        }

        public static void SetActive(this Renderer renderer , bool value)
        {
            renderer.gameObject.SetActive(value);
        }

        public static void SetActive(this Transform transform , bool value)
        {
            transform.gameObject.SetActive(value);
        }

        public static bool ToggleActive(this MonoBehaviour monoBehaviour)
        {
            var gameObject = monoBehaviour.gameObject;
            return gameObject.ToggleActive();
        }

        public static bool ToggleActive(this Renderer renderer)
        {
            var gameObject = renderer.gameObject;
            return gameObject.ToggleActive();
        }

        public static bool ToggleActive(this GameObject gameObject)
        {
            var toggleActive = !gameObject.activeSelf;
            gameObject.SetActive(toggleActive);
            return toggleActive;
        }

        public static Vector2 ToVector2(this Vector3 vector2)
        {
            return vector2;
        }

        public static Vector3 ToVector3(this Vector2 vector2)
        {
            return vector2;
        }

    #endregion
    }
}