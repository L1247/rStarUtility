#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class UnityInfoHelper
    {
    #region Public Methods

        public static float GetDeltaTime(float deltaTimeOfTest)
        {
            return IsRuntime() ? GetDeltaTime() : deltaTimeOfTest;
        }

        public static float GetDeltaTime()
        {
            return Time.deltaTime;
        }

        public static float GetTimeScale()
        {
            return Time.timeScale;
        }

        public static bool IsEditor()
        {
            return Application.isEditor;
        }

        public static bool IsKeyDown(KeyCode key , KeyCode fakeKey)
        {
            if (IsRuntime()) return Input.GetKeyDown(key);
            return fakeKey == key;
        }

        public static bool IsRuntime()
        {
            return Application.isPlaying;
        }

        public static bool IsTest()
        {
            return IsRuntime() == false;
        }

    #endregion
    }
}