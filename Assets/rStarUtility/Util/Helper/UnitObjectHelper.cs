#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class UnitObjectHelper
    {
    #region Public Methods

        public static T Create<T>(T prefab = null) where T : UnityEngine.Component
        {
            return prefab ? Object.Instantiate(prefab) : new GameObject(typeof(T).Name).AddComponent<T>();
        }

        public static T Create<T>(T prefab , Transform contentParent) where T : UnityEngine.Component
        {
            var obj = Create(prefab);
            obj.transform.SetParent(contentParent);
            return obj;
        }

        public static void Destroy(GameObject gameObject)
        {
            if (UnityInfoHelper.IsRuntime()) Object.Destroy(gameObject);
            else Object.DestroyImmediate(gameObject);
        }

        public static void Destroy(MonoBehaviour monoBehaviour)
        {
            Destroy(monoBehaviour.gameObject);
        }

        public static void Destroy(Transform transform)
        {
            Destroy(transform.gameObject);
        }

        public static void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public static void SetTimeScale(float runtimeTimeScale , int editorTimeScale)
        {
            if (UnityInfoHelper.IsRuntime()) SetTimeScale(runtimeTimeScale);
            else SetTimeScale(editorTimeScale);
        }

    #endregion
    }
}