#region

#endregion

#region

using rStarUtility.Util.Extensions.CSharp;
using UnityEngine;

#endregion

namespace rStarUtility.Util.Extensions.Unity
{
    public static class UnityExtension
    {
    #region Public Methods

        /// <summary>
        ///     https://www.youtube.com/shorts/IHEGj3ncgpw?feature=share
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void Activate(this MonoBehaviour monoBehaviour)
        {
            monoBehaviour.SetActive(true);
        }

        public static void Activate(this Behaviour behaviour)
        {
            behaviour.SetActive(true);
        }

        public static void Activate(this Transform transform)
        {
            transform.SetActive(true);
        }

        public static T AssignWithGetComponentIfNull<T>(this Behaviour monoBehaviour , GameObject componentInGameObject)
        where T : Behaviour
        {
            return monoBehaviour.IsNull() ? componentInGameObject.GetComponent<T>() : (T)monoBehaviour;
        }

        /// <summary>
        ///     https://www.youtube.com/shorts/IHEGj3ncgpw?feature=share
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void Deactivate(this MonoBehaviour monoBehaviour)
        {
            monoBehaviour.SetActive(false);
        }

        public static void Deactivate(this Behaviour behaviour)
        {
            behaviour.SetActive(false);
        }

        public static void Deactivate(this Transform transform)
        {
            transform.SetActive(false);
        }

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

        public static bool TryGetComponentInChildren<T>(this GameObject gameObject , out T t)
        {
            var componentInParent = gameObject.GetComponentInChildren<T>();
            t = componentInParent;
            return componentInParent.IsNotNull();
        }

        public static bool TryGetComponentInChildren<T>(this Behaviour behaviour , out T t)
        {
            var componentInParent = behaviour.GetComponentInChildren<T>();
            t = componentInParent;
            return componentInParent.IsNotNull();
        }

        public static bool TryGetComponentInParent<T>(this Behaviour behaviour , out T t)
        {
            var componentInParent = behaviour.GetComponentInParent<T>();
            t = componentInParent;
            return componentInParent.IsNotNull();
        }

        public static bool TryGetComponentInParent<T>(this GameObject gameObject , out T t)
        {
            var componentInParent = gameObject.GetComponentInParent<T>();
            t = componentInParent;
            return componentInParent.IsNotNull();
        }

    #endregion
    }
}