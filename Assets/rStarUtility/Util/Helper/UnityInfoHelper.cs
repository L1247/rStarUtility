#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class UnityInfoHelper
    {
    #region Public Methods

        public static int GetAnimationFrameOfCurrentClip(Animator animator)
        {
            var clipInfo                 = animator.GetCurrentAnimatorClipInfo(0)[0];
            var currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            var clip                     = clipInfo.clip;
            var clipFrameRate            = clip.frameRate;
            var normalizedTime           = currentAnimatorStateInfo.normalizedTime;
            var currentFrame             = (int)(clip.length * (normalizedTime % 1) * clipFrameRate) + 1;
            return currentFrame;
        }

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

        public static bool IsAnimationPlayEnd(Animator animator , string animatorStatName)
        {
            if (animator is null) return false;
            var currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            var isPlaningThatStat        = currentAnimatorStateInfo.IsName(animatorStatName);
            var isPlayOnce               = currentAnimatorStateInfo.normalizedTime >= 1;
            var isPlayEnd                = isPlaningThatStat && isPlayOnce;
            return isPlayEnd;
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