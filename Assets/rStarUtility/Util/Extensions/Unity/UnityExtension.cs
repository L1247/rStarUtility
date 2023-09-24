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

    #endregion
    }
}