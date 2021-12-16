#region

using UnityEngine;

#endregion

namespace AutoBot.Scripts.Utilities.Extensions
{
    public static class UnityExtension
    {
    #region Public Variables

        public static bool ToggleActive(this MonoBehaviour monoBehaviour)
        {
            var gameObject   = monoBehaviour.gameObject;
            var toggleActive = !gameObject.activeSelf;
            gameObject.SetActive(toggleActive);
            return toggleActive;
        }

        public static bool ToggleActive(this GameObject gameObject)
        {
            var toggleActive = !gameObject.activeSelf;
            gameObject.SetActive(toggleActive);
            return toggleActive;
        }

        public static void SetActive(this MonoBehaviour monoBehaviour , bool value)
        {
            monoBehaviour.gameObject.SetActive(value);
        }

        public static void SetActive(this Transform transform , bool value)
        {
            transform.gameObject.SetActive(value);
        }

    #endregion
    }
}